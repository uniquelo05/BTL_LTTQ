namespace BTL_LTTQ
{
    partial class formDiem
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
            this.txtSearchMaLop = new System.Windows.Forms.TextBox();
            this.lblSearchMaLop = new System.Windows.Forms.Label();
            this.txtSearchMaSV = new System.Windows.Forms.TextBox();
            this.lblSearchMaSV = new System.Windows.Forms.Label();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDiemThi = new System.Windows.Forms.TextBox();
            this.lblDiemThi = new System.Windows.Forms.Label();
            this.txtDiemGK = new System.Windows.Forms.TextBox();
            this.lblDiemGK = new System.Windows.Forms.Label();
            this.txtDiemCC = new System.Windows.Forms.TextBox();
            this.lblDiemCC = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTenSV = new System.Windows.Forms.TextBox();
            this.lblTenSV = new System.Windows.Forms.Label();
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.lblMaSV = new System.Windows.Forms.Label();
            this.txtMaLop = new System.Windows.Forms.TextBox();
            this.lblMaLop = new System.Windows.Forms.Label();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.pnlData = new System.Windows.Forms.Panel();
            this.dgvDiem = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlInput.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiem)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(66)))), ((int)(((byte)(193)))));
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
            this.lblTitle.Size = new System.Drawing.Size(283, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📊 QUẢN LÝ ĐIỂM";
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.Color.White;
            this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearch.Controls.Add(this.btnRefreshSearch);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.txtSearchMaLop);
            this.pnlSearch.Controls.Add(this.lblSearchMaLop);
            this.pnlSearch.Controls.Add(this.txtSearchMaSV);
            this.pnlSearch.Controls.Add(this.lblSearchMaSV);
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
            this.btnRefreshSearch.Location = new System.Drawing.Point(900, 12);
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
            this.btnSearch.Location = new System.Drawing.Point(760, 12);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 35);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "🔍 Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtSearchMaLop
            // 
            this.txtSearchMaLop.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSearchMaLop.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtSearchMaLop.Location = new System.Drawing.Point(510, 14);
            this.txtSearchMaLop.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchMaLop.Name = "txtSearchMaLop";
            this.txtSearchMaLop.Size = new System.Drawing.Size(220, 32);
            this.txtSearchMaLop.TabIndex = 3;
            this.txtSearchMaLop.Text = "Mã lớp...";
            // 
            // lblSearchMaLop
            // 
            this.lblSearchMaLop.AutoSize = true;
            this.lblSearchMaLop.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSearchMaLop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(66)))), ((int)(((byte)(193)))));
            this.lblSearchMaLop.Location = new System.Drawing.Point(420, 17);
            this.lblSearchMaLop.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSearchMaLop.Name = "lblSearchMaLop";
            this.lblSearchMaLop.Size = new System.Drawing.Size(79, 25);
            this.lblSearchMaLop.TabIndex = 2;
            this.lblSearchMaLop.Text = "Mã lớp:";
            // 
            // txtSearchMaSV
            // 
            this.txtSearchMaSV.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSearchMaSV.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtSearchMaSV.Location = new System.Drawing.Point(145, 14);
            this.txtSearchMaSV.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchMaSV.Name = "txtSearchMaSV";
            this.txtSearchMaSV.Size = new System.Drawing.Size(250, 32);
            this.txtSearchMaSV.TabIndex = 1;
            this.txtSearchMaSV.Text = "Nhập mã sinh viên...";
            // 
            // lblSearchMaSV
            // 
            this.lblSearchMaSV.AutoSize = true;
            this.lblSearchMaSV.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSearchMaSV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(66)))), ((int)(((byte)(193)))));
            this.lblSearchMaSV.Location = new System.Drawing.Point(15, 17);
            this.lblSearchMaSV.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSearchMaSV.Name = "lblSearchMaSV";
            this.lblSearchMaSV.Size = new System.Drawing.Size(125, 25);
            this.lblSearchMaSV.TabIndex = 0;
            this.lblSearchMaSV.Text = "🔍 Tìm kiếm:";
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
            this.groupBox2.Controls.Add(this.txtDiemThi);
            this.groupBox2.Controls.Add(this.lblDiemThi);
            this.groupBox2.Controls.Add(this.txtDiemGK);
            this.groupBox2.Controls.Add(this.lblDiemGK);
            this.groupBox2.Controls.Add(this.txtDiemCC);
            this.groupBox2.Controls.Add(this.lblDiemCC);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(66)))), ((int)(((byte)(193)))));
            this.groupBox2.Location = new System.Drawing.Point(665, 10);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(12);
            this.groupBox2.Size = new System.Drawing.Size(620, 160);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "📊 Điểm số";
            // 
            // txtDiemThi
            // 
            this.txtDiemThi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDiemThi.Location = new System.Drawing.Point(420, 57);
            this.txtDiemThi.Margin = new System.Windows.Forms.Padding(4);
            this.txtDiemThi.Name = "txtDiemThi";
            this.txtDiemThi.Size = new System.Drawing.Size(180, 30);
            this.txtDiemThi.TabIndex = 5;
            this.txtDiemThi.Text = "0";
            // 
            // lblDiemThi
            // 
            this.lblDiemThi.AutoSize = true;
            this.lblDiemThi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDiemThi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDiemThi.Location = new System.Drawing.Point(330, 60);
            this.lblDiemThi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDiemThi.Name = "lblDiemThi";
            this.lblDiemThi.Size = new System.Drawing.Size(82, 23);
            this.lblDiemThi.TabIndex = 4;
            this.lblDiemThi.Text = "Điểm Thi:";
            // 
            // txtDiemGK
            // 
            this.txtDiemGK.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDiemGK.Location = new System.Drawing.Point(171, 92);
            this.txtDiemGK.Margin = new System.Windows.Forms.Padding(4);
            this.txtDiemGK.Name = "txtDiemGK";
            this.txtDiemGK.Size = new System.Drawing.Size(150, 30);
            this.txtDiemGK.TabIndex = 3;
            this.txtDiemGK.Text = "0";
            // 
            // lblDiemGK
            // 
            this.lblDiemGK.AutoSize = true;
            this.lblDiemGK.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDiemGK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDiemGK.Location = new System.Drawing.Point(20, 95);
            this.lblDiemGK.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDiemGK.Name = "lblDiemGK";
            this.lblDiemGK.Size = new System.Drawing.Size(113, 23);
            this.lblDiemGK.TabIndex = 2;
            this.lblDiemGK.Text = "Điểm giữa kỳ:";
            // 
            // txtDiemCC
            // 
            this.txtDiemCC.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDiemCC.Location = new System.Drawing.Point(171, 57);
            this.txtDiemCC.Margin = new System.Windows.Forms.Padding(4);
            this.txtDiemCC.Name = "txtDiemCC";
            this.txtDiemCC.Size = new System.Drawing.Size(150, 30);
            this.txtDiemCC.TabIndex = 1;
            this.txtDiemCC.Text = "0";
            // 
            // lblDiemCC
            // 
            this.lblDiemCC.AutoSize = true;
            this.lblDiemCC.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDiemCC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDiemCC.Location = new System.Drawing.Point(20, 60);
            this.lblDiemCC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDiemCC.Name = "lblDiemCC";
            this.lblDiemCC.Size = new System.Drawing.Size(146, 23);
            this.lblDiemCC.TabIndex = 0;
            this.lblDiemCC.Text = "Điểm chuyên cần:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTenSV);
            this.groupBox1.Controls.Add(this.lblTenSV);
            this.groupBox1.Controls.Add(this.txtMaSV);
            this.groupBox1.Controls.Add(this.lblMaSV);
            this.groupBox1.Controls.Add(this.txtMaLop);
            this.groupBox1.Controls.Add(this.lblMaLop);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(66)))), ((int)(((byte)(193)))));
            this.groupBox1.Location = new System.Drawing.Point(15, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(12);
            this.groupBox1.Size = new System.Drawing.Size(650, 160);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "📝 Thông tin sinh viên";
            // 
            // txtTenSV
            // 
            this.txtTenSV.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTenSV.Location = new System.Drawing.Point(165, 92);
            this.txtTenSV.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenSV.Name = "txtTenSV";
            this.txtTenSV.ReadOnly = true;
            this.txtTenSV.Size = new System.Drawing.Size(465, 30);
            this.txtTenSV.TabIndex = 5;
            // 
            // lblTenSV
            // 
            this.lblTenSV.AutoSize = true;
            this.lblTenSV.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTenSV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTenSV.Location = new System.Drawing.Point(20, 95);
            this.lblTenSV.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTenSV.Name = "lblTenSV";
            this.lblTenSV.Size = new System.Drawing.Size(112, 23);
            this.lblTenSV.TabIndex = 4;
            this.lblTenSV.Text = "Tên sinh viên:";
            // 
            // txtMaSV
            // 
            this.txtMaSV.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMaSV.Location = new System.Drawing.Point(405, 57);
            this.txtMaSV.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.Size = new System.Drawing.Size(225, 30);
            this.txtMaSV.TabIndex = 3;
            // 
            // lblMaSV
            // 
            this.lblMaSV.AutoSize = true;
            this.lblMaSV.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMaSV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMaSV.Location = new System.Drawing.Point(280, 60);
            this.lblMaSV.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaSV.Name = "lblMaSV";
            this.lblMaSV.Size = new System.Drawing.Size(122, 23);
            this.lblMaSV.TabIndex = 2;
            this.lblMaSV.Text = "Mã sinh viên: *";
            // 
            // txtMaLop
            // 
            this.txtMaLop.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMaLop.Location = new System.Drawing.Point(165, 57);
            this.txtMaLop.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaLop.Name = "txtMaLop";
            this.txtMaLop.Size = new System.Drawing.Size(100, 30);
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
            this.btnXuatExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(66)))), ((int)(((byte)(193)))));
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
            this.pnlData.Controls.Add(this.dgvDiem);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlData.Location = new System.Drawing.Point(0, 365);
            this.pnlData.Margin = new System.Windows.Forms.Padding(4);
            this.pnlData.Name = "pnlData";
            this.pnlData.Padding = new System.Windows.Forms.Padding(15);
            this.pnlData.Size = new System.Drawing.Size(1300, 335);
            this.pnlData.TabIndex = 4;
            // 
            // dgvDiem
            // 
            this.dgvDiem.AllowUserToAddRows = false;
            this.dgvDiem.AllowUserToDeleteRows = false;
            this.dgvDiem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDiem.BackgroundColor = System.Drawing.Color.White;
            this.dgvDiem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDiem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(66)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(51)))), ((int)(((byte)(155)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDiem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDiem.ColumnHeadersHeight = 35;
            this.dgvDiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(196)))), ((int)(((byte)(233)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDiem.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDiem.EnableHeadersVisualStyles = false;
            this.dgvDiem.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvDiem.Location = new System.Drawing.Point(15, 15);
            this.dgvDiem.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDiem.MultiSelect = false;
            this.dgvDiem.Name = "dgvDiem";
            this.dgvDiem.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDiem.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDiem.RowHeadersVisible = false;
            this.dgvDiem.RowHeadersWidth = 51;
            this.dgvDiem.RowTemplate.Height = 32;
            this.dgvDiem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDiem.Size = new System.Drawing.Size(1270, 305);
            this.dgvDiem.TabIndex = 0;
            // 
            // formDiem
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
            this.Name = "formDiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Điểm";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlInput.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.pnlData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Button btnRefreshSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchMaLop;
        private System.Windows.Forms.Label lblSearchMaLop;
        private System.Windows.Forms.TextBox txtSearchMaSV;
        private System.Windows.Forms.Label lblSearchMaSV;
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMaLop;
        private System.Windows.Forms.Label lblMaLop;
        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.Label lblMaSV;
        private System.Windows.Forms.TextBox txtTenSV;
        private System.Windows.Forms.Label lblTenSV;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDiemCC;
        private System.Windows.Forms.Label lblDiemCC;
        private System.Windows.Forms.TextBox txtDiemGK;
        private System.Windows.Forms.Label lblDiemGK;
        private System.Windows.Forms.TextBox txtDiemThi;
        private System.Windows.Forms.Label lblDiemThi;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.DataGridView dgvDiem;
    }
}