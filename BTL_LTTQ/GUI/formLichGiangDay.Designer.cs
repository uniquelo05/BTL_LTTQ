namespace BTL_LTTQ.GUI
{
    partial class formLichGiangDay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStripBottom = new System.Windows.Forms.StatusStrip();
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.groupBoxActions = new System.Windows.Forms.GroupBox();
            this.btnChangeSlot = new System.Windows.Forms.Button();
            this.btnExportSchedule = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnXem = new System.Windows.Forms.Button();
            this.groupBoxFilter = new System.Windows.Forms.GroupBox();
            this.txtMaGV = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTuan = new System.Windows.Forms.ComboBox();
            this.labelHe1 = new System.Windows.Forms.Label();
            this.cboHocKy = new System.Windows.Forms.ComboBox();
            this.labelHocKy1 = new System.Windows.Forms.Label();
            this.cboNamHoc = new System.Windows.Forms.ComboBox();
            this.labelNamHoc = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).BeginInit();
            this.panelTop.SuspendLayout();
            this.groupBoxActions.SuspendLayout();
            this.groupBoxFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStripBottom
            // 
            this.statusStripBottom.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStripBottom.Location = new System.Drawing.Point(15, 604);
            this.statusStripBottom.Name = "statusStripBottom";
            this.statusStripBottom.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStripBottom.Size = new System.Drawing.Size(1049, 22);
            this.statusStripBottom.TabIndex = 1;
            this.statusStripBottom.Text = "statusStrip1";
            // 
            // dgvSchedule
            // 
            this.dgvSchedule.AllowUserToAddRows = false;
            this.dgvSchedule.AllowUserToDeleteRows = false;
            this.dgvSchedule.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSchedule.BackgroundColor = System.Drawing.Color.White;
            this.dgvSchedule.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSchedule.ColumnHeadersHeight = 35;
            this.dgvSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
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
            this.dgvSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSchedule.EnableHeadersVisualStyles = false;
            this.dgvSchedule.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvSchedule.Location = new System.Drawing.Point(15, 140);
            this.dgvSchedule.Margin = new System.Windows.Forms.Padding(4);
            this.dgvSchedule.Name = "dgvSchedule";
            this.dgvSchedule.ReadOnly = true;
            this.dgvSchedule.RowHeadersVisible = false;
            this.dgvSchedule.RowHeadersWidth = 51;
            this.dgvSchedule.RowTemplate.Height = 30;
            this.dgvSchedule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSchedule.Size = new System.Drawing.Size(1049, 464);
            this.dgvSchedule.TabIndex = 2;
            // 
            // colCa
            // 
            this.colCa.FillWeight = 25F;
            this.colCa.HeaderText = "Ca";
            this.colCa.MinimumWidth = 6;
            this.colCa.Name = "colCa";
            this.colCa.ReadOnly = true;
            // 
            // colGio
            // 
            this.colGio.FillWeight = 45F;
            this.colGio.HeaderText = "Giờ";
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
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.panelTop.Controls.Add(this.groupBoxActions);
            this.panelTop.Controls.Add(this.groupBoxFilter);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(15, 15);
            this.panelTop.Margin = new System.Windows.Forms.Padding(4);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(10);
            this.panelTop.Size = new System.Drawing.Size(1049, 125);
            this.panelTop.TabIndex = 3;
            // 
            // groupBoxActions
            // 
            this.groupBoxActions.Controls.Add(this.btnChangeSlot);
            this.groupBoxActions.Controls.Add(this.btnExportSchedule);
            this.groupBoxActions.Controls.Add(this.btnSearch);
            this.groupBoxActions.Controls.Add(this.btnXem);
            this.groupBoxActions.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBoxActions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxActions.Location = new System.Drawing.Point(599, 10);
            this.groupBoxActions.Name = "groupBoxActions";
            this.groupBoxActions.Padding = new System.Windows.Forms.Padding(10);
            this.groupBoxActions.Size = new System.Drawing.Size(440, 105);
            this.groupBoxActions.TabIndex = 1;
            this.groupBoxActions.TabStop = false;
            this.groupBoxActions.Text = "Thao tác";
            // 
            // btnChangeSlot
            // 
            this.btnChangeSlot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnChangeSlot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangeSlot.FlatAppearance.BorderSize = 0;
            this.btnChangeSlot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeSlot.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeSlot.ForeColor = System.Drawing.Color.White;
            this.btnChangeSlot.Location = new System.Drawing.Point(227, 60);
            this.btnChangeSlot.Margin = new System.Windows.Forms.Padding(4);
            this.btnChangeSlot.Name = "btnChangeSlot";
            this.btnChangeSlot.Size = new System.Drawing.Size(200, 35);
            this.btnChangeSlot.TabIndex = 12;
            this.btnChangeSlot.Text = "Đổi Ca Dạy";
            this.btnChangeSlot.UseVisualStyleBackColor = false;
            // 
            // btnExportSchedule
            // 
            this.btnExportSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnExportSchedule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportSchedule.FlatAppearance.BorderSize = 0;
            this.btnExportSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportSchedule.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportSchedule.ForeColor = System.Drawing.Color.White;
            this.btnExportSchedule.Location = new System.Drawing.Point(13, 60);
            this.btnExportSchedule.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportSchedule.Name = "btnExportSchedule";
            this.btnExportSchedule.Size = new System.Drawing.Size(200, 35);
            this.btnExportSchedule.TabIndex = 11;
            this.btnExportSchedule.Text = "📊 Xuất Excel";
            this.btnExportSchedule.UseVisualStyleBackColor = false;
           // this.btnExportSchedule.Click += new System.EventHandler(this.btnExportSchedule_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(227, 20);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(200, 35);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "🔍 Tìm Kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnXem
            // 
            this.btnXem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnXem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXem.FlatAppearance.BorderSize = 0;
            this.btnXem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXem.ForeColor = System.Drawing.Color.White;
            this.btnXem.Location = new System.Drawing.Point(13, 20);
            this.btnXem.Margin = new System.Windows.Forms.Padding(4);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(200, 35);
            this.btnXem.TabIndex = 13;
            this.btnXem.Text = "👁 Xem Lịch";
            this.btnXem.UseVisualStyleBackColor = false;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.Controls.Add(this.txtMaGV);
            this.groupBoxFilter.Controls.Add(this.label1);
            this.groupBoxFilter.Controls.Add(this.cboTuan);
            this.groupBoxFilter.Controls.Add(this.labelHe1);
            this.groupBoxFilter.Controls.Add(this.cboHocKy);
            this.groupBoxFilter.Controls.Add(this.labelHocKy1);
            this.groupBoxFilter.Controls.Add(this.cboNamHoc);
            this.groupBoxFilter.Controls.Add(this.labelNamHoc);
            this.groupBoxFilter.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxFilter.Location = new System.Drawing.Point(10, 10);
            this.groupBoxFilter.Name = "groupBoxFilter";
            this.groupBoxFilter.Padding = new System.Windows.Forms.Padding(10);
            this.groupBoxFilter.Size = new System.Drawing.Size(580, 105);
            this.groupBoxFilter.TabIndex = 0;
            this.groupBoxFilter.TabStop = false;
            this.groupBoxFilter.Text = "Bộ lọc";
            // 
            // txtMaGV
            // 
            this.txtMaGV.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaGV.Location = new System.Drawing.Point(405, 28);
            this.txtMaGV.Name = "txtMaGV";
            this.txtMaGV.Size = new System.Drawing.Size(160, 27);
            this.txtMaGV.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(335, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Mã GV";
            // 
            // cboTuan
            // 
            this.cboTuan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTuan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTuan.FormattingEnabled = true;
            this.cboTuan.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17"});
            this.cboTuan.Location = new System.Drawing.Point(405, 64);
            this.cboTuan.Margin = new System.Windows.Forms.Padding(4);
            this.cboTuan.Name = "cboTuan";
            this.cboTuan.Size = new System.Drawing.Size(160, 28);
            this.cboTuan.TabIndex = 3;
            // 
            // labelHe1
            // 
            this.labelHe1.AutoSize = true;
            this.labelHe1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHe1.Location = new System.Drawing.Point(346, 67);
            this.labelHe1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHe1.Name = "labelHe1";
            this.labelHe1.Size = new System.Drawing.Size(41, 20);
            this.labelHe1.TabIndex = 2;
            this.labelHe1.Text = "Tuần";
            // 
            // cboHocKy
            // 
            this.cboHocKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHocKy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboHocKy.FormattingEnabled = true;
            this.cboHocKy.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cboHocKy.Location = new System.Drawing.Point(103, 64);
            this.cboHocKy.Margin = new System.Windows.Forms.Padding(4);
            this.cboHocKy.Name = "cboHocKy";
            this.cboHocKy.Size = new System.Drawing.Size(200, 28);
            this.cboHocKy.TabIndex = 1;
            // 
            // labelHocKy1
            // 
            this.labelHocKy1.AutoSize = true;
            this.labelHocKy1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHocKy1.Location = new System.Drawing.Point(13, 67);
            this.labelHocKy1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHocKy1.Name = "labelHocKy1";
            this.labelHocKy1.Size = new System.Drawing.Size(54, 20);
            this.labelHocKy1.TabIndex = 0;
            this.labelHocKy1.Text = "Học kỳ";
            // 
            // cboNamHoc
            // 
            this.cboNamHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNamHoc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNamHoc.FormattingEnabled = true;
            this.cboNamHoc.Items.AddRange(new object[] {
            "2022",
            "2023",
            "2024",
            "2025"});
            this.cboNamHoc.Location = new System.Drawing.Point(103, 28);
            this.cboNamHoc.Margin = new System.Windows.Forms.Padding(4);
            this.cboNamHoc.Name = "cboNamHoc";
            this.cboNamHoc.Size = new System.Drawing.Size(200, 28);
            this.cboNamHoc.TabIndex = 5;
            // 
            // labelNamHoc
            // 
            this.labelNamHoc.AutoSize = true;
            this.labelNamHoc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNamHoc.Location = new System.Drawing.Point(13, 31);
            this.labelNamHoc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNamHoc.Name = "labelNamHoc";
            this.labelNamHoc.Size = new System.Drawing.Size(69, 20);
            this.labelNamHoc.TabIndex = 4;
            this.labelNamHoc.Text = "Năm học";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // formLichGiangDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1079, 641);
            this.Controls.Add(this.dgvSchedule);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.statusStripBottom);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "formLichGiangDay";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LỊCH GIẢNG DẠY CỦA TÔI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.formLichGiangDay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.groupBoxActions.ResumeLayout(false);
            this.groupBoxFilter.ResumeLayout(false);
            this.groupBoxFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStripBottom;
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
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ComboBox cboNamHoc;
        private System.Windows.Forms.Label labelNamHoc;
        private System.Windows.Forms.ComboBox cboTuan;
        private System.Windows.Forms.Label labelHe1;
        private System.Windows.Forms.ComboBox cboHocKy;
        private System.Windows.Forms.Label labelHocKy1;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Button btnChangeSlot;
        private System.Windows.Forms.Button btnExportSchedule;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaGV;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.GroupBox groupBoxFilter;
        private System.Windows.Forms.GroupBox groupBoxActions;
    }
}