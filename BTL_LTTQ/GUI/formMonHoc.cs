using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using BTL_LTTQ.BLL.Subject;
using BTL_LTTQ.DTO;

namespace BTL_LTTQ
{
    public partial class formMonHoc : Form
    {
        private readonly SubjectBLL bll = new SubjectBLL();
        private const string placeholderSearch = "Tìm theo tên hoặc mã môn học...";

        public formMonHoc()
        {
            InitializeComponent();
            this.Load += formMonHoc_Load;
        }

        #region Form Load & Setup
        private void formMonHoc_Load(object sender, EventArgs e)
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
                MessageBox.Show($"Lỗi khởi tạo form: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AttachEventHandlers()
        {
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnLamMoi.Click += BtnLamMoi_Click;
            btnTimKiem.Click += BtnTimKiem_Click;
            btnTatCa.Click += BtnTatCa_Click;
            btnXuatExcel.Click += BtnXuatExcel_Click;
            dgvMonHoc.CellClick += DgvMonHoc_CellClick;

            // Placeholder tìm kiếm
            txtTimKiem.Enter += (s, e) =>
            {
                if (txtTimKiem.Text == placeholderSearch)
                {
                    txtTimKiem.Text = "";
                    txtTimKiem.ForeColor = Color.Black;
                }
            };

            txtTimKiem.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
                {
                    txtTimKiem.Text = placeholderSearch;
                    txtTimKiem.ForeColor = SystemColors.GrayText;
                }
            };
        }

        private void SetupPlaceholders()
        {
            txtTimKiem.Text = placeholderSearch;
            txtTimKiem.ForeColor = SystemColors.GrayText;
        }
        #endregion

        #region Load Data
        private void LoadDataGridView()
        {
            try
            {
                var subjects = bll.GetAllSubjects();
                dgvMonHoc.DataSource = null;
                dgvMonHoc.DataSource = subjects;

                // Tùy chỉnh tiêu đề cột
                if (dgvMonHoc.Columns["MaMH"] != null) dgvMonHoc.Columns["MaMH"].HeaderText = "Mã Môn";
                if (dgvMonHoc.Columns["TenMH"] != null) dgvMonHoc.Columns["TenMH"].HeaderText = "Tên Môn Học";
                if (dgvMonHoc.Columns["SoTC"] != null) dgvMonHoc.Columns["SoTC"].HeaderText = "Số TC";
                if (dgvMonHoc.Columns["SoTietLT"] != null) dgvMonHoc.Columns["SoTietLT"].HeaderText = "Tiết LT";
                if (dgvMonHoc.Columns["SoTietTH"] != null) dgvMonHoc.Columns["SoTietTH"].HeaderText = "Tiết TH";
                if (dgvMonHoc.Columns["HeSoDQT"] != null) dgvMonHoc.Columns["HeSoDQT"].HeaderText = "HS ĐQT";
                if (dgvMonHoc.Columns["HeSoThi"] != null) dgvMonHoc.Columns["HeSoThi"].HeaderText = "HS Thi";
                if (dgvMonHoc.Columns["MaKhoa"] != null) dgvMonHoc.Columns["MaKhoa"].HeaderText = "Mã Khoa";
                if (dgvMonHoc.Columns["TenKhoa"] != null) dgvMonHoc.Columns["TenKhoa"].HeaderText = "Tên Khoa";

                dgvMonHoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
                var departments = bll.GetAllDepartments();
                cbbMaKhoa.DataSource = departments;
                cbbMaKhoa.DisplayMember = "TenKhoa";
                cbbMaKhoa.ValueMember = "MaKhoa";
                cbbMaKhoa.SelectedIndex = -1;
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
            txtMaMH.Clear();
            txtTenMH.Clear();
            numSoTC.Value = 1;
            numSoTietLT.Value = 0;
            numSoTietTH.Value = 0;
            txtHeSoDQT.Text = "0.3";
            txtHeSoThi.Text = "0.7";
            cbbMaKhoa.SelectedIndex = -1;

            txtMaMH.ReadOnly = false;
            txtMaMH.Focus();
        }

        private Subject GetSubjectFromGUI()
        {
            var subject = new Subject
            {
                MaMH = txtMaMH.Text.Trim(),
                TenMH = txtTenMH.Text.Trim(),
                SoTC = (int)numSoTC.Value,
                SoTietLT = (int)numSoTietLT.Value,
                SoTietTH = (int)numSoTietTH.Value,
                MaKhoa = cbbMaKhoa.SelectedValue?.ToString()
            };

            // Xử lý hệ số
            decimal heSoDQT = 0.3M;
            decimal heSoThi = 0.7M;

            if (!decimal.TryParse(txtHeSoDQT.Text, out heSoDQT)) heSoDQT = 0.3M;
            if (!decimal.TryParse(txtHeSoThi.Text, out heSoThi)) heSoThi = 0.7M;

            if (Math.Abs(heSoDQT + heSoThi - 1.0M) > 0.001M)
            {
                MessageBox.Show("Tổng hệ số Đánh giá quá trình và Thi phải bằng 1!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            subject.HeSoDQT = heSoDQT;
            subject.HeSoThi = heSoThi;

            return subject;
        }
        #endregion

        #region CRUD Operations
        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var subject = GetSubjectFromGUI();
            if (subject == null) return;

            try
            {
                // KIỂM TRA TRÙNG MÃ MÔN HỌC
                if (bll.CheckSubjectExists(subject.MaMH))
                {
                    MessageBox.Show("Mã môn học đã tồn tại! Vui lòng nhập mã khác.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaMH.Focus();
                    return;
                }

                if (bll.AddSubject(subject))
                {
                    MessageBox.Show("Thêm môn học thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại! Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (!txtMaMH.ReadOnly || string.IsNullOrWhiteSpace(txtMaMH.Text))
            {
                MessageBox.Show("Vui lòng chọn môn học cần sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput(false)) return;

            var subject = GetSubjectFromGUI();
            if (subject == null) return;

            try
            {
                if (bll.UpdateSubject(subject))
                {
                    MessageBox.Show("Cập nhật thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Lỗi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (!txtMaMH.ReadOnly || string.IsNullOrWhiteSpace(txtMaMH.Text))
            {
                MessageBox.Show("Vui lòng chọn môn học cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa môn học:\n\n{txtTenMH.Text} ({txtMaMH.Text})?\n\n" +
                "Tất cả lớp tín chỉ và điểm liên quan sẽ bị xóa!",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    if (bll.DeleteSubject(txtMaMH.Text.Trim()))
                    {
                        MessageBox.Show("Xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataGridView();
                        ClearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadDataGridView();
        }
        #endregion

        #region Search - TÌM KIẾM THÔNG MINH
        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text == placeholderSearch ? "" : txtTimKiem.Text.Trim();

            try
            {
                List<Subject> results;

                if (string.IsNullOrEmpty(keyword))
                {
                    results = bll.GetAllSubjects();
                }
                else
                {
                    // Kiểm tra xem keyword có giống định dạng mã môn học không (VD: MH001, IT102, CS201...)
                    bool looksLikeCode = Regex.IsMatch(keyword, @"^[A-Z]{1,4}\d{2,4}$", RegexOptions.IgnoreCase);

                    if (looksLikeCode)
                    {
                        results = bll.SearchSubjects(keyword, "", true); // Tìm chính xác theo mã
                    }
                    else
                    {
                        results = bll.SearchSubjects(keyword); // Tìm theo tên
                    }
                }

                dgvMonHoc.DataSource = null;
                dgvMonHoc.DataSource = results;

                if (results.Count == 0)
                    MessageBox.Show("Không tìm thấy môn học nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnTatCa_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = placeholderSearch;
            txtTimKiem.ForeColor = SystemColors.GrayText;
            LoadDataGridView();
        }
        #endregion

        #region Export CSV (UTF-8, có dấu)
        private void BtnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvMonHoc.Rows.Count == 0 || dgvMonHoc.Rows[0].IsNewRow)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "CSV File (*.csv)|*.csv|Tất cả file (*.*)|*.*",
                FileName = $"DanhSach_MonHoc_{DateTime.Now:yyyyMMdd_HHmmss}.csv",
                Title = "Xuất danh sách môn học"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ExportToCSV(sfd.FileName);
                    MessageBox.Show($"Xuất file thành công!\n{sfd.FileName}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ExportToCSV(string path)
        {
            var sb = new StringBuilder();
            sb.AppendLine("DANH SÁCH MÔN HỌC");
            sb.AppendLine($"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
            sb.AppendLine();

            // Header
            var headers = dgvMonHoc.Columns.Cast<DataGridViewColumn>()
                .Where(c => c.Visible)
                .Select(c => $"\"{c.HeaderText}\"");
            sb.AppendLine(string.Join(",", headers));

            // Data
            foreach (DataGridViewRow row in dgvMonHoc.Rows)
            {
                if (row.IsNewRow) continue;
                var cells = row.Cells.Cast<DataGridViewCell>()
                    .Where(cell => dgvMonHoc.Columns[cell.ColumnIndex].Visible)
                    .Select(cell => $"\"{(cell.Value?.ToString() ?? "").Replace("\"", "\"\"")}\"");
                sb.AppendLine(string.Join(",", cells));
            }

            File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
        }
        #endregion

        #region DataGridView Click - CHỌN DÒNG CHUẨN
        private void DgvMonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvMonHoc.Rows.Count || dgvMonHoc.Rows[e.RowIndex].IsNewRow)
                return;

            try
            {
                var subject = dgvMonHoc.Rows[e.RowIndex].DataBoundItem as Subject;
                if (subject != null)
                {
                    txtMaMH.Text = subject.MaMH?.Trim() ?? "";
                    txtTenMH.Text = subject.TenMH ?? "";
                    numSoTC.Value = subject.SoTC;
                    numSoTietLT.Value = subject.SoTietLT;
                    numSoTietTH.Value = subject.SoTietTH;
                    txtHeSoDQT.Text = subject.HeSoDQT.ToString("0.0##");
                    txtHeSoThi.Text = subject.HeSoThi.ToString("0.0##");

                    if (!string.IsNullOrEmpty(subject.MaKhoa))
                        cbbMaKhoa.SelectedValue = subject.MaKhoa;
                    else
                        cbbMaKhoa.SelectedIndex = -1;

                    txtMaMH.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chọn dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Validation
        private bool ValidateInput(bool isAdd = true)
        {
            if (string.IsNullOrWhiteSpace(txtMaMH.Text))
            {
                MessageBox.Show("Mã môn học không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaMH.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenMH.Text))
            {
                MessageBox.Show("Tên môn học không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenMH.Focus();
                return false;
            }

            if (cbbMaKhoa.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn khoa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbbMaKhoa.Focus();
                return false;
            }

            if (numSoTC.Value <= 0)
            {
                MessageBox.Show("Số tín chỉ phải lớn hơn 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numSoTC.Focus();
                return false;
            }

            return true;
        }
        #endregion
    }
}