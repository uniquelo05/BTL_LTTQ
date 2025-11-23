using System;
using System.Windows.Forms;
using BTL_LTTQ.BLL.Schedule;
using Excel = Microsoft.Office.Interop.Excel;
using BTL_LTTQ.DTO;

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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo form: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // ✅ ĐỔI TÊN: btnXem -> btnTimKiem
            btnTimKiem.Click += btnTimKiem_Click;
            
            // ✅ ĐỔI TÊN: btnSearch -> btnLamMoi
            btnLamMoi.Click += btnLamMoi_Click;
            
            // ✅ ĐỔI TÊN: btnExportSchedule -> btnXuatExcel
            btnXuatExcel.Click += btnXuatExcel_Click;
        }

        #endregion

        #region Khởi Tạo Lưới

        private void InitializeScheduleGrid()
        {
            dgvSchedule.Rows.Clear();

            // Ngăn sort
            foreach (DataGridViewColumn col in dgvSchedule.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;

            // ✅ 5 ca cố định
            dgvSchedule.Rows.Add("Ca 1", "7h00 - 9h30", "", "", "", "", "", "", "");
            dgvSchedule.Rows.Add("Ca 2", "9h35 - 12h00", "", "", "", "", "", "", "");
            dgvSchedule.Rows.Add("Ca 3", "13h00 - 15h30", "", "", "", "", "", "", "");
            dgvSchedule.Rows.Add("Ca 4", "15h35 - 18h00", "", "", "", "", "", "", "");
            dgvSchedule.Rows.Add("Ca 5", "18h30 - 21h00", "", "", "", "", "", "", "");

            // Style cho cột Ca và Giờ
            dgvSchedule.Columns["colCa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSchedule.Columns["colCa"].DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            
            dgvSchedule.Columns["colGio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSchedule.Columns["colGio"].DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);

            // Style cho các ô môn học
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

        #endregion

        #region Button Events

        private void btnTimKiem_Click(object sender, EventArgs e) // ✅ ĐỔI TÊN TỪ btnXem_Click
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
                InitializeScheduleGrid();

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

                MessageBox.Show($"✅ Đã tải lịch giảng dạy tuần {tuan} - Học kỳ {hocKy}/{namHoc}", 
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xem lịch: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e) // ✅ ĐỔI TÊN TỪ btnSearch_Click
        {
            // Reset về trạng thái ban đầu
            txtMaGV.Clear();
            SetDefaultValues();
            InitializeScheduleGrid();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e) // ✅ ĐỔI TÊN TỪ btnExportSchedule_Click
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

                // Auto-fit columns
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