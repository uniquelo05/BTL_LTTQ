namespace BTL_LTTQ
{
    partial class Login
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pictureLogo = new System.Windows.Forms.PictureBox();
            this.lblAppName = new System.Windows.Forms.Label();
            this.lblAppDescription = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.pnlUsername = new System.Windows.Forms.Panel();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.lblUsernameIcon = new System.Windows.Forms.Label();
            this.pnlPassword = new System.Windows.Forms.Panel();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.btnShowPassword = new System.Windows.Forms.Button();
            this.lblPasswordIcon = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.pnlUsername.SuspendLayout();
            this.pnlPassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.pnlLeft);
            this.pnlMain.Controls.Add(this.pnlRight);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(900, 550);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.pnlLeft.Controls.Add(this.pictureLogo);
            this.pnlLeft.Controls.Add(this.lblAppName);
            this.pnlLeft.Controls.Add(this.lblAppDescription);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(450, 550);
            this.pnlLeft.TabIndex = 1;
            // 
            // pictureLogo
            // 
            this.pictureLogo.Location = new System.Drawing.Point(148, 67);
            this.pictureLogo.Name = "pictureLogo";
            this.pictureLogo.Size = new System.Drawing.Size(150, 150);
            this.pictureLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureLogo.TabIndex = 2;
            this.pictureLogo.TabStop = false;
            // 
            // lblAppName
            // 
            this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblAppName.ForeColor = System.Drawing.Color.White;
            this.lblAppName.Location = new System.Drawing.Point(30, 220);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(390, 120);
            this.lblAppName.TabIndex = 0;
            this.lblAppName.Text = "HỆ THỐNG QUẢN LÝ GIẢNG DẠY";
            this.lblAppName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAppDescription
            // 
            this.lblAppDescription.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblAppDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblAppDescription.Location = new System.Drawing.Point(50, 360);
            this.lblAppDescription.Name = "lblAppDescription";
            this.lblAppDescription.Size = new System.Drawing.Size(350, 60);
            this.lblAppDescription.TabIndex = 1;
            this.lblAppDescription.Text = "Quản lý hiệu quả - Giảng dạy chất lượng";
            this.lblAppDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.White;
            this.pnlRight.Controls.Add(this.btnClose);
            this.pnlRight.Controls.Add(this.lblWelcome);
            this.pnlRight.Controls.Add(this.lblSubTitle);
            this.pnlRight.Controls.Add(this.pnlUsername);
            this.pnlRight.Controls.Add(this.pnlPassword);
            this.pnlRight.Controls.Add(this.btnLogin);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(450, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(40, 20, 40, 40);
            this.pnlRight.Size = new System.Drawing.Size(450, 550);
            this.pnlRight.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnClose.Location = new System.Drawing.Point(400, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 40);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.LbClose_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.lblWelcome.Location = new System.Drawing.Point(40, 80);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(276, 62);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Đăng Nhập";
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lblSubTitle.Location = new System.Drawing.Point(46, 150);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(273, 25);
            this.lblSubTitle.TabIndex = 1;
            this.lblSubTitle.Text = "Vui lòng đăng nhập để tiếp tục";
            // 
            // pnlUsername
            // 
            this.pnlUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.pnlUsername.Controls.Add(this.tbUserName);
            this.pnlUsername.Controls.Add(this.lblUsernameIcon);
            this.pnlUsername.Location = new System.Drawing.Point(40, 210);
            this.pnlUsername.Name = "pnlUsername";
            this.pnlUsername.Size = new System.Drawing.Size(370, 55);
            this.pnlUsername.TabIndex = 2;
            // 
            // tbUserName
            // 
            this.tbUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.tbUserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbUserName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.tbUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbUserName.Location = new System.Drawing.Point(55, 15);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(300, 27);
            this.tbUserName.TabIndex = 1;
            this.tbUserName.Text = "Tên đăng nhập";
            this.tbUserName.Enter += new System.EventHandler(this.TbUserName_Enter);
            this.tbUserName.Leave += new System.EventHandler(this.TbUserName_Leave);
            // 
            // lblUsernameIcon
            // 
            this.lblUsernameIcon.AutoSize = true;
            this.lblUsernameIcon.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblUsernameIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.lblUsernameIcon.Location = new System.Drawing.Point(9, 9);
            this.lblUsernameIcon.Name = "lblUsernameIcon";
            this.lblUsernameIcon.Size = new System.Drawing.Size(54, 37);
            this.lblUsernameIcon.TabIndex = 0;
            this.lblUsernameIcon.Text = "👤";
            // 
            // pnlPassword
            // 
            this.pnlPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.pnlPassword.Controls.Add(this.tbPassword);
            this.pnlPassword.Controls.Add(this.btnShowPassword);
            this.pnlPassword.Controls.Add(this.lblPasswordIcon);
            this.pnlPassword.Location = new System.Drawing.Point(40, 285);
            this.pnlPassword.Name = "pnlPassword";
            this.pnlPassword.Size = new System.Drawing.Size(370, 55);
            this.pnlPassword.TabIndex = 3;
            // 
            // tbPassword
            // 
            this.tbPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.tbPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.tbPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbPassword.Location = new System.Drawing.Point(55, 15);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(260, 27);
            this.tbPassword.TabIndex = 1;
            this.tbPassword.UseSystemPasswordChar = true;
            this.tbPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbPassword_KeyPress);
            // 
            // btnShowPassword
            // 
            this.btnShowPassword.BackColor = System.Drawing.Color.Transparent;
            this.btnShowPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowPassword.FlatAppearance.BorderSize = 0;
            this.btnShowPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnShowPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.btnShowPassword.Location = new System.Drawing.Point(320, 10);
            this.btnShowPassword.Name = "btnShowPassword";
            this.btnShowPassword.Size = new System.Drawing.Size(40, 35);
            this.btnShowPassword.TabIndex = 2;
            this.btnShowPassword.Text = "👁";
            this.btnShowPassword.UseVisualStyleBackColor = false;
            this.btnShowPassword.Click += new System.EventHandler(this.BtnShowPassword_Click);
            // 
            // lblPasswordIcon
            // 
            this.lblPasswordIcon.AutoSize = true;
            this.lblPasswordIcon.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblPasswordIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.lblPasswordIcon.Location = new System.Drawing.Point(9, 9);
            this.lblPasswordIcon.Name = "lblPasswordIcon";
            this.lblPasswordIcon.Size = new System.Drawing.Size(54, 37);
            this.lblPasswordIcon.TabIndex = 0;
            this.lblPasswordIcon.Text = "🔒";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(40, 375);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(370, 55);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "ĐĂNG NHẬP";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 550);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.pnlUsername.ResumeLayout(false);
            this.pnlUsername.PerformLayout();
            this.pnlPassword.ResumeLayout(false);
            this.pnlPassword.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Panel pnlUsername;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label lblUsernameIcon;
        private System.Windows.Forms.Panel pnlPassword;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button btnShowPassword;
        private System.Windows.Forms.Label lblPasswordIcon;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Label lblAppDescription;
        private System.Windows.Forms.PictureBox pictureLogo;
        private System.Windows.Forms.Button btnClose;
    }
}