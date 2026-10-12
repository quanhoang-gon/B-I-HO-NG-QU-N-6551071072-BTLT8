using System;
using System.Data;
using System.IO;
using System.Linq;
using ClosedXML.Excel;
using FastReport;
using FastReport.Export.Pdf;
using Microsoft.EntityFrameworkCore;
using Bai_1.Models;

namespace Bai_1
{
    public class Tester
    {
        public static void RunTests()
        {
            Console.WriteLine("=== BẮT ĐẦU KIỂM TRA TỰ ĐỘNG BÀI 1 ===");

            using var context = new TiemTapHoaDbContext();

            // 1. Kiểm tra 6 dòng dữ liệu mẫu
            var allItems = context.HangHoas.AsNoTracking().ToList();
            Console.WriteLine($"[TEST 1] Tổng số hàng hóa trong CSDL: {allItems.Count} (Mong đợi: 6)");
            if (allItems.Count != 6) throw new Exception("Test 1 thất bại!");

            // 2. Kiểm tra tìm kiếm "nước"
            var searchNuoc = context.HangHoas.AsNoTracking()
                .Where(h => EF.Functions.Like(h.TenHang, "%nước%"))
                .ToList();
            Console.WriteLine($"[TEST 2] Tìm 'nước': {searchNuoc.Count} kết quả (Mong đợi: 2: {string.Join(", ", searchNuoc.Select(x => x.TenHang))})");
            if (searchNuoc.Count != 2) throw new Exception("Test 2 thất bại!");

            // 3. Kiểm tra tìm kiếm "nước" + Chỉ hiện còn kinh doanh
            var searchNuocActive = context.HangHoas.AsNoTracking()
                .Where(h => EF.Functions.Like(h.TenHang, "%nước%") && h.ConKinhDoanh)
                .ToList();
            Console.WriteLine($"[TEST 3] Tìm 'nước' + Còn kinh doanh: {searchNuocActive.Count} kết quả (Mong đợi: 1: {searchNuocActive.FirstOrDefault()?.TenHang})");
            if (searchNuocActive.Count != 1) throw new Exception("Test 3 thất bại!");

            // 4. Kiểm tra dữ liệu còn kinh doanh cho báo cáo bảng giá
            var activeItems = context.HangHoas.AsNoTracking()
                .Where(h => h.ConKinhDoanh)
                .OrderBy(h => h.MaHang)
                .ToList();
            Console.WriteLine($"[TEST 4] Hàng còn kinh doanh: {activeItems.Count} mặt hàng (Mong đợi: 5)");
            if (activeItems.Count != 5) throw new Exception("Test 4 thất bại!");

            // 5. Kiểm tra FastReport
            string reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports", "BangGia.frx");
            if (!File.Exists(reportPath))
                reportPath = Path.Combine(Directory.GetCurrentDirectory(), "Reports", "BangGia.frx");

            Console.WriteLine($"[TEST 5] Đường dẫn file .frx: {reportPath}");
            var dt = new DataTable("HangHoa");
            dt.Columns.Add("MaHang", typeof(int));
            dt.Columns.Add("TenHang", typeof(string));
            dt.Columns.Add("LoaiHang", typeof(string));
            dt.Columns.Add("DonVi", typeof(string));
            dt.Columns.Add("GiaBan", typeof(decimal));
            dt.Columns.Add("SoLuongTon", typeof(int));
            dt.Columns.Add("NgayNhap", typeof(DateTime));
            dt.Columns.Add("ConKinhDoanh", typeof(bool));

            foreach (var item in activeItems)
            {
                dt.Rows.Add(item.MaHang, item.TenHang, item.LoaiHang, item.DonVi, item.GiaBan, item.SoLuongTon, item.NgayNhap, item.ConKinhDoanh);
            }

            using (var report = new Report())
            {
                report.Load(reportPath);
                report.RegisterData(dt, "HangHoa");
                var ds = report.GetDataSource("HangHoa");
                if (ds != null) ds.Enabled = true;
                report.SetParameterValue("NgayIn", DateTime.Now.ToString("dd/MM/yyyy"));
                report.Prepare();

                string testPdfPath = Path.Combine(Directory.GetCurrentDirectory(), "BangGia_Test.pdf");
                using (var export = new PDFExport())
                {
                    export.Export(report, testPdfPath);
                }
                Console.WriteLine($"[TEST 5] Đã xuất PDF thành công: {testPdfPath}, Dung lượng: {new FileInfo(testPdfPath).Length} bytes");
            }

            // 6. Kiểm tra ClosedXML Xuất Excel Tồn kho
            string testExcelPath = Path.Combine(Directory.GetCurrentDirectory(), "TonKho_Test.xlsx");
            using (var wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("TonKho");
                string[] headers = { "STT", "Mã hàng", "Tên hàng", "Loại hàng", "Đơn vị", "Giá bán", "Số lượng tồn", "Giá trị tồn" };
                for (int c = 0; c < headers.Length; c++)
                {
                    var cell = ws.Cell(1, c + 1);
                    cell.Value = headers[c];
                    cell.Style.Font.Bold = true;
                }

                int startRow = 2;
                for (int i = 0; i < activeItems.Count; i++)
                {
                    int r = startRow + i;
                    var item = activeItems[i];
                    ws.Cell(r, 1).SetValue(i + 1);
                    ws.Cell(r, 2).SetValue(item.MaHang);
                    ws.Cell(r, 3).SetValue(item.TenHang);
                    ws.Cell(r, 4).SetValue(item.LoaiHang ?? "");
                    ws.Cell(r, 5).SetValue(item.DonVi ?? "");
                    ws.Cell(r, 6).SetValue(item.GiaBan);
                    ws.Cell(r, 7).SetValue(item.SoLuongTon);
                    ws.Cell(r, 8).FormulaA1 = $"F{r}*G{r}";
                }

                int lastRow = startRow + activeItems.Count - 1;
                int totalRow = lastRow + 1;
                ws.Cell(totalRow, 3).SetValue("Tổng");
                ws.Cell(totalRow, 7).FormulaA1 = $"SUM(G{startRow}:G{lastRow})";
                ws.Cell(totalRow, 8).FormulaA1 = $"SUM(H{startRow}:H{lastRow})";

                ws.Range(1, 1, 1, headers.Length).SetAutoFilter();
                ws.SheetView.FreezeRows(1);
                wb.SaveAs(testExcelPath);
            }

            // Đọc lại file Excel để kiểm tra công thức và giá trị
            using (var checkWb = new XLWorkbook(testExcelPath))
            {
                var ws = checkWb.Worksheet("TonKho");
                Console.WriteLine($"[TEST 6] Ô H2 công thức: {ws.Cell(2, 8).FormulaA1}");
                Console.WriteLine($"[TEST 6] Ô H7 (Tổng) công thức: {ws.Cell(7, 8).FormulaA1}");
                decimal tongGiaTri = ws.Cell(7, 8).GetValue<decimal>();
                Console.WriteLine($"[TEST 6] Giá trị tính toán của ô Tổng: {tongGiaTri:N0} VNĐ (Mong đợi: 7.300.000)");
                if (tongGiaTri != 7300000m) throw new Exception("Tổng giá trị không bằng 7.300.000!");
            }

            // 7. Tạo ảnh chụp màn hình (Screenshots)
            Directory.CreateDirectory("Screenshots");
            using (var form = new Form1())
            {
                form.Show();
                Application.DoEvents();
                System.Threading.Thread.Sleep(300);

                // Chụp màn hình Form1 ban đầu
                using (var bmp = new System.Drawing.Bitmap(form.Width, form.Height))
                {
                    form.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, form.Width, form.Height));
                    bmp.Save("Screenshots/Hinh1_1_GiaoDien_BanDau.png", System.Drawing.Imaging.ImageFormat.Png);
                }

                // Gõ "nước" vào ô tìm kiếm
                var txtTim = form.Controls.Find("txtTimKiem", true).FirstOrDefault() as TextBox;
                if (txtTim != null)
                {
                    txtTim.Text = "nước";
                    var sw = System.Diagnostics.Stopwatch.StartNew();
                    while (sw.ElapsedMilliseconds < 550)
                    {
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(25);
                    }

                    using (var bmp = new System.Drawing.Bitmap(form.Width, form.Height))
                    {
                        form.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, form.Width, form.Height));
                        bmp.Save("Screenshots/Hinh1_1_GiaoDien_TimNuoc.png", System.Drawing.Imaging.ImageFormat.Png);
                    }
                }

                // Check "Chỉ hiện hàng còn kinh doanh"
                var chkLoc = form.Controls.Find("chkLocConKinhDoanh", true).FirstOrDefault() as CheckBox;
                if (chkLoc != null)
                {
                    chkLoc.Checked = true;
                    var sw = System.Diagnostics.Stopwatch.StartNew();
                    while (sw.ElapsedMilliseconds < 550)
                    {
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(25);
                    }

                    using (var bmp = new System.Drawing.Bitmap(form.Width, form.Height))
                    {
                        form.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, form.Width, form.Height));
                        bmp.Save("Screenshots/Hinh1_1_GiaoDien_TimNuoc_ConKinhDoanh.png", System.Drawing.Imaging.ImageFormat.Png);
                    }
                }

                form.Close();
            }

            // Xuất ảnh Báo cáo Bảng giá
            using (var report = new Report())
            {
                report.Load(reportPath);
                report.RegisterData(dt, "HangHoa");
                var ds = report.GetDataSource("HangHoa");
                if (ds != null) ds.Enabled = true;
                report.SetParameterValue("NgayIn", DateTime.Now.ToString("dd/MM/yyyy"));
                report.Prepare();

                using (var imgExport = new FastReport.Export.Image.ImageExport())
                {
                    imgExport.ImageFormat = FastReport.Export.Image.ImageExportFormat.Png;
                    imgExport.Export(report, "Screenshots/Hinh1_2_ReportBangGia.png");
                }

                // Cửa sổ xem trước (Preview Form)
                using (var previewForm = new Form())
                {
                    previewForm.Size = new System.Drawing.Size(950, 750);
                    previewForm.StartPosition = FormStartPosition.CenterScreen;
                    previewForm.Text = "Xem trước Bảng giá - FastReport .NET";
                    var previewCtrl = new FastReport.Preview.PreviewControl();
                    previewCtrl.Dock = DockStyle.Fill;
                    previewForm.Controls.Add(previewCtrl);
                    report.Preview = previewCtrl;
                    report.ShowPrepared();
                    previewForm.Show();

                    var sw = System.Diagnostics.Stopwatch.StartNew();
                    while (sw.ElapsedMilliseconds < 500)
                    {
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(25);
                    }

                    using (var bmp = new System.Drawing.Bitmap(previewForm.Width, previewForm.Height))
                    {
                        previewForm.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, previewForm.Width, previewForm.Height));
                        bmp.Save("Screenshots/Hinh1_2_CuaSoXemTruoc.png", System.Drawing.Imaging.ImageFormat.Png);
                    }
                    previewForm.Close();
                }
            }
            Console.WriteLine("[TEST 7] Đã tạo các ảnh chụp màn hình trong thư mục Screenshots/");

            Console.WriteLine("=== TẤT CẢ CÁC BÀI TEST ĐÃ ĐẠT 100%! ===");
        }
    }
}
