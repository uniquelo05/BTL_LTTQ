namespace BTL_LTTQ
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlUserInfo = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblUserRole = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnLichGiangDay = new System.Windows.Forms.Button();
            this.btnSinhVien = new System.Windows.Forms.Button();
            this.btnMonHoc = new System.Windows.Forms.Button();
            this.btnLopTC = new System.Windows.Forms.Button();
            this.btnPhanCong = new System.Windows.Forms.Button();
            this.btnDiem = new System.Windows.Forms.Button();
            this.btnGiangVien = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlSidebar.SuspendLayout();
            this.pnlUserInfo.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(52)))));
            this.pnlSidebar.Controls.Add(this.pnlUserInfo);
            this.pnlSidebar.Controls.Add(this.pnlMenu);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(250, 700);
            this.pnlSidebar.TabIndex = 0;
            // 
            // pnlUserInfo
            // 
            this.pnlUserInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(34)))), ((int)(((byte)(42)))));
            this.pnlUserInfo.Controls.Add(this.btnLogout);
            this.pnlUserInfo.Controls.Add(this.lblUserRole);
            this.pnlUserInfo.Controls.Add(this.lblUserName);
            this.pnlUserInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlUserInfo.Location = new System.Drawing.Point(0, 600);
            this.pnlUserInfo.Name = "pnlUserInfo";
            this.pnlUserInfo.Padding = new System.Windows.Forms.Padding(15, 12, 15, 12);
            this.pnlUserInfo.Size = new System.Drawing.Size(250, 100);
            this.pnlUserInfo.TabIndex = 2;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(15, 58);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(220, 30);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "🚪 Đăng Xuất";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblUserRole
            // 
            this.lblUserRole.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUserRole.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblUserRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.lblUserRole.Location = new System.Drawing.Point(15, 32);
            this.lblUserRole.Name = "lblUserRole";
            this.lblUserRole.Size = new System.Drawing.Size(220, 16);
            this.lblUserRole.TabIndex = 1;
            this.lblUserRole.Text = "Quản trị viên";
            // 
            // lblUserName
            // 
            this.lblUserName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUserName.ForeColor = System.Drawing.Color.White;
            this.lblUserName.Location = new System.Drawing.Point(15, 12);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(220, 20);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "👤 Admin";
            // 
            // pnlMenu
            // 
            this.pnlMenu.AutoScroll = true;
            this.pnlMenu.Controls.Add(this.btnLichGiangDay);
            this.pnlMenu.Controls.Add(this.btnSinhVien);
            this.pnlMenu.Controls.Add(this.btnMonHoc);
            this.pnlMenu.Controls.Add(this.btnLopTC);
            this.pnlMenu.Controls.Add(this.btnPhanCong);
            this.pnlMenu.Controls.Add(this.btnDiem);
            this.pnlMenu.Controls.Add(this.btnGiangVien);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Padding = new System.Windows.Forms.Padding(8, 20, 8, 8);
            this.pnlMenu.Size = new System.Drawing.Size(250, 700);
            this.pnlMenu.TabIndex = 1;
            // 
            // btnLichGiangDay
            // 
            this.btnLichGiangDay.BackColor = System.Drawing.Color.Transparent;
            this.btnLichGiangDay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLichGiangDay.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLichGiangDay.FlatAppearance.BorderSize = 0;
            this.btnLichGiangDay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnLichGiangDay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnLichGiangDay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLichGiangDay.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnLichGiangDay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.btnLichGiangDay.Location = new System.Drawing.Point(8, 344);
            this.btnLichGiangDay.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.btnLichGiangDay.Name = "btnLichGiangDay";
            this.btnLichGiangDay.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnLichGiangDay.Size = new System.Drawing.Size(234, 54);
            this.btnLichGiangDay.TabIndex = 6;
            this.btnLichGiangDay.Text = "   📅 Lịch Giảng Dạy";
            this.btnLichGiangDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLichGiangDay.UseVisualStyleBackColor = false;
            this.btnLichGiangDay.Click += new System.EventHandler(this.btnLichGiangDay_Click);
            // 
            // btnSinhVien
            // 
            this.btnSinhVien.BackColor = System.Drawing.Color.Transparent;
            this.btnSinhVien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSinhVien.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSinhVien.FlatAppearance.BorderSize = 0;
            this.btnSinhVien.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnSinhVien.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnSinhVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSinhVien.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnSinhVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.btnSinhVien.Location = new System.Drawing.Point(8, 290);
            this.btnSinhVien.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.btnSinhVien.Name = "btnSinhVien";
            this.btnSinhVien.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnSinhVien.Size = new System.Drawing.Size(234, 54);
            this.btnSinhVien.TabIndex = 5;
            this.btnSinhVien.Text = "   👨‍🎓 Sinh Viên";
            this.btnSinhVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSinhVien.UseVisualStyleBackColor = false;
            this.btnSinhVien.Click += new System.EventHandler(this.btnSinhVien_Click);
            // 
            // btnMonHoc
            // 
            this.btnMonHoc.BackColor = System.Drawing.Color.Transparent;
            this.btnMonHoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMonHoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMonHoc.FlatAppearance.BorderSize = 0;
            this.btnMonHoc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnMonHoc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnMonHoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMonHoc.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnMonHoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.btnMonHoc.Location = new System.Drawing.Point(8, 236);
            this.btnMonHoc.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.btnMonHoc.Name = "btnMonHoc";
            this.btnMonHoc.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnMonHoc.Size = new System.Drawing.Size(234, 54);
            this.btnMonHoc.TabIndex = 4;
            this.btnMonHoc.Text = "   📚 Môn Học";
            this.btnMonHoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMonHoc.UseVisualStyleBackColor = false;
            this.btnMonHoc.Click += new System.EventHandler(this.btnMonHoc_Click);
            // 
            // btnLopTC
            // 
            this.btnLopTC.BackColor = System.Drawing.Color.Transparent;
            this.btnLopTC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLopTC.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLopTC.FlatAppearance.BorderSize = 0;
            this.btnLopTC.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnLopTC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnLopTC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLopTC.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnLopTC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.btnLopTC.Location = new System.Drawing.Point(8, 182);
            this.btnLopTC.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.btnLopTC.Name = "btnLopTC";
            this.btnLopTC.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnLopTC.Size = new System.Drawing.Size(234, 54);
            this.btnLopTC.TabIndex = 3;
            this.btnLopTC.Text = "   🏫 Lớp Tín Chỉ";
            this.btnLopTC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLopTC.UseVisualStyleBackColor = false;
            this.btnLopTC.Click += new System.EventHandler(this.btnLopTC_Click);
            // 
            // btnPhanCong
            // 
            this.btnPhanCong.BackColor = System.Drawing.Color.Transparent;
            this.btnPhanCong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPhanCong.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPhanCong.FlatAppearance.BorderSize = 0;
            this.btnPhanCong.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnPhanCong.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnPhanCong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhanCong.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnPhanCong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.btnPhanCong.Location = new System.Drawing.Point(8, 128);
            this.btnPhanCong.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.btnPhanCong.Name = "btnPhanCong";
            this.btnPhanCong.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnPhanCong.Size = new System.Drawing.Size(234, 54);
            this.btnPhanCong.TabIndex = 2;
            this.btnPhanCong.Text = "   📋 Phân Công GV";
            this.btnPhanCong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPhanCong.UseVisualStyleBackColor = false;
            this.btnPhanCong.Click += new System.EventHandler(this.btnPhanCong_Click);
            // 
            // btnDiem
            // 
            this.btnDiem.BackColor = System.Drawing.Color.Transparent;
            this.btnDiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDiem.FlatAppearance.BorderSize = 0;
            this.btnDiem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnDiem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnDiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiem.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnDiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.btnDiem.Location = new System.Drawing.Point(8, 74);
            this.btnDiem.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.btnDiem.Name = "btnDiem";
            this.btnDiem.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnDiem.Size = new System.Drawing.Size(234, 54);
            this.btnDiem.TabIndex = 1;
            this.btnDiem.Text = "   📊 Điểm";
            this.btnDiem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDiem.UseVisualStyleBackColor = false;
            this.btnDiem.Click += new System.EventHandler(this.btnDiem_Click);
            // 
            // btnGiangVien
            // 
            this.btnGiangVien.BackColor = System.Drawing.Color.Transparent;
            this.btnGiangVien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGiangVien.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGiangVien.FlatAppearance.BorderSize = 0;
            this.btnGiangVien.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnGiangVien.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnGiangVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGiangVien.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnGiangVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.btnGiangVien.Location = new System.Drawing.Point(8, 20);
            this.btnGiangVien.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.btnGiangVien.Name = "btnGiangVien";
            this.btnGiangVien.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnGiangVien.Size = new System.Drawing.Size(234, 54);
            this.btnGiangVien.TabIndex = 0;
            this.btnGiangVien.Text = "   👨‍🏫 Giảng Viên";
            this.btnGiangVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGiangVien.UseVisualStyleBackColor = false;
            this.btnGiangVien.Click += new System.EventHandler(this.btnGiangVien_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(250, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(0);
            this.pnlMain.Size = new System.Drawing.Size(1050, 700);
            this.pnlMain.TabIndex = 1;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 700);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlSidebar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "📚 Hệ Thống Quản Lý Giảng Dạy";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlSidebar.ResumeLayout(false);
            this.pnlUserInfo.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnGiangVien;
        private System.Windows.Forms.Button btnDiem;
        private System.Windows.Forms.Button btnPhanCong;
        private System.Windows.Forms.Button btnLopTC;
        private System.Windows.Forms.Button btnMonHoc;
        private System.Windows.Forms.Button btnSinhVien;
        private System.Windows.Forms.Button btnLichGiangDay;
        private System.Windows.Forms.Panel pnlUserInfo;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblUserRole;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel pnlMain;
    }
}