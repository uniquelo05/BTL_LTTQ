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

        public Login()
        {
            InitializeComponent();
            _loginBLL = new LoginBLL();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = tbUserName.Text.Trim();
            string password = tbPassword.Text;

            var result = _loginBLL.ProcessLogin(username, password);

            if (!result.Success)
            {
                MessageBox.Show(result.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Đăng nhập thành công
            // MessageBox.Show(result.Message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Mở FormMain
            FormMain mainForm = new FormMain();
            mainForm.Show();

            // Ẩn Form Login
            this.Hide();
        }


        private void Login_Load(object sender, EventArgs e)
        {
            // Thiết lập các sự kiện
            SetupEvents();

            // Thiết lập placeholder text
            SetupPlaceholderText();
        }

        private void SetupEvents()
        {
            // Sự kiện click button đăng nhập
            btnLogin.Click += BtnLogin_Click;

            // Sự kiện click label đóng
            lbClose.Click += LbClose_Click;

            // Sự kiện Enter để đăng nhập
            tbPassword.KeyPress += TbPassword_KeyPress;

            // Sự kiện focus textbox để xóa placeholder
            tbUserName.Enter += TbUserName_Enter;
            tbUserName.Leave += TbUserName_Leave;
        }
private void SetupPlaceholderText()
        {
            // Thiết lập màu sắc placeholder
            if (tbUserName.Text == "User name")
            {
                tbUserName.ForeColor = Color.Gray;
            }
        }
                private void LbClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void TbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Nhấn Enter để đăng nhập
            if (e.KeyChar == (char)Keys.Enter)
            {
                BtnLogin_Click(sender, e);
            }
        }
                private void TbUserName_Enter(object sender, EventArgs e)
        {
            // Xóa placeholder text khi focus
            if (tbUserName.Text == "User name")
            {
                tbUserName.Text = "";
                tbUserName.ForeColor = Color.White;
            }
        }
                private void TbUserName_Leave(object sender, EventArgs e)
        {
            // Hiện lại placeholder nếu rỗng
            if (string.IsNullOrEmpty(tbUserName.Text))
            {
                tbUserName.Text = "User name";
                tbUserName.ForeColor = Color.Gray;
            }
        }
                private void tbUserName_TextChanged(object sender, EventArgs e)
        {
            // Xử lý khi text thay đổi - có thể để trống hoặc thêm logic validation
        }
    }
}