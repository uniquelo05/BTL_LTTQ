namespace BTL_LTTQ
{
    partial class formMonHoc
    {
        private System.ComponentModel.IContainer components = null;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.btnTatCa = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.numSoTiet = new System.Windows.Forms.NumericUpDown();
            this.lblSoTiet = new System.Windows.Forms.Label();
            this.numSoTC = new System.Windows.Forms.NumericUpDown();
            this.lblSoTC = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbbMaKhoa = new System.Windows.Forms.ComboBox();
            this.lblMaKhoa = new System.Windows.Forms.Label();
            this.txtTenMH = new System.Windows.Forms.TextBox();
            this.lblTenMH = new System.Windows.Forms.Label();
            this.txtMaMH = new System.Windows.Forms.TextBox();
            this.lblMaMH = new System.Windows.Forms.Label();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.pnlData = new System.Windows.Forms.Panel();
            this.dgvMonHoc = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlInput.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoTC)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonHoc)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(135)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1300, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 12);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(327, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📚 QUẢN LÝ MÔN HỌC";
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.Color.White;
            this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearch.Controls.Add(this.btnTatCa);
            this.pnlSearch.Controls.Add(this.btnTimKiem);
            this.pnlSearch.Controls.Add(this.txtTimKiem);
            this.pnlSearch.Controls.Add(this.lblSearch);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 60);
            this.pnlSearch.Margin = new System.Windows.Forms.Padding(4);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Padding = new System.Windows.Forms.Padding(15, 8, 15, 8);
            this.pnlSearch.Size = new System.Drawing.Size(1300, 60);
            this.pnlSearch.TabIndex = 1;
            // 
            // btnTatCa
            // 
            this.btnTatCa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnTatCa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTatCa.FlatAppearance.BorderSize = 0;
            this.btnTatCa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTatCa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTatCa.ForeColor = System.Drawing.Color.White;
            this.btnTatCa.Location = new System.Drawing.Point(700, 12);
            this.btnTatCa.Margin = new System.Windows.Forms.Padding(4);
            this.btnTatCa.Name = "btnTatCa";
            this.btnTatCa.Size = new System.Drawing.Size(120, 35);
            this.btnTatCa.TabIndex = 3;
            this.btnTatCa.Text = "🔄 Tất cả";
            this.btnTatCa.UseVisualStyleBackColor = false;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(560, 12);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(120, 35);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "🔍 Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTimKiem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtTimKiem.Location = new System.Drawing.Point(120, 14);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(420, 32);
            this.txtTimKiem.TabIndex = 1;
            this.txtTimKiem.Text = "Tìm theo tên hoặc mã môn học...";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(135)))));
            this.lblSearch.Location = new System.Drawing.Point(15, 17);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(98, 25);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Tìm kiếm:";
            // 
            // pnlInput
            // 
            this.pnlInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.pnlInput.Controls.Add(this.groupBox2);
            this.pnlInput.Controls.Add(this.groupBox1);
            this.pnlInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInput.Location = new System.Drawing.Point(0, 120);
            this.pnlInput.Margin = new System.Windows.Forms.Padding(4);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.pnlInput.Size = new System.Drawing.Size(1300, 180);
            this.pnlInput.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtMoTa);
            this.groupBox2.Controls.Add(this.lblMoTa);
            this.groupBox2.Controls.Add(this.numSoTiet);
            this.groupBox2.Controls.Add(this.lblSoTiet);
            this.groupBox2.Controls.Add(this.numSoTC);
            this.groupBox2.Controls.Add(this.lblSoTC);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(135)))));
            this.groupBox2.Location = new System.Drawing.Point(665, 10);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(12);
            this.groupBox2.Size = new System.Drawing.Size(620, 160);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "📊 Thông tin chi tiết";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMoTa.Location = new System.Drawing.Point(150, 93);
            this.txtMoTa.Margin = new System.Windows.Forms.Padding(4);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(450, 50);
            this.txtMoTa.TabIndex = 5;
            // 
            // lblMoTa
            // 
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMoTa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMoTa.Location = new System.Drawing.Point(20, 96);
            this.lblMoTa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(59, 23);
            this.lblMoTa.TabIndex = 4;
            this.lblMoTa.Text = "Mô tả:";
            // 
            // numSoTiet
            // 
            this.numSoTiet.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numSoTiet.Location = new System.Drawing.Point(392, 58);
            this.numSoTiet.Margin = new System.Windows.Forms.Padding(4);
            this.numSoTiet.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numSoTiet.Name = "numSoTiet";
            this.numSoTiet.Size = new System.Drawing.Size(208, 30);
            this.numSoTiet.TabIndex = 3;
            // 
            // lblSoTiet
            // 
            this.lblSoTiet.AutoSize = true;
            this.lblSoTiet.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSoTiet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSoTiet.Location = new System.Drawing.Point(312, 61);
            this.lblSoTiet.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSoTiet.Name = "lblSoTiet";
            this.lblSoTiet.Size = new System.Drawing.Size(68, 23);
            this.lblSoTiet.TabIndex = 2;
            this.lblSoTiet.Text = "Số tiết:";
            // 
            // numSoTC
            // 
            this.numSoTC.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numSoTC.Location = new System.Drawing.Point(150, 58);
            this.numSoTC.Margin = new System.Windows.Forms.Padding(4);
            this.numSoTC.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numSoTC.Name = "numSoTC";
            this.numSoTC.Size = new System.Drawing.Size(145, 30);
            this.numSoTC.TabIndex = 1;
            // 
            // lblSoTC
            // 
            this.lblSoTC.AutoSize = true;
            this.lblSoTC.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSoTC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSoTC.Location = new System.Drawing.Point(20, 61);
            this.lblSoTC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSoTC.Name = "lblSoTC";
            this.lblSoTC.Size = new System.Drawing.Size(99, 23);
            this.lblSoTC.TabIndex = 0;
            this.lblSoTC.Text = "Số tín chỉ: *";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbbMaKhoa);
            this.groupBox1.Controls.Add(this.lblMaKhoa);
            this.groupBox1.Controls.Add(this.txtTenMH);
            this.groupBox1.Controls.Add(this.lblTenMH);
            this.groupBox1.Controls.Add(this.txtMaMH);
            this.groupBox1.Controls.Add(this.lblMaMH);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(135)))));
            this.groupBox1.Location = new System.Drawing.Point(15, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(12);
            this.groupBox1.Size = new System.Drawing.Size(650, 160);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "📝 Thông tin cơ bản";
            // 
            // cbbMaKhoa
            // 
            this.cbbMaKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMaKhoa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbMaKhoa.FormattingEnabled = true;
            this.cbbMaKhoa.Location = new System.Drawing.Point(165, 112);
            this.cbbMaKhoa.Margin = new System.Windows.Forms.Padding(4);
            this.cbbMaKhoa.Name = "cbbMaKhoa";
            this.cbbMaKhoa.Size = new System.Drawing.Size(465, 31);
            this.cbbMaKhoa.TabIndex = 5;
            // 
            // lblMaKhoa
            // 
            this.lblMaKhoa.AutoSize = true;
            this.lblMaKhoa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMaKhoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMaKhoa.Location = new System.Drawing.Point(20, 115);
            this.lblMaKhoa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaKhoa.Name = "lblMaKhoa";
            this.lblMaKhoa.Size = new System.Drawing.Size(74, 23);
            this.lblMaKhoa.TabIndex = 4;
            this.lblMaKhoa.Text = "Khoa: *";
            // 
            // txtTenMH
            // 
            this.txtTenMH.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTenMH.Location = new System.Drawing.Point(165, 77);
            this.txtTenMH.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenMH.Name = "txtTenMH";
            this.txtTenMH.Size = new System.Drawing.Size(465, 30);
            this.txtTenMH.TabIndex = 3;
            // 
            // lblTenMH
            // 
            this.lblTenMH.AutoSize = true;
            this.lblTenMH.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTenMH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTenMH.Location = new System.Drawing.Point(20, 80);
            this.lblTenMH.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTenMH.Name = "lblTenMH";
            this.lblTenMH.Size = new System.Drawing.Size(131, 23);
            this.lblTenMH.TabIndex = 2;
            this.lblTenMH.Text = "Tên môn học: *";
            // 
            // txtMaMH
            // 
            this.txtMaMH.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMaMH.Location = new System.Drawing.Point(165, 42);
            this.txtMaMH.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaMH.Name = "txtMaMH";
            this.txtMaMH.Size = new System.Drawing.Size(180, 30);
            this.txtMaMH.TabIndex = 1;
            // 
            // lblMaMH
            // 
            this.lblMaMH.AutoSize = true;
            this.lblMaMH.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMaMH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMaMH.Location = new System.Drawing.Point(20, 45);
            this.lblMaMH.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaMH.Name = "lblMaMH";
            this.lblMaMH.Size = new System.Drawing.Size(128, 23);
            this.lblMaMH.TabIndex = 0;
            this.lblMaMH.Text = "Mã môn học: *";
            // 
            // pnlActions
            // 
            this.pnlActions.BackColor = System.Drawing.Color.White;
            this.pnlActions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlActions.Controls.Add(this.btnLamMoi);
            this.pnlActions.Controls.Add(this.btnXoa);
            this.pnlActions.Controls.Add(this.btnSua);
            this.pnlActions.Controls.Add(this.btnThem);
            this.pnlActions.Controls.Add(this.btnXuatExcel);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlActions.Location = new System.Drawing.Point(0, 300);
            this.pnlActions.Margin = new System.Windows.Forms.Padding(4);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Padding = new System.Windows.Forms.Padding(15, 8, 15, 8);
            this.pnlActions.Size = new System.Drawing.Size(1300, 65);
            this.pnlActions.TabIndex = 3;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(620, 10);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(4);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(140, 42);
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Text = "🔄 Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(430, 10);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(140, 42);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "🗑️ Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(240, 10);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(140, 42);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "✏️ Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(50, 10);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(140, 42);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "➕ Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(135)))));
            this.btnXuatExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXuatExcel.FlatAppearance.BorderSize = 0;
            this.btnXuatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnXuatExcel.ForeColor = System.Drawing.Color.White;
            this.btnXuatExcel.Location = new System.Drawing.Point(810, 10);
            this.btnXuatExcel.Margin = new System.Windows.Forms.Padding(4);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(160, 42);
            this.btnXuatExcel.TabIndex = 4;
            this.btnXuatExcel.Text = "📊 Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = false;
            // 
            // pnlData
            // 
            this.pnlData.BackColor = System.Drawing.Color.White;
            this.pnlData.Controls.Add(this.dgvMonHoc);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlData.Location = new System.Drawing.Point(0, 365);
            this.pnlData.Margin = new System.Windows.Forms.Padding(4);
            this.pnlData.Name = "pnlData";
            this.pnlData.Padding = new System.Windows.Forms.Padding(15);
            this.pnlData.Size = new System.Drawing.Size(1300, 335);
            this.pnlData.TabIndex = 4;
            // 
            // dgvMonHoc
            // 
            this.dgvMonHoc.AllowUserToAddRows = false;
            this.dgvMonHoc.AllowUserToDeleteRows = false;
            this.dgvMonHoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMonHoc.BackgroundColor = System.Drawing.Color.White;
            this.dgvMonHoc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMonHoc.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(135)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(108)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMonHoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMonHoc.ColumnHeadersHeight = 35;
            this.dgvMonHoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMonHoc.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMonHoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMonHoc.EnableHeadersVisualStyles = false;
            this.dgvMonHoc.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvMonHoc.Location = new System.Drawing.Point(15, 15);
            this.dgvMonHoc.Margin = new System.Windows.Forms.Padding(4);
            this.dgvMonHoc.MultiSelect = false;
            this.dgvMonHoc.Name = "dgvMonHoc";
            this.dgvMonHoc.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMonHoc.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMonHoc.RowHeadersVisible = false;
            this.dgvMonHoc.RowHeadersWidth = 51;
            this.dgvMonHoc.RowTemplate.Height = 32;
            this.dgvMonHoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMonHoc.Size = new System.Drawing.Size(1270, 305);
            this.dgvMonHoc.TabIndex = 0;
            // 
            // formMonHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 700);
            this.Controls.Add(this.pnlData);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.pnlInput);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1300, 700);
            this.Name = "formMonHoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Môn Học";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlInput.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoTC)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.pnlData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonHoc)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMaMH;
        private System.Windows.Forms.Label lblMaMH;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.DataGridView dgvMonHoc;
        private System.Windows.Forms.TextBox txtTenMH;
        private System.Windows.Forms.Label lblTenMH;
        private System.Windows.Forms.ComboBox cbbMaKhoa;
        private System.Windows.Forms.Label lblMaKhoa;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numSoTC;
        private System.Windows.Forms.Label lblSoTC;
        private System.Windows.Forms.NumericUpDown numSoTiet;
        private System.Windows.Forms.Label lblSoTiet;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnTatCa;
        private System.Windows.Forms.Button btnXuatExcel;
    }
}