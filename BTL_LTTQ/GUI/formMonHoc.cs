using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTL_LTTQ.BLL.Subject;
using BTL_LTTQ.DTO;
using System.IO;

namespace BTL_LTTQ
{
    public partial class formMonHoc : Form
    {
        private SubjectBLL subjectBLL;
        private List<DTO.Subject> currentSubjects;

        public formMonHoc()
        {
            InitializeComponent();
            subjectBLL = new SubjectBLL();
            currentSubjects = new List<DTO.Subject>();
            
            // Khởi tạo form
            InitializeForm();
        }

        private void InitializeForm()
        {
            try
            {
                // Load danh sách khoa vào ComboBox
                LoadDepartments();
                
                // Load tất cả môn học
                LoadAllSubjects();
                
                // Thiết lập DataGridView
                SetupDataGridView();
                
                // Gán sự kiện
                AttachEvents();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo form: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDepartments()
        {
            try
            {
                List<Department> departments = subjectBLL.GetAllDepartments();
                
                // Thêm item "Tất cả" vào đầu danh sách
                cbbMaKhoa.Items.Clear();
                cbbMaKhoa.Items.Add(new { MaKhoa = "", TenKhoa = "-- Chọn khoa --" });
                
                cbbTimTheoKhoa.Items.Clear();
                cbbTimTheoKhoa.Items.Add(new { MaKhoa = "", TenKhoa = "-- Tất cả khoa --" });
                
                foreach (Department dept in departments)
                {
                    var item = new { MaKhoa = dept.MaKhoa, TenKhoa = $"{dept.MaKhoa} - {dept.TenKhoa}" };
                    cbbMaKhoa.Items.Add(item);
                    cbbTimTheoKhoa.Items.Add(item);
                }
                
                cbbMaKhoa.DisplayMember = "TenKhoa";
                cbbMaKhoa.ValueMember = "MaKhoa";
                cbbMaKhoa.SelectedIndex = 0;
                
                cbbTimTheoKhoa.DisplayMember = "TenKhoa";
                cbbTimTheoKhoa.ValueMember = "MaKhoa";
                cbbTimTheoKhoa.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load danh sách khoa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAllSubjects()
        {
            try
            {
                List<DTO.Subject> subjects = subjectBLL.GetAllSubjects();
                DisplaySubjects(subjects);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách môn học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplaySubjects(List<DTO.Subject> subjects)
        {
            try
            {
                dgvSV.DataSource = null;
                dgvSV.Columns.Clear();

                dgvSV.DataSource = subjects;

                dgvSV.Columns["MaMH"].HeaderText = "Mã Môn Học";
                dgvSV.Columns["TenMH"].HeaderText = "Tên Môn Học";
                dgvSV.Columns["SoTC"].HeaderText = "Số Tín Chỉ";
                dgvSV.Columns["SoTietLT"].HeaderText = "Số Tiết Lý Thuyết";
                dgvSV.Columns["SoTietTH"].HeaderText = "Số Tiết Thực Hành";
                dgvSV.Columns["HeSoDQT"].HeaderText = "Hệ Số Điểm Quá Trình";
                dgvSV.Columns["HeSoThi"].HeaderText = "Hệ Số Điểm Thi";
                dgvSV.Columns["TenKhoa"].HeaderText = "Tên Khoa";

                dgvSV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị danh sách môn học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDataGridView()
        {
            dgvSV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSV.MultiSelect = false;
            dgvSV.ReadOnly = true;
            dgvSV.AllowUserToAddRows = false;
            dgvSV.AllowUserToDeleteRows = false;
        }

        private void AttachEvents()
        {
            // Sự kiện click cho các nút
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnRefresh.Click += BtnRefresh_Click;
            btnTimKiem.Click += BtnTimKiem_Click;
            btnTatCa.Click += BtnTatCa_Click;
            btnXuatExcel.Click += BtnXuatExcel_Click;
            
            // Sự kiện click trên DataGridView
            dgvSV.CellClick += DgvSV_CellClick;
        }

        private void DgvSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dgvSV.Rows.Count && dgvSV.Rows[e.RowIndex].DataBoundItem != null)
                {
                    DataGridViewRow row = dgvSV.Rows[e.RowIndex];

                    tbMaMon.Text = row.Cells["MaMH"].Value?.ToString() ?? "";
                    tbTenMon.Text = row.Cells["TenMH"].Value?.ToString() ?? "";
                    tbSoTC.Text = row.Cells["SoTC"].Value?.ToString() ?? "";
                    tbTietLT.Text = row.Cells["SoTietLT"].Value?.ToString() ?? "";
                    tbTietTH.Text = row.Cells["SoTietTH"].Value?.ToString() ?? "";
                    tbHeSoDQT.Text = row.Cells["HeSoDQT"].Value?.ToString() ?? "";
                    tbHeSoThi.Text = row.Cells["HeSoThi"].Value?.ToString() ?? "";

                    // Lấy giá trị MaKhoa từ hàng được chọn
                    string maKhoa = row.Cells["MaKhoa"].Value?.ToString() ?? "";

                    // Tìm và chọn item trong ComboBox tương ứng với MaKhoa
                    foreach (var item in cbbMaKhoa.Items)
                    {
                        if (((dynamic)item).MaKhoa == maKhoa)
                        {
                            cbbMaKhoa.SelectedItem = item;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn dòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    var newSubject = new DTO.Subject
                    {
                        MaMH = tbMaMon.Text.Trim(),
                        TenMH = tbTenMon.Text.Trim(),
                        SoTC = int.Parse(tbSoTC.Text.Trim()),
                        SoTietLT = int.Parse(tbTietLT.Text.Trim()),
                        SoTietTH = int.Parse(tbTietTH.Text.Trim()),
                        HeSoDQT = decimal.Parse(tbHeSoDQT.Text.Trim()), // Thêm trường HeSoDQT
                        HeSoThi = decimal.Parse(tbHeSoThi.Text.Trim()), // Thêm trường HeSoThi
                        MaKhoa = ((dynamic)cbbMaKhoa.SelectedItem).MaKhoa
                    };

                    if (subjectBLL.AddSubject(newSubject))
                    {
                        MessageBox.Show("Thêm môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAllSubjects();
                        ClearInput();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm môn học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbMaMon.Text))
                {
                    MessageBox.Show("Vui lòng chọn môn học để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (ValidateInput())
                {
                    var updateSubject = new DTO.Subject
                    {
                        MaMH = tbMaMon.Text.Trim(),
                        TenMH = tbTenMon.Text.Trim(),
                        SoTC = int.Parse(tbSoTC.Text.Trim()),
                        SoTietLT = int.Parse(tbTietLT.Text.Trim()),
                        SoTietTH = int.Parse(tbTietTH.Text.Trim()),
                        HeSoDQT = decimal.Parse(tbHeSoDQT.Text.Trim()), // Thêm trường HeSoDQT
                        HeSoThi = decimal.Parse(tbHeSoThi.Text.Trim()), // Thêm trường HeSoThi
                        MaKhoa = ((dynamic)cbbMaKhoa.SelectedItem).MaKhoa
                    };

                    if (subjectBLL.UpdateSubject(updateSubject))
                    {
                        MessageBox.Show("Cập nhật môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAllSubjects();
                        ClearInput();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật môn học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbMaMon.Text))
                {
                    MessageBox.Show("Vui lòng chọn môn học để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa môn học '{tbTenMon.Text}'?", 
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (subjectBLL.DeleteSubject(tbMaMon.Text.Trim()))
                    {
                        MessageBox.Show("Xóa môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAllSubjects();
                        ClearInput();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa môn học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadAllSubjects();
            ClearInput();
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = tbTimKiemTheoTen.Text.Trim();
                string maKhoa = ((dynamic)cbbTimTheoKhoa.SelectedItem)?.MaKhoa ?? "";

                if (string.IsNullOrEmpty(searchText) && string.IsNullOrEmpty(maKhoa))
                {
                    LoadAllSubjects();
                    return;
                }

                List<DTO.Subject> searchResults = new List<DTO.Subject>();

                if (!string.IsNullOrEmpty(searchText))
                {
                    // Thử tìm theo mã trước (nếu text ngắn và không có dấu cách)
                    if (searchText.Length <= 10 && !searchText.Contains(" "))
                    {
                        // Có thể là mã môn học
                        var codeResults = subjectBLL.SearchSubjectsByCode(searchText);
                        if (codeResults.Count > 0)
                        {
                            searchResults = codeResults;
                        }
                        else
                        {
                            // Nếu không tìm thấy theo mã, thử tìm theo tên
                            searchResults = subjectBLL.SearchSubjectsByName(searchText);
                        }
                    }
                    else
                    {
                        // Có thể là tên môn học
                        searchResults = subjectBLL.SearchSubjectsByName(searchText);
                    }
                }
                else
                {
                    // Chỉ tìm theo khoa
                    searchResults = subjectBLL.GetSubjectsByDepartment(maKhoa);
                }

                // Lọc thêm theo khoa nếu có
                if (!string.IsNullOrEmpty(maKhoa) && !string.IsNullOrEmpty(searchText))
                {
                    searchResults = searchResults.Where(s => s.MaKhoa.Equals(maKhoa, StringComparison.OrdinalIgnoreCase)).ToList();
                }

                DisplaySubjects(searchResults);
                
                // Hiển thị thông báo kết quả
                if (searchResults.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnTatCa_Click(object sender, EventArgs e)
        {
            LoadAllSubjects();
            tbTimKiemTheoTen.Clear();
            cbbTimTheoKhoa.SelectedIndex = 0;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(tbMaMon.Text.Trim()))
            {
                MessageBox.Show("Mã môn học không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbMaMon.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(tbTenMon.Text.Trim()))
            {
                MessageBox.Show("Tên môn học không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbTenMon.Focus();
                return false;
            }

            if (!int.TryParse(tbSoTC.Text.Trim(), out int soTC) || soTC <= 0)
            {
                MessageBox.Show("Số tín chỉ phải là số nguyên dương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbSoTC.Focus();
                return false;
            }

            if (!int.TryParse(tbTietLT.Text.Trim(), out int soTietLT) || soTietLT < 0) // Updated to SoTietLT
            {
                MessageBox.Show("Số tiết lý thuyết phải là số nguyên không âm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbTietLT.Focus();
                return false;
            }

            if (!int.TryParse(tbTietTH.Text.Trim(), out int soTietTH) || soTietTH < 0) // Updated to SoTietTH
            {
                MessageBox.Show("Số tiết thực hành phải là số nguyên không âm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbTietTH.Focus();
                return false;
            }

            if (cbbMaKhoa.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn khoa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbbMaKhoa.Focus();
                return false;
            }

            return true;
        }

        private void ClearInput()
        {
            tbMaMon.Clear();
            tbTenMon.Clear();
            tbSoTC.Clear();
            tbTietLT.Clear();
            tbTietTH.Clear();
            cbbMaKhoa.SelectedIndex = 0;
        }

        #region Excel Export

        private void BtnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSV.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu môn học để xuất!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Files (*.csv)|*.csv|All Files (*.*)|*.*";
                sfd.FileName = $"DanhSach_MonHoc_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                sfd.Title = "Lưu file Excel";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExportToCSV_MonHoc(sfd.FileName);

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

        private void ExportToCSV_MonHoc(string filePath)
        {
            StringBuilder sb = new StringBuilder();

            using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                sb.AppendLine("DANH SÁCH MÔN HỌC");
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
