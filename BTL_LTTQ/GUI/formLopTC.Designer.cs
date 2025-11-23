using System.Windows.Forms;

namespace BTL_LTTQ
{
    partial class formLopTC
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
            this.btnRefreshSearch = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtTimTheoNam = new System.Windows.Forms.TextBox();
            this.lblTimNam = new System.Windows.Forms.Label();
            this.cbbTimTheoKhoa = new System.Windows.Forms.ComboBox();
            this.lblTimKhoa = new System.Windows.Forms.Label();
            this.txtTimKiemTheoTen = new System.Windows.Forms.TextBox();
            this.lblSearchTitle = new System.Windows.Forms.Label();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbbMaMon = new System.Windows.Forms.ComboBox();
            this.lblMaMon = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbbMaKhoa = new System.Windows.Forms.ComboBox();
            this.lblMaKhoa = new System.Windows.Forms.Label();
            this.txtNamHoc = new System.Windows.Forms.TextBox();
            this.lblNamHoc = new System.Windows.Forms.Label();
            this.numHocKy = new System.Windows.Forms.NumericUpDown();
            this.lblHocKy = new System.Windows.Forms.Label();
            this.txtMaLop = new System.Windows.Forms.TextBox();
            this.lblMaLop = new System.Windows.Forms.Label();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.pnlData = new System.Windows.Forms.Panel();
            this.dgvSV = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlInput.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHocKy)).BeginInit();
            this.pnlActions.SuspendLayout();
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSV)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
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
            this.lblTitle.Size = new System.Drawing.Size(382, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🎓 QUẢN LÝ LỚP TÍN CHỈ";
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.Color.White;
            this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearch.Controls.Add(this.btnRefreshSearch);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.txtTimTheoNam);
            this.pnlSearch.Controls.Add(this.lblTimNam);
            this.pnlSearch.Controls.Add(this.cbbTimTheoKhoa);
            this.pnlSearch.Controls.Add(this.lblTimKhoa);
            this.pnlSearch.Controls.Add(this.txtTimKiemTheoTen);
            this.pnlSearch.Controls.Add(this.lblSearchTitle);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 60);
            this.pnlSearch.Margin = new System.Windows.Forms.Padding(4);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Padding = new System.Windows.Forms.Padding(15, 8, 15, 8);
            this.pnlSearch.Size = new System.Drawing.Size(1300, 60);
            this.pnlSearch.TabIndex = 1;
            // 
            // btnRefreshSearch
            // 
            this.btnRefreshSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnRefreshSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshSearch.FlatAppearance.BorderSize = 0;
            this.btnRefreshSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefreshSearch.ForeColor = System.Drawing.Color.White;
            this.btnRefreshSearch.Location = new System.Drawing.Point(1040, 12);
            this.btnRefreshSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefreshSearch.Name = "btnRefreshSearch";
            this.btnRefreshSearch.Size = new System.Drawing.Size(120, 35);
            this.btnRefreshSearch.TabIndex = 7;
            this.btnRefreshSearch.Text = "🔄 Tất cả";
            this.btnRefreshSearch.UseVisualStyleBackColor = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(900, 12);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 35);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "🔍 Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtTimTheoNam
            // 
            this.txtTimTheoNam.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTimTheoNam.Location = new System.Drawing.Point(730, 14);
            this.txtTimTheoNam.Margin = new System.Windows.Forms.Padding(4);
            this.txtTimTheoNam.Name = "txtTimTheoNam";
            this.txtTimTheoNam.Size = new System.Drawing.Size(140, 32);
            this.txtTimTheoNam.TabIndex = 5;
            // 
            // lblTimNam
            // 
            this.lblTimNam.AutoSize = true;
            this.lblTimNam.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTimNam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.lblTimNam.Location = new System.Drawing.Point(635, 17);
            this.lblTimNam.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimNam.Name = "lblTimNam";
            this.lblTimNam.Size = new System.Drawing.Size(96, 25);
            this.lblTimNam.TabIndex = 4;
            this.lblTimNam.Text = "Năm học:";
            // 
            // cbbTimTheoKhoa
            // 
            this.cbbTimTheoKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTimTheoKhoa.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cbbTimTheoKhoa.FormattingEnabled = true;
            this.cbbTimTheoKhoa.Location = new System.Drawing.Point(435, 14);
            this.cbbTimTheoKhoa.Margin = new System.Windows.Forms.Padding(4);
            this.cbbTimTheoKhoa.Name = "cbbTimTheoKhoa";
            this.cbbTimTheoKhoa.Size = new System.Drawing.Size(175, 33);
            this.cbbTimTheoKhoa.TabIndex = 3;
            // 
            // lblTimKhoa
            // 
            this.lblTimKhoa.AutoSize = true;
            this.lblTimKhoa.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTimKhoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.lblTimKhoa.Location = new System.Drawing.Point(365, 17);
            this.lblTimKhoa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimKhoa.Name = "lblTimKhoa";
            this.lblTimKhoa.Size = new System.Drawing.Size(62, 25);
            this.lblTimKhoa.TabIndex = 2;
            this.lblTimKhoa.Text = "Khoa:";
            // 
            // txtTimKiemTheoTen
            // 
            this.txtTimKiemTheoTen.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTimKiemTheoTen.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtTimKiemTheoTen.Location = new System.Drawing.Point(145, 14);
            this.txtTimKiemTheoTen.Margin = new System.Windows.Forms.Padding(4);
            this.txtTimKiemTheoTen.Name = "txtTimKiemTheoTen";
            this.txtTimKiemTheoTen.Size = new System.Drawing.Size(200, 32);
            this.txtTimKiemTheoTen.TabIndex = 1;
            this.txtTimKiemTheoTen.Text = "nhập mã lớp";
            // 
            // lblSearchTitle
            // 
            this.lblSearchTitle.AutoSize = true;
            this.lblSearchTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSearchTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.lblSearchTitle.Location = new System.Drawing.Point(15, 17);
            this.lblSearchTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSearchTitle.Name = "lblSearchTitle";
            this.lblSearchTitle.Size = new System.Drawing.Size(125, 25);
            this.lblSearchTitle.TabIndex = 0;
            this.lblSearchTitle.Text = "🔍 Tìm kiếm:";
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
            this.groupBox2.Controls.Add(this.cbbMaMon);
            this.groupBox2.Controls.Add(this.lblMaMon);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.groupBox2.Location = new System.Drawing.Point(665, 10);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(12);
            this.groupBox2.Size = new System.Drawing.Size(620, 160);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "📚 Môn học";
            // 
            // cbbMaMon
            // 
            this.cbbMaMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMaMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbMaMon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbMaMon.FormattingEnabled = true;
            this.cbbMaMon.Location = new System.Drawing.Point(150, 57);
            this.cbbMaMon.Margin = new System.Windows.Forms.Padding(4);
            this.cbbMaMon.Name = "cbbMaMon";
            this.cbbMaMon.Size = new System.Drawing.Size(450, 31);
            this.cbbMaMon.TabIndex = 1;
            // 
            // lblMaMon
            // 
            this.lblMaMon.AutoSize = true;
            this.lblMaMon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMaMon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMaMon.Location = new System.Drawing.Point(20, 60);
            this.lblMaMon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaMon.Name = "lblMaMon";
            this.lblMaMon.Size = new System.Drawing.Size(94, 23);
            this.lblMaMon.TabIndex = 0;
            this.lblMaMon.Text = "Môn học: *";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbbMaKhoa);
            this.groupBox1.Controls.Add(this.lblMaKhoa);
            this.groupBox1.Controls.Add(this.txtNamHoc);
            this.groupBox1.Controls.Add(this.lblNamHoc);
            this.groupBox1.Controls.Add(this.numHocKy);
            this.groupBox1.Controls.Add(this.lblHocKy);
            this.groupBox1.Controls.Add(this.txtMaLop);
            this.groupBox1.Controls.Add(this.lblMaLop);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.groupBox1.Location = new System.Drawing.Point(15, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(12);
            this.groupBox1.Size = new System.Drawing.Size(650, 160);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "📝 Thông tin lớp";
            // 
            // cbbMaKhoa
            // 
            this.cbbMaKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMaKhoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbMaKhoa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbMaKhoa.FormattingEnabled = true;
            this.cbbMaKhoa.Location = new System.Drawing.Point(475, 92);
            this.cbbMaKhoa.Margin = new System.Windows.Forms.Padding(4);
            this.cbbMaKhoa.Name = "cbbMaKhoa";
            this.cbbMaKhoa.Size = new System.Drawing.Size(155, 31);
            this.cbbMaKhoa.TabIndex = 7;
            // 
            // lblMaKhoa
            // 
            this.lblMaKhoa.AutoSize = true;
            this.lblMaKhoa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMaKhoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMaKhoa.Location = new System.Drawing.Point(405, 95);
            this.lblMaKhoa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaKhoa.Name = "lblMaKhoa";
            this.lblMaKhoa.Size = new System.Drawing.Size(53, 23);
            this.lblMaKhoa.TabIndex = 6;
            this.lblMaKhoa.Text = "Khoa:";
            // 
            // txtNamHoc
            // 
            this.txtNamHoc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNamHoc.Location = new System.Drawing.Point(165, 92);
            this.txtNamHoc.Margin = new System.Windows.Forms.Padding(4);
            this.txtNamHoc.Name = "txtNamHoc";
            this.txtNamHoc.Size = new System.Drawing.Size(220, 30);
            this.txtNamHoc.TabIndex = 5;
            // 
            // lblNamHoc
            // 
            this.lblNamHoc.AutoSize = true;
            this.lblNamHoc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNamHoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblNamHoc.Location = new System.Drawing.Point(20, 95);
            this.lblNamHoc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNamHoc.Name = "lblNamHoc";
            this.lblNamHoc.Size = new System.Drawing.Size(96, 23);
            this.lblNamHoc.TabIndex = 4;
            this.lblNamHoc.Text = "Năm học: *";
            // 
            // numHocKy
            // 
            this.numHocKy.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numHocKy.Location = new System.Drawing.Point(475, 57);
            this.numHocKy.Margin = new System.Windows.Forms.Padding(4);
            this.numHocKy.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numHocKy.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHocKy.Name = "numHocKy";
            this.numHocKy.Size = new System.Drawing.Size(155, 30);
            this.numHocKy.TabIndex = 3;
            this.numHocKy.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblHocKy
            // 
            this.lblHocKy.AutoSize = true;
            this.lblHocKy.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblHocKy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblHocKy.Location = new System.Drawing.Point(406, 60);
            this.lblHocKy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHocKy.Name = "lblHocKy";
            this.lblHocKy.Size = new System.Drawing.Size(65, 23);
            this.lblHocKy.TabIndex = 2;
            this.lblHocKy.Text = "Học kỳ:";
            // 
            // txtMaLop
            // 
            this.txtMaLop.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMaLop.Location = new System.Drawing.Point(165, 57);
            this.txtMaLop.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaLop.Name = "txtMaLop";
            this.txtMaLop.Size = new System.Drawing.Size(220, 30);
            this.txtMaLop.TabIndex = 1;
            // 
            // lblMaLop
            // 
            this.lblMaLop.AutoSize = true;
            this.lblMaLop.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMaLop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMaLop.Location = new System.Drawing.Point(20, 60);
            this.lblMaLop.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaLop.Name = "lblMaLop";
            this.lblMaLop.Size = new System.Drawing.Size(79, 23);
            this.lblMaLop.TabIndex = 0;
            this.lblMaLop.Text = "Mã lớp: *";
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
            this.btnXuatExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
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
            this.pnlData.Controls.Add(this.dgvSV);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlData.Location = new System.Drawing.Point(0, 365);
            this.pnlData.Margin = new System.Windows.Forms.Padding(4);
            this.pnlData.Name = "pnlData";
            this.pnlData.Padding = new System.Windows.Forms.Padding(15);
            this.pnlData.Size = new System.Drawing.Size(1300, 335);
            this.pnlData.TabIndex = 4;
            // 
            // dgvSV
            // 
            this.dgvSV.AllowUserToAddRows = false;
            this.dgvSV.AllowUserToDeleteRows = false;
            this.dgvSV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSV.BackgroundColor = System.Drawing.Color.White;
            this.dgvSV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSV.ColumnHeadersHeight = 35;
            this.dgvSV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSV.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSV.EnableHeadersVisualStyles = false;
            this.dgvSV.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvSV.Location = new System.Drawing.Point(15, 15);
            this.dgvSV.Margin = new System.Windows.Forms.Padding(4);
            this.dgvSV.MultiSelect = false;
            this.dgvSV.Name = "dgvSV";
            this.dgvSV.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSV.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSV.RowHeadersVisible = false;
            this.dgvSV.RowHeadersWidth = 51;
            this.dgvSV.RowTemplate.Height = 32;
            this.dgvSV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSV.Size = new System.Drawing.Size(1270, 305);
            this.dgvSV.TabIndex = 0;
            // 
            // formLopTC
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
            this.Name = "formLopTC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Lớp Tín Chỉ";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlInput.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHocKy)).EndInit();
            this.pnlActions.ResumeLayout(false);
            this.pnlData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Button btnRefreshSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtTimTheoNam;
        private System.Windows.Forms.Label lblTimNam;
        private System.Windows.Forms.ComboBox cbbTimTheoKhoa;
        private System.Windows.Forms.Label lblTimKhoa;
        private System.Windows.Forms.TextBox txtTimKiemTheoTen;
        private System.Windows.Forms.Label lblSearchTitle;
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMaLop;
        private System.Windows.Forms.Label lblMaLop;
        private System.Windows.Forms.NumericUpDown numHocKy;
        private System.Windows.Forms.Label lblHocKy;
        private System.Windows.Forms.TextBox txtNamHoc;
        private System.Windows.Forms.Label lblNamHoc;
        private System.Windows.Forms.ComboBox cbbMaKhoa;
        private System.Windows.Forms.Label lblMaKhoa;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbbMaMon;
        private System.Windows.Forms.Label lblMaMon;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.DataGridView dgvSV;
    }
}