using System.Data;
using System.Diagnostics;
using ClosedXML.Excel;
using FastReport;
using FastReport.Export.Pdf;
using Microsoft.EntityFrameworkCore;
using Bai_1.Models;

namespace Bai_1
{
    public partial class Form1 : Form
    {
        private int? _selectedMaHang = null;
        private bool _isBinding = false;

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // Khởi tạo danh mục cho ComboBox
                cboLoaiHang.Items.Clear();
                cboLoaiHang.Items.AddRange(new object[] { "Đồ uống", "Thực phẩm khô", "Gia vị", "Đồ gia dụng" });
                cboLoaiHang.SelectedIndex = 0;

                cboDonVi.Items.Clear();
                cboDonVi.Items.AddRange(new object[] { "Chai", "Gói", "Hộp", "Túi" });
                cboDonVi.SelectedIndex = 0;

                cboLocLoai.Items.Clear();
                cboLocLoai.Items.AddRange(new object[] { "Tất cả", "Đồ uống", "Thực phẩm khô", "Gia vị", "Đồ gia dụng" });
                cboLocLoai.SelectedIndex = 0;

                nudGiaBan.Value = 500;
                nudSoLuongTon.Value = 0;
                dtpNgayNhap.Value = DateTime.Now;
                chkConKinhDoanh.Checked = true;
                chkLocConKinhDoanh.Checked = false;

                dgvHangHoa.AutoGenerateColumns = false;
                colMaHang.DataPropertyName = "MaHang";
                colTenHang.DataPropertyName = "TenHang";
                colLoaiHang.DataPropertyName = "LoaiHang";
                colDonVi.DataPropertyName = "DonVi";
                colGiaBan.DataPropertyName = "GiaBan";
                colSoLuongTon.DataPropertyName = "SoLuongTon";
                colNgayNhap.DataPropertyName = "NgayNhap";
                colConKinhDoanh.DataPropertyName = "ConKinhDoanh";

                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo form: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadDataAsync()
        {
            try
            {
                _isBinding = true;
                string keyword = txtTimKiem.Text.Trim();
                string selectedLoai = cboLocLoai.SelectedItem?.ToString() ?? "Tất cả";
                bool onlyActive = chkLocConKinhDoanh.Checked;

                using var context = new TiemTapHoaDbContext();
                var query = context.HangHoas.AsNoTracking().AsQueryable();

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    query = query.Where(h => EF.Functions.Like(h.TenHang, $"%{keyword}%"));
                }

                if (!string.IsNullOrWhiteSpace(selectedLoai) && selectedLoai != "Tất cả")
                {
                    query = query.Where(h => h.LoaiHang == selectedLoai);
                }

                if (onlyActive)
                {
                    query = query.Where(h => h.ConKinhDoanh);
                }

                var list = await query.OrderBy(h => h.MaHang).ToListAsync();
                dgvHangHoa.DataSource = list;
                lblTrangThai.Text = $"Tìm thấy {list.Count} mặt hàng";

                // Đổ dữ liệu dòng đầu tiên lên form nếu có
                if (list.Count > 0)
                {
                    // Nếu mặt hàng đang chọn vẫn nằm trong kết quả thì giữ nguyên
                    var currentItem = _selectedMaHang.HasValue
                        ? list.FirstOrDefault(h => h.MaHang == _selectedMaHang.Value)
                        : list[0];

                    if (currentItem != null)
                    {
                        HienThiThongTin(currentItem);
                    }
                    else
                    {
                        HienThiThongTin(list[0]);
                    }
                }
                else
                {
                    LamMoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isBinding = false;
            }
        }

        private void HienThiThongTin(HangHoa item)
        {
            _selectedMaHang = item.MaHang;
            txtTenHang.Text = item.TenHang;

            if (!string.IsNullOrEmpty(item.LoaiHang) && cboLoaiHang.Items.Contains(item.LoaiHang))
                cboLoaiHang.SelectedItem = item.LoaiHang;
            else if (cboLoaiHang.Items.Count > 0)
                cboLoaiHang.SelectedIndex = 0;

            if (!string.IsNullOrEmpty(item.DonVi) && cboDonVi.Items.Contains(item.DonVi))
                cboDonVi.SelectedItem = item.DonVi;
            else if (cboDonVi.Items.Count > 0)
                cboDonVi.SelectedIndex = 0;

            nudGiaBan.Value = item.GiaBan;
            nudSoLuongTon.Value = item.SoLuongTon;
            dtpNgayNhap.Value = item.NgayNhap;
            chkConKinhDoanh.Checked = item.ConKinhDoanh;
        }

        private void dgvHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvHangHoa.Rows.Count) return;
            if (dgvHangHoa.Rows[e.RowIndex].DataBoundItem is HangHoa item)
            {
                HienThiThongTin(item);
            }
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu hợp lệ
                if (string.IsNullOrWhiteSpace(txtTenHang.Text))
                {
                    MessageBox.Show("Tên hàng không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenHang.Focus();
                    return;
                }

                if (nudGiaBan.Value <= 0)
                {
                    MessageBox.Show("Giá bán phải lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nudGiaBan.Focus();
                    return;
                }

                var hh = new HangHoa
                {
                    TenHang = txtTenHang.Text.Trim(),
                    LoaiHang = cboLoaiHang.SelectedItem?.ToString() ?? "",
                    DonVi = cboDonVi.SelectedItem?.ToString() ?? "",
                    GiaBan = nudGiaBan.Value,
                    SoLuongTon = (int)nudSoLuongTon.Value,
                    NgayNhap = dtpNgayNhap.Value,
                    ConKinhDoanh = chkConKinhDoanh.Checked
                };

                using var context = new TiemTapHoaDbContext();
                context.HangHoas.Add(hh);
                await context.SaveChangesAsync();

                MessageBox.Show("Thêm hàng hóa mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _selectedMaHang = hh.MaHang;
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm hàng hóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_selectedMaHang.HasValue)
                {
                    MessageBox.Show("Vui lòng chọn hàng hóa cần sửa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTenHang.Text))
                {
                    MessageBox.Show("Tên hàng không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenHang.Focus();
                    return;
                }

                if (nudGiaBan.Value <= 0)
                {
                    MessageBox.Show("Giá bán phải lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nudGiaBan.Focus();
                    return;
                }

                using var context = new TiemTapHoaDbContext();
                var hh = await context.HangHoas.FindAsync(_selectedMaHang.Value);
                if (hh == null)
                {
                    MessageBox.Show("Không tìm thấy hàng hóa cần sửa trong cơ sở dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                hh.TenHang = txtTenHang.Text.Trim();
                hh.LoaiHang = cboLoaiHang.SelectedItem?.ToString() ?? "";
                hh.DonVi = cboDonVi.SelectedItem?.ToString() ?? "";
                hh.GiaBan = nudGiaBan.Value;
                hh.SoLuongTon = (int)nudSoLuongTon.Value;
                hh.NgayNhap = dtpNgayNhap.Value;
                hh.ConKinhDoanh = chkConKinhDoanh.Checked;

                await context.SaveChangesAsync();
                MessageBox.Show("Cập nhật thông tin hàng hóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa hàng hóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_selectedMaHang.HasValue)
                {
                    MessageBox.Show("Vui lòng chọn hàng hóa cần xóa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var ans = MessageBox.Show($"Bạn có chắc chắn muốn xóa mặt hàng '{txtTenHang.Text}' không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans != DialogResult.Yes) return;

                using var context = new TiemTapHoaDbContext();
                var hh = await context.HangHoas.FindAsync(_selectedMaHang.Value);
                if (hh != null)
                {
                    context.HangHoas.Remove(hh);
                    await context.SaveChangesAsync();
                    MessageBox.Show("Xóa hàng hóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _selectedMaHang = null;
                    await LoadDataAsync();
                    LamMoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa hàng hóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void LamMoi()
        {
            _selectedMaHang = null;
            txtTenHang.Clear();
            if (cboLoaiHang.Items.Count > 0) cboLoaiHang.SelectedIndex = 0;
            if (cboDonVi.Items.Count > 0) cboDonVi.SelectedIndex = 0;
            nudGiaBan.Value = 500;
            nudSoLuongTon.Value = 0;
            dtpNgayNhap.Value = DateTime.Now;
            chkConKinhDoanh.Checked = true;
            dgvHangHoa.ClearSelection();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            tmrTimKiem.Stop();
            tmrTimKiem.Start();
        }

        private async void tmrTimKiem_Tick(object sender, EventArgs e)
        {
            tmrTimKiem.Stop();
            await LoadDataAsync();
        }

        private async void cboLocLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isBinding) return;
            await LoadDataAsync();
        }

        private async void chkLocConKinhDoanh_CheckedChanged(object sender, EventArgs e)
        {
            if (_isBinding) return;
            await LoadDataAsync();
        }

        private async Task<Report?> PrepareBangGiaReportAsync()
        {
            string reportPath = Path.Combine(Application.StartupPath, "Reports", "BangGia.frx");
            if (!File.Exists(reportPath))
            {
                reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Reports", "BangGia.frx");
            }
            if (!File.Exists(reportPath))
            {
                reportPath = Path.Combine(Directory.GetCurrentDirectory(), "Reports", "BangGia.frx");
            }
            if (!File.Exists(reportPath))
            {
                MessageBox.Show("Không tìm thấy tệp mẫu báo cáo BangGia.frx trong thư mục Reports!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            using var context = new TiemTapHoaDbContext();
            var list = await context.HangHoas.AsNoTracking()
                .Where(h => h.ConKinhDoanh)
                .OrderBy(h => h.MaHang)
                .ToListAsync();

            var dt = new DataTable("HangHoa");
            dt.Columns.Add("MaHang", typeof(int));
            dt.Columns.Add("TenHang", typeof(string));
            dt.Columns.Add("LoaiHang", typeof(string));
            dt.Columns.Add("DonVi", typeof(string));
            dt.Columns.Add("GiaBan", typeof(decimal));
            dt.Columns.Add("SoLuongTon", typeof(int));
            dt.Columns.Add("NgayNhap", typeof(DateTime));
            dt.Columns.Add("ConKinhDoanh", typeof(bool));

            foreach (var item in list)
            {
                dt.Rows.Add(item.MaHang, item.TenHang, item.LoaiHang, item.DonVi, item.GiaBan, item.SoLuongTon, item.NgayNhap, item.ConKinhDoanh);
            }

            var report = new Report();
            report.Load(reportPath);
            report.RegisterData(dt, "HangHoa");

            var ds = report.GetDataSource("HangHoa");
            if (ds != null)
            {
                ds.Enabled = true;
            }

            report.SetParameterValue("NgayIn", DateTime.Now.ToString("dd/MM/yyyy"));
            report.Prepare();
            return report;
        }

        private async void btnXemBangGia_Click(object sender, EventArgs e)
        {
            try
            {
                using var report = await PrepareBangGiaReportAsync();
                if (report != null)
                {
                    report.ShowPrepared(true, this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi hiển thị báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnXuatPdf_Click(object sender, EventArgs e)
        {
            try
            {
                using var sfd = new SaveFileDialog();
                sfd.Filter = "Tài liệu PDF (*.pdf)|*.pdf";
                sfd.FileName = $"BangGia_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                sfd.Title = "Chọn nơi lưu tệp PDF Bảng giá";

                if (sfd.ShowDialog() != DialogResult.OK) return;

                using var report = await PrepareBangGiaReportAsync();
                if (report != null)
                {
                    using var export = new PDFExport();
                    export.Export(report, sfd.FileName);

                    var ans = MessageBox.Show("Xuất file PDF thành công! Bạn có muốn mở file vừa xuất không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ans == DialogResult.Yes)
                    {
                        Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                    }
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Tệp đang được mở bởi ứng dụng khác. Vui lòng đóng tệp rồi thử lại!", "Lỗi truy cập tệp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất PDF: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXuatExcelLuoi_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvHangHoa.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu trên lưới để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using var sfd = new SaveFileDialog();
                sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                sfd.FileName = $"DanhSachHangHoa_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                sfd.Title = "Chọn nơi lưu file Excel xuất từ lưới";

                if (sfd.ShowDialog() != DialogResult.OK) return;

                using var workbook = new XLWorkbook();
                var ws = workbook.Worksheets.Add("HangHoa");

                // Tiêu đề cột
                string[] headers = { "STT", "Mã hàng", "Tên hàng", "Loại hàng", "Đơn vị", "Giá bán", "Số lượng tồn", "Ngày nhập", "Kinh doanh" };
                for (int c = 0; c < headers.Length; c++)
                {
                    var cell = ws.Cell(1, c + 1);
                    cell.Value = headers[c];
                    cell.Style.Font.Bold = true;
                    cell.Style.Fill.BackgroundColor = XLColor.LightGray;
                    cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                }

                int rowIdx = 2;
                for (int i = 0; i < dgvHangHoa.Rows.Count; i++)
                {
                    var row = dgvHangHoa.Rows[i];
                    if (row.IsNewRow) continue;

                    // STT (số)
                    ws.Cell(rowIdx, 1).SetValue(rowIdx - 1);
                    ws.Cell(rowIdx, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    // Mã hàng (số int)
                    int maHang = Convert.ToInt32(row.Cells["colMaHang"].Value);
                    ws.Cell(rowIdx, 2).SetValue(maHang);
                    ws.Cell(rowIdx, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    // Tên hàng (chuỗi)
                    ws.Cell(rowIdx, 3).SetValue(row.Cells["colTenHang"].Value?.ToString() ?? "");

                    // Loại hàng (chuỗi)
                    ws.Cell(rowIdx, 4).SetValue(row.Cells["colLoaiHang"].Value?.ToString() ?? "");

                    // Đơn vị (chuỗi)
                    ws.Cell(rowIdx, 5).SetValue(row.Cells["colDonVi"].Value?.ToString() ?? "");
                    ws.Cell(rowIdx, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    // Giá bán (số decimal)
                    decimal giaBan = Convert.ToDecimal(row.Cells["colGiaBan"].Value);
                    ws.Cell(rowIdx, 6).SetValue(giaBan);
                    ws.Cell(rowIdx, 6).Style.NumberFormat.Format = "#,##0";
                    ws.Cell(rowIdx, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                    // Số lượng tồn (số int)
                    int soLuongTon = Convert.ToInt32(row.Cells["colSoLuongTon"].Value);
                    ws.Cell(rowIdx, 7).SetValue(soLuongTon);
                    ws.Cell(rowIdx, 7).Style.NumberFormat.Format = "#,##0";
                    ws.Cell(rowIdx, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                    // Ngày nhập (DateTime)
                    DateTime ngayNhap = Convert.ToDateTime(row.Cells["colNgayNhap"].Value);
                    ws.Cell(rowIdx, 8).SetValue(ngayNhap);
                    ws.Cell(rowIdx, 8).Style.DateFormat.Format = "dd/MM/yyyy";
                    ws.Cell(rowIdx, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    // Kinh doanh
                    bool conKD = Convert.ToBoolean(row.Cells["colConKinhDoanh"].Value);
                    ws.Cell(rowIdx, 9).SetValue(conKD ? "Còn bán" : "Ngừng bán");
                    ws.Cell(rowIdx, 9).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    rowIdx++;
                }

                var tableRange = ws.Range(1, 1, rowIdx - 1, headers.Length);
                tableRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                tableRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                ws.Columns().AdjustToContents();

                workbook.SaveAs(sfd.FileName);

                var ans = MessageBox.Show("Xuất file Excel thành công! Bạn có muốn mở file không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == DialogResult.Yes)
                {
                    Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Tệp đang được mở bởi ứng dụng khác. Vui lòng đóng tệp Excel rồi thử lại!", "Lỗi truy cập tệp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnXuatExcelTonKho_Click(object sender, EventArgs e)
        {
            try
            {
                using var sfd = new SaveFileDialog();
                sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                sfd.FileName = $"BaoCaoTonKho_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                sfd.Title = "Chọn nơi lưu file Excel báo cáo tồn kho";

                if (sfd.ShowDialog() != DialogResult.OK) return;

                using var context = new TiemTapHoaDbContext();
                var list = await context.HangHoas.AsNoTracking()
                    .Where(h => h.ConKinhDoanh)
                    .OrderBy(h => h.MaHang)
                    .ToListAsync();

                if (list.Count == 0)
                {
                    MessageBox.Show("Không có mặt hàng nào đang kinh doanh để xuất báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using var workbook = new XLWorkbook();
                var ws = workbook.Worksheets.Add("TonKho");

                // Dòng tiêu đề
                string[] headers = { "STT", "Mã hàng", "Tên hàng", "Loại hàng", "Đơn vị", "Giá bán", "Số lượng tồn", "Giá trị tồn" };
                for (int c = 0; c < headers.Length; c++)
                {
                    var cell = ws.Cell(1, c + 1);
                    cell.Value = headers[c];
                    cell.Style.Font.Bold = true;
                    cell.Style.Fill.BackgroundColor = XLColor.LightGray;
                    cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                }

                int startRow = 2;
                for (int i = 0; i < list.Count; i++)
                {
                    int r = startRow + i;
                    var item = list[i];

                    // STT (số)
                    ws.Cell(r, 1).SetValue(i + 1);
                    ws.Cell(r, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    // Mã hàng (số)
                    ws.Cell(r, 2).SetValue(item.MaHang);
                    ws.Cell(r, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    // Tên hàng
                    ws.Cell(r, 3).SetValue(item.TenHang);

                    // Loại hàng
                    ws.Cell(r, 4).SetValue(item.LoaiHang ?? "");

                    // Đơn vị
                    ws.Cell(r, 5).SetValue(item.DonVi ?? "");
                    ws.Cell(r, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    // Giá bán (số)
                    ws.Cell(r, 6).SetValue(item.GiaBan);
                    ws.Cell(r, 6).Style.NumberFormat.Format = "#,##0";
                    ws.Cell(r, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                    // Số lượng tồn (số)
                    ws.Cell(r, 7).SetValue(item.SoLuongTon);
                    ws.Cell(r, 7).Style.NumberFormat.Format = "#,##0";
                    ws.Cell(r, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                    // Giá trị tồn: Công thức Giá bán * Số lượng tồn (F{r} * G{r})
                    ws.Cell(r, 8).FormulaA1 = $"F{r}*G{r}";
                    ws.Cell(r, 8).Style.NumberFormat.Format = "#,##0";
                    ws.Cell(r, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                }

                int lastDataRow = startRow + list.Count - 1;
                int totalRow = lastDataRow + 1;

                // Dòng Tổng
                ws.Cell(totalRow, 3).SetValue("Tổng");
                ws.Cell(totalRow, 3).Style.Font.Bold = true;
                ws.Cell(totalRow, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                // Tổng số lượng tồn: SUM
                ws.Cell(totalRow, 7).FormulaA1 = $"SUM(G{startRow}:G{lastDataRow})";
                ws.Cell(totalRow, 7).Style.Font.Bold = true;
                ws.Cell(totalRow, 7).Style.NumberFormat.Format = "#,##0";
                ws.Cell(totalRow, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                // Tổng giá trị tồn: SUM
                ws.Cell(totalRow, 8).FormulaA1 = $"SUM(H{startRow}:H{lastDataRow})";
                ws.Cell(totalRow, 8).Style.Font.Bold = true;
                ws.Cell(totalRow, 8).Style.NumberFormat.Format = "#,##0";
                ws.Cell(totalRow, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                // Định dạng viền bảng
                var fullRange = ws.Range(1, 1, totalRow, headers.Length);
                fullRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                fullRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                // AutoFilter dòng tiêu đề
                ws.Range(1, 1, 1, headers.Length).SetAutoFilter();

                // Cố định dòng tiêu đề (Freeze rows 1)
                ws.SheetView.FreezeRows(1);

                ws.Columns().AdjustToContents();

                workbook.SaveAs(sfd.FileName);

                var ans = MessageBox.Show("Xuất báo cáo tồn kho thành công! Bạn có muốn mở file không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == DialogResult.Yes)
                {
                    Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Tệp đang được mở bởi ứng dụng khác. Vui lòng đóng tệp Excel rồi thử lại!", "Lỗi truy cập tệp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất Excel tồn kho: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
