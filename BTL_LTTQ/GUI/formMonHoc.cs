using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using BTL_LTTQ.BLL.Subject;  // ✅ SỬ DỤNG BLL CÓ SẴN
using BTL_LTTQ.DTO;           // ✅ SỬ DỤNG DTO CÓ SẴN
using System.IO;
using System.Text;

namespace BTL_LTTQ
{
    public partial class formMonHoc : Form
    {
        private readonly SubjectBLL bll = new SubjectBLL();  // ✅ SỬ DỤNG SubjectBLL
        private const string placeholderSearch = "Tìm theo tên hoặc mã môn học...";
        private List<Subject> currentSubjects;  // ✅ Cache data

        public formMonHoc()
        {
            InitializeComponent();
            this.Load += formMonHoc_Load;
            currentSubjects = new List<Subject>();
        }

        #region Form Load

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
                MessageBox.Show($"Lỗi khởi tạo form: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            // Placeholder events
            txtTimKiem.Enter += (s, e) =>
            {
                if (txtTimKiem.Text == placeholderSearch && txtTimKiem.ForeColor == System.Drawing.SystemColors.GrayText)
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
                    txtTimKiem.ForeColor = System.Drawing.SystemColors.GrayText;
                }
            };
        }

        private void SetupPlaceholders()
        {
            txtTimKiem.Text = placeholderSearch;
            txtTimKiem.ForeColor = System.Drawing.SystemColors.GrayText;
        }

        #endregion

        #region Load Data

        private void LoadDataGridView()
        {
            try
            {
                currentSubjects = bll.GetAllSubjects();
                dgvMonHoc.DataSource = null;
                dgvMonHoc.DataSource = currentSubjects;

                // Tùy chỉnh header
                if (dgvMonHoc.Columns["MaMH"] != null) dgvMonHoc.Columns["MaMH"].HeaderText = "Mã Môn";
                if (dgvMonHoc.Columns["TenMH"] != null) dgvMonHoc.Columns["TenMH"].HeaderText = "Tên Môn Học";
                if (dgvMonHoc.Columns["SoTC"] != null) dgvMonHoc.Columns["SoTC"].HeaderText = "Số TC";
                if (dgvMonHoc.Columns["SoTietLT"] != null) dgvMonHoc.Columns["SoTietLT"].HeaderText = "Tiết LT";
                if (dgvMonHoc.Columns["SoTietTH"] != null) dgvMonHoc.Columns["SoTietTH"].HeaderText = "Tiết TH";
                if (dgvMonHoc.Columns["HeSoDQT"] != null) dgvMonHoc.Columns["HeSoDQT"].HeaderText = "HS ĐQT";
                if (dgvMonHoc.Columns["HeSoThi"] != null) dgvMonHoc.Columns["HeSoThi"].HeaderText = "HS Thi";
                if (dgvMonHoc.Columns["MaKhoa"] != null) dgvMonHoc.Columns["MaKhoa"].HeaderText = "Mã Khoa";
                if (dgvMonHoc.Columns["TenKhoa"] != null) dgvMonHoc.Columns["TenKhoa"].HeaderText = "Tên Khoa";
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
                List<Department> departments = bll.GetAllDepartments();
                
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
            txtMaMH.Text = "";
            txtTenMH.Text = "";
            numSoTC.Value = 0;
            numSoTiet.Value = 0;
            txtMoTa.Text = "";
            cbbMaKhoa.SelectedIndex = -1;
            txtMaMH.ReadOnly = false;
            txtMaMH.Focus();
        }

        private Subject GetSubjectFromGUI()
        {
            Subject subject = new Subject();
            subject.MaMH = txtMaMH.Text.Trim();
            subject.TenMH = txtTenMH.Text.Trim();
            subject.SoTC = (int)numSoTC.Value;
            
            // ✅ Tính tổng số tiết (numSoTiet) thành SoTietLT (design mới đơn giản hóa)
            // Có thể chia 50/50 hoặc toàn bộ vào LT
            int tongSoTiet = (int)numSoTiet.Value;
            subject.SoTietLT = tongSoTiet; // Hoặc chia: tongSoTiet / 2
            subject.SoTietTH = 0;          // Hoặc chia: tongSoTiet - subject.SoTietLT
            
            // Default hệ số nếu không có trên GUI
            subject.HeSoDQT = 0.3M;
            subject.HeSoThi = 0.7M;
            
            subject.MaKhoa = cbbMaKhoa.SelectedValue?.ToString();
            
            return subject;
        }

        #endregion

        #region CRUD Events

        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaMH.Text))
            {
                MessageBox.Show("Mã môn học không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaMH.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTenMH.Text))
            {
                MessageBox.Show("Tên môn học không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenMH.Focus();
                return;
            }
            if (cbbMaKhoa.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn khoa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbbMaKhoa.Focus();
                return;
            }
            if (numSoTC.Value == 0)
            {
                MessageBox.Show("Số tín chỉ phải lớn hơn 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numSoTC.Focus();
                return;
            }

            Subject subject = GetSubjectFromGUI();

            try
            {
                if (bll.AddSubject(subject))
                {
                    MessageBox.Show("Thêm môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Thêm môn học thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaMH.Text) || !txtMaMH.ReadOnly)
            {
                MessageBox.Show("Vui lòng chọn môn học để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Subject subject = GetSubjectFromGUI();

            try
            {
                if (bll.UpdateSubject(subject))
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

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaMH.Text) || !txtMaMH.ReadOnly)
            {
                MessageBox.Show("Vui lòng chọn môn học để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa môn học '{txtTenMH.Text}' (Mã: {txtMaMH.Text})?\n\n" +
                "CẢNH BÁO: Lớp tín chỉ và điểm liên quan cũng sẽ bị xóa!",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    if (bll.DeleteSubject(txtMaMH.Text))
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

        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadDataGridView();
        }

        #endregion

        #region Search Events

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = (txtTimKiem.Text == placeholderSearch) ? "" : txtTimKiem.Text;

            try
            {
                List<Subject> results;
                
                if (string.IsNullOrEmpty(keyword))
                {
                    // Hiển thị tất cả
                    results = bll.GetAllSubjects();
                }
                else
                {
                    // Tìm theo tên môn học
                    results = bll.SearchSubjectsByName(keyword);
                }
                
                dgvMonHoc.DataSource = null;
                dgvMonHoc.DataSource = results;

                if (results.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnTatCa_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = placeholderSearch;
            txtTimKiem.ForeColor = System.Drawing.SystemColors.GrayText;
            LoadDataGridView();
        }

        #endregion

        #region Export Excel

        private void BtnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMonHoc.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Files (*.csv)|*.csv|All Files (*.*)|*.*";
                sfd.FileName = $"DanhSach_MonHoc_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
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
                sb.AppendLine("DANH SÁCH MÔN HỌC");
                sb.AppendLine($"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                sb.AppendLine();

                var headers = dgvMonHoc.Columns.Cast<DataGridViewColumn>()
                    .Where(c => c.Visible)
                    .Select(c => EscapeCSV(c.HeaderText));
                sb.AppendLine(string.Join(",", headers));

                foreach (DataGridViewRow row in dgvMonHoc.Rows)
                {
                    if (row.IsNewRow) continue;

                    var cells = dgvMonHoc.Columns.Cast<DataGridViewColumn>()
                        .Where(c => c.Visible)
                        .Select(c => EscapeCSV(row.Cells[c.Index].Value?.ToString() ?? ""));

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

        private void DgvMonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    Subject subject = dgvMonHoc.Rows[e.RowIndex].DataBoundItem as Subject;
                    if (subject != null)
                    {
                        txtMaMH.Text = subject.MaMH;
                        txtTenMH.Text = subject.TenMH;
                        numSoTC.Value = subject.SoTC;
                        numSoTiet.Value = subject.SoTietLT + subject.SoTietTH;
                        txtMoTa.Text = ""; // Không có field MoTa trong Subject hiện tại
                        cbbMaKhoa.SelectedValue = subject.MaKhoa;
                        txtMaMH.ReadOnly = true;
                    }
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
