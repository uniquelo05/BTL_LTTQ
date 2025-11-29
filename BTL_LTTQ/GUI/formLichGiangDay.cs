using System;
using System.Windows.Forms;
using BTL_LTTQ.BLL.Schedule;
using Excel = Microsoft.Office.Interop.Excel;
using BTL_LTTQ.DTO;
using BTL_LTTQ.BLL.Session; // Đừng quên import Session

namespace BTL_LTTQ.GUI
{
    public partial class formLichGiangDay : Form
    {
        private ScheduleBLL scheduleBLL = new ScheduleBLL();

        public formLichGiangDay()
        {
            InitializeComponent();
            this.Load += formLichGiangDay_Load;
        }

        #region Form Load

        private void formLichGiangDay_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeScheduleGrid();
                LoadComboBoxData();
                SetDefaultValues();
                AttachEvents();

                // --- PHÂN QUYỀN: CHỈNH SỬA TẠI ĐÂY ---
                ApplyPermissions();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo form: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyPermissions()
        {
            // Kiểm tra nếu người đăng nhập không phải Admin (tức là Giảng viên)
            if (!UserSession.Instance.IsAdmin())
            {
                // 1. Tự động điền mã GV của người đang đăng nhập
                txtMaGV.Text = UserSession.Instance.MaGV;

                // 2. Khóa ô nhập liệu để không cho sửa
                txtMaGV.Enabled = false;
                // Hoặc dùng: txtMaGV.ReadOnly = true;

                // 3. (Tùy chọn) Tự động load lịch luôn nếu đã chọn đủ thông tin mặc định
                // btnTimKiem_Click(null, null); 
            }
        }

        private void LoadComboBoxData()
        {
            // Load dữ liệu cho ComboBox Tuần (1-17)
            for (int i = 1; i <= 17; i++)
            {
                cboTuan.Items.Add(i.ToString());
            }
        }

        private void SetDefaultValues()
        {
            if (cboNamHoc.Items.Count > 0)
                cboNamHoc.SelectedIndex = cboNamHoc.Items.Count - 1; // Năm mới nhất

            if (cboHocKy.Items.Count > 0)
                cboHocKy.SelectedIndex = 0; // Học kỳ 1

            if (cboTuan.Items.Count > 0)
                cboTuan.SelectedIndex = 0; // Tuần 1
        }

        private void AttachEvents()
        {
            btnTimKiem.Click += btnTimKiem_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnXuatExcel.Click += btnXuatExcel_Click;
        }

        #endregion

        #region Khởi Tạo Lưới

        private void InitializeScheduleGrid(DateTime? tuanStart = null)
        {
            dgvSchedule.Rows.Clear();

            // Ngăn sort
            foreach (DataGridViewColumn col in dgvSchedule.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;

            dgvSchedule.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvSchedule.ColumnHeadersHeight = 60;

            // 5 ca cố định
            dgvSchedule.Rows.Add("Ca 1", "7h00 - 9h30", "", "", "", "", "", "", "");
            dgvSchedule.Rows.Add("Ca 2", "9h35 - 12h00", "", "", "", "", "", "", "");
            dgvSchedule.Rows.Add("Ca 3", "13h00 - 15h30", "", "", "", "", "", "", "");
            dgvSchedule.Rows.Add("Ca 4", "15h35 - 18h00", "", "", "", "", "", "", "");
            dgvSchedule.Rows.Add("Ca 5", "18h30 - 21h00", "", "", "", "", "", "", "");

            if (tuanStart.HasValue)
            {
                DateTime startDay = GetStartOfWeek(tuanStart.Value);

                dgvSchedule.Columns["colThuHai"].HeaderText = $"Thứ Hai\n({startDay:dd/MM})";
                dgvSchedule.Columns["colThuBa"].HeaderText = $"Thứ Ba\n({startDay.AddDays(1):dd/MM})";
                dgvSchedule.Columns["colThuTu"].HeaderText = $"Thứ Tư\n({startDay.AddDays(2):dd/MM})";
                dgvSchedule.Columns["colThuNam"].HeaderText = $"Thứ Năm\n({startDay.AddDays(3):dd/MM})";
                dgvSchedule.Columns["colThuSau"].HeaderText = $"Thứ Sáu\n({startDay.AddDays(4):dd/MM})";
                dgvSchedule.Columns["colThuBay"].HeaderText = $"Thứ Bảy\n({startDay.AddDays(5):dd/MM})";
                dgvSchedule.Columns["colChuNhat"].HeaderText = $"Chủ Nhật\n({startDay.AddDays(6):dd/MM})";
            }
            else
            {
                dgvSchedule.Columns["colThuHai"].HeaderText = "Thứ Hai";
                dgvSchedule.Columns["colThuBa"].HeaderText = "Thứ Ba";
                dgvSchedule.Columns["colThuTu"].HeaderText = "Thứ Tư";
                dgvSchedule.Columns["colThuNam"].HeaderText = "Thứ Năm";
                dgvSchedule.Columns["colThuSau"].HeaderText = "Thứ Sáu";
                dgvSchedule.Columns["colThuBay"].HeaderText = "Thứ Bảy";
                dgvSchedule.Columns["colChuNhat"].HeaderText = "Chủ Nhật";
            }

            // Style
            dgvSchedule.Columns["colCa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSchedule.Columns["colCa"].DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dgvSchedule.Columns["colGio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSchedule.Columns["colGio"].DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);

            var cellStyle = new DataGridViewCellStyle
            {
                WrapMode = DataGridViewTriState.True,
                Alignment = DataGridViewContentAlignment.TopLeft,
                Padding = new System.Windows.Forms.Padding(5),
                Font = new System.Drawing.Font("Segoe UI", 9F)
            };

            dgvSchedule.Columns["colThuHai"].DefaultCellStyle = cellStyle;
            dgvSchedule.Columns["colThuBa"].DefaultCellStyle = cellStyle;
            dgvSchedule.Columns["colThuTu"].DefaultCellStyle = cellStyle;
            dgvSchedule.Columns["colThuNam"].DefaultCellStyle = cellStyle;
            dgvSchedule.Columns["colThuSau"].DefaultCellStyle = cellStyle;
            dgvSchedule.Columns["colThuBay"].DefaultCellStyle = cellStyle;
            dgvSchedule.Columns["colChuNhat"].DefaultCellStyle = cellStyle;

            dgvSchedule.ClearSelection();
        }

        private DateTime GetStartOfWeek(DateTime date)
        {
            int diff = (7 + (date.DayOfWeek - DayOfWeek.Monday)) % 7;
            return date.AddDays(-1 * diff).Date;
        }

        #endregion

        #region Button Events

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Kiểm tra mã GV
                string maGV = txtMaGV.Text.Trim();
                if (string.IsNullOrWhiteSpace(maGV))
                {
                    MessageBox.Show("Vui lòng nhập mã giảng viên!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaGV.Focus();
                    return;
                }

                // 2. Kiểm tra combobox
                if (cboHocKy.SelectedItem == null ||
                    cboNamHoc.SelectedItem == null ||
                    cboTuan.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn đầy đủ năm học, học kỳ và tuần!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 3. Lấy dữ liệu
                int hocKy = int.Parse(cboHocKy.SelectedItem.ToString());
                int namHoc = int.Parse(cboNamHoc.SelectedItem.ToString());
                int tuan = int.Parse(cboTuan.SelectedItem.ToString());

                // 4. Lấy khoảng tuần
                var (tuanStart, tuanEnd) = scheduleBLL.GetWeekRange(hocKy, namHoc, tuan);

                // 5. Lấy lịch
                var list = scheduleBLL.LoadSchedule(maGV, tuanStart, tuanEnd);

                // 6. Xóa + khởi tạo lại
                InitializeScheduleGrid(tuanStart);

                // 7. Đổ dữ liệu
                foreach (var item in list)
                {
                    int rowIndex = item.CaHoc - 1;
                    int colIndex = -1;

                    switch (item.Thu)
                    {
                        case 2: colIndex = dgvSchedule.Columns["colThuHai"].Index; break;
                        case 3: colIndex = dgvSchedule.Columns["colThuBa"].Index; break;
                        case 4: colIndex = dgvSchedule.Columns["colThuTu"].Index; break;
                        case 5: colIndex = dgvSchedule.Columns["colThuNam"].Index; break;
                        case 6: colIndex = dgvSchedule.Columns["colThuSau"].Index; break;
                        case 7: colIndex = dgvSchedule.Columns["colThuBay"].Index; break;
                        case 8: colIndex = dgvSchedule.Columns["colChuNhat"].Index; break;
                    }

                    if (colIndex >= 0 && rowIndex >= 0 && rowIndex < dgvSchedule.Rows.Count)
                    {
                        string cellText = $"{item.MonHoc}\nPhòng: {item.Phong}\n({item.NgayBD:dd/MM} - {item.NgayKT:dd/MM})";
                        dgvSchedule.Rows[rowIndex].Cells[colIndex].Value = cellText;

                        // Highlight
                        dgvSchedule.Rows[rowIndex].Cells[colIndex].Style.BackColor =
                            System.Drawing.Color.FromArgb(225, 245, 254);
                        dgvSchedule.Rows[rowIndex].Cells[colIndex].Style.ForeColor =
                            System.Drawing.Color.FromArgb(1, 87, 155);
                    }
                }

                // Chỉ hiện thông báo nếu là Admin hoặc người dùng tự bấm nút
                // MessageBox.Show($"✅ Đã tải lịch giảng dạy tuần {tuan} - Học kỳ {hocKy}/{namHoc}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xem lịch: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            // Reset về trạng thái ban đầu
            // NẾU LÀ ADMIN THÌ MỚI ĐƯỢC XÓA MÃ GV
            if (UserSession.Instance.IsAdmin())
            {
                txtMaGV.Clear();
            }
            // NẾU LÀ GIẢNG VIÊN THÌ GIỮ NGUYÊN MÃ

            SetDefaultValues();
            InitializeScheduleGrid();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSchedule.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Excel.Application excel = new Excel.Application();
                excel.Visible = false;
                Excel.Workbook wb = excel.Workbooks.Add(Type.Missing);
                Excel.Worksheet ws = (Excel.Worksheet)wb.ActiveSheet;

                ws.Name = "LichGiangDay";

                // Header
                for (int col = 0; col < dgvSchedule.Columns.Count; col++)
                {
                    ws.Cells[1, col + 1] = dgvSchedule.Columns[col].HeaderText;
                    ((Excel.Range)ws.Cells[1, col + 1]).Font.Bold = true;
                    ((Excel.Range)ws.Cells[1, col + 1]).Interior.Color =
                        System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 150, 136));
                    ((Excel.Range)ws.Cells[1, col + 1]).Font.Color =
                        System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                }

                // Data
                for (int row = 0; row < dgvSchedule.Rows.Count; row++)
                {
                    for (int col = 0; col < dgvSchedule.Columns.Count; col++)
                    {
                        ws.Cells[row + 2, col + 1] = dgvSchedule.Rows[row].Cells[col].Value?.ToString();
                    }
                }

                ws.Columns.AutoFit();

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel files (*.xlsx)|*.xlsx";
                sfd.FileName = $"Lich_Giang_Day_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    wb.SaveAs(sfd.FileName);
                    wb.Close();
                    excel.Quit();
                    MessageBox.Show($"✅ XUẤT EXCEL THÀNH CÔNG!\n\nĐường dẫn: {sfd.FileName}",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    wb.Close();
                    excel.Quit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xuất Excel: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}