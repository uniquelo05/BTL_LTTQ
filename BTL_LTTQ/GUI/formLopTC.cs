// formLopTC.cs (đã được refactor)
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq; // Cần giữ lại
using System.Windows.Forms;
using BTL_LTTQ.BLL;
using BTL_LTTQ.DTO;
using BTL_LTTQ.DAL;
using System.IO;
using System.Text;
using System.Linq;

namespace BTL_LTTQ
{
    public partial class formLopTC : Form
    {
        private readonly LopTC_BLL bll = new LopTC_BLL();

        private const string placeholderMaLop = "nhập mã lớp";

        public formLopTC()
        {
            InitializeComponent();
        }

        #region Form Load

        private void formLopTC_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            LoadComboBoxes();
            AttachEventHandlers();
            ClearFields();
            SetPlaceholderText();

            dgvSV.AutoGenerateColumns = false;
            SetupDataGridViewColumns();
        }


        private void SetupDataGridViewColumns()
        {
            dgvSV.Columns.Clear();

            // Mã Lớp
            dgvSV.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "MaLop",
                Name = "MaLop",
                HeaderText = "Mã Lớp",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            // Mã Môn Học
            dgvSV.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "MaMH",
                Name = "MaMH",
                HeaderText = "Mã Môn",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            // Tên Môn Học
            dgvSV.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "TenMH",
                Name = "TenMH",
                HeaderText = "Tên Môn",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // Khoa
            dgvSV.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "MaKhoa",
                Name = "MaKhoa",
                HeaderText = "Khoa",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            // Học kỳ
            dgvSV.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "HocKy",
                Name = "HocKy",
                HeaderText = "Học kỳ",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            // Năm học
            dgvSV.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "NamHoc",
                Name = "NamHoc",
                HeaderText = "Năm học",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            // Tình Trạng Lớp
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
            btnThem.Click += new EventHandler(btnThem_Click);
            btnSua.Click += new EventHandler(btnSua_Click);
            btnXoa.Click += new EventHandler(btnXoa_Click);
            btnRefresh.Click += new EventHandler(btnRefresh_Click);
            btnTimKiem.Click += new EventHandler(btnTimKiem_Click);
            btnTatCa.Click += new EventHandler(btnTatCa_Click);
            dgvSV.CellClick += new DataGridViewCellEventHandler(dgvSV_CellClick);
            tbTimKiemTheoTen.Enter += new EventHandler(tbTimKiemTheoTen_Enter);
            tbTimKiemTheoTen.Leave += new EventHandler(tbTimKiemTheoTen_Leave);
            cbbMaKhoa.SelectedIndexChanged += new EventHandler(cbbMaKhoa_SelectedIndexChanged);

            // ĐÃ THÊM: Thêm sự kiện để format cột BIT (0/1)
            // Đây chính là code sửa lỗi FormatException trong ảnh của bạn
            dgvSV.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvSV_CellFormatting);
            btnXuatExcel.Click += new EventHandler(btnXuatExcel_Click);
        }

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
                    ExportToCSV_LTC(sfd.FileName); // Gọi hàm export

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

            // Sử dụng StreamWriter với Encoding.UTF8
            using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                sb.AppendLine("DANH SÁCH LỚP TÍN CHỈ");
                sb.AppendLine($"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                sb.AppendLine();

                // Ghi header các cột (chỉ các cột hiển thị)
                var headers = dgvSV.Columns.Cast<DataGridViewColumn>()
                    .Where(c => c.Visible)
                    .Select(c => EscapeCSV(c.HeaderText));
                sb.AppendLine(string.Join(",", headers));

                // Ghi dữ liệu từng dòng
                foreach (DataGridViewRow row in dgvSV.Rows)
                {
                    if (row.IsNewRow) continue;

                    var cells = dgvSV.Columns.Cast<DataGridViewColumn>()
                        .Where(c => c.Visible)
                        .Select(c =>
                        {
                            var cellValue = row.Cells[c.Index].Value;

                            // ✅ Xử lý cột TinhTrangLop (đã được format)
                            if (c.Name == "TinhTrangLop")
                            {
                                // Lấy giá trị đã được format từ sự kiện CellFormatting
                                return EscapeCSV(row.Cells[c.Index].FormattedValue?.ToString() ?? "Chưa phân công");
                            }

                            return EscapeCSV(cellValue?.ToString() ?? "");
                        });

                    sb.AppendLine(string.Join(",", cells));
                }

                sw.Write(sb.ToString());
            }
        }

        // Tái sử dụng hàm EscapeCSV (thường được đặt trong một lớp tiện ích chung)
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

        #region Phương thức Helper (Tải dữ liệu, Xóa trường)

        private void LoadDataGridView()
        {
            try
            {
                DataTable dt = bll.LoadDanhSachLTC(); // Gọi BLL
                dgvSV.DataSource = dt;

                dgvSV.Columns["MaLop"].HeaderText = "Mã Lớp";
                dgvSV.Columns["MaMH"].HeaderText = "Mã Môn Học";
                dgvSV.Columns["TenMH"].HeaderText = "Tên Môn Học";
                dgvSV.Columns["MaKhoa"].HeaderText = "Mã Khoa";
                dgvSV.Columns["HocKy"].HeaderText = "Học Kỳ";
                dgvSV.Columns["NamHoc"].HeaderText = "Năm Học";
                // ĐÃ SỬA: Đổi tên cột

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
                DataTable dtKhoa = bll.LoadDanhSachKhoa(); // Gọi BLL

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

                // ĐÃ SỬA: Xóa toàn bộ phần 'cbbTinhTrang'
                // vì control này không còn tồn tại trên Designer
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
                DataTable dtMonHoc = bll.LoadDanhSachMonHoc(maKhoa); // Gọi BLL
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
            tbMaLop.Text = "";
            numericUpDownHocky.Value = 1;
            tbNamHoc.Text = "";
            cbbMaKhoa.SelectedIndex = -1;
            cbbMaMon.SelectedIndex = -1;

            // ĐÃ SỬA: Xóa 'cbbTinhTrang'

            tbMaLop.ReadOnly = false;
            tbMaLop.Focus();
        }

        private LopTC_DTO GetLopTinChiFromGUI()
        {
            LopTC_DTO ltc = new LopTC_DTO();
            ltc.MaLop = tbMaLop.Text.Trim();
            ltc.MaMH = cbbMaMon.SelectedValue?.ToString();
            ltc.HocKy = (int)numericUpDownHocky.Value;

            int namHoc;
            if (int.TryParse(tbNamHoc.Text, out namHoc))
            {
                ltc.NamHoc = namHoc;
            }
            else
            {
                ltc.NamHoc = null;
            }

            // ĐÃ SỬA: Xóa 'cbbTinhTrang'.
            // TinhTrangLop sẽ mặc định là false (0) khi tạo mới DTO
            ltc.TinhTrangLop = false;

            return ltc;
        }

        #endregion

        #region Sự kiện CRUD (Gọi BLL)

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbMaLop.Text))
            {
                MessageBox.Show("Mã lớp không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbMaLop.Focus();
                return;
            }
            if (cbbMaMon.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn môn học.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbbMaMon.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(tbNamHoc.Text))
            {
                MessageBox.Show("Năm học không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbNamHoc.Focus();
                return;
            }
            int namHoc;
            if (!int.TryParse(tbNamHoc.Text, out namHoc))
            {
                MessageBox.Show("Năm học phải là một con số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbNamHoc.Focus();
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
            if (string.IsNullOrWhiteSpace(tbMaLop.Text) || tbMaLop.ReadOnly == false)
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
            if (string.IsNullOrWhiteSpace(tbMaLop.Text) || tbMaLop.ReadOnly == false)
            {
                MessageBox.Show("Vui lòng chọn một lớp từ danh sách để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa Lớp Tín Chỉ (Mã: {tbMaLop.Text}) không?" +
                $"\n\nCẢNH BÁO: Toàn bộ dữ liệu Phân công giảng dạy và Điểm số của sinh viên liên quan đến lớp này cũng sẽ bị xóa vĩnh viễn.",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    if (bll.XoaLTC(tbMaLop.Text))
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadDataGridView();

            tbTimKiemTheoTen.Text = placeholderMaLop;
            tbTimKiemTheoTen.ForeColor = Color.Gray;
            tbTimTheoNam.Text = "";
            cbbTimTheoKhoa.SelectedIndex = 0;
        }

        #endregion

        #region Sự kiện Tìm kiếm (Gọi BLL)

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = (tbTimKiemTheoTen.Text == placeholderMaLop) ? "" : tbTimKiemTheoTen.Text;
            string namHocTim = tbTimTheoNam.Text;
            string maKhoaTim = cbbTimTheoKhoa.SelectedValue?.ToString();

            try
            {
                DataTable dt = bll.TimKiemLTC(tuKhoa, namHocTim, maKhoaTim); // Gọi BLL
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

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            tbTimKiemTheoTen.Text = placeholderMaLop;
            tbTimKiemTheoTen.ForeColor = Color.Gray;
            tbTimTheoNam.Text = "";
            cbbTimTheoKhoa.SelectedIndex = 0;

            LoadDataGridView();
        }

        #endregion

        #region Sự kiện Giao diện

        /// <summary>
        /// Sửa lỗi FormatException: Dịch BIT (0/1) sang text "0: Chưa..." / "1: Đã..."
        /// </summary>
        private void dgvSV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvSV.Columns[e.ColumnIndex].Name == "TinhTrangLop")
            {
                if (e.Value == null || e.Value == DBNull.Value)
                {
                    e.Value = "0: Chưa phân công";
                    e.FormattingApplied = true;
                    return;
                }

                bool isAssigned;

                if (e.Value is bool)
                    isAssigned = (bool)e.Value;
                else if (e.Value is byte || e.Value is int)
                    isAssigned = Convert.ToInt32(e.Value) == 1;
                else
                {
                    // Đề phòng trường hợp dữ liệu không chuẩn → bỏ qua
                    return;
                }

                e.Value = isAssigned ? "Đã phân công" : "Chưa phân công";
                e.FormattingApplied = true;
            }
        }




        private void dgvSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSV.Rows[e.RowIndex];

                tbMaLop.Text = row.Cells["MaLop"].Value?.ToString();
                tbNamHoc.Text = row.Cells["NamHoc"].Value?.ToString();

                if (row.Cells["HocKy"].Value != null && row.Cells["HocKy"].Value != DBNull.Value)
                {
                    numericUpDownHocky.Value = Convert.ToDecimal(row.Cells["HocKy"].Value);
                }
                else
                {
                    numericUpDownHocky.Value = 1;
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

                // ĐÃ SỬA: Xóa logic gán cho Tình Trạng
                // vì control không còn trên form
                tbMaLop.ReadOnly = true;

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

        // --- Placeholder ---
        private void SetPlaceholderText()
        {
            tbTimKiemTheoTen.Text = placeholderMaLop;
            tbTimKiemTheoTen.ForeColor = Color.Gray;
        }

        private void tbTimKiemTheoTen_Enter(object sender, EventArgs e)
        {
            if (tbTimKiemTheoTen.Text == placeholderMaLop)
            {
                tbTimKiemTheoTen.Text = "";
                tbTimKiemTheoTen.ForeColor = Color.Black;
            }
        }

        private void tbTimKiemTheoTen_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbTimKiemTheoTen.Text))
            {
                tbTimKiemTheoTen.Text = placeholderMaLop;
                tbTimKiemTheoTen.ForeColor = Color.Gray;
            }
        }

        #endregion

        // Hàm này bạn có trong code gốc, tôi giữ lại
        private void tbMaLop_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvSV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}