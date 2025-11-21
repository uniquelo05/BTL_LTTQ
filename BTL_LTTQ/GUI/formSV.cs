// formSV.cs - PHIÊN BẢN HOÀN CHỈNH VỚI XUẤT EXCEL
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BTL_LTTQ.BLL;
using BTL_LTTQ.DTO;

namespace BTL_LTTQ
{
    public partial class formSV : Form
    {
        private SinhVienBLL svBLL = new SinhVienBLL();
        private string maLopHienTai = "";
        private bool isLoadingData = false;

        public formSV()
        {
            InitializeComponent();
            CauHinhPlaceholder();
            CauHinhNgaySinh();
        }

        private void formSV_Load(object sender, EventArgs e)
        {
            isLoadingData = true;
            LoadKhoa();
            LoadTatCaLopTinChi();
            SetupDataGridView();
            LoadTatCaSinhVien();
            KhoiTaoTrangThaiThemMoi();
            isLoadingData = false;

            cmbTimTheoKhoa.SelectedIndexChanged += cmbTimTheoKhoa_SelectedIndexChanged;
            cmbTimTheoLop.SelectedIndexChanged += cmbTimTheoLop_SelectedIndexChanged;
            tbTimKiemTheoMa.TextChanged += tbTimKiemTheoMa_TextChanged;
            dgvSV.CellDoubleClick += dgvSV_CellDoubleClick;
            dgvSV.CellClick += dgvSV_CellClick;
            btnTimKiem.Click += btnTimKiem_Click;
            btnTatCa.Click += btnTatCa_Click;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnXuatExcel.Click += btnXuatExcel_Click; // ✅ THÊM SỰ KIỆN XUẤT EXCEL
        }

        #region CẤU HÌNH
        private void CauHinhNgaySinh()
        {
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.ShowUpDown = false;
        }

        private void CauHinhPlaceholder()
        {
            tbTimKiemTheoMa.Text = "Nhập mã sinh viên...";
            tbTimKiemTheoMa.ForeColor = SystemColors.GrayText;

            tbTimKiemTheoMa.GotFocus += (s, e) =>
            {
                if (tbTimKiemTheoMa.Text == "Nhập mã sinh viên...")
                {
                    tbTimKiemTheoMa.Text = "";
                    tbTimKiemTheoMa.ForeColor = SystemColors.WindowText;
                }
            };
            tbTimKiemTheoMa.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(tbTimKiemTheoMa.Text))
                {
                    tbTimKiemTheoMa.Text = "Nhập mã sinh viên...";
                    tbTimKiemTheoMa.ForeColor = SystemColors.GrayText;
                }
            };
        }
        #endregion

        #region DATA GRID VIEW
        private void SetupDataGridView()
        {
            dgvSV.AutoGenerateColumns = false;
            dgvSV.Columns.Clear();

            string[] colNames = { "MaSV", "TenSV", "GioiTinh", "NgaySinh", "QueQuan", "SDT", "Email", "TenKhoa", "TenLop" };
            string[] headers = { "Mã SV", "Họ tên", "Giới tính", "Ngày sinh", "Quê quán", "SĐT", "Email", "Khoa", "Lớp tín chỉ" };

            for (int i = 0; i < colNames.Length; i++)
            {
                var col = new DataGridViewTextBoxColumn
                {
                    Name = colNames[i],
                    HeaderText = headers[i],
                    DataPropertyName = colNames[i],
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                };
                if (colNames[i] == "NgaySinh")
                    col.DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvSV.Columns.Add(col);
            }

            dgvSV.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaLop",
                DataPropertyName = "MaLop",
                Visible = false
            });
        }
        #endregion

        #region LOAD DỮ LIỆU
        private void LoadKhoa()
        {
            try
            {
                var dt = svBLL.LayKhoa();
                DataRow empty = dt.NewRow();
                empty["MaKhoa"] = DBNull.Value;
                empty["TenKhoa"] = "-- Chọn khoa --";
                dt.Rows.InsertAt(empty, 0);

                cmbTimTheoKhoa.DataSource = dt.Copy();
                cmbTimTheoKhoa.DisplayMember = "TenKhoa";
                cmbTimTheoKhoa.ValueMember = "MaKhoa";
                cmbTimTheoKhoa.SelectedIndex = 0;

                cmbKhoa.DataSource = dt.Copy();
                cmbKhoa.DisplayMember = "TenKhoa";
                cmbKhoa.ValueMember = "MaKhoa";
                cmbKhoa.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load khoa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTatCaLopTinChi()
        {
            try
            {
                var dt = svBLL.LayTatCaLopTinChi();
                DataRow empty = dt.NewRow();
                empty["MaLop"] = DBNull.Value;
                empty["TenLop"] = "-- Chọn lớp --";
                dt.Rows.InsertAt(empty, 0);

                cmbTimTheoLop.DataSource = dt;
                cmbTimTheoLop.DisplayMember = "TenLop";
                cmbTimTheoLop.ValueMember = "MaLop";
                cmbTimTheoLop.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load lớp: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTatCaSinhVien()
        {
            try
            {
                var dt = svBLL.TimKiem("", "", "");
                dgvSV.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load sinh viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region ĐỒNG BỘ KHOA & LỚP
        private void DongBoKhoaLopChiTiet()
        {
            if (isLoadingData) return;

            try
            {
                if (cmbTimTheoKhoa.SelectedValue != null && cmbTimTheoKhoa.SelectedValue.ToString() != "System.DBNull")
                {
                    string maKhoa = cmbTimTheoKhoa.SelectedValue.ToString();
                    if (cmbKhoa.SelectedValue?.ToString() != maKhoa)
                        cmbKhoa.SelectedValue = maKhoa;
                }

                if (cmbTimTheoLop.SelectedValue != null && cmbTimTheoLop.SelectedValue.ToString() != "System.DBNull")
                {
                    string maLop = cmbTimTheoLop.SelectedValue.ToString();
                    maLopHienTai = maLop;

                    string maKhoa = cmbTimTheoKhoa.SelectedValue?.ToString() ?? "";
                    DataTable dtLop = string.IsNullOrEmpty(maKhoa) || maKhoa == "System.DBNull"
                        ? svBLL.LayTatCaLopTinChi()
                        : svBLL.LayLopTinChiTheoKhoa(maKhoa);

                    cmbMaLopTC.DataSource = dtLop;
                    cmbMaLopTC.DisplayMember = "TenLop";
                    cmbMaLopTC.ValueMember = "MaLop";
                    cmbMaLopTC.SelectedValue = maLop;
                    cmbMaLopTC.Enabled = false;
                }
                else
                {
                    maLopHienTai = "";
                    cmbMaLopTC.DataSource = null;
                    cmbMaLopTC.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi đồng bộ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DongBoTuSinhVienLenTimKiem(string tenKhoa, string maLop)
        {
            if (isLoadingData) return;

            try
            {
                isLoadingData = true;

                for (int i = 0; i < cmbTimTheoKhoa.Items.Count; i++)
                {
                    var item = cmbTimTheoKhoa.Items[i] as DataRowView;
                    if (item != null && item["TenKhoa"].ToString() == tenKhoa)
                    {
                        cmbTimTheoKhoa.SelectedIndex = i;
                        break;
                    }
                }

                string maKhoa = cmbTimTheoKhoa.SelectedValue?.ToString() ?? "";
                if (!string.IsNullOrEmpty(maKhoa) && maKhoa != "System.DBNull")
                {
                    var dtLop = svBLL.LayLopTinChiTheoKhoa(maKhoa);
                    DataRow empty = dtLop.NewRow();
                    empty["MaLop"] = DBNull.Value;
                    empty["TenLop"] = "-- Chọn lớp --";
                    dtLop.Rows.InsertAt(empty, 0);

                    cmbTimTheoLop.DataSource = dtLop;
                    cmbTimTheoLop.DisplayMember = "TenLop";
                    cmbTimTheoLop.ValueMember = "MaLop";

                    if (!string.IsNullOrEmpty(maLop))
                        cmbTimTheoLop.SelectedValue = maLop;
                }

                isLoadingData = false;
                TimKiemTuDong();
            }
            catch (Exception ex)
            {
                isLoadingData = false;
                MessageBox.Show($"Lỗi đồng bộ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region LỌC THEO KHOA & LỚP
        private void cmbTimTheoKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoadingData) return;

            try
            {
                if (cmbTimTheoKhoa.SelectedIndex <= 0 || cmbTimTheoKhoa.SelectedValue == null)
                {
                    isLoadingData = true;
                    LoadTatCaLopTinChi();
                    isLoadingData = false;
                    TimKiemTuDong();
                    return;
                }

                string maKhoa = cmbTimTheoKhoa.SelectedValue.ToString();
                if (string.IsNullOrEmpty(maKhoa) || maKhoa == "System.DBNull")
                {
                    isLoadingData = true;
                    LoadTatCaLopTinChi();
                    isLoadingData = false;
                    TimKiemTuDong();
                    return;
                }

                isLoadingData = true;
                var dtLop = svBLL.LayLopTinChiTheoKhoa(maKhoa);
                DataRow empty = dtLop.NewRow();
                empty["MaLop"] = DBNull.Value;
                empty["TenLop"] = "-- Chọn lớp --";
                dtLop.Rows.InsertAt(empty, 0);

                cmbTimTheoLop.DataSource = dtLop;
                cmbTimTheoLop.DisplayMember = "TenLop";
                cmbTimTheoLop.ValueMember = "MaLop";
                cmbTimTheoLop.SelectedIndex = 0;
                isLoadingData = false;

                TimKiemTuDong();
            }
            catch (Exception ex)
            {
                isLoadingData = false;
                MessageBox.Show($"Lỗi chọn khoa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbTimTheoLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoadingData) return;

            try
            {
                if (cmbTimTheoLop.SelectedValue != null && cmbTimTheoLop.SelectedValue.ToString() != "System.DBNull")
                    maLopHienTai = cmbTimTheoLop.SelectedValue.ToString();
                else
                    maLopHienTai = "";

                TimKiemTuDong();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chọn lớp: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbTimKiemTheoMa_TextChanged(object sender, EventArgs e)
        {
            if (tbTimKiemTheoMa.Text == "Nhập mã sinh viên...")
                return;
            TimKiemTuDong();
        }

        private void TimKiemTuDong()
        {
            if (isLoadingData) return;

            try
            {
                string maKhoa = "";
                string maLop = "";
                string maSV = tbTimKiemTheoMa.Text.Trim();

                if (cmbTimTheoKhoa.SelectedValue != null && cmbTimTheoKhoa.SelectedValue.ToString() != "System.DBNull")
                    maKhoa = cmbTimTheoKhoa.SelectedValue.ToString();

                if (cmbTimTheoLop.SelectedValue != null && cmbTimTheoLop.SelectedValue.ToString() != "System.DBNull")
                    maLop = cmbTimTheoLop.SelectedValue.ToString();

                if (maSV == "Nhập mã sinh viên...")
                    maSV = "";

                var dt = svBLL.TimKiem(maKhoa, maLop, maSV);
                dgvSV.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region NÚT TÌM & TẤT CẢ
        private void btnTimKiem_Click(object sender, EventArgs e) => TimKiemTuDong();

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            isLoadingData = true;
            cmbTimTheoKhoa.SelectedIndex = 0;
            LoadTatCaLopTinChi();
            tbTimKiemTheoMa.Text = "Nhập mã sinh viên...";
            tbTimKiemTheoMa.ForeColor = SystemColors.GrayText;
            isLoadingData = false;
            LoadTatCaSinhVien();
            KhoiTaoTrangThaiThemMoi();
            ResetHighlight();
        }
        #endregion

        #region VALIDATE
        private bool ValidateInput()
        {
            if (!string.IsNullOrWhiteSpace(tbSoDt.Text))
            {
                if (!Regex.IsMatch(tbSoDt.Text.Trim(), @"^\d{10}$"))
                {
                    MessageBox.Show("Số điện thoại phải đúng 10 chữ số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbSoDt.Focus();
                    return false;
                }
            }

            if (!string.IsNullOrWhiteSpace(tbEmail.Text))
            {
                if (!Regex.IsMatch(tbEmail.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Email phải có định dạng: abc@domain.com", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbEmail.Focus();
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region TRẠNG THÁI FORM
        private void KhoiTaoTrangThaiThemMoi()
        {
            tbMaSV.Clear(); tbMaSV.Enabled = true;
            tbHoTen.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            rdoNam.Checked = true;
            tbDiaChi.Clear(); tbSoDt.Clear(); tbEmail.Clear();
            cmbMaLopTC.Enabled = !string.IsNullOrEmpty(maLopHienTai);
            ResetHighlight();
        }

        private void KhoiTaoTrangThaiSua()
        {
            tbMaSV.Enabled = false;
            cmbKhoa.Enabled = false;
            cmbMaLopTC.Enabled = false;
        }
        #endregion

        #region THÊM SINH VIÊN
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maLopHienTai))
            {
                MessageBox.Show("Vui lòng chọn lớp tín chỉ ở phần tìm kiếm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maSV = tbMaSV.Text.Trim();
            if (string.IsNullOrWhiteSpace(maSV))
            {
                MessageBox.Show("Nhập Mã SV!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (svBLL.KiemTraSVTrongLop(maSV, maLopHienTai))
            {
                MessageBox.Show($"Sinh viên {maSV} đã tồn tại trong lớp này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ✅ KIỂM TRA SINH VIÊN ĐÃ TỒN TẠI
            var svTonTai = svBLL.LaySinhVienTheoMa(maSV);
            if (svTonTai != null)
            {
                // ✅ HIỂN THỊ THÔNG TIN CHI TIẾT VÀ HỎI XÁC NHẬN
                string msg = $"SINH VIÊN ĐÃ TỒN TẠI TRONG HỆ THỐNG!\n\n" +
                             $"📋 THÔNG TIN SINH VIÊN:\n" +
                             $"━━━━━━━━━━━━━━━━━━━━━━━━━━━━\n" +
                             $"Mã SV: {svTonTai.MaSV}\n" +
                             $"Họ tên: {svTonTai.TenSV}\n" +
                             $"Giới tính: {svTonTai.GioiTinh}\n" +
                             $"Ngày sinh: {(svTonTai.NgaySinh.HasValue ? svTonTai.NgaySinh.Value.ToString("dd/MM/yyyy") : "Chưa có")}\n" +
                             $"Quê quán: {(string.IsNullOrEmpty(svTonTai.QueQuan) ? "Chưa có" : svTonTai.QueQuan)}\n" +
                             $"SĐT: {(string.IsNullOrEmpty(svTonTai.SDT) ? "Chưa có" : svTonTai.SDT)}\n" +
                             $"Email: {(string.IsNullOrEmpty(svTonTai.Email) ? "Chưa có" : svTonTai.Email)}\n" +
                             $"━━━━━━━━━━━━━━━━━━━━━━━━━━━━\n\n" +
                             $"⚠ BẠN CÓ MUỐN THÊM SINH VIÊN NÀY VÀO LỚP HIỆN TẠI KHÔNG?\n\n" +
                             $"Lớp: {cmbTimTheoLop.Text}";

                DialogResult result = MessageBox.Show(msg, "Xác nhận thêm sinh viên đã tồn tại", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                {
                    tbMaSV.Focus();
                    return;
                }

                // ✅ TỰ ĐỘNG ĐIỀN THÔNG TIN VÀO FORM
                tbHoTen.Text = svTonTai.TenSV;
                dtpNgaySinh.Value = svTonTai.NgaySinh ?? DateTime.Now;
                rdoNam.Checked = svTonTai.GioiTinh == "Nam";
                rdoNu.Checked = svTonTai.GioiTinh != "Nam";
                tbDiaChi.Text = svTonTai.QueQuan;
                tbSoDt.Text = svTonTai.SDT;
                tbEmail.Text = svTonTai.Email;
                if (!string.IsNullOrEmpty(svTonTai.MaKhoa))
                    cmbKhoa.SelectedValue = svTonTai.MaKhoa;
            }
            else
            {
                // SINH VIÊN MỚI → YÊU CẦU NHẬP ĐẦY ĐỦ THÔNG TIN
                if (string.IsNullOrWhiteSpace(tbHoTen.Text))
                {
                    MessageBox.Show("Nhập Họ tên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!ValidateInput()) return;
            }

            // THỰC HIỆN THÊM VÀO DATABASE
            var sv = new SinhVienDTO
            {
                MaSV = maSV,
                TenSV = tbHoTen.Text.Trim(),
                NgaySinh = dtpNgaySinh.Value,
                GioiTinh = rdoNam.Checked ? "Nam" : "Nữ",
                QueQuan = tbDiaChi.Text.Trim(),
                SDT = tbSoDt.Text.Trim(),
                Email = tbEmail.Text.Trim(),
                MaKhoa = cmbKhoa.SelectedValue?.ToString() ?? "",
                MaLop = maLopHienTai
            };

            if (svBLL.Them(sv))
            {
                MessageBox.Show($"✅ THÊM THÀNH CÔNG!\n\nSinh viên {sv.TenSV} ({sv.MaSV}) đã được thêm vào lớp {cmbTimTheoLop.Text}", 
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TimKiemTuDong();
                HighlightSinhVien(maSV);
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region SỬA / XÓA / LÀM MỚI
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbMaSV.Text))
            {
                MessageBox.Show("Chọn sinh viên để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput()) return;

            string maSVDangChon = tbMaSV.Text.Trim();

            var sv = new SinhVienDTO
            {
                MaSV = maSVDangChon,
                TenSV = tbHoTen.Text.Trim(),
                NgaySinh = dtpNgaySinh.Value,
                GioiTinh = rdoNam.Checked ? "Nam" : "Nữ",
                QueQuan = tbDiaChi.Text.Trim(),
                SDT = tbSoDt.Text.Trim(),
                Email = tbEmail.Text.Trim()
            };

            if (svBLL.Sua(sv))
            {
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TimKiemTuDong();
                HighlightSinhVien(maSVDangChon);
            }
            else
            {
                MessageBox.Show("Sửa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maLopHienTai) || string.IsNullOrWhiteSpace(tbMaSV.Text))
            {
                MessageBox.Show("Chọn lớp và sinh viên để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Xóa sinh viên {tbMaSV.Text} khỏi lớp?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (svBLL.Xoa(tbMaSV.Text.Trim(), maLopHienTai))
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TimKiemTuDong();
                    KhoiTaoTrangThaiThemMoi();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            KhoiTaoTrangThaiThemMoi();
        }
        #endregion

        #region CLICK SINH VIÊN
        private void dgvSV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            LoadChiTietSinhVien(e.RowIndex);
        }

        private void dgvSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            LoadChiTietSinhVien(e.RowIndex);
        }

        private void LoadChiTietSinhVien(int rowIndex)
        {
            try
            {
                var row = dgvSV.Rows[rowIndex];
                string maSV = row.Cells["MaSV"].Value?.ToString() ?? "";

                tbMaSV.Text = maSV;
                tbHoTen.Text = row.Cells["TenSV"].Value?.ToString() ?? "";
                dtpNgaySinh.Value = row.Cells["NgaySinh"].Value is DateTime dt ? dt : DateTime.Today;
                rdoNam.Checked = row.Cells["GioiTinh"].Value?.ToString() == "Nam";
                rdoNu.Checked = !rdoNam.Checked;
                tbDiaChi.Text = row.Cells["QueQuan"].Value?.ToString() ?? "";
                tbSoDt.Text = row.Cells["SDT"].Value?.ToString() ?? "";
                tbEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";

                string tenKhoa = row.Cells["TenKhoa"].Value?.ToString() ?? "";
                string maLop = row.Cells["MaLop"].Value?.ToString() ?? "";

                if (!string.IsNullOrEmpty(tenKhoa) && !string.IsNullOrEmpty(maLop))
                {
                    DongBoTuSinhVienLenTimKiem(tenKhoa, maLop);
                    HighlightSinhVien(maSV);
                }

                DongBoKhoaLopChiTiet();
                KhoiTaoTrangThaiSua();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load chi tiết: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region HIGHLIGHT SINH VIÊN
        private void HighlightSinhVien(string maSV)
        {
            if (dgvSV.Rows.Count == 0 || string.IsNullOrEmpty(maSV)) return;

            foreach (DataGridViewRow row in dgvSV.Rows)
            {
                if (row.Cells["MaSV"].Value?.ToString() == maSV)
                {
                    row.Selected = true;
                    if (row.Index >= 0 && row.Index < dgvSV.Rows.Count)
                        dgvSV.FirstDisplayedScrollingRowIndex = row.Index;

                    row.DefaultCellStyle.BackColor = Color.FromArgb(178, 223, 219);
                    row.DefaultCellStyle.ForeColor = Color.Black;
                    row.DefaultCellStyle.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
                }
                else
                {
                    row.DefaultCellStyle.BackColor = SystemColors.Window;
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
                    row.DefaultCellStyle.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular);
                }
            }
        }

        private void ResetHighlight()
        {
            foreach (DataGridViewRow row in dgvSV.Rows)
            {
                row.DefaultCellStyle.BackColor = SystemColors.Window;
                row.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
                row.DefaultCellStyle.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular);
            }
        }
        #endregion

        #region ✅ XUẤT EXCEL
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSV.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string tenLop = cmbTimTheoLop.SelectedIndex > 0 
                    ? cmbTimTheoLop.Text.Replace(" - ", "_").Replace(" ", "_")
                    : "TatCa";
                
                string tenKhoa = cmbTimTheoKhoa.SelectedIndex > 0 
                    ? cmbTimTheoKhoa.Text.Replace(" - ", "_").Replace(" ", "_")
                    : "TatCa";

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Files (*.csv)|*.csv|All Files (*.*)|*.*";
                sfd.FileName = $"DanhSach_SinhVien_{tenLop}_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                sfd.Title = "Lưu file Excel";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExportToCSV(sfd.FileName, tenKhoa, tenLop);
                    
                    DialogResult result = MessageBox.Show(
                        $"✅ XUẤT FILE THÀNH CÔNG!\n\n" +
                        $"Đường dẫn: {sfd.FileName}\n" +
                        $"Tổng số sinh viên: {dgvSV.Rows.Count}\n\n" +
                        "Bạn có muốn mở file ngay không?",
                        "Xuất Excel thành công",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information);

                    if (result == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(sfd.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất file: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportToCSV(string filePath, string tenKhoa, string tenLop)
        {
            StringBuilder sb = new StringBuilder();

            using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                sb.AppendLine("DANH SÁCH SINH VIÊN");
                sb.AppendLine($"Khoa: {tenKhoa}");
                sb.AppendLine($"Lớp tín chỉ: {tenLop}");
                sb.AppendLine($"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                sb.AppendLine($"Tổng số sinh viên: {dgvSV.Rows.Count}");
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
                            
                            if (cellValue is DateTime dt)
                                return EscapeCSV(dt.ToString("dd/MM/yyyy"));
                            
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
    }
}