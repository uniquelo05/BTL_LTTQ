using BTL_LTTQ.BLL.Session;
using BTL_LTTQ.GUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BTL_LTTQ
{
    public partial class FormMain : Form
    {
        // Dictionary để cache form con
        private readonly Dictionary<string, Form> _formCache = new Dictionary<string, Form>();
        private Button _currentActiveButton = null;

        public FormMain()
        {
            InitializeComponent();
            InitializeForm();
            
            // Quan trọng: Ngăn form đóng khi user click X
            this.FormClosing += FormMain_FormClosing;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Nếu session đã bị clear (đang trong quá trình logout), cho phép đóng
            if (!UserSession.IsLoggedIn)
            {
                return;
            }

            // Nếu user click X, hỏi xác nhận giống như Logout
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn đăng xuất?",
                    "Xác nhận đăng xuất",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    // Đăng xuất
                    PerformLogout();
                    e.Cancel = true; // Hủy việc đóng form
                }
                else
                {
                    // Không đăng xuất → Cancel việc đóng form
                    e.Cancel = true;
                }
            }
        }

        private void InitializeForm()
        {
            // Hiển thị thông tin user
            DisplayUserInfo();

            // Cấu hình quyền truy cập
            ConfigureAccessByRole();

            // Thiết lập hover effects cho menu
            SetupMenuHoverEffects();

            // Load form mặc định
            LoadChildForm(typeof(formMonHoc));
            SetActiveButton(btnMonHoc);
        }

        #region Menu Hover Effects

        private void SetupMenuHoverEffects()
        {
            List<Button> menuButtons = new List<Button>
            {
                btnGiangVien, btnDiem, btnPhanCong, btnLopTC,
                btnMonHoc, btnSinhVien, btnLichGiangDay
            };

            foreach (Button btn in menuButtons)
            {
                // ✅ KHÔNG CẦN THÊM GÌ - MouseOverBackColor đã có sẵn trong Designer
                // Chỉ cần handle Paint event để vẽ viền trái
                btn.Paint += MenuButton_Paint;
            }
        }

        private void MenuButton_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            
            // ✅ VẼ VIỀN TRÁI CHO BUTTON ACTIVE
            if (btn == _currentActiveButton)
            {
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(52, 152, 219)))
                {
                    e.Graphics.FillRectangle(brush, 0, 0, 4, btn.Height);
                }
            }
        }

        private void MenuButton_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            
            // Nếu không phải button đang active thì highlight
            if (btn != _currentActiveButton)
            {
                btn.BackColor = Color.FromArgb(0, 121, 107); // Màu hover
                btn.ForeColor = Color.White;
            }
        }

        private void MenuButton_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            
            // Nếu không phải button đang active thì về transparent
            if (btn != _currentActiveButton)
            {
                btn.BackColor = Color.Transparent;
                btn.ForeColor = Color.White;
            }
        }

        #endregion

        #region Load Child Forms

        private void LoadChildForm(Type formType)
        {
            try
            {
                Form instance;

                // Kiểm tra có nằm trong cache chưa
                if (!_formCache.ContainsKey(formType.FullName))
                {
                    instance = (Form)Activator.CreateInstance(formType);
                    _formCache[formType.FullName] = instance;
                }
                else
                {
                    instance = _formCache[formType.FullName];
                }

                ConfigureAndShowForm(instance);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải form: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureAndShowForm(Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(form);

            form.Show();
        }

        #endregion

        #region Menu Navigation Events

        private void btnGiangVien_Click(object sender, EventArgs e)
        {
            LoadChildForm(typeof(formGV));
            SetActiveButton(btnGiangVien);
        }

        private void btnDiem_Click(object sender, EventArgs e)
        {
            LoadChildForm(typeof(formDiem));
            SetActiveButton(btnDiem);
        }

        private void btnPhanCong_Click(object sender, EventArgs e)
        {
            LoadChildForm(typeof(formPhanCongGV));
            SetActiveButton(btnPhanCong);
        }

        private void btnLopTC_Click(object sender, EventArgs e)
        {
            LoadChildForm(typeof(formLopTC));
            SetActiveButton(btnLopTC);
        }

        private void btnMonHoc_Click(object sender, EventArgs e)
        {
            LoadChildForm(typeof(formMonHoc));
            SetActiveButton(btnMonHoc);
        }

        private void btnSinhVien_Click(object sender, EventArgs e)
        {
            LoadChildForm(typeof(formSV));
            SetActiveButton(btnSinhVien);
        }

        private void btnLichGiangDay_Click(object sender, EventArgs e)
        {
            LoadChildForm(typeof(formLichGiangDay));
            SetActiveButton(btnLichGiangDay);
        }

        #endregion

        #region Window Control Events

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                PerformLogout();
            }
        }

        private void PerformLogout()
        {
            // Xóa session
            UserSession.ClearSession();
            
            // Xóa cache forms để giải phóng bộ nhớ
            foreach (var form in _formCache.Values)
            {
                form.Dispose();
            }
            _formCache.Clear();
            
            // Ẩn FormMain (KHÔNG đóng)
            this.Hide();

            // Mở lại form Login
            Login loginForm = new Login();
            
            loginForm.FormClosed += (s, args) =>
            {
                if (UserSession.IsLoggedIn)
                {
                    // Login thành công → Show lại FormMain
                    InitializeForm();
                    this.Show();
                }
                else
                {
                    // Đóng Login mà không đăng nhập → Thoát app
                    Application.Exit();
                }
            };
            
            loginForm.Show();
        }

        #endregion

        #region UI Helper Methods

        private void SetActiveButton(Button activeButton)
        {
            // Reset button trước
            if (_currentActiveButton != null)
            {
                _currentActiveButton.BackColor = Color.Transparent;
                _currentActiveButton.Invalidate(); // Redraw
            }

            // Set active
            activeButton.BackColor = Color.FromArgb(44, 62, 80);
            _currentActiveButton = activeButton;
            activeButton.Invalidate(); // Redraw để vẽ viền trái
        }

        private void DisplayUserInfo()
        {
            if (UserSession.IsLoggedIn)
            {
                lblUserName.Text = UserSession.Instance.Username;
                lblUserRole.Text = UserSession.Instance.IsAdmin() ? "Quản trị viên" : "Giảng viên";
            }
            else
            {
                lblUserName.Text = "Chưa đăng nhập";
                lblUserRole.Text = "";
            }
        }

        private void ConfigureAccessByRole()
        {
            if (!UserSession.Instance.IsAdmin())
            {
                // Ẩn các menu chỉ dành cho Admin
                btnGiangVien.Visible = false;
                btnPhanCong.Visible = false;
                btnLopTC.Visible = false;
                btnMonHoc.Visible = false;
            }
        }

        #endregion
    }
}