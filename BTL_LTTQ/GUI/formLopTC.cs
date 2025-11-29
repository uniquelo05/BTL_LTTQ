using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BTL_LTTQ.BLL;
using BTL_LTTQ.DTO;
using System.IO;
using System.Text;
using System.Globalization;

namespace BTL_LTTQ
{
    public partial class formLopTC : Form
    {
        private readonly LopTC_BLL bll = new LopTC_BLL();

        // Cờ kiểm soát để không chạy tìm kiếm khi form đang load
        private bool isLoadingData = false;

        private const string placeholderMaLop = "nhập mã lớp";

        public formLopTC()
        {
            InitializeComponent();
            this.Load += formLopTC_Load;
        }

        #region Form Load & Cấu hình

        private void formLopTC_Load(object sender, EventArgs e)
        {
            try
            {
                isLoadingData = true; // Bắt đầu load dữ liệu -> Chặn tìm kiếm tự động

                dgvSV.AutoGenerateColumns = false;
                SetupDataGridViewColumns();

                SetPlaceholderText();
                LoadComboBoxes();      // Load Khoa/Môn
                LoadDataGridView();    // Load danh sách Lớp TC

                ClearFields();
                AttachEventHandlers(); // Gắn sự kiện sau khi load xong

                isLoadingData = false; // Load xong -> Cho phép tìm kiếm tự động
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo form: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDataGridViewColumns()
        {
            dgvSV.Columns.Clear();

            AddColumn("MaLop", "Mã Lớp", "MaLop");
            AddColumn("MaMH", "Mã Môn", "MaMH");
            AddColumn("TenMH", "Tên Môn", "TenMH", true); // Fill
            AddColumn("MaKhoa", "Khoa", "MaKhoa");
            AddColumn("HocKy", "Học kỳ", "HocKy");
            AddColumn("NamHoc", "Năm học", "NamHoc");
            AddColumn("TinhTrangLop", "Tình Trạng", "TinhTrangLop");
        }

        private void AddColumn(string name, string header, string dataProp, bool isFill = false)
        {
            var col = new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = header,
                DataPropertyName = dataProp,
                AutoSizeMode = isFill ? DataGridViewAutoSizeColumnMode.Fill : DataGridViewAutoSizeColumnMode.AllCells
            };
            dgvSV.Columns.Add(col);
        }

        private void AttachEventHandlers()
        {
            // CRUD
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnXuatExcel.Click += btnXuatExcel_Click;

            // Grid Interaction
            dgvSV.CellClick += dgvSV_CellClick;
            dgvSV.CellFormatting += dgvSV_CellFormatting;

            // --- TÌM KIẾM TỰ ĐỘNG (Auto Search) ---
            // 1. Gõ chữ vào ô Mã lớp -> Tìm ngay
            txtTimKiemTheoTen.TextChanged += (s, e) => {
                // Nếu đang hiện placeholder thì không tìm
                if (!isLoadingData && txtTimKiemTheoTen.Text != placeholderMaLop)
                    TimKiemTuDong();
            };

            // 2. Gõ chữ vào ô Năm học -> Tìm ngay
            txtTimTheoNam.TextChanged += (s, e) => {
                if (!isLoadingData) TimKiemTuDong();
            };

            // 3. Chọn Khoa -> Lọc ngay
            cbbTimTheoKhoa.SelectedIndexChanged += (s, e) => {
                if (!isLoadingData) TimKiemTuDong();
            };

            // 4. Placeholder logic
            txtTimKiemTheoTen.Enter += txtTimKiemTheoTen_Enter;
            txtTimKiemTheoTen.Leave += txtTimKiemTheoTen_Leave;

            // 5. Logic chọn khoa khi nhập liệu
            cbbMaKhoa.SelectedIndexChanged += cbbMaKhoa_SelectedIndexChanged;
        }

        private void SetPlaceholderText()
        {
            txtTimKiemTheoTen.Text = placeholderMaLop;
            txtTimKiemTheoTen.ForeColor = Color.Gray;
        }

        #endregion

        #region Load Data Helper

        private void LoadDataGridView()
        {
            try
            {
                DataTable dt = bll.LoadDanhSachLTC();
                dgvSV.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi");
            }
        }

        private void LoadComboBoxes()
        {
            try
            {
                DataTable dtKhoa = bll.LoadDanhSachKhoa();

                // 1. Cbb Nhập liệu (Bắt buộc chọn)
                cbbMaKhoa.DataSource = dtKhoa.Copy();
                cbbMaKhoa.DisplayMember = "TenKhoa";
                cbbMaKhoa.ValueMember = "MaKhoa";
                cbbMaKhoa.SelectedIndex = -1;

                // 2. Cbb Tìm kiếm (Có dòng Tất cả)
                DataTable dtKhoaSearch = dtKhoa.Copy();
                DataRow rowAll = dtKhoaSearch.NewRow();
                rowAll["MaKhoa"] = "";
                rowAll["TenKhoa"] = "--- Tất cả khoa ---";
                dtKhoaSearch.Rows.InsertAt(rowAll, 0);

                cbbTimTheoKhoa.DataSource = dtKhoaSearch;
                cbbTimTheoKhoa.DisplayMember = "TenKhoa";
                cbbTimTheoKhoa.ValueMember = "MaKhoa";
                cbbTimTheoKhoa.SelectedIndex = 0;

                LoadMonHocComboBox(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách Khoa: " + ex.Message);
            }
        }

        private void LoadMonHocComboBox(string maKhoa)
        {
            try
            {
                DataTable dtMonHoc = bll.LoadDanhSachMonHoc(maKhoa);
                cbbMaMon.DataSource = dtMonHoc;
                cbbMaMon.DisplayMember = "TenMH";
                cbbMaMon.ValueMember = "MaMH";
                cbbMaMon.SelectedIndex = -1;
            }
            catch { }
        }

        #endregion

        #region TÌM KIẾM TỰ ĐỘNG (Logic mới)

        private void TimKiemTuDong()
        {
            if (isLoadingData) return;

            try
            {
                // Lấy từ khóa Mã lớp (bỏ qua placeholder)
                string tuKhoa = txtTimKiemTheoTen.Text.Trim();
                if (tuKhoa == placeholderMaLop) tuKhoa = "";

                // Lấy Năm học
                string namHocTim = txtTimTheoNam.Text.Trim();

                // Lấy Mã khoa
                string maKhoaTim = "";
                if (cbbTimTheoKhoa.SelectedValue != null && cbbTimTheoKhoa.SelectedValue.ToString() != "")
                {
                    maKhoaTim = cbbTimTheoKhoa.SelectedValue.ToString();
                }

                // Gọi BLL tìm kiếm
                DataTable dt = bll.TimKiemLTC(tuKhoa, namHocTim, maKhoaTim);
                dgvSV.DataSource = dt;
            }
            catch (Exception ex)
            {
                // Không hiện MessageBox lỗi liên tục khi gõ phím để tránh khó chịu
                // Console.WriteLine(ex.Message); 
            }
        }

        // Nút Tìm kiếm (nếu vẫn muốn giữ nút này)
        private void btnSearch_Click(object sender, EventArgs e)
        {
            TimKiemTuDong();
        }

        // Nút Tất cả (Reset bộ lọc)
        private void btnRefreshSearch_Click(object sender, EventArgs e)
        {
            isLoadingData = true; // Chặn sự kiện text change tạm thời

            txtTimKiemTheoTen.Text = placeholderMaLop;
            txtTimKiemTheoTen.ForeColor = Color.Gray;
            txtTimTheoNam.Text = "";
            cbbTimTheoKhoa.SelectedIndex = 0; // Về "Tất cả khoa"

            isLoadingData = false;

            LoadDataGridView(); // Load lại toàn bộ
        }

        #endregion

        #region Validate & Nhập liệu

        private void ClearFields()
        {
            txtMaLop.Text = "";
            numHocKy.Value = 1;
            txtNamHoc.Text = "";
            cbbMaKhoa.SelectedIndex = -1;
            cbbMaMon.SelectedIndex = -1;
            txtMaLop.ReadOnly = false;
            txtMaLop.Focus();
        }

        private LopTC_DTO GetLopTinChiFromGUI()
        {
            LopTC_DTO ltc = new LopTC_DTO();
            ltc.MaLop = txtMaLop.Text.Trim();
            ltc.MaMH = cbbMaMon.SelectedValue?.ToString();
            ltc.HocKy = (int)numHocKy.Value;

            if (int.TryParse(txtNamHoc.Text, out int namHoc))
                ltc.NamHoc = namHoc;
            else
                ltc.NamHoc = null;

            ltc.TinhTrangLop = false;
            return ltc;
        }

        #endregion

        #region CRUD (Thêm, Sửa, Xóa) - Đã Validate & Check Trùng

        private void btnThem_Click(object sender, EventArgs e)
        {
            // 1. VALIDATE DỮ LIỆU
            if (string.IsNullOrWhiteSpace(txtMaLop.Text)) { MessageBox.Show("Mã lớp trống!", "Cảnh báo"); txtMaLop.Focus(); return; }
            if (cbbMaKhoa.SelectedIndex == -1) { MessageBox.Show("Chưa chọn Khoa!", "Cảnh báo"); cbbMaKhoa.Focus(); return; }
            if (cbbMaMon.SelectedIndex == -1) { MessageBox.Show("Chưa chọn Môn!", "Cảnh báo"); cbbMaMon.Focus(); return; }
            if (string.IsNullOrWhiteSpace(txtNamHoc.Text)) { MessageBox.Show("Năm học trống!", "Cảnh báo"); txtNamHoc.Focus(); return; }

            if (!int.TryParse(txtNamHoc.Text.Trim(), out int _))
            {
                MessageBox.Show("Năm học phải là số (VD: 2025)!", "Lỗi nhập liệu");
                txtNamHoc.Focus(); txtNamHoc.SelectAll(); return;
            }

            // 2. CHECK TRÙNG MÃ
            string maLop = txtMaLop.Text.Trim();
            DataTable checkDt = bll.TimKiemLTC(maLop, "", "");
            if (checkDt != null && checkDt.AsEnumerable().Any(r => r["MaLop"].ToString().ToLower() == maLop.ToLower()))
            {
                MessageBox.Show($"Mã lớp '{maLop}' đã tồn tại!", "Trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLop.Focus(); txtMaLop.SelectAll(); return;
            }

            // 3. THÊM
            LopTC_DTO ltc = GetLopTinChiFromGUI();
            if (bll.ThemLTC(ltc))
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGridView();
                ClearFields();
            }
            else MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaLop.Text) || !txtMaLop.ReadOnly)
            {
                MessageBox.Show("Chọn lớp để sửa!", "Cảnh báo"); return;
            }

            if (MessageBox.Show("Cập nhật thông tin lớp?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                LopTC_DTO ltc = GetLopTinChiFromGUI();
                if (bll.SuaLTC(ltc))
                {
                    MessageBox.Show("Cập nhật thành công!");
                    LoadDataGridView();
                    ClearFields();
                }
                else MessageBox.Show("Cập nhật thất bại!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaLop.Text) || !txtMaLop.ReadOnly)
            {
                MessageBox.Show("Chọn lớp để xóa!", "Cảnh báo"); return;
            }

            if (MessageBox.Show($"Xóa lớp {txtMaLop.Text}? Dữ liệu phân công và điểm sẽ mất!",
                "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (bll.XoaLTC(txtMaLop.Text))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadDataGridView();
                    ClearFields();
                }
                else MessageBox.Show("Xóa thất bại!");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadDataGridView();
        }

        #endregion

        #region Placeholder Logic

        private void txtTimKiemTheoTen_Enter(object sender, EventArgs e)
        {
            if (txtTimKiemTheoTen.Text == placeholderMaLop)
            {
                txtTimKiemTheoTen.Text = "";
                txtTimKiemTheoTen.ForeColor = Color.Black;
            }
        }

        private void txtTimKiemTheoTen_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiemTheoTen.Text))
            {
                txtTimKiemTheoTen.Text = placeholderMaLop;
                txtTimKiemTheoTen.ForeColor = Color.Gray;
            }
        }

        private void cbbMaKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbMaKhoa.SelectedValue != null)
                LoadMonHocComboBox(cbbMaKhoa.SelectedValue.ToString());
            else
                LoadMonHocComboBox(null);
        }

        #endregion

        #region Grid Interaction & Excel

        private void dgvSV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvSV.Columns[e.ColumnIndex].Name == "TinhTrangLop")
            {
                bool isAssigned = false;
                if (e.Value is bool b) isAssigned = b;
                else if (e.Value is int i) isAssigned = i == 1;

                e.Value = isAssigned ? "Đã phân công" : "Chưa phân công";
                e.FormattingApplied = true;
            }
        }

        private void dgvSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvSV.Rows[e.RowIndex];
            txtMaLop.Text = row.Cells["MaLop"].Value?.ToString();
            txtNamHoc.Text = row.Cells["NamHoc"].Value?.ToString();

            if (decimal.TryParse(row.Cells["HocKy"].Value?.ToString(), out decimal hk))
                numHocKy.Value = hk;

            string maKhoa = row.Cells["MaKhoa"].Value?.ToString();
            if (!string.IsNullOrEmpty(maKhoa)) cbbMaKhoa.SelectedValue = maKhoa;

            string maMH = row.Cells["MaMH"].Value?.ToString();
            if (!string.IsNullOrEmpty(maMH)) cbbMaMon.SelectedValue = maMH;

            txtMaLop.ReadOnly = true; // Khóa mã lớp
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvSV.Rows.Count == 0) { MessageBox.Show("Không có dữ liệu!"); return; }

            SaveFileDialog sfd = new SaveFileDialog { Filter = "CSV (*.csv)|*.csv", FileName = $"DS_LopTC_{DateTime.Now:yyyyMMdd}.csv" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("DANH SÁCH LỚP TÍN CHỈ");
                // Header
                sb.AppendLine(string.Join(",", dgvSV.Columns.Cast<DataGridViewColumn>().Where(c => c.Visible).Select(c => "\"" + c.HeaderText + "\"")));
                // Data
                foreach (DataGridViewRow row in dgvSV.Rows)
                {
                    if (row.IsNewRow) continue;
                    var cells = dgvSV.Columns.Cast<DataGridViewColumn>().Where(c => c.Visible).Select(c => "\"" + (c.Name == "TinhTrangLop" ? row.Cells[c.Index].FormattedValue : row.Cells[c.Index].Value) + "\"");
                    sb.AppendLine(string.Join(",", cells));
                }
                File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                if (MessageBox.Show("Xuất xong! Mở file không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    System.Diagnostics.Process.Start(sfd.FileName);
            }
        }

        #endregion
    }
}