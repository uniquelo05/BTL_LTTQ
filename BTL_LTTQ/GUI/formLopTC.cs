// formLopTC.cs (đã được refactor)
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BTL_LTTQ.BLL;
using BTL_LTTQ.DTO;
using BTL_LTTQ.DAL;
using System.IO;
using System.Text;

namespace BTL_LTTQ
{
    public partial class formLopTC : Form
    {
        private readonly LopTC_BLL bll = new LopTC_BLL();
        private const string placeholderMaLop = "nhập mã lớp";

        public formLopTC()
        {
            InitializeComponent();
            this.Load += formLopTC_Load;
        }

        #region Form Load

        private void formLopTC_Load(object sender, EventArgs e)
        {
            try
            {
                dgvSV.AutoGenerateColumns = false;
                SetupDataGridViewColumns();
                LoadDataGridView();
                LoadComboBoxes();
                AttachEventHandlers();
                SetPlaceholderText();
                ClearFields();
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

            dgvSV.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "MaLop",
                Name = "MaLop",
                HeaderText = "Mã Lớp",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            dgvSV.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "MaMH",
                Name = "MaMH",
                HeaderText = "Mã Môn",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            dgvSV.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "TenMH",
                Name = "TenMH",
                HeaderText = "Tên Môn",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvSV.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "MaKhoa",
                Name = "MaKhoa",
                HeaderText = "Khoa",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            dgvSV.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "HocKy",
                Name = "HocKy",
                HeaderText = "Học kỳ",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            dgvSV.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "NamHoc",
                Name = "NamHoc",
                HeaderText = "Năm học",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            dgvSV.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "TinhTrangLop",
                Name = "TinhTrangLop",
                HeaderText = "Tình Trạng",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });
        }

        private void AttachEventHandlers()
        {
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click; // ✅ ĐỔI TỪ btnRefresh
            btnSearch.Click += btnSearch_Click; // ✅ ĐỔI TỪ btnTimKiem
            btnRefreshSearch.Click += btnRefreshSearch_Click; // ✅ ĐỔI TỪ btnTatCa
            dgvSV.CellClick += dgvSV_CellClick;
            txtTimKiemTheoTen.Enter += txtTimKiemTheoTen_Enter; // ✅ ĐỔI TỪ tbTimKiemTheoTen
            txtTimKiemTheoTen.Leave += txtTimKiemTheoTen_Leave; // ✅ ĐỔI TỪ tbTimKiemTheoTen
            cbbMaKhoa.SelectedIndexChanged += cbbMaKhoa_SelectedIndexChanged;
            dgvSV.CellFormatting += dgvSV_CellFormatting;
            btnXuatExcel.Click += btnXuatExcel_Click;
        }

        #endregion

        #region Export Excel

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSV.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu lớp tín chỉ để xuất!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Files (*.csv)|*.csv|All Files (*.*)|*.*";
                sfd.FileName = $"DanhSach_LopTC_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                sfd.Title = "Lưu file Excel";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExportToCSV_LTC(sfd.FileName);
                    MessageBox.Show($"✅ XUẤT FILE THÀNH CÔNG!\n\nĐường dẫn: {sfd.FileName}",
                        "Xuất Excel thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất file: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportToCSV_LTC(string filePath)
        {
            StringBuilder sb = new StringBuilder();

            using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                sb.AppendLine("DANH SÁCH LỚP TÍN CHỈ");
                sb.AppendLine($"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                sb.AppendLine();

                var headers = dgvSV.Columns.Cast<DataGridViewColumn>()
                    .Where(c => c.Visible)
                    .Select(c => EscapeCSV(c.HeaderText));
                sb.AppendLine(string.Join(",", headers));

                foreach (DataGridViewRow row in dgvSV.Rows)
                {
                    if (row.IsNewRow) continue;

                    var cells = dgvSV.Columns.Cast<DataGridViewColumn>()
                        .Where(c => c.Visible)
                        .Select(c =>
                        {
                            var cellValue = row.Cells[c.Index].Value;
                            if (c.Name == "TinhTrangLop")
                            {
                                return EscapeCSV(row.Cells[c.Index].FormattedValue?.ToString() ?? "Chưa phân công");
                            }
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

        #region Load Data

        private void LoadDataGridView()
        {
            try
            {
                DataTable dt = bll.LoadDanhSachLTC();
                dgvSV.DataSource = dt;

                if (dgvSV.Columns["MaLop"] != null) 
                    dgvSV.Columns["MaLop"].HeaderText = "Mã Lớp";
                if (dgvSV.Columns["MaMH"] != null) 
                    dgvSV.Columns["MaMH"].HeaderText = "Mã Môn Học";
                if (dgvSV.Columns["TenMH"] != null) 
                    dgvSV.Columns["TenMH"].HeaderText = "Tên Môn Học";
                if (dgvSV.Columns["MaKhoa"] != null) 
                    dgvSV.Columns["MaKhoa"].HeaderText = "Mã Khoa";
                if (dgvSV.Columns["HocKy"] != null) 
                    dgvSV.Columns["HocKy"].HeaderText = "Học Kỳ";
                if (dgvSV.Columns["NamHoc"] != null) 
                    dgvSV.Columns["NamHoc"].HeaderText = "Năm Học";
                if (dgvSV.Columns["TinhTrangLop"] != null) 
                    dgvSV.Columns["TinhTrangLop"].HeaderText = "Tình Trạng";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ LỖI TẢI DỮ LIỆU:\n\n{ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadComboBoxes()
        {
            try
            {
                DataTable dtKhoa = bll.LoadDanhSachKhoa();

                cbbMaKhoa.DataSource = dtKhoa;
                cbbMaKhoa.DisplayMember = "TenKhoa";
                cbbMaKhoa.ValueMember = "MaKhoa";
                cbbMaKhoa.SelectedIndex = -1;

                DataTable dtKhoaSearch = dtKhoa.Copy();
                DataRow tatCaRow = dtKhoaSearch.NewRow();
                tatCaRow["MaKhoa"] = "";
                tatCaRow["TenKhoa"] = "--- Tất cả khoa ---";
                dtKhoaSearch.Rows.InsertAt(tatCaRow, 0);

                cbbTimTheoKhoa.DataSource = dtKhoaSearch;
                cbbTimTheoKhoa.DisplayMember = "TenKhoa";
                cbbTimTheoKhoa.ValueMember = "MaKhoa";
                cbbTimTheoKhoa.SelectedIndex = 0;

                LoadMonHocComboBox(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách Khoa/Môn học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách Môn học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txtMaLop.Text = ""; // ✅ ĐỔI TỪ tbMaLop
            numHocKy.Value = 1; // ✅ ĐỔI TỪ numericUpDownHocky
            txtNamHoc.Text = ""; // ✅ ĐỔI TỪ tbNamHoc
            cbbMaKhoa.SelectedIndex = -1;
            cbbMaMon.SelectedIndex = -1;
            txtMaLop.ReadOnly = false;
            txtMaLop.Focus();
        }

        private LopTC_DTO GetLopTinChiFromGUI()
        {
            LopTC_DTO ltc = new LopTC_DTO();
            ltc.MaLop = txtMaLop.Text.Trim(); // ✅ ĐỔI TỪ tbMaLop
            ltc.MaMH = cbbMaMon.SelectedValue?.ToString();
            ltc.HocKy = (int)numHocKy.Value; // ✅ ĐỔI TỪ numericUpDownHocky

            int namHoc;
            if (int.TryParse(txtNamHoc.Text, out namHoc)) // ✅ ĐỔI TỪ tbNamHoc
            {
                ltc.NamHoc = namHoc;
            }
            else
            {
                ltc.NamHoc = null;
            }

            ltc.TinhTrangLop = false;
            return ltc;
        }

        #endregion

        #region CRUD Events

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaLop.Text))
            {
                MessageBox.Show("Mã lớp không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLop.Focus();
                return;
            }
            if (cbbMaMon.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn môn học.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbbMaMon.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtNamHoc.Text))
            {
                MessageBox.Show("Năm học không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamHoc.Focus();
                return;
            }
            int namHoc;
            if (!int.TryParse(txtNamHoc.Text, out namHoc))
            {
                MessageBox.Show("Năm học phải là một con số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamHoc.Focus();
                return;
            }

            LopTC_DTO ltc = GetLopTinChiFromGUI();

            try
            {
                if (bll.ThemLTC(ltc))
                {
                    MessageBox.Show("Thêm lớp tín chỉ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Thêm lớp tín chỉ thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show("Mã lớp này đã tồn tại. Vui lòng nhập mã khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Lỗi khi thêm: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không xác định: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaLop.Text) || txtMaLop.ReadOnly == false)
            {
                MessageBox.Show("Vui lòng chọn một lớp tín chỉ từ danh sách để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LopTC_DTO ltc = GetLopTinChiFromGUI();

            try
            {
                if (bll.SuaLTC(ltc))
                {
                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy lớp để cập nhật hoặc dữ liệu không đổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaLop.Text) || txtMaLop.ReadOnly == false)
            {
                MessageBox.Show("Vui lòng chọn một lớp từ danh sách để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa Lớp Tín Chỉ (Mã: {txtMaLop.Text}) không?" +
                $"\n\nCẢNH BÁO: Toàn bộ dữ liệu Phân công giảng dạy và Điểm số của sinh viên liên quan đến lớp này cũng sẽ bị xóa vĩnh viễn.",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    if (bll.XoaLTC(txtMaLop.Text))
                    {
                        MessageBox.Show("Xóa lớp tín chỉ và các dữ liệu liên quan thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataGridView();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy lớp để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi trong quá trình xóa: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e) // ✅ ĐỔI TỪ btnRefresh_Click
        {
            ClearFields();
            LoadDataGridView();

            txtTimKiemTheoTen.Text = placeholderMaLop;
            txtTimKiemTheoTen.ForeColor = Color.Gray;
            txtTimTheoNam.Text = "";
            cbbTimTheoKhoa.SelectedIndex = 0;
        }

        #endregion

        #region Search Events

        private void btnSearch_Click(object sender, EventArgs e) // ✅ ĐỔI TỪ btnTimKiem_Click
        {
            string tuKhoa = (txtTimKiemTheoTen.Text == placeholderMaLop) ? "" : txtTimKiemTheoTen.Text;
            string namHocTim = txtTimTheoNam.Text;
            string maKhoaTim = cbbTimTheoKhoa.SelectedValue?.ToString();

            try
            {
                DataTable dt = bll.TimKiemLTC(tuKhoa, namHocTim, maKhoaTim);
                dgvSV.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (FormatException fex)
            {
                MessageBox.Show(fex.Message, "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshSearch_Click(object sender, EventArgs e) // ✅ ĐỔI TỪ btnTatCa_Click
        {
            txtTimKiemTheoTen.Text = placeholderMaLop;
            txtTimKiemTheoTen.ForeColor = Color.Gray;
            txtTimTheoNam.Text = "";
            cbbTimTheoKhoa.SelectedIndex = 0;

            LoadDataGridView();
        }

        #endregion

        #region UI Events

        private void dgvSV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvSV.Columns[e.ColumnIndex].Name == "TinhTrangLop")
            {
                if (e.Value == null || e.Value == DBNull.Value)
                {
                    e.Value = "Chưa phân công";
                    e.FormattingApplied = true;
                    return;
                }

                bool isAssigned;

                if (e.Value is bool)
                    isAssigned = (bool)e.Value;
                else if (e.Value is byte || e.Value is int)
                    isAssigned = Convert.ToInt32(e.Value) == 1;
                else
                    return;

                e.Value = isAssigned ? "Đã phân công" : "Chưa phân công";
                e.FormattingApplied = true;
            }
        }

        private void dgvSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSV.Rows[e.RowIndex];

                txtMaLop.Text = row.Cells["MaLop"].Value?.ToString();
                txtNamHoc.Text = row.Cells["NamHoc"].Value?.ToString();

                if (row.Cells["HocKy"].Value != null && row.Cells["HocKy"].Value != DBNull.Value)
                {
                    numHocKy.Value = Convert.ToDecimal(row.Cells["HocKy"].Value);
                }
                else
                {
                    numHocKy.Value = 1;
                }

                string maKhoa = row.Cells["MaKhoa"].Value?.ToString();
                if (!string.IsNullOrEmpty(maKhoa))
                {
                    cbbMaKhoa.SelectedValue = maKhoa;
                }
                else
                {
                    cbbMaKhoa.SelectedIndex = -1;
                }

                string maMH = row.Cells["MaMH"].Value?.ToString();
                if (!string.IsNullOrEmpty(maMH))
                {
                    cbbMaMon.SelectedValue = maMH;
                }
                else
                {
                    cbbMaMon.SelectedIndex = -1;
                }

                txtMaLop.ReadOnly = true;
            }
        }

        private void cbbMaKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbMaKhoa.SelectedValue != null)
            {
                string maKhoa = cbbMaKhoa.SelectedValue.ToString();
                LoadMonHocComboBox(maKhoa);
            }
            else
            {
                LoadMonHocComboBox(null);
            }
        }

        private void SetPlaceholderText()
        {
            txtTimKiemTheoTen.Text = placeholderMaLop;
            txtTimKiemTheoTen.ForeColor = Color.Gray;
        }

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

        #endregion
    }
}