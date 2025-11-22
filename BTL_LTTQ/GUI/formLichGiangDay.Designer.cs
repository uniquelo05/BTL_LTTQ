namespace BTL_LTTQ.GUI
{
    partial class formLichGiangDay
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
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.cboTuan = new System.Windows.Forms.ComboBox();
            this.lblTuan = new System.Windows.Forms.Label();
            this.cboHocKy = new System.Windows.Forms.ComboBox();
            this.lblHocKy = new System.Windows.Forms.Label();
            this.cboNamHoc = new System.Windows.Forms.ComboBox();
            this.lblNamHoc = new System.Windows.Forms.Label();
            this.txtMaGV = new System.Windows.Forms.TextBox();
            this.lblMaGV = new System.Windows.Forms.Label();
            this.lblFilterTitle = new System.Windows.Forms.Label();
            this.pnlData = new System.Windows.Forms.Panel();
            this.dgvSchedule = new System.Windows.Forms.DataGridView();
            this.colCa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThuHai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThuBa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThuTu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThuNam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThuSau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThuBay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChuNhat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlHeader.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
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
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(100)))));
            this.lblTitle.Location = new System.Drawing.Point(15, 12);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(339, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📅 LỊCH GIẢNG DẠY";
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.White;
            this.pnlFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilter.Controls.Add(this.btnXuatExcel);
            this.pnlFilter.Controls.Add(this.btnLamMoi);
            this.pnlFilter.Controls.Add(this.btnTimKiem);
            this.pnlFilter.Controls.Add(this.cboTuan);
            this.pnlFilter.Controls.Add(this.lblTuan);
            this.pnlFilter.Controls.Add(this.cboHocKy);
            this.pnlFilter.Controls.Add(this.lblHocKy);
            this.pnlFilter.Controls.Add(this.cboNamHoc);
            this.pnlFilter.Controls.Add(this.lblNamHoc);
            this.pnlFilter.Controls.Add(this.txtMaGV);
            this.pnlFilter.Controls.Add(this.lblMaGV);
            this.pnlFilter.Controls.Add(this.lblFilterTitle);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 60);
            this.pnlFilter.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(15, 8, 15, 8);
            this.pnlFilter.Size = new System.Drawing.Size(1300, 100);
            this.pnlFilter.TabIndex = 1;
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnXuatExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXuatExcel.FlatAppearance.BorderSize = 0;
            this.btnXuatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXuatExcel.ForeColor = System.Drawing.Color.White;
            this.btnXuatExcel.Location = new System.Drawing.Point(1110, 47);
            this.btnXuatExcel.Margin = new System.Windows.Forms.Padding(4);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(150, 38);
            this.btnXuatExcel.TabIndex = 11;
            this.btnXuatExcel.Text = "📊 Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = false;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(980, 47);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(4);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(110, 38);
            this.btnLamMoi.TabIndex = 10;
            this.btnLamMoi.Text = "🔄 Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(850, 47);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(110, 38);
            this.btnTimKiem.TabIndex = 9;
            this.btnTimKiem.Text = "👁 Xem lịch";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // cboTuan
            // 
            this.cboTuan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTuan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTuan.FormattingEnabled = true;
            this.cboTuan.Location = new System.Drawing.Point(765, 52);
            this.cboTuan.Margin = new System.Windows.Forms.Padding(4);
            this.cboTuan.Name = "cboTuan";
            this.cboTuan.Size = new System.Drawing.Size(75, 31);
            this.cboTuan.TabIndex = 8;
            // 
            // lblTuan
            // 
            this.lblTuan.AutoSize = true;
            this.lblTuan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTuan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(100)))));
            this.lblTuan.Location = new System.Drawing.Point(710, 55);
            this.lblTuan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTuan.Name = "lblTuan";
            this.lblTuan.Size = new System.Drawing.Size(52, 23);
            this.lblTuan.TabIndex = 7;
            this.lblTuan.Text = "Tuần:";
            // 
            // cboHocKy
            // 
            this.cboHocKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHocKy.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboHocKy.FormattingEnabled = true;
            this.cboHocKy.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cboHocKy.Location = new System.Drawing.Point(610, 52);
            this.cboHocKy.Margin = new System.Windows.Forms.Padding(4);
            this.cboHocKy.Name = "cboHocKy";
            this.cboHocKy.Size = new System.Drawing.Size(90, 31);
            this.cboHocKy.TabIndex = 6;
            // 
            // lblHocKy
            // 
            this.lblHocKy.AutoSize = true;
            this.lblHocKy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHocKy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(100)))));
            this.lblHocKy.Location = new System.Drawing.Point(540, 55);
            this.lblHocKy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHocKy.Name = "lblHocKy";
            this.lblHocKy.Size = new System.Drawing.Size(67, 23);
            this.lblHocKy.TabIndex = 5;
            this.lblHocKy.Text = "Học kỳ:";
            // 
            // cboNamHoc
            // 
            this.cboNamHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNamHoc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboNamHoc.FormattingEnabled = true;
            this.cboNamHoc.Items.AddRange(new object[] {
            "2022",
            "2023",
            "2024",
            "2025"});
            this.cboNamHoc.Location = new System.Drawing.Point(405, 52);
            this.cboNamHoc.Margin = new System.Windows.Forms.Padding(4);
            this.cboNamHoc.Name = "cboNamHoc";
            this.cboNamHoc.Size = new System.Drawing.Size(120, 31);
            this.cboNamHoc.TabIndex = 4;
            // 
            // lblNamHoc
            // 
            this.lblNamHoc.AutoSize = true;
            this.lblNamHoc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNamHoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(100)))));
            this.lblNamHoc.Location = new System.Drawing.Point(315, 55);
            this.lblNamHoc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNamHoc.Name = "lblNamHoc";
            this.lblNamHoc.Size = new System.Drawing.Size(87, 23);
            this.lblNamHoc.TabIndex = 3;
            this.lblNamHoc.Text = "Năm học:";
            // 
            // txtMaGV
            // 
            this.txtMaGV.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMaGV.Location = new System.Drawing.Point(145, 52);
            this.txtMaGV.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaGV.Name = "txtMaGV";
            this.txtMaGV.Size = new System.Drawing.Size(150, 30);
            this.txtMaGV.TabIndex = 2;
            // 
            // lblMaGV
            // 
            this.lblMaGV.AutoSize = true;
            this.lblMaGV.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMaGV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(100)))));
            this.lblMaGV.Location = new System.Drawing.Point(70, 55);
            this.lblMaGV.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaGV.Name = "lblMaGV";
            this.lblMaGV.Size = new System.Drawing.Size(68, 23);
            this.lblMaGV.TabIndex = 1;
            this.lblMaGV.Text = "Mã GV:";
            // 
            // lblFilterTitle
            // 
            this.lblFilterTitle.AutoSize = true;
            this.lblFilterTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblFilterTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(100)))));
            this.lblFilterTitle.Location = new System.Drawing.Point(15, 12);
            this.lblFilterTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFilterTitle.Name = "lblFilterTitle";
            this.lblFilterTitle.Size = new System.Drawing.Size(87, 25);
            this.lblFilterTitle.TabIndex = 0;
            this.lblFilterTitle.Text = "🔍 Bộ lọc";
            // 
            // pnlData
            // 
            this.pnlData.BackColor = System.Drawing.Color.White;
            this.pnlData.Controls.Add(this.dgvSchedule);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlData.Location = new System.Drawing.Point(0, 160);
            this.pnlData.Margin = new System.Windows.Forms.Padding(4);
            this.pnlData.Name = "pnlData";
            this.pnlData.Padding = new System.Windows.Forms.Padding(15);
            this.pnlData.Size = new System.Drawing.Size(1300, 540);
            this.pnlData.TabIndex = 2;
            // 
            // dgvSchedule
            // 
            this.dgvSchedule.AllowUserToAddRows = false;
            this.dgvSchedule.AllowUserToDeleteRows = false;
            this.dgvSchedule.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSchedule.BackgroundColor = System.Drawing.Color.White;
            this.dgvSchedule.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSchedule.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSchedule.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSchedule.ColumnHeadersHeight = 40;
            this.dgvSchedule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCa,
            this.colGio,
            this.colThuHai,
            this.colThuBa,
            this.colThuTu,
            this.colThuNam,
            this.colThuSau,
            this.colThuBay,
            this.colChuNhat});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSchedule.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSchedule.EnableHeadersVisualStyles = false;
            this.dgvSchedule.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvSchedule.Location = new System.Drawing.Point(15, 15);
            this.dgvSchedule.Margin = new System.Windows.Forms.Padding(4);
            this.dgvSchedule.MultiSelect = false;
            this.dgvSchedule.Name = "dgvSchedule";
            this.dgvSchedule.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSchedule.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSchedule.RowHeadersVisible = false;
            this.dgvSchedule.RowHeadersWidth = 51;
            this.dgvSchedule.RowTemplate.Height = 70;
            this.dgvSchedule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvSchedule.Size = new System.Drawing.Size(1270, 510);
            this.dgvSchedule.TabIndex = 0;
            // 
            // colCa
            // 
            this.colCa.FillWeight = 40F;
            this.colCa.HeaderText = "Ca";
            this.colCa.MinimumWidth = 6;
            this.colCa.Name = "colCa";
            this.colCa.ReadOnly = true;
            // 
            // colGio
            // 
            this.colGio.FillWeight = 70F;
            this.colGio.HeaderText = "Giờ học";
            this.colGio.MinimumWidth = 6;
            this.colGio.Name = "colGio";
            this.colGio.ReadOnly = true;
            // 
            // colThuHai
            // 
            this.colThuHai.HeaderText = "Thứ Hai";
            this.colThuHai.MinimumWidth = 6;
            this.colThuHai.Name = "colThuHai";
            this.colThuHai.ReadOnly = true;
            // 
            // colThuBa
            // 
            this.colThuBa.HeaderText = "Thứ Ba";
            this.colThuBa.MinimumWidth = 6;
            this.colThuBa.Name = "colThuBa";
            this.colThuBa.ReadOnly = true;
            // 
            // colThuTu
            // 
            this.colThuTu.HeaderText = "Thứ Tư";
            this.colThuTu.MinimumWidth = 6;
            this.colThuTu.Name = "colThuTu";
            this.colThuTu.ReadOnly = true;
            // 
            // colThuNam
            // 
            this.colThuNam.HeaderText = "Thứ Năm";
            this.colThuNam.MinimumWidth = 6;
            this.colThuNam.Name = "colThuNam";
            this.colThuNam.ReadOnly = true;
            // 
            // colThuSau
            // 
            this.colThuSau.HeaderText = "Thứ Sáu";
            this.colThuSau.MinimumWidth = 6;
            this.colThuSau.Name = "colThuSau";
            this.colThuSau.ReadOnly = true;
            // 
            // colThuBay
            // 
            this.colThuBay.HeaderText = "Thứ Bảy";
            this.colThuBay.MinimumWidth = 6;
            this.colThuBay.Name = "colThuBay";
            this.colThuBay.ReadOnly = true;
            // 
            // colChuNhat
            // 
            this.colChuNhat.HeaderText = "Chủ Nhật";
            this.colChuNhat.MinimumWidth = 6;
            this.colChuNhat.Name = "colChuNhat";
            this.colChuNhat.ReadOnly = true;
            // 
            // formLichGiangDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 700);
            this.Controls.Add(this.pnlData);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1300, 700);
            this.Name = "formLichGiangDay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lịch Giảng Dạy";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblFilterTitle;
        private System.Windows.Forms.Label lblMaGV;
        private System.Windows.Forms.TextBox txtMaGV;
        private System.Windows.Forms.Label lblNamHoc;
        private System.Windows.Forms.ComboBox cboNamHoc;
        private System.Windows.Forms.Label lblHocKy;
        private System.Windows.Forms.ComboBox cboHocKy;
        private System.Windows.Forms.Label lblTuan;
        private System.Windows.Forms.ComboBox cboTuan;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.DataGridView dgvSchedule;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThuHai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThuBa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThuTu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThuNam;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThuSau;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThuBay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChuNhat;
    }
}