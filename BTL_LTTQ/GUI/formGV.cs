using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions; // Dùng cho Validate Email/SĐT
using System.Windows.Forms;
using System.Globalization;
using BTL_LTTQ.BLL;
using BTL_LTTQ.DTO;

namespace BTL_LTTQ
{
    public partial class formGV : Form
    {
        // 1. Khởi tạo BLL và các biến cờ
        private readonly GiangVien_BLL bll = new GiangVien_BLL();
        private bool isLoadingData = false; // Cờ chặn sự kiện khi đang load dữ liệu

        // Cấu hình Placeholder cho ô ngày sinh và tìm kiếm
        private const string placeholderSearch = "Tìm theo tên hoặc mã GV...";
        private const string placeholderNgaySinh = "mm/dd/yyyy";
        private const string dateFormat = "MM/dd/yyyy"; // Định dạng ngày tháng nhập vào

        public formGV()
        {
            InitializeComponent();
            this.Load += formGV_Load; // Đảm bảo sự kiện Load được gắn
        }

        #region 1. Form Load & Cấu hình ban đầu

        private void formGV_Load(object sender, EventArgs e)
        {
            try
            {
                isLoadingData = true; // Bắt đầu load, chặn các sự kiện thay đổi text/index

                // Cấu hình giao diện
                SetupDataGridView();       // Tạo cột cho lưới
                SetupPlaceholders();       // Cài đặt chữ mờ hướng dẫn

                // Load dữ liệu
                LoadComboBoxes();          // Load Khoa vào 2 combobox
                LoadTatCaGiangVien();      // Load danh sách GV lên lưới

                // Reset form nhập liệu về trạng thái sạch
                ClearFields();

                // Gắn các sự kiện (Event) thủ công để dễ quản lý
                AttachEventHandlers();

                isLoadingData = false; // Load xong, mở lại sự kiện
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo form: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AttachEventHandlers()
        {
            // Nhóm Tìm kiếm
            cbbKhoa.SelectedIndexChanged += (s, e) => { if (!isLoadingData) TimKiemTuDong(); };
            txtSearch.TextChanged += (s, e) => {
                if (!isLoadingData && txtSearch.Text != placeholderSearch) TimKiemTuDong();
            };
            btnSearch.Click += (s, e) => TimKiemTuDong();
            btnRefreshSearch.Click += BtnRefreshSearch_Click;

            // Nhóm Chức năng CRUD
            btnThem.Click += BtnAdd_Click;
            btnSua.Click += BtnEdit_Click;
            btnXoa.Click += BtnDelete_Click;
            btnLamMoi.Click += BtnRefresh_Click;
            btnXuatExcel.Click += BtnExportExcel_Click;

            // Sự kiện bảng (Grid)
            dgvGV.CellClick += DgvGV_CellClick;
            dgvGV.CellDoubleClick += DgvGV_CellDoubleClick;
        }

        private void SetupPlaceholders()
        {
            // Placeholder cho ô Tìm kiếm
            txtSearch.Text = placeholderSearch;
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Enter += (s, e) => {
                if (txtSearch.Text == placeholderSearch) { txtSearch.Text = ""; txtSearch.ForeColor = Color.Black; }
            };
            txtSearch.Leave += (s, e) => {
                if (string.IsNullOrWhiteSpace(txtSearch.Text)) { txtSearch.Text = placeholderSearch; txtSearch.ForeColor = Color.Gray; }
            };

            // Placeholder cho ô Ngày sinh
            txtNgaySinh.Text = placeholderNgaySinh;
            txtNgaySinh.ForeColor = Color.Gray;
            txtNgaySinh.Enter += (s, e) => {
                if (txtNgaySinh.Text == placeholderNgaySinh) { txtNgaySinh.Text = ""; txtNgaySinh.ForeColor = Color.Black; }
            };
            txtNgaySinh.Leave += (s, e) => {
                if (string.IsNullOrWhiteSpace(txtNgaySinh.Text)) { txtNgaySinh.Text = placeholderNgaySinh; txtNgaySinh.ForeColor = Color.Gray; }
            };
        }

        #endregion

        #region 2. Cấu hình DataGridView (Quan trọng để hiện dữ liệu)

        private void SetupDataGridView()
        {
            dgvGV.AutoGenerateColumns = false; // Tắt tự động tạo cột để tránh cột rác
            dgvGV.Columns.Clear();

            // Định nghĩa cột thủ công để đảm bảo Map đúng với Database
            AddColumn("MaGV", "Mã GV", "MaGV");
            AddColumn("TenGV", "Họ Tên", "TenGV");
            AddColumn("GioiTinh", "Giới Tính", "GioiTinh");

            // Cột Ngày sinh cần format
            var colDate = AddColumn("NgaySinh", "Ngày Sinh", "NgaySinh");
            colDate.DefaultCellStyle.Format = "dd/MM/yyyy";

            AddColumn("DiaChi", "Địa Chỉ", "DiaChi");
            AddColumn("SDT", "Số ĐT", "SDT");
            AddColumn("Email", "Email", "Email");
            AddColumn("HocHam", "Học Hàm", "HocHam");
            AddColumn("HocVi", "Học Vị", "HocVi");
            AddColumn("MaKhoa", "Mã Khoa", "MaKhoa"); // Cột này có thể ẩn nếu muốn

            dgvGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private DataGridViewTextBoxColumn AddColumn(string name, string header, string dataProperty)
        {
            var col = new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = header,
                DataPropertyName = dataProperty // Phải trùng tên cột trong SQL
            };
            dgvGV.Columns.Add(col);
            return col;
        }

        #endregion

        #region 3. Load Dữ liệu & Combobox

        private void LoadTatCaGiangVien()
        {
            try
            {
                DataTable dt = bll.LoadDanhSachGV();
                dgvGV.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu GV: " + ex.Message);
            }
        }

        private void LoadComboBoxes()
        {
            try
            {
                DataTable dtKhoa = bll.LoadDanhSachKhoa();

                // 1. Combobox Nhập liệu (cbbMaKhoa): Bắt buộc chọn khoa
                cbbMaKhoa.DataSource = dtKhoa.Copy();
                cbbMaKhoa.DisplayMember = "TenKhoa";
                cbbMaKhoa.ValueMember = "MaKhoa";
                cbbMaKhoa.SelectedIndex = -1;

                // 2. Combobox Tìm kiếm (cbbKhoa): Thêm dòng "Tất cả"
                DataTable dtSearch = dtKhoa.Copy();
                DataRow rowAll = dtSearch.NewRow();
                rowAll["MaKhoa"] = DBNull.Value;
                rowAll["TenKhoa"] = "-- Tất cả khoa --";
                dtSearch.Rows.InsertAt(rowAll, 0);

                cbbKhoa.DataSource = dtSearch;
                cbbKhoa.DisplayMember = "TenKhoa";
                cbbKhoa.ValueMember = "MaKhoa";
                cbbKhoa.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách Khoa: " + ex.Message);
            }
        }

        #endregion

        #region 4. Logic Tìm kiếm Tự động (Giống formSV)

        private void TimKiemTuDong()
        {
            if (isLoadingData) return;

            try
            {
                string keyword = txtSearch.Text.Trim();
                if (keyword == placeholderSearch) keyword = "";

                string maKhoa = "";
                if (cbbKhoa.SelectedValue != null && cbbKhoa.SelectedValue.ToString() != "")
                {
                    maKhoa = cbbKhoa.SelectedValue.ToString();
                }

                DataTable dt = bll.TimKiemGV(keyword, maKhoa);
                dgvGV.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private void BtnRefreshSearch_Click(object sender, EventArgs e)
        {
            isLoadingData = true;
            txtSearch.Text = placeholderSearch;
            txtSearch.ForeColor = Color.Gray;
            cbbKhoa.SelectedIndex = 0; // Về tất cả
            isLoadingData = false;

            LoadTatCaGiangVien();
            ClearFields();
        }

        #endregion

        #region 5. Xử lý Logic & Validate (Regex)

        private void ClearFields()
        {
            txtMaGV.Text = ""; txtMaGV.Enabled = true; // Cho phép nhập Mã
            txtHoTen.Text = "";
            txtNgaySinh.Text = placeholderNgaySinh; txtNgaySinh.ForeColor = Color.Gray;
            txtDiaChi.Text = "";
            txtSoDt.Text = "";
            txtEmail.Text = "";
            txtHocHam.Text = "";
            txtHocVi.Text = "";
            cbbMaKhoa.SelectedIndex = -1;
            rdoNam.Checked = true;

            ResetHighlight();
        }

        private GiangVien_DTO GetGiangVienFromGUI()
        {
            GiangVien_DTO gv = new GiangVien_DTO();
            gv.MaGV = txtMaGV.Text.Trim();
            gv.TenGV = txtHoTen.Text.Trim();
            gv.GioiTinh = rdoNam.Checked ? "Nam" : "Nữ";

            // Xử lý ngày sinh từ TextBox
            if (txtNgaySinh.Text != placeholderNgaySinh &&
                DateTime.TryParseExact(txtNgaySinh.Text, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime d))
            {
                gv.NgaySinh = d;
            }
            else
            {
                gv.NgaySinh = null;
            }

            gv.DiaChi = txtDiaChi.Text.Trim();
            gv.SDT = txtSoDt.Text.Trim();
            gv.Email = txtEmail.Text.Trim();
            gv.HocHam = txtHocHam.Text.Trim();
            gv.HocVi = txtHocVi.Text.Trim();
            gv.MaKhoa = cbbMaKhoa.SelectedValue?.ToString();

            return gv;
        }

        private bool ValidateInput()
        {
            // 1. Kiểm tra Mã GV
            if (string.IsNullOrWhiteSpace(txtMaGV.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã giảng viên!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaGV.Focus();
                return false;
            }

            // 2. Kiểm tra Họ tên
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ tên giảng viên!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }

            // 3. Kiểm tra Khoa (MỚI THÊM)
            // Kiểm tra nếu chưa chọn gì (SelectedIndex = -1) hoặc giá trị null
            if (cbbKhoa.SelectedIndex == -1 || cbbKhoa.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Khoa công tác!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbbKhoa.Focus(); // Đưa con trỏ về ô Khoa
                return false;
            }

            // 4. Kiểm tra Ngày sinh
            if (txtNgaySinh.Text == placeholderNgaySinh || string.IsNullOrWhiteSpace(txtNgaySinh.Text))
            {
                MessageBox.Show("Vui lòng nhập Ngày sinh!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgaySinh.Focus();
                return false;
            }
            DateTime dob;
            if (!DateTime.TryParseExact(txtNgaySinh.Text, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dob))
            {
                MessageBox.Show($"Ngày sinh không đúng định dạng {dateFormat}!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgaySinh.Focus();
                return false;
            }
            if (DateTime.Now.Year - dob.Year < 22)
            {
                MessageBox.Show("Giảng viên phải từ 22 tuổi trở lên!", "Lỗi logic", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgaySinh.Focus();
                return false;
            }

            // 5. Kiểm tra Địa chỉ
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập Địa chỉ!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return false;
            }

            // 6. Kiểm tra SĐT
            if (string.IsNullOrWhiteSpace(txtSoDt.Text))
            {
                MessageBox.Show("Vui lòng nhập Số điện thoại!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDt.Focus();
                return false;
            }
            if (!Regex.IsMatch(txtSoDt.Text.Trim(), @"^0\d{9}$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ (phải có 10 số và bắt đầu bằng 0)!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDt.Focus();
                return false;
            }

            // 7. Kiểm tra Email
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập Email!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }
            if (!Regex.IsMatch(txtEmail.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email không đúng định dạng!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            // 8. Kiểm tra Học hàm
            if (string.IsNullOrWhiteSpace(txtHocHam.Text))
            {
                MessageBox.Show("Vui lòng nhập Học hàm (Nếu không có ghi 'Không')!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHocHam.Focus();
                return false;
            }

            // 9. Kiểm tra Học vị
            if (string.IsNullOrWhiteSpace(txtHocVi.Text))
            {
                MessageBox.Show("Vui lòng nhập Học vị!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHocVi.Focus();
                return false;
            }

            return true;
        }

        #endregion

        #region 6. Chức năng CRUD (Thêm, Sửa, Xóa)

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            string maGV = txtMaGV.Text.Trim();

            // 1. Kiểm tra tồn tại trước khi thêm (Logic formSV)
            DataTable check = bll.TimKiemGV(maGV, "");
            if (check != null && check.AsEnumerable().Any(r => r["MaGV"].ToString() == maGV))
            {
                MessageBox.Show($"Mã GV '{maGV}' đã tồn tại trong hệ thống!", "Trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaGV.Focus(); txtMaGV.SelectAll();
                return;
            }

            // 2. Thêm mới
            GiangVien_DTO gv = GetGiangVienFromGUI();
            if (bll.ThemGV(gv))
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Đồng bộ bộ lọc tìm kiếm về Khoa của GV vừa thêm
                if (!string.IsNullOrEmpty(gv.MaKhoa)) cbbKhoa.SelectedValue = gv.MaKhoa;

                TimKiemTuDong();
                HighlightRow(maGV);
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaGV.Text) || txtMaGV.Enabled) // Nếu ô Mã đang Enabled nghĩa là chưa chọn dòng nào
            {
                MessageBox.Show("Vui lòng chọn Giảng viên từ bảng để sửa!", "Cảnh báo");
                return;
            }
            if (!ValidateInput()) return;

            if (MessageBox.Show("Cập nhật thông tin giảng viên?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GiangVien_DTO gv = GetGiangVienFromGUI();
                if (bll.SuaGV(gv))
                {
                    MessageBox.Show("Cập nhật thành công!");
                    TimKiemTuDong();
                    HighlightRow(gv.MaGV);
                }
                else MessageBox.Show("Cập nhật thất bại!");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaGV.Text)) return;

            if (MessageBox.Show($"Xóa GV '{txtMaGV.Text}'?\n(Tài khoản và Lịch dạy liên quan sẽ bị xóa)",
                "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (bll.XoaGV(txtMaGV.Text))
                {
                    MessageBox.Show("Xóa thành công!");
                    TimKiemTuDong();
                    ClearFields();
                }
                else MessageBox.Show("Xóa thất bại!");
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        #endregion

        #region 7. Tương tác Bảng & Highlight (UX)

        private void DgvGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            LoadChiTiet(e.RowIndex);
        }

        private void DgvGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            LoadChiTiet(e.RowIndex);
        }

        private void LoadChiTiet(int index)
        {
            try
            {
                DataGridViewRow row = dgvGV.Rows[index];
                string maGV = row.Cells["MaGV"].Value?.ToString();

                // Đổ dữ liệu lên form
                txtMaGV.Text = maGV;
                txtHoTen.Text = row.Cells["TenGV"].Value?.ToString();

                // Ngày sinh
                if (row.Cells["NgaySinh"].Value != DBNull.Value)
                {
                    txtNgaySinh.Text = Convert.ToDateTime(row.Cells["NgaySinh"].Value).ToString(dateFormat);
                    txtNgaySinh.ForeColor = Color.Black;
                }
                else
                {
                    txtNgaySinh.Text = placeholderNgaySinh;
                    txtNgaySinh.ForeColor = Color.Gray;
                }

                rdoNam.Checked = row.Cells["GioiTinh"].Value?.ToString() == "Nam";
                rdoNu.Checked = !rdoNam.Checked;

                txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString();
                txtSoDt.Text = row.Cells["SDT"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString();
                txtHocHam.Text = row.Cells["HocHam"].Value?.ToString();
                txtHocVi.Text = row.Cells["HocVi"].Value?.ToString();

                // Chọn combobox Khoa
                string maKhoa = row.Cells["MaKhoa"].Value?.ToString();
                if (!string.IsNullOrEmpty(maKhoa)) cbbMaKhoa.SelectedValue = maKhoa;

                // Khóa Mã GV và Highlight dòng
                txtMaGV.Enabled = false;
                HighlightRow(maGV);
            }
            catch { }
        }

        private void HighlightRow(string maGV)
        {
            if (string.IsNullOrEmpty(maGV)) return;
            foreach (DataGridViewRow row in dgvGV.Rows)
            {
                if (row.Cells["MaGV"].Value?.ToString() == maGV)
                {
                    row.Selected = true;
                    row.DefaultCellStyle.BackColor = Color.FromArgb(178, 223, 219); // Màu xanh nhạt (giống formSV)
                    if (row.Index >= 0 && row.Index < dgvGV.Rows.Count)
                        dgvGV.FirstDisplayedScrollingRowIndex = row.Index;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void ResetHighlight()
        {
            foreach (DataGridViewRow row in dgvGV.Rows) row.DefaultCellStyle.BackColor = Color.White;
        }

        #endregion

        #region 8. Xuất Excel (CSV) - Chuẩn formSV

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvGV.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo");
                    return;
                }

                // Lấy tên khoa đang lọc để đặt tên file
                string tenKhoa = cbbKhoa.SelectedIndex > 0
                    ? cbbKhoa.Text.Replace(" - ", "_").Replace(" ", "_")
                    : "TatCa";

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = $"DS_GiangVien_{tenKhoa}_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("DANH SÁCH GIẢNG VIÊN");
                    sb.AppendLine($"Khoa: {tenKhoa}");
                    sb.AppendLine($"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                    sb.AppendLine($"Tổng số: {dgvGV.Rows.Count}");
                    sb.AppendLine();

                    // Header
                    var headers = dgvGV.Columns.Cast<DataGridViewColumn>()
                        .Where(c => c.Visible)
                        .Select(c => EscapeCSV(c.HeaderText));
                    sb.AppendLine(string.Join(",", headers));

                    // Data Rows
                    foreach (DataGridViewRow row in dgvGV.Rows)
                    {
                        if (row.IsNewRow) continue;
                        var cells = dgvGV.Columns.Cast<DataGridViewColumn>()
                            .Where(c => c.Visible)
                            .Select(c =>
                            {
                                var v = row.Cells[c.Index].Value;
                                if (v is DateTime dt) return EscapeCSV(dt.ToString("dd/MM/yyyy"));
                                return EscapeCSV(v?.ToString() ?? "");
                            });
                        sb.AppendLine(string.Join(",", cells));
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);

                    if (MessageBox.Show("Xuất file thành công! Bạn có muốn mở ngay không?",
                        "Thành công", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(sfd.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất file: " + ex.Message);
            }
        }

        private string EscapeCSV(string value)
        {
            if (string.IsNullOrEmpty(value)) return "\"\"";
            if (value.Contains(",") || value.Contains("\"") || value.Contains("\n"))
            {
                value = value.Replace("\"", "\"\"");
                return $"\"{value}\"";
            }
            return value;
        }

        #endregion
    }
}