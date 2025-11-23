// Login.cs
using BTL_LTTQ.BLL;
using BTL_LTTQ.BLL.Session;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_LTTQ
{
    public partial class Login : Form
    {
        private readonly LoginBLL _loginBLL;
        private bool _isPasswordVisible = false;

        public Login()
        {
            InitializeComponent();
            _loginBLL = new LoginBLL();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = tbUserName.Text.Trim();
            string password = tbPassword.Text;

            // Kiểm tra placeholder
            if (username == "Tên đăng nhập" || string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbUserName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbPassword.Focus();
                return;
            }

            var result = _loginBLL.ProcessLogin(username, password);

            if (!result.Success)
            {
                MessageBox.Show(result.Message, "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbPassword.Clear();
                tbPassword.Focus();
                return;
            }

            // Đăng nhập thành công - Chỉ mở FormMain
            try
            {
                FormMain mainForm = new FormMain();
                mainForm.FormClosed += (s, args) => this.Close();
                mainForm.Show();

                // Ẩn form Login
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // Thiết lập các sự kiện
            SetupEvents();

            // Thiết lập placeholder text
            SetupPlaceholderText();

            // Thêm bo góc cho form (tùy chọn)
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void SetupEvents()
        {
            // ❌ XÓA DÒNG NÀY - đã được đăng ký trong Designer
            // tbPassword.KeyPress += TbPassword_KeyPress;
            
            // Các sự kiện không bị trùng lặp
            tbUserName.Enter += TbUserName_Enter;
            tbUserName.Leave += TbUserName_Leave;
            
            // Thêm hover effect cho button
            btnLogin.MouseEnter += BtnLogin_MouseEnter;
            btnLogin.MouseLeave += BtnLogin_MouseLeave;
        }

        private void SetupPlaceholderText()
        {
            // Thiết lập màu sắc placeholder cho username
            if (tbUserName.Text == "Tên đăng nhập")
            {
                tbUserName.ForeColor = Color.Gray;
            }
        }

        private void LbClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát?", 
                "Xác nhận", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void TbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Nhấn Enter để đăng nhập
            if (e.KeyChar == (char)Keys.Enter)
            {
                BtnLogin_Click(sender, e);
                e.Handled = true;
            }
        }

        private void TbUserName_Enter(object sender, EventArgs e)
        {
            // Xóa placeholder text khi focus
            if (tbUserName.Text == "Tên đăng nhập")
            {
                tbUserName.Text = "";
                tbUserName.ForeColor = Color.FromArgb(64, 64, 64);
            }
        }

        private void TbUserName_Leave(object sender, EventArgs e)
        {
            // Hiện lại placeholder nếu rỗng
            if (string.IsNullOrWhiteSpace(tbUserName.Text))
            {
                tbUserName.Text = "Tên đăng nhập";
                tbUserName.ForeColor = Color.Gray;
            }
        }

        private void BtnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(0, 121, 107);
        }

        private void BtnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(0, 150, 136);
        }

        // Sự kiện mới: Show/Hide Password
        private void BtnShowPassword_Click(object sender, EventArgs e)
        {
            _isPasswordVisible = !_isPasswordVisible;
            
            if (_isPasswordVisible)
            {
                tbPassword.UseSystemPasswordChar = false;
                btnShowPassword.Text = "🙈"; // Icon ẩn mật khẩu
            }
            else
            {
                tbPassword.UseSystemPasswordChar = true;
                btnShowPassword.Text = "👁"; // Icon hiện mật khẩu
            }
        }

        // Import để tạo bo góc cho form
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );
    }
}