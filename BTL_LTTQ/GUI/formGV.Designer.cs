namespace BTL_LTTQ
{
    partial class formGV
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
            this.cbbKhoa = new System.Windows.Forms.ComboBox();
            this.lblSearchKhoa = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearchTitle = new System.Windows.Forms.Label();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtSoDt = new System.Windows.Forms.TextBox();
            this.lblSoDt = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbbMaKhoa = new System.Windows.Forms.ComboBox();
            this.lblMaKhoa = new System.Windows.Forms.Label();
            this.txtHocVi = new System.Windows.Forms.TextBox();
            this.lblHocVi = new System.Windows.Forms.Label();
            this.txtHocHam = new System.Windows.Forms.TextBox();
            this.lblHocHam = new System.Windows.Forms.Label();
            this.pnlGioiTinh = new System.Windows.Forms.Panel();
            this.rdoNam = new System.Windows.Forms.RadioButton();
            this.rdoNu = new System.Windows.Forms.RadioButton();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.txtNgaySinh = new System.Windows.Forms.TextBox();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtMaGV = new System.Windows.Forms.TextBox();
            this.lblMaGV = new System.Windows.Forms.Label();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.pnlData = new System.Windows.Forms.Panel();
            this.dgvGV = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlInput.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlGioiTinh.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGV)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(174)))), ((int)(((byte)(98)))));
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
            this.lblTitle.Size = new System.Drawing.Size(381, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "👨‍🏫 QUẢN LÝ GIẢNG VIÊN";
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.Color.White;
            this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearch.Controls.Add(this.btnRefreshSearch);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.cbbKhoa);
            this.pnlSearch.Controls.Add(this.lblSearchKhoa);
            this.pnlSearch.Controls.Add(this.txtSearch);
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
            this.btnRefreshSearch.TabIndex = 5;
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
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "🔍 Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // cbbKhoa
            // 
            this.cbbKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbKhoa.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cbbKhoa.FormattingEnabled = true;
            this.cbbKhoa.Location = new System.Drawing.Point(620, 14);
            this.cbbKhoa.Margin = new System.Windows.Forms.Padding(4);
            this.cbbKhoa.Name = "cbbKhoa";
            this.cbbKhoa.Size = new System.Drawing.Size(250, 33);
            this.cbbKhoa.TabIndex = 3;
            // 
            // lblSearchKhoa
            // 
            this.lblSearchKhoa.AutoSize = true;
            this.lblSearchKhoa.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSearchKhoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(174)))), ((int)(((byte)(98)))));
            this.lblSearchKhoa.Location = new System.Drawing.Point(550, 17);
            this.lblSearchKhoa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSearchKhoa.Name = "lblSearchKhoa";
            this.lblSearchKhoa.Size = new System.Drawing.Size(62, 25);
            this.lblSearchKhoa.TabIndex = 2;
            this.lblSearchKhoa.Text = "Khoa:";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSearch.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtSearch.Location = new System.Drawing.Point(145, 14);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(380, 32);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.Text = "Tìm theo tên hoặc mã GV...";
            // 
            // lblSearchTitle
            // 
            this.lblSearchTitle.AutoSize = true;
            this.lblSearchTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSearchTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(174)))), ((int)(((byte)(98)))));
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
            this.pnlInput.Size = new System.Drawing.Size(1300, 220);
            this.pnlInput.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtEmail);
            this.groupBox2.Controls.Add(this.lblEmail);
            this.groupBox2.Controls.Add(this.txtSoDt);
            this.groupBox2.Controls.Add(this.lblSoDt);
            this.groupBox2.Controls.Add(this.txtDiaChi);
            this.groupBox2.Controls.Add(this.lblDiaChi);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(174)))), ((int)(((byte)(98)))));
            this.groupBox2.Location = new System.Drawing.Point(665, 10);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(12);
            this.groupBox2.Size = new System.Drawing.Size(620, 200);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "📞 Thông tin liên hệ";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.Location = new System.Drawing.Point(150, 127);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(450, 30);
            this.txtEmail.TabIndex = 5;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblEmail.Location = new System.Drawing.Point(20, 130);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(55, 23);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email:";
            // 
            // txtSoDt
            // 
            this.txtSoDt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSoDt.Location = new System.Drawing.Point(150, 92);
            this.txtSoDt.Margin = new System.Windows.Forms.Padding(4);
            this.txtSoDt.Name = "txtSoDt";
            this.txtSoDt.Size = new System.Drawing.Size(234, 30);
            this.txtSoDt.TabIndex = 3;
            // 
            // lblSoDt
            // 
            this.lblSoDt.AutoSize = true;
            this.lblSoDt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSoDt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSoDt.Location = new System.Drawing.Point(20, 95);
            this.lblSoDt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSoDt.Name = "lblSoDt";
            this.lblSoDt.Size = new System.Drawing.Size(115, 23);
            this.lblSoDt.TabIndex = 2;
            this.lblSoDt.Text = "Số điện thoại:";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDiaChi.Location = new System.Drawing.Point(150, 57);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(4);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(450, 30);
            this.txtDiaChi.TabIndex = 1;
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDiaChi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDiaChi.Location = new System.Drawing.Point(20, 60);
            this.lblDiaChi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(66, 23);
            this.lblDiaChi.TabIndex = 0;
            this.lblDiaChi.Text = "Địa chỉ:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbbMaKhoa);
            this.groupBox1.Controls.Add(this.lblMaKhoa);
            this.groupBox1.Controls.Add(this.txtHocVi);
            this.groupBox1.Controls.Add(this.lblHocVi);
            this.groupBox1.Controls.Add(this.txtHocHam);
            this.groupBox1.Controls.Add(this.lblHocHam);
            this.groupBox1.Controls.Add(this.pnlGioiTinh);
            this.groupBox1.Controls.Add(this.lblGioiTinh);
            this.groupBox1.Controls.Add(this.txtNgaySinh);
            this.groupBox1.Controls.Add(this.lblNgaySinh);
            this.groupBox1.Controls.Add(this.txtHoTen);
            this.groupBox1.Controls.Add(this.lblHoTen);
            this.groupBox1.Controls.Add(this.txtMaGV);
            this.groupBox1.Controls.Add(this.lblMaGV);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(174)))), ((int)(((byte)(98)))));
            this.groupBox1.Location = new System.Drawing.Point(15, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(12);
            this.groupBox1.Size = new System.Drawing.Size(650, 200);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "📝 Thông tin cơ bản";
            // 
            // cbbMaKhoa
            // 
            this.cbbMaKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMaKhoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbMaKhoa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbMaKhoa.FormattingEnabled = true;
            this.cbbMaKhoa.Location = new System.Drawing.Point(478, 110);
            this.cbbMaKhoa.Margin = new System.Windows.Forms.Padding(4);
            this.cbbMaKhoa.Name = "cbbMaKhoa";
            this.cbbMaKhoa.Size = new System.Drawing.Size(155, 31);
            this.cbbMaKhoa.TabIndex = 13;
            // 
            // lblMaKhoa
            // 
            this.lblMaKhoa.AutoSize = true;
            this.lblMaKhoa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMaKhoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMaKhoa.Location = new System.Drawing.Point(393, 114);
            this.lblMaKhoa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaKhoa.Name = "lblMaKhoa";
            this.lblMaKhoa.Size = new System.Drawing.Size(53, 23);
            this.lblMaKhoa.TabIndex = 12;
            this.lblMaKhoa.Text = "Khoa:";
            // 
            // txtHocVi
            // 
            this.txtHocVi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtHocVi.Location = new System.Drawing.Point(478, 76);
            this.txtHocVi.Margin = new System.Windows.Forms.Padding(4);
            this.txtHocVi.Name = "txtHocVi";
            this.txtHocVi.Size = new System.Drawing.Size(155, 30);
            this.txtHocVi.TabIndex = 11;
            // 
            // lblHocVi
            // 
            this.lblHocVi.AutoSize = true;
            this.lblHocVi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblHocVi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblHocVi.Location = new System.Drawing.Point(393, 79);
            this.lblHocVi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHocVi.Name = "lblHocVi";
            this.lblHocVi.Size = new System.Drawing.Size(61, 23);
            this.lblHocVi.TabIndex = 10;
            this.lblHocVi.Text = "Học vị:";
            // 
            // txtHocHam
            // 
            this.txtHocHam.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtHocHam.Location = new System.Drawing.Point(165, 145);
            this.txtHocHam.Margin = new System.Windows.Forms.Padding(4);
            this.txtHocHam.Name = "txtHocHam";
            this.txtHocHam.Size = new System.Drawing.Size(220, 30);
            this.txtHocHam.TabIndex = 9;
            // 
            // lblHocHam
            // 
            this.lblHocHam.AutoSize = true;
            this.lblHocHam.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblHocHam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblHocHam.Location = new System.Drawing.Point(20, 148);
            this.lblHocHam.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHocHam.Name = "lblHocHam";
            this.lblHocHam.Size = new System.Drawing.Size(83, 23);
            this.lblHocHam.TabIndex = 8;
            this.lblHocHam.Text = "Học hàm:";
            // 
            // pnlGioiTinh
            // 
            this.pnlGioiTinh.Controls.Add(this.rdoNam);
            this.pnlGioiTinh.Controls.Add(this.rdoNu);
            this.pnlGioiTinh.Location = new System.Drawing.Point(478, 41);
            this.pnlGioiTinh.Margin = new System.Windows.Forms.Padding(4);
            this.pnlGioiTinh.Name = "pnlGioiTinh";
            this.pnlGioiTinh.Size = new System.Drawing.Size(155, 30);
            this.pnlGioiTinh.TabIndex = 7;
            // 
            // rdoNam
            // 
            this.rdoNam.AutoSize = true;
            this.rdoNam.Checked = true;
            this.rdoNam.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rdoNam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rdoNam.Location = new System.Drawing.Point(3, 2);
            this.rdoNam.Margin = new System.Windows.Forms.Padding(4);
            this.rdoNam.Name = "rdoNam";
            this.rdoNam.Size = new System.Drawing.Size(68, 27);
            this.rdoNam.TabIndex = 0;
            this.rdoNam.TabStop = true;
            this.rdoNam.Text = "Nam";
            this.rdoNam.UseVisualStyleBackColor = true;
            // 
            // rdoNu
            // 
            this.rdoNu.AutoSize = true;
            this.rdoNu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rdoNu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rdoNu.Location = new System.Drawing.Point(85, 2);
            this.rdoNu.Margin = new System.Windows.Forms.Padding(4);
            this.rdoNu.Name = "rdoNu";
            this.rdoNu.Size = new System.Drawing.Size(54, 27);
            this.rdoNu.TabIndex = 1;
            this.rdoNu.Text = "Nữ";
            this.rdoNu.UseVisualStyleBackColor = true;
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblGioiTinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblGioiTinh.Location = new System.Drawing.Point(393, 44);
            this.lblGioiTinh.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(79, 23);
            this.lblGioiTinh.TabIndex = 6;
            this.lblGioiTinh.Text = "Giới tính:";
            // 
            // txtNgaySinh
            // 
            this.txtNgaySinh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNgaySinh.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtNgaySinh.Location = new System.Drawing.Point(165, 111);
            this.txtNgaySinh.Margin = new System.Windows.Forms.Padding(4);
            this.txtNgaySinh.Name = "txtNgaySinh";
            this.txtNgaySinh.Size = new System.Drawing.Size(220, 30);
            this.txtNgaySinh.TabIndex = 5;
            this.txtNgaySinh.Text = "mm/dd/yyyy";
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNgaySinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblNgaySinh.Location = new System.Drawing.Point(20, 114);
            this.lblNgaySinh.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(90, 23);
            this.lblNgaySinh.TabIndex = 4;
            this.lblNgaySinh.Text = "Ngày sinh:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtHoTen.Location = new System.Drawing.Point(165, 76);
            this.txtHoTen.Margin = new System.Windows.Forms.Padding(4);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(220, 30);
            this.txtHoTen.TabIndex = 3;
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblHoTen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblHoTen.Location = new System.Drawing.Point(20, 79);
            this.lblHoTen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(78, 23);
            this.lblHoTen.TabIndex = 2;
            this.lblHoTen.Text = "Họ tên: *";
            // 
            // txtMaGV
            // 
            this.txtMaGV.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMaGV.Location = new System.Drawing.Point(165, 41);
            this.txtMaGV.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaGV.Name = "txtMaGV";
            this.txtMaGV.Size = new System.Drawing.Size(220, 30);
            this.txtMaGV.TabIndex = 1;
            // 
            // lblMaGV
            // 
            this.lblMaGV.AutoSize = true;
            this.lblMaGV.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMaGV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMaGV.Location = new System.Drawing.Point(20, 44);
            this.lblMaGV.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaGV.Name = "lblMaGV";
            this.lblMaGV.Size = new System.Drawing.Size(78, 23);
            this.lblMaGV.TabIndex = 0;
            this.lblMaGV.Text = "Mã GV: *";
            // 
            // pnlActions
            // 
            this.pnlActions.BackColor = System.Drawing.Color.White;
            this.pnlActions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlActions.Controls.Add(this.btnXuatExcel);
            this.pnlActions.Controls.Add(this.btnLamMoi);
            this.pnlActions.Controls.Add(this.btnXoa);
            this.pnlActions.Controls.Add(this.btnSua);
            this.pnlActions.Controls.Add(this.btnThem);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlActions.Location = new System.Drawing.Point(0, 340);
            this.pnlActions.Margin = new System.Windows.Forms.Padding(4);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Padding = new System.Windows.Forms.Padding(15, 8, 15, 8);
            this.pnlActions.Size = new System.Drawing.Size(1300, 65);
            this.pnlActions.TabIndex = 3;
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(174)))), ((int)(((byte)(98)))));
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
            // pnlData
            // 
            this.pnlData.BackColor = System.Drawing.Color.White;
            this.pnlData.Controls.Add(this.dgvGV);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlData.Location = new System.Drawing.Point(0, 405);
            this.pnlData.Margin = new System.Windows.Forms.Padding(4);
            this.pnlData.Name = "pnlData";
            this.pnlData.Padding = new System.Windows.Forms.Padding(15);
            this.pnlData.Size = new System.Drawing.Size(1300, 295);
            this.pnlData.TabIndex = 4;
            // 
            // dgvGV
            // 
            this.dgvGV.AllowUserToAddRows = false;
            this.dgvGV.AllowUserToDeleteRows = false;
            this.dgvGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGV.BackgroundColor = System.Drawing.Color.White;
            this.dgvGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(174)))), ((int)(((byte)(98)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(154)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGV.ColumnHeadersHeight = 35;
            this.dgvGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(234)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGV.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGV.EnableHeadersVisualStyles = false;
            this.dgvGV.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvGV.Location = new System.Drawing.Point(15, 15);
            this.dgvGV.Margin = new System.Windows.Forms.Padding(4);
            this.dgvGV.MultiSelect = false;
            this.dgvGV.Name = "dgvGV";
            this.dgvGV.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvGV.RowHeadersVisible = false;
            this.dgvGV.RowHeadersWidth = 51;
            this.dgvGV.RowTemplate.Height = 32;
            this.dgvGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGV.Size = new System.Drawing.Size(1270, 265);
            this.dgvGV.TabIndex = 0;
            // 
            // formGV
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
            this.Name = "formGV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Giảng Viên";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlInput.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlGioiTinh.ResumeLayout(false);
            this.pnlGioiTinh.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.pnlData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Button btnRefreshSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cbbKhoa;
        private System.Windows.Forms.Label lblSearchKhoa;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearchTitle;
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMaGV;
        private System.Windows.Forms.Label lblMaGV;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtNgaySinh;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.Panel pnlGioiTinh;
        private System.Windows.Forms.RadioButton rdoNam;
        private System.Windows.Forms.RadioButton rdoNu;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.TextBox txtHocHam;
        private System.Windows.Forms.Label lblHocHam;
        private System.Windows.Forms.TextBox txtHocVi;
        private System.Windows.Forms.Label lblHocVi;
        private System.Windows.Forms.ComboBox cbbMaKhoa;
        private System.Windows.Forms.Label lblMaKhoa;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtSoDt;
        private System.Windows.Forms.Label lblSoDt;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.DataGridView dgvGV;
    }
}