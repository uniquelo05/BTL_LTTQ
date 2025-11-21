using BTL_LTTQ.BLL.Session;
using BTL_LTTQ.GUI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BTL_LTTQ
{
    public partial class FormMain : Form
    {
        // Dictionary để cache form con
        private readonly Dictionary<string, Form> _formCache = new Dictionary<string, Form>();

        public FormMain()
        {
            InitializeComponent();

            // Load form đầu tiên
            LoadChildForm(typeof(formMonHoc));

            // Gán sự kiện panel click
            panelMonHoc.Click += (s, e) => LoadChildForm(typeof(formMonHoc));
            panelGiangVien.Click += (s, e) => LoadChildForm(typeof(formGV));
            panelPhanCongGiangVien.Click += (s, e) => LoadChildForm(typeof(formPhanCongGV));
            paneLopTC.Click += (s, e) => LoadChildForm(typeof(formLopTC));
            panelDiem.Click += (s, e) => LoadChildForm(typeof(formDiem));
            panelSinhVien.Click += (s, e) => LoadChildForm(typeof(formSV));
            panelSchedule.Click += (s, e) => LoadChildForm(typeof(formLichGiangDay));

            // Hiển thị user đang đăng nhập
            DisplayUserInfo();

            // Kiểm tra quyền và ẩn các chức năng không phù hợp
            ConfigureAccessByRole();
        }

        // ------------------------- LOAD FORM -------------------------
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
                MessageBox.Show("Lỗi tải form: " + ex.Message);
            }
        }

        private void ConfigureAndShowForm(Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            panelMain.Controls.Clear();
            panelMain.Controls.Add(form);

            form.Show();
        }

        // ----------------------- USER INFO --------------------------
        private void DisplayUserInfo()
        {
            lblUserInfo.Text = UserSession.IsLoggedIn
                ? UserSession.Instance.GetDisplayInfo()
                : "Chưa đăng nhập";
        }

private void ConfigureAccessByRole()
{
    if (!UserSession.Instance.IsAdmin())
    {
        // 1. Ẩn các khối chức năng Admin
        panelKhoi.Visible = false;  // Khối Giảng viên
        panelKhoi3.Visible = false; // Khối Phân công

        // 2. Lấy vị trí bắt đầu trám (lấy vị trí cũ của panelKhoi)
        int currentY = panelKhoi.Location.Y; 

        // 3. Dịch chuyển các panel lên trên
        
        // --- Dịch chuyển Lớp Tín Chỉ ---
        panelKhoi4.Location = new System.Drawing.Point(panelKhoi4.Location.X, currentY);
        currentY += panelKhoi4.Height;

        // --- Dịch chuyển Môn Học ---
        panelKhoi5.Location = new System.Drawing.Point(panelKhoi5.Location.X, currentY);
        currentY += panelKhoi5.Height;

        // --- Dịch chuyển Sinh Viên ---
        panelKhoi6.Location = new System.Drawing.Point(panelKhoi6.Location.X, currentY);
        currentY += panelKhoi6.Height;

        // --- Dịch chuyển Lịch Trình (Schedule) - MỚI ---
        panelKhoi7.Location = new System.Drawing.Point(panelKhoi7.Location.X, currentY);
        currentY += panelKhoi7.Height;

        // --- KHẮC PHỤC: Dịch chuyển chỉ trắng dưới cùng (panel4) ---
        // panel4 phải nằm ngay dưới đáy của panelKhoi6
        panel4.Location = new System.Drawing.Point(panel4.Location.X, currentY);
    }
    else
    {
        // Nếu là Admin: Hiện lại và Reset về vị trí gốc (theo Designer)
        panelKhoi.Visible = true;
        panelKhoi3.Visible = true;

        panelKhoi.Location = new System.Drawing.Point(0, 135);
        panelKhoi3.Location = new System.Drawing.Point(0, 197);
        panelKhoi4.Location = new System.Drawing.Point(0, 249);
        panelKhoi5.Location = new System.Drawing.Point(0, 299);
        panelKhoi6.Location = new System.Drawing.Point(0, 350);
        panelKhoi7.Location = new System.Drawing.Point(0, 401);
        
        // Reset lại vị trí chỉ trắng panel4
        panel4.Location = new System.Drawing.Point(0, 452);
    }
}

        private void panelSinhVien_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblUserInfo_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
