using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTL_LTTQ.BLL.Diem;
using BTL_LTTQ.DTO;
using Excel = Microsoft.Office.Interop.Excel;
using BTL_LTTQ.BLL.Session;

namespace BTL_LTTQ
{
    public partial class formDiem : Form
    {
        private DiemBLL diemBLL = new DiemBLL();

        public formDiem()
        {
            InitializeComponent();
            
            // Thiết lập form
            InitializeFormDiem();
        }

        private void InitializeFormDiem()
        {
            // Load dữ liệu
            LoadData();
            
            // Setup placeholders
            SetupSearchPlaceholders();
            
            // Gán sự kiện
            AttachEvents();
        }

        #region Setup Placeholders

        private void SetupSearchPlaceholders()
        {
            // Placeholder cho txtSearchMaSV
            txtSearchMaSV.Enter += (s, e) => 
            {
                if (txtSearchMaSV.Text == "Nhập mã sinh viên..." && txtSearchMaSV.ForeColor == System.Drawing.SystemColors.GrayText)
                {
                    txtSearchMaSV.Text = "";
                    txtSearchMaSV.ForeColor = Color.Black;
                }
            };
            
            txtSearchMaSV.Leave += (s, e) => 
            {
                if (string.IsNullOrWhiteSpace(txtSearchMaSV.Text))
                {
                    txtSearchMaSV.Text = "Nhập mã sinh viên...";
                    txtSearchMaSV.ForeColor = System.Drawing.SystemColors.GrayText;
                }
            };

            // Placeholder cho txtSearchMaLop
            txtSearchMaLop.Enter += (s, e) => 
            {
                if (txtSearchMaLop.Text == "Mã lớp..." && txtSearchMaLop.ForeColor == System.Drawing.SystemColors.GrayText)
                {
                    txtSearchMaLop.Text = "";
                    txtSearchMaLop.ForeColor = Color.Black;
                }
            };
            
            txtSearchMaLop.Leave += (s, e) => 
            {
                if (string.IsNullOrWhiteSpace(txtSearchMaLop.Text))
                {
                    txtSearchMaLop.Text = "Mã lớp...";
                    txtSearchMaLop.ForeColor = System.Drawing.SystemColors.GrayText;
                }
            };
        }

        #endregion

        #region Attach Events

        private void AttachEvents()
        {
            // ✅ SỬA: Đổi tên buttons từ btnAdd/btnEdit/... thành btnThem/btnSua/...
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnLamMoi.Click += BtnLamMoi_Click;
            btnSearch.Click += BtnTim_Click;
            btnRefreshSearch.Click += BtnTatCa_Click;
            btnXuatExcel.Click += BtnXuatExcel_Click;
            
            // Sự kiện DataGridView
            dgvDiem.CellClick += DataGridView1_CellClick;
        }

        #endregion

        #region Load & Display Data

        /// <summary>
        /// Tải dữ liệu điểm lên DataGridView
        /// </summary>
        private void LoadData()
        {
            try
            {
                string maGV = UserSession.Instance.MaGV;
                string loaiTaiKhoan = UserSession.Instance.LoaiTaiKhoan;
                dgvDiem.DataSource = diemBLL.LayDanhSach(maGV, loaiTaiKhoan);
                dgvDiem.Refresh();
                
                // Đặt lại header text nếu cần
                if (dgvDiem.Columns["MaLop"] != null) dgvDiem.Columns["MaLop"].HeaderText = "Mã Lớp";
                if (dgvDiem.Columns["MaSV"] != null) dgvDiem.Columns["MaSV"].HeaderText = "Mã SV";
                if (dgvDiem.Columns["TenSV"] != null) dgvDiem.Columns["TenSV"].HeaderText = "Tên Sinh Viên";
                if (dgvDiem.Columns["DiemCC"] != null) dgvDiem.Columns["DiemCC"].HeaderText = "Điểm CC";
                if (dgvDiem.Columns["DiemGK"] != null) dgvDiem.Columns["DiemGK"].HeaderText = "Điểm GK";
                if (dgvDiem.Columns["DiemThi"] != null) dgvDiem.Columns["DiemThi"].HeaderText = "Điểm Thi";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        #endregion

        #region Get & Clear Input

        /// <summary>
        /// Lấy dữ liệu từ các control trên Form và tạo đối tượng Score
        /// </summary>
        private Score GetScoreFromInputs()
        {
            double diemCC, diemGK, diemThi;

            Double.TryParse(txtDiemCC.Text, out diemCC);
            Double.TryParse(txtDiemGK.Text, out diemGK);
            Double.TryParse(txtDiemThi.Text, out diemThi);

            return new Score
            {
                MaLop = txtMaLop.Text.Trim(),
                MaSV = txtMaSV.Text.Trim(),
                DiemCc = diemCC,
                DiemGK = diemGK,
                DiemThi = diemThi
            };
        }

        /// <summary>
        /// Xóa trắng các trường nhập liệu
        /// </summary>
        private void ClearInputs()
        {
            txtMaLop.Clear();
            txtMaSV.Clear();
            txtTenSV.Clear();
            txtDiemCC.Text = "0";
            txtDiemGK.Text = "0";
            txtDiemThi.Text = "0";
            txtMaLop.Focus();
        }

        #endregion

        #region Button Click Events

        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            try
            {
                Score diem = GetScoreFromInputs();
                string maGV = UserSession.Instance.MaGV;
                string loaiTaiKhoan = UserSession.Instance.LoaiTaiKhoan;

                string result = diemBLL.ThemDiem(diem, maGV, loaiTaiKhoan);
                MessageBox.Show(result);

                if (result == "Thêm thành công!")
                {
                    LoadData();
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm điểm: " + ex.Message);
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            try
            {
                Score scoreToUpdate = GetScoreFromInputs();
                
                if (string.IsNullOrWhiteSpace(scoreToUpdate.MaLop) || string.IsNullOrWhiteSpace(scoreToUpdate.MaSV))
                {
                    MessageBox.Show("Vui lòng chọn điểm cần sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                string result = diemBLL.SuaDiem(scoreToUpdate);

                MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK, 
                    result.Contains("thành công") ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                
                if (result.Contains("Sửa thành công!") || result.Contains("thành công"))
                {
                    LoadData();
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maLop = txtMaLop.Text.Trim();
                string maSV = txtMaSV.Text.Trim();

                if (string.IsNullOrEmpty(maLop) || string.IsNullOrEmpty(maSV))
                {
                    MessageBox.Show("Vui lòng chọn điểm cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult confirm = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa điểm của SV {maSV} trong lớp {maLop}?", 
                    "Xác nhận xóa", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question
                );

                if (confirm == DialogResult.Yes)
                {
                    string result = diemBLL.XoaDiem(maLop, maSV);
                    
                    MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK, 
                        result.Contains("thành công") ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                    
                    if (result.Contains("Xóa thành công!") || result.Contains("thành công"))
                    {
                        LoadData();
                        ClearInputs();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnTim_Click(object sender, EventArgs e)
        {
            try
            {
                string maGV = UserSession.Instance.MaGV;
                string loaiTaiKhoan = UserSession.Instance.LoaiTaiKhoan;
                string maLop = txtSearchMaLop.Text.Trim();
                string maSV = txtSearchMaSV.Text.Trim();

                // Bỏ qua placeholders
                if (maLop == "Mã lớp...") maLop = "";
                if (maSV == "Nhập mã sinh viên...") maSV = "";

                if (string.IsNullOrWhiteSpace(maLop) && string.IsNullOrWhiteSpace(maSV))
                {
                    MessageBox.Show("Vui lòng nhập ít nhất Mã lớp hoặc Mã SV để tìm kiếm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable dt = diemBLL.TimKiem(maLop, maSV, maGV, loaiTaiKhoan);

                if (dt != null && dt.Rows.Count > 0)
                {
                    dgvDiem.DataSource = dt;
                    dgvDiem.Refresh();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dữ liệu phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvDiem.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }

        private void BtnTatCa_Click(object sender, EventArgs e)
        {
            LoadData();
            
            // Reset search boxes
            txtSearchMaSV.Text = "Nhập mã sinh viên...";
            txtSearchMaSV.ForeColor = System.Drawing.SystemColors.GrayText;
            txtSearchMaLop.Text = "Mã lớp...";
            txtSearchMaLop.ForeColor = System.Drawing.SystemColors.GrayText;
        }

        private void BtnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDiem.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                XuatRaExcel(dgvDiem);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region DataGridView Events

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dgvDiem.Rows.Count)
                {
                    DataGridViewRow row = dgvDiem.Rows[e.RowIndex];

                    txtMaLop.Text = row.Cells["MaLop"].Value?.ToString() ?? "";
                    txtMaSV.Text = row.Cells["MaSV"].Value?.ToString() ?? "";
                    txtTenSV.Text = row.Cells["TenSV"].Value?.ToString() ?? "";
                    txtDiemCC.Text = row.Cells["DiemCC"].Value?.ToString() ?? "0";
                    txtDiemGK.Text = row.Cells["DiemGK"].Value?.ToString() ?? "0";
                    txtDiemThi.Text = row.Cells["DiemThi"].Value?.ToString() ?? "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn dòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Export Excel

        private void XuatRaExcel(DataGridView dgv)
        {
            try
            {
                Excel.Application excelApp = new Excel.Application();
                excelApp.Application.Workbooks.Add(Type.Missing);

                // Đặt tiêu đề cột
                for (int i = 1; i <= dgv.Columns.Count; i++)
                {
                    excelApp.Cells[1, i] = dgv.Columns[i - 1].HeaderText;
                }

                // Ghi dữ liệu từng dòng
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        excelApp.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j].Value?.ToString();
                    }
                }

                // Hiện file Excel
                excelApp.Visible = true;

                MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}