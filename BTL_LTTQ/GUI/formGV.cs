// Giả sử file này nằm ở BTL_LTTQ/GUI/formGV.cs
// Nếu nó ở gốc, hãy xóa ".GUI" khỏi namespace
// và cập nhật using cho BLL và DTO
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using BTL_LTTQ.BLL;
using BTL_LTTQ.DTO;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Linq;

namespace BTL_LTTQ
{
    public partial class formGV : Form
    {
        private readonly GiangVien_BLL bll = new GiangVien_BLL();
        private const string placeholderSearch = "Tìm theo tên hoặc mã GV...";
        private const string placeholderNgaySinh = "mm/dd/yyyy";
        private const string dateFormat = "MM/dd/yyyy";

        public formGV()
        {
            InitializeComponent();
            
            // ✅ Gắn sự kiện Load
            this.Load += formGV_Load;
        }

        #region Form Load

        private void formGV_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDataGridView();
                LoadComboBoxes();
                AttachEventHandlers();
                SetupPlaceholders();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo form: {ex.Message}\n\n{ex.StackTrace}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AttachEventHandlers()
        {
            btnThem.Click += BtnAdd_Click;
            btnSua.Click += BtnEdit_Click;
            btnXoa.Click += BtnDelete_Click;  // ✅ GIỮ NGUYÊN
            btnLamMoi.Click += BtnRefresh_Click;
            btnSearch.Click += BtnSearch_Click;
            btnRefreshSearch.Click += BtnRefreshSearch_Click;
            btnXuatExcel.Click += BtnExportExcel_Click;
            dgvGV.CellClick += DgvGV_CellClick;
            
            // Placeholder events
            txtSearch.Enter += (s, e) =>
            {
                if (txtSearch.Text == placeholderSearch && txtSearch.ForeColor == Color.Gray)
                {
                    txtSearch.Text = "";
                    txtSearch.ForeColor = Color.Black;
                }
            };
            
            txtSearch.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    txtSearch.Text = placeholderSearch;
                    txtSearch.ForeColor = Color.Gray;
                }
            };

            txtNgaySinh.Enter += (s, e) =>
            {
                if (txtNgaySinh.Text == placeholderNgaySinh && txtNgaySinh.ForeColor == Color.Gray)
                {
                    txtNgaySinh.Text = "";
                    txtNgaySinh.ForeColor = Color.Black;
                }
            };

            txtNgaySinh.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtNgaySinh.Text))
                {
                    txtNgaySinh.Text = placeholderNgaySinh;
                    txtNgaySinh.ForeColor = Color.Gray;
                }
            };
        }

        private void SetupPlaceholders()
        {
            txtSearch.Text = placeholderSearch;
            txtSearch.ForeColor = Color.Gray;
            txtNgaySinh.Text = placeholderNgaySinh;
            txtNgaySinh.ForeColor = Color.Gray;
        }

        #endregion

        #region Load Data

        private void LoadDataGridView()
        {
            try
            {
                DataTable dt = bll.LoadDanhSachGV();
                dgvGV.DataSource = dt;

                // Tùy chỉnh tên cột
                if (dgvGV.Columns["MaGV"] != null) dgvGV.Columns["MaGV"].HeaderText = "Mã GV";
                if (dgvGV.Columns["TenGV"] != null) dgvGV.Columns["TenGV"].HeaderText = "Họ Tên";
                if (dgvGV.Columns["GioiTinh"] != null) dgvGV.Columns["GioiTinh"].HeaderText = "Giới Tính";
                if (dgvGV.Columns["NgaySinh"] != null) dgvGV.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
                if (dgvGV.Columns["DiaChi"] != null) dgvGV.Columns["DiaChi"].HeaderText = "Địa Chỉ";
                if (dgvGV.Columns["SDT"] != null) dgvGV.Columns["SDT"].HeaderText = "Số ĐT";
                if (dgvGV.Columns["Email"] != null) dgvGV.Columns["Email"].HeaderText = "Email";
                if (dgvGV.Columns["HocHam"] != null) dgvGV.Columns["HocHam"].HeaderText = "Học Hàm";
                if (dgvGV.Columns["HocVi"] != null) dgvGV.Columns["HocVi"].HeaderText = "Học Vị";
                if (dgvGV.Columns["MaKhoa"] != null) dgvGV.Columns["MaKhoa"].HeaderText = "Mã Khoa";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadComboBoxes()
        {
            try
            {
                DataTable dtKhoa = bll.LoadDanhSachKhoa();

                // ComboBox chi tiết (cbbMaKhoa)
                cbbMaKhoa.DataSource = dtKhoa.Copy();
                cbbMaKhoa.DisplayMember = "TenKhoa";
                cbbMaKhoa.ValueMember = "MaKhoa";
                cbbMaKhoa.SelectedIndex = -1;

                // ComboBox tìm kiếm (cbbKhoa)
                DataTable dtKhoaSearch = dtKhoa.Copy();
                DataRow allRow = dtKhoaSearch.NewRow();
                allRow["MaKhoa"] = "";
                allRow["TenKhoa"] = "-- Tất cả khoa --";
                dtKhoaSearch.Rows.InsertAt(allRow, 0);

                cbbKhoa.DataSource = dtKhoaSearch;
                cbbKhoa.DisplayMember = "TenKhoa";
                cbbKhoa.ValueMember = "MaKhoa";
                cbbKhoa.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách khoa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Helper Methods

        private void ClearFields()
        {
            txtMaGV.Text = "";
            txtHoTen.Text = "";
            txtNgaySinh.Text = placeholderNgaySinh;
            txtNgaySinh.ForeColor = Color.Gray;
            txtDiaChi.Text = "";
            txtSoDt.Text = "";
            txtEmail.Text = "";
            txtHocHam.Text = "";
            txtHocVi.Text = "";
            cbbMaKhoa.SelectedIndex = -1;
            rdoNam.Checked = true;
            rdoNu.Checked = false;
            txtMaGV.ReadOnly = false;
            txtMaGV.Focus();
        }

        private GiangVien_DTO GetGiangVienFromGUI()
        {
            GiangVien_DTO gv = new GiangVien_DTO();
            gv.MaGV = txtMaGV.Text.Trim();
            gv.TenGV = txtHoTen.Text.Trim();
            gv.GioiTinh = rdoNam.Checked ? "Nam" : (rdoNu.Checked ? "Nữ" : null);

            DateTime ngaySinh;
            if (DateTime.TryParseExact(txtNgaySinh.Text, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out ngaySinh))
            {
                gv.NgaySinh = ngaySinh;
            }
            else
            {
                gv.NgaySinh = null;
            }

            gv.DiaChi = string.IsNullOrWhiteSpace(txtDiaChi.Text) ? null : txtDiaChi.Text.Trim();
            gv.SDT = string.IsNullOrWhiteSpace(txtSoDt.Text) ? null : txtSoDt.Text.Trim();
            gv.Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim();
            gv.HocHam = string.IsNullOrWhiteSpace(txtHocHam.Text) ? null : txtHocHam.Text.Trim();
            gv.HocVi = string.IsNullOrWhiteSpace(txtHocVi.Text) ? null : txtHocVi.Text.Trim();
            gv.MaKhoa = cbbMaKhoa.SelectedValue?.ToString();

            return gv;
        }

        #endregion

        #region CRUD Events

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaGV.Text))
            {
                MessageBox.Show("Mã giảng viên không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaGV.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Tên giảng viên không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }
            if (cbbMaKhoa.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn khoa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbbMaKhoa.Focus();
                return;
            }

            GiangVien_DTO gv = GetGiangVienFromGUI();

            try
            {
                if (bll.ThemGV(gv))
                {
                    MessageBox.Show("Thêm giảng viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Thêm giảng viên thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show("Mã giảng viên đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaGV.Text) || !txtMaGV.ReadOnly)
            {
                MessageBox.Show("Vui lòng chọn giảng viên để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            GiangVien_DTO gv = GetGiangVienFromGUI();

            try
            {
                if (bll.SuaGV(gv))
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaGV.Text) || !txtMaGV.ReadOnly)
            {
                MessageBox.Show("Vui lòng chọn giảng viên để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa giảng viên '{txtHoTen.Text}' (Mã: {txtMaGV.Text})?\n\n" +
                "CẢNH BÁO: Tài khoản và phân công liên quan cũng sẽ bị xóa!",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    if (bll.XoaGV(txtMaGV.Text))
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataGridView();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadDataGridView();
            
            txtSearch.Text = placeholderSearch;
            txtSearch.ForeColor = Color.Gray;
            cbbKhoa.SelectedIndex = 0;
        }

        #endregion

        #region Search Events

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string keyword = (txtSearch.Text == placeholderSearch) ? "" : txtSearch.Text;
            string maKhoa = cbbKhoa.SelectedValue?.ToString();

            try
            {
                DataTable dt = bll.TimKiemGV(keyword, maKhoa);
                dgvGV.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRefreshSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = placeholderSearch;
            txtSearch.ForeColor = Color.Gray;
            cbbKhoa.SelectedIndex = 0;
            LoadDataGridView();
        }

        #endregion

        #region Export Excel

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvGV.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Files (*.csv)|*.csv|All Files (*.*)|*.*";
                sfd.FileName = $"DanhSach_GiangVien_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                sfd.Title = "Lưu file Excel";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExportToCSV(sfd.FileName);
                    MessageBox.Show($"✅ Xuất file thành công!\n\nĐường dẫn: {sfd.FileName}",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportToCSV(string filePath)
        {
            StringBuilder sb = new StringBuilder();

            using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                sb.AppendLine("DANH SÁCH GIẢNG VIÊN");
                sb.AppendLine($"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                sb.AppendLine();

                var headers = dgvGV.Columns.Cast<DataGridViewColumn>()
                    .Where(c => c.Visible)
                    .Select(c => EscapeCSV(c.HeaderText));
                sb.AppendLine(string.Join(",", headers));

                foreach (DataGridViewRow row in dgvGV.Rows)
                {
                    if (row.IsNewRow) continue;

                    var cells = dgvGV.Columns.Cast<DataGridViewColumn>()
                        .Where(c => c.Visible)
                        .Select(c =>
                        {
                            var cellValue = row.Cells[c.Index].Value;
                            if (cellValue is DateTime dt)
                                return EscapeCSV(dt.ToString("MM/dd/yyyy"));
                            return EscapeCSV(cellValue?.ToString() ?? "");
                        });

                    sb.AppendLine(string.Join(",", cells));
                }

                sw.Write(sb.ToString());
            }
        }

        private string EscapeCSV(string value)
        {
            if (string.IsNullOrEmpty(value))
                return "\"\"";

            if (value.Contains(",") || value.Contains("\"") || value.Contains("\n"))
            {
                value = value.Replace("\"", "\"\"");
                return $"\"{value}\"";
            }

            return value;
        }

        #endregion

        #region DataGridView Events

        private void DgvGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvGV.Rows[e.RowIndex];

                    txtMaGV.Text = row.Cells["MaGV"].Value?.ToString();
                    txtHoTen.Text = row.Cells["TenGV"].Value?.ToString();

                    string gioiTinh = row.Cells["GioiTinh"].Value?.ToString();
                    rdoNu.Checked = (gioiTinh == "Nữ");
                    rdoNam.Checked = (gioiTinh != "Nữ");

                    if (row.Cells["NgaySinh"].Value != null && row.Cells["NgaySinh"].Value != DBNull.Value)
                    {
                        txtNgaySinh.Text = Convert.ToDateTime(row.Cells["NgaySinh"].Value).ToString(dateFormat);
                        txtNgaySinh.ForeColor = Color.Black;
                    }
                    else
                    {
                        txtNgaySinh.Text = placeholderNgaySinh;
                        txtNgaySinh.ForeColor = Color.Gray;
                    }

                    txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString();
                    txtSoDt.Text = row.Cells["SDT"].Value?.ToString();
                    txtEmail.Text = row.Cells["Email"].Value?.ToString();
                    txtHocHam.Text = row.Cells["HocHam"].Value?.ToString();
                    txtHocVi.Text = row.Cells["HocVi"].Value?.ToString();

                    string maKhoa = row.Cells["MaKhoa"].Value?.ToString();
                    if (!string.IsNullOrEmpty(maKhoa))
                    {
                        cbbMaKhoa.SelectedValue = maKhoa;
                    }
                    else
                    {
                        cbbMaKhoa.SelectedIndex = -1;
                    }

                    txtMaGV.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chọn dòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}