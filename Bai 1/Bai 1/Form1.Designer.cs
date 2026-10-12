namespace Bai_1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.GroupBox gbThongTin;
        private System.Windows.Forms.Label lblTenHang;
        private System.Windows.Forms.TextBox txtTenHang;
        private System.Windows.Forms.Label lblLoaiHang;
        private System.Windows.Forms.ComboBox cboLoaiHang;
        private System.Windows.Forms.Label lblDonVi;
        private System.Windows.Forms.ComboBox cboDonVi;
        private System.Windows.Forms.Label lblGiaBan;
        private System.Windows.Forms.NumericUpDown nudGiaBan;
        private System.Windows.Forms.Label lblSoLuongTon;
        private System.Windows.Forms.NumericUpDown nudSoLuongTon;
        private System.Windows.Forms.Label lblNgayNhap;
        private System.Windows.Forms.DateTimePicker dtpNgayNhap;
        private System.Windows.Forms.CheckBox chkConKinhDoanh;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;

        private System.Windows.Forms.GroupBox gbTimKiem;
        private System.Windows.Forms.Label lblTimTen;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblLocLoai;
        private System.Windows.Forms.ComboBox cboLocLoai;
        private System.Windows.Forms.CheckBox chkLocConKinhDoanh;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Button btnXemBangGia;
        private System.Windows.Forms.Button btnXuatPdf;
        private System.Windows.Forms.Button btnXuatExcelLuoi;
        private System.Windows.Forms.Button btnXuatExcelTonKho;
        private System.Windows.Forms.Timer tmrTimKiem;

        private System.Windows.Forms.DataGridView dgvHangHoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoaiHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonVi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuongTon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayNhap;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colConKinhDoanh;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle cellStyleGiaBan = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle cellStyleSoLuong = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle cellStyleNgayNhap = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle cellStyleMaHang = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle cellStyleDonVi = new System.Windows.Forms.DataGridViewCellStyle();

            gbThongTin = new System.Windows.Forms.GroupBox();
            lblTenHang = new System.Windows.Forms.Label();
            txtTenHang = new System.Windows.Forms.TextBox();
            lblLoaiHang = new System.Windows.Forms.Label();
            cboLoaiHang = new System.Windows.Forms.ComboBox();
            lblDonVi = new System.Windows.Forms.Label();
            cboDonVi = new System.Windows.Forms.ComboBox();
            lblGiaBan = new System.Windows.Forms.Label();
            nudGiaBan = new System.Windows.Forms.NumericUpDown();
            lblSoLuongTon = new System.Windows.Forms.Label();
            nudSoLuongTon = new System.Windows.Forms.NumericUpDown();
            lblNgayNhap = new System.Windows.Forms.Label();
            dtpNgayNhap = new System.Windows.Forms.DateTimePicker();
            chkConKinhDoanh = new System.Windows.Forms.CheckBox();
            btnThem = new System.Windows.Forms.Button();
            btnSua = new System.Windows.Forms.Button();
            btnXoa = new System.Windows.Forms.Button();
            btnLamMoi = new System.Windows.Forms.Button();

            gbTimKiem = new System.Windows.Forms.GroupBox();
            lblTimTen = new System.Windows.Forms.Label();
            txtTimKiem = new System.Windows.Forms.TextBox();
            lblLocLoai = new System.Windows.Forms.Label();
            cboLocLoai = new System.Windows.Forms.ComboBox();
            chkLocConKinhDoanh = new System.Windows.Forms.CheckBox();
            lblTrangThai = new System.Windows.Forms.Label();
            btnXemBangGia = new System.Windows.Forms.Button();
            btnXuatPdf = new System.Windows.Forms.Button();
            btnXuatExcelLuoi = new System.Windows.Forms.Button();
            btnXuatExcelTonKho = new System.Windows.Forms.Button();
            tmrTimKiem = new System.Windows.Forms.Timer(components);

            dgvHangHoa = new System.Windows.Forms.DataGridView();
            colMaHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colTenHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colLoaiHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colDonVi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colGiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colSoLuongTon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colNgayNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colConKinhDoanh = new System.Windows.Forms.DataGridViewCheckBoxColumn();

            gbThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudGiaBan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSoLuongTon).BeginInit();
            gbTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHangHoa).BeginInit();
            SuspendLayout();

            // 
            // gbThongTin
            // 
            gbThongTin.Controls.Add(lblTenHang);
            gbThongTin.Controls.Add(txtTenHang);
            gbThongTin.Controls.Add(lblLoaiHang);
            gbThongTin.Controls.Add(cboLoaiHang);
            gbThongTin.Controls.Add(lblDonVi);
            gbThongTin.Controls.Add(cboDonVi);
            gbThongTin.Controls.Add(lblGiaBan);
            gbThongTin.Controls.Add(nudGiaBan);
            gbThongTin.Controls.Add(lblSoLuongTon);
            gbThongTin.Controls.Add(nudSoLuongTon);
            gbThongTin.Controls.Add(lblNgayNhap);
            gbThongTin.Controls.Add(dtpNgayNhap);
            gbThongTin.Controls.Add(chkConKinhDoanh);
            gbThongTin.Controls.Add(btnThem);
            gbThongTin.Controls.Add(btnSua);
            gbThongTin.Controls.Add(btnXoa);
            gbThongTin.Controls.Add(btnLamMoi);
            gbThongTin.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            gbThongTin.Location = new System.Drawing.Point(15, 12);
            gbThongTin.Name = "gbThongTin";
            gbThongTin.Size = new System.Drawing.Size(1030, 155);
            gbThongTin.TabIndex = 0;
            gbThongTin.TabStop = false;
            gbThongTin.Text = "Thông tin hàng hóa";

            // lblTenHang
            lblTenHang.AutoSize = true;
            lblTenHang.Location = new System.Drawing.Point(15, 28);
            lblTenHang.Name = "lblTenHang";
            lblTenHang.Size = new System.Drawing.Size(76, 21);
            lblTenHang.TabIndex = 0;
            lblTenHang.Text = "Tên hàng:";

            // txtTenHang
            txtTenHang.Location = new System.Drawing.Point(97, 25);
            txtTenHang.Name = "txtTenHang";
            txtTenHang.Size = new System.Drawing.Size(280, 29);
            txtTenHang.TabIndex = 1;

            // lblLoaiHang
            lblLoaiHang.AutoSize = true;
            lblLoaiHang.Location = new System.Drawing.Point(395, 28);
            lblLoaiHang.Name = "lblLoaiHang";
            lblLoaiHang.Size = new System.Drawing.Size(81, 21);
            lblLoaiHang.TabIndex = 2;
            lblLoaiHang.Text = "Loại hàng:";

            // cboLoaiHang
            cboLoaiHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboLoaiHang.FormattingEnabled = true;
            cboLoaiHang.Location = new System.Drawing.Point(482, 25);
            cboLoaiHang.Name = "cboLoaiHang";
            cboLoaiHang.Size = new System.Drawing.Size(155, 29);
            cboLoaiHang.TabIndex = 3;

            // lblDonVi
            lblDonVi.AutoSize = true;
            lblDonVi.Location = new System.Drawing.Point(655, 28);
            lblDonVi.Name = "lblDonVi";
            lblDonVi.Size = new System.Drawing.Size(59, 21);
            lblDonVi.TabIndex = 4;
            lblDonVi.Text = "Đơn vị:";

            // cboDonVi
            cboDonVi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboDonVi.FormattingEnabled = true;
            cboDonVi.Location = new System.Drawing.Point(720, 25);
            cboDonVi.Name = "cboDonVi";
            cboDonVi.Size = new System.Drawing.Size(115, 29);
            cboDonVi.TabIndex = 5;

            // chkConKinhDoanh
            chkConKinhDoanh.AutoSize = true;
            chkConKinhDoanh.Checked = true;
            chkConKinhDoanh.CheckState = System.Windows.Forms.CheckState.Checked;
            chkConKinhDoanh.Location = new System.Drawing.Point(865, 27);
            chkConKinhDoanh.Name = "chkConKinhDoanh";
            chkConKinhDoanh.Size = new System.Drawing.Size(142, 25);
            chkConKinhDoanh.TabIndex = 6;
            chkConKinhDoanh.Text = "Còn kinh doanh";
            chkConKinhDoanh.UseVisualStyleBackColor = true;

            // lblGiaBan
            lblGiaBan.AutoSize = true;
            lblGiaBan.Location = new System.Drawing.Point(15, 68);
            lblGiaBan.Name = "lblGiaBan";
            lblGiaBan.Size = new System.Drawing.Size(66, 21);
            lblGiaBan.TabIndex = 7;
            lblGiaBan.Text = "Giá bán:";

            // nudGiaBan
            nudGiaBan.Increment = new decimal(new int[] { 500, 0, 0, 0 });
            nudGiaBan.Location = new System.Drawing.Point(97, 65);
            nudGiaBan.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nudGiaBan.Name = "nudGiaBan";
            nudGiaBan.Size = new System.Drawing.Size(145, 29);
            nudGiaBan.TabIndex = 8;
            nudGiaBan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            nudGiaBan.ThousandsSeparator = true;

            // lblSoLuongTon
            lblSoLuongTon.AutoSize = true;
            lblSoLuongTon.Location = new System.Drawing.Point(265, 68);
            lblSoLuongTon.Name = "lblSoLuongTon";
            lblSoLuongTon.Size = new System.Drawing.Size(102, 21);
            lblSoLuongTon.TabIndex = 9;
            lblSoLuongTon.Text = "Số lượng tồn:";

            // nudSoLuongTon
            nudSoLuongTon.Location = new System.Drawing.Point(373, 65);
            nudSoLuongTon.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudSoLuongTon.Name = "nudSoLuongTon";
            nudSoLuongTon.Size = new System.Drawing.Size(110, 29);
            nudSoLuongTon.TabIndex = 10;
            nudSoLuongTon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            nudSoLuongTon.ThousandsSeparator = true;

            // lblNgayNhap
            lblNgayNhap.AutoSize = true;
            lblNgayNhap.Location = new System.Drawing.Point(505, 68);
            lblNgayNhap.Name = "lblNgayNhap";
            lblNgayNhap.Size = new System.Drawing.Size(89, 21);
            lblNgayNhap.TabIndex = 11;
            lblNgayNhap.Text = "Ngày nhập:";

            // dtpNgayNhap
            dtpNgayNhap.CustomFormat = "dd/MM/yyyy";
            dtpNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpNgayNhap.Location = new System.Drawing.Point(600, 65);
            dtpNgayNhap.Name = "dtpNgayNhap";
            dtpNgayNhap.Size = new System.Drawing.Size(150, 29);
            dtpNgayNhap.TabIndex = 12;

            // btnThem
            btnThem.BackColor = System.Drawing.Color.SteelBlue;
            btnThem.ForeColor = System.Drawing.Color.White;
            btnThem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnThem.Location = new System.Drawing.Point(97, 107);
            btnThem.Name = "btnThem";
            btnThem.Size = new System.Drawing.Size(95, 36);
            btnThem.TabIndex = 13;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;

            // btnSua
            btnSua.BackColor = System.Drawing.Color.Teal;
            btnSua.ForeColor = System.Drawing.Color.White;
            btnSua.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnSua.Location = new System.Drawing.Point(208, 107);
            btnSua.Name = "btnSua";
            btnSua.Size = new System.Drawing.Size(95, 36);
            btnSua.TabIndex = 14;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;

            // btnXoa
            btnXoa.BackColor = System.Drawing.Color.Firebrick;
            btnXoa.ForeColor = System.Drawing.Color.White;
            btnXoa.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnXoa.Location = new System.Drawing.Point(319, 107);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new System.Drawing.Size(95, 36);
            btnXoa.TabIndex = 15;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;

            // btnLamMoi
            btnLamMoi.BackColor = System.Drawing.Color.SlateGray;
            btnLamMoi.ForeColor = System.Drawing.Color.White;
            btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnLamMoi.Location = new System.Drawing.Point(430, 107);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new System.Drawing.Size(95, 36);
            btnLamMoi.TabIndex = 16;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;

            // 
            // gbTimKiem
            // 
            gbTimKiem.Controls.Add(lblTimTen);
            gbTimKiem.Controls.Add(txtTimKiem);
            gbTimKiem.Controls.Add(lblLocLoai);
            gbTimKiem.Controls.Add(cboLocLoai);
            gbTimKiem.Controls.Add(chkLocConKinhDoanh);
            gbTimKiem.Controls.Add(lblTrangThai);
            gbTimKiem.Controls.Add(btnXemBangGia);
            gbTimKiem.Controls.Add(btnXuatPdf);
            gbTimKiem.Controls.Add(btnXuatExcelLuoi);
            gbTimKiem.Controls.Add(btnXuatExcelTonKho);
            gbTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            gbTimKiem.Location = new System.Drawing.Point(15, 175);
            gbTimKiem.Name = "gbTimKiem";
            gbTimKiem.Size = new System.Drawing.Size(1030, 105);
            gbTimKiem.TabIndex = 1;
            gbTimKiem.TabStop = false;
            gbTimKiem.Text = "Tìm kiếm & Xuất dữ liệu";

            // lblTimTen
            lblTimTen.AutoSize = true;
            lblTimTen.Location = new System.Drawing.Point(15, 27);
            lblTimTen.Name = "lblTimTen";
            lblTimTen.Size = new System.Drawing.Size(103, 21);
            lblTimTen.TabIndex = 0;
            lblTimTen.Text = "Tìm theo tên:";

            // txtTimKiem
            txtTimKiem.Location = new System.Drawing.Point(120, 24);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Gõ tên hàng để tìm...";
            txtTimKiem.Size = new System.Drawing.Size(225, 29);
            txtTimKiem.TabIndex = 1;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;

            // lblLocLoai
            lblLocLoai.AutoSize = true;
            lblLocLoai.Location = new System.Drawing.Point(360, 27);
            lblLocLoai.Name = "lblLocLoai";
            lblLocLoai.Size = new System.Drawing.Size(81, 21);
            lblLocLoai.TabIndex = 2;
            lblLocLoai.Text = "Loại hàng:";

            // cboLocLoai
            cboLocLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboLocLoai.FormattingEnabled = true;
            cboLocLoai.Location = new System.Drawing.Point(445, 24);
            cboLocLoai.Name = "cboLocLoai";
            cboLocLoai.Size = new System.Drawing.Size(150, 29);
            cboLocLoai.TabIndex = 3;
            cboLocLoai.SelectedIndexChanged += cboLocLoai_SelectedIndexChanged;

            // chkLocConKinhDoanh
            chkLocConKinhDoanh.AutoSize = true;
            chkLocConKinhDoanh.Location = new System.Drawing.Point(615, 26);
            chkLocConKinhDoanh.Name = "chkLocConKinhDoanh";
            chkLocConKinhDoanh.Size = new System.Drawing.Size(226, 25);
            chkLocConKinhDoanh.TabIndex = 4;
            chkLocConKinhDoanh.Text = "Chỉ hiện hàng còn kinh doanh";
            chkLocConKinhDoanh.UseVisualStyleBackColor = true;
            chkLocConKinhDoanh.CheckedChanged += chkLocConKinhDoanh_CheckedChanged;

            // lblTrangThai
            lblTrangThai.AutoSize = true;
            lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblTrangThai.ForeColor = System.Drawing.Color.Navy;
            lblTrangThai.Location = new System.Drawing.Point(855, 27);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new System.Drawing.Size(156, 21);
            lblTrangThai.TabIndex = 5;
            lblTrangThai.Text = "Tìm thấy 0 mặt hàng";

            // btnXemBangGia
            btnXemBangGia.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            btnXemBangGia.ForeColor = System.Drawing.Color.White;
            btnXemBangGia.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnXemBangGia.Location = new System.Drawing.Point(15, 62);
            btnXemBangGia.Name = "btnXemBangGia";
            btnXemBangGia.Size = new System.Drawing.Size(140, 34);
            btnXemBangGia.TabIndex = 6;
            btnXemBangGia.Text = "Xem bảng giá";
            btnXemBangGia.UseVisualStyleBackColor = false;
            btnXemBangGia.Click += btnXemBangGia_Click;

            // btnXuatPdf
            btnXuatPdf.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            btnXuatPdf.ForeColor = System.Drawing.Color.White;
            btnXuatPdf.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnXuatPdf.Location = new System.Drawing.Point(165, 62);
            btnXuatPdf.Name = "btnXuatPdf";
            btnXuatPdf.Size = new System.Drawing.Size(130, 34);
            btnXuatPdf.TabIndex = 7;
            btnXuatPdf.Text = "Xuất PDF";
            btnXuatPdf.UseVisualStyleBackColor = false;
            btnXuatPdf.Click += btnXuatPdf_Click;

            // btnXuatExcelLuoi
            btnXuatExcelLuoi.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            btnXuatExcelLuoi.ForeColor = System.Drawing.Color.White;
            btnXuatExcelLuoi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnXuatExcelLuoi.Location = new System.Drawing.Point(305, 62);
            btnXuatExcelLuoi.Name = "btnXuatExcelLuoi";
            btnXuatExcelLuoi.Size = new System.Drawing.Size(160, 34);
            btnXuatExcelLuoi.TabIndex = 8;
            btnXuatExcelLuoi.Text = "Xuất Excel (lưới)";
            btnXuatExcelLuoi.UseVisualStyleBackColor = false;
            btnXuatExcelLuoi.Click += btnXuatExcelLuoi_Click;

            // btnXuatExcelTonKho
            btnXuatExcelTonKho.BackColor = System.Drawing.Color.FromArgb(46, 139, 87);
            btnXuatExcelTonKho.ForeColor = System.Drawing.Color.White;
            btnXuatExcelTonKho.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnXuatExcelTonKho.Location = new System.Drawing.Point(475, 62);
            btnXuatExcelTonKho.Name = "btnXuatExcelTonKho";
            btnXuatExcelTonKho.Size = new System.Drawing.Size(165, 34);
            btnXuatExcelTonKho.TabIndex = 9;
            btnXuatExcelTonKho.Text = "Xuất Excel tồn kho";
            btnXuatExcelTonKho.UseVisualStyleBackColor = false;
            btnXuatExcelTonKho.Click += btnXuatExcelTonKho_Click;

            // tmrTimKiem
            tmrTimKiem.Interval = 350;
            tmrTimKiem.Tick += tmrTimKiem_Tick;

            // 
            // dgvHangHoa
            // 
            dgvHangHoa.AllowUserToAddRows = false;
            dgvHangHoa.AllowUserToDeleteRows = false;
            dgvHangHoa.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvHangHoa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvHangHoa.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dgvHangHoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHangHoa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                colMaHang,
                colTenHang,
                colLoaiHang,
                colDonVi,
                colGiaBan,
                colSoLuongTon,
                colNgayNhap,
                colConKinhDoanh
            });
            dgvHangHoa.Location = new System.Drawing.Point(15, 290);
            dgvHangHoa.MultiSelect = false;
            dgvHangHoa.Name = "dgvHangHoa";
            dgvHangHoa.ReadOnly = true;
            dgvHangHoa.RowHeadersVisible = false;
            dgvHangHoa.RowHeadersWidth = 51;
            dgvHangHoa.RowTemplate.Height = 29;
            dgvHangHoa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvHangHoa.Size = new System.Drawing.Size(1030, 360);
            dgvHangHoa.TabIndex = 2;
            dgvHangHoa.CellClick += dgvHangHoa_CellClick;

            // colMaHang
            cellStyleMaHang.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            colMaHang.DefaultCellStyle = cellStyleMaHang;
            colMaHang.FillWeight = 65F;
            colMaHang.HeaderText = "Mã hàng";
            colMaHang.MinimumWidth = 75;
            colMaHang.Name = "colMaHang";
            colMaHang.ReadOnly = true;

            // colTenHang
            colTenHang.FillWeight = 180F;
            colTenHang.HeaderText = "Tên hàng";
            colTenHang.MinimumWidth = 150;
            colTenHang.Name = "colTenHang";
            colTenHang.ReadOnly = true;

            // colLoaiHang
            colLoaiHang.FillWeight = 95F;
            colLoaiHang.HeaderText = "Loại hàng";
            colLoaiHang.MinimumWidth = 90;
            colLoaiHang.Name = "colLoaiHang";
            colLoaiHang.ReadOnly = true;

            // colDonVi
            cellStyleDonVi.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            colDonVi.DefaultCellStyle = cellStyleDonVi;
            colDonVi.FillWeight = 60F;
            colDonVi.HeaderText = "Đơn vị";
            colDonVi.MinimumWidth = 65;
            colDonVi.Name = "colDonVi";
            colDonVi.ReadOnly = true;

            // colGiaBan
            cellStyleGiaBan.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            cellStyleGiaBan.Format = "N0";
            cellStyleGiaBan.NullValue = "0";
            colGiaBan.DefaultCellStyle = cellStyleGiaBan;
            colGiaBan.FillWeight = 85F;
            colGiaBan.HeaderText = "Giá bán";
            colGiaBan.MinimumWidth = 85;
            colGiaBan.Name = "colGiaBan";
            colGiaBan.ReadOnly = true;

            // colSoLuongTon
            cellStyleSoLuong.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            cellStyleSoLuong.Format = "N0";
            cellStyleSoLuong.NullValue = "0";
            colSoLuongTon.DefaultCellStyle = cellStyleSoLuong;
            colSoLuongTon.FillWeight = 85F;
            colSoLuongTon.HeaderText = "Số lượng tồn";
            colSoLuongTon.MinimumWidth = 85;
            colSoLuongTon.Name = "colSoLuongTon";
            colSoLuongTon.ReadOnly = true;

            // colNgayNhap
            cellStyleNgayNhap.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            cellStyleNgayNhap.Format = "dd/MM/yyyy";
            colNgayNhap.DefaultCellStyle = cellStyleNgayNhap;
            colNgayNhap.FillWeight = 80F;
            colNgayNhap.HeaderText = "Ngày nhập";
            colNgayNhap.MinimumWidth = 85;
            colNgayNhap.Name = "colNgayNhap";
            colNgayNhap.ReadOnly = true;

            // colConKinhDoanh
            colConKinhDoanh.FillWeight = 75F;
            colConKinhDoanh.HeaderText = "Kinh doanh";
            colConKinhDoanh.MinimumWidth = 80;
            colConKinhDoanh.Name = "colConKinhDoanh";
            colConKinhDoanh.ReadOnly = true;
            colConKinhDoanh.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            colConKinhDoanh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;

            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            ClientSize = new System.Drawing.Size(1060, 665);
            Controls.Add(dgvHangHoa);
            Controls.Add(gbTimKiem);
            Controls.Add(gbThongTin);
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            MinimumSize = new System.Drawing.Size(950, 600);
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Tiệm tạp hóa Nhà trường UTC2 - Quản lý Hàng hóa & Báo cáo";
            Load += Form1_Load;
            gbThongTin.ResumeLayout(false);
            gbThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudGiaBan).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSoLuongTon).EndInit();
            gbTimKiem.ResumeLayout(false);
            gbTimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHangHoa).EndInit();
            ResumeLayout(false);
        }

        #endregion
    }
}
