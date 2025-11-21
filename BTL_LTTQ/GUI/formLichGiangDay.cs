using System;
using System.Windows.Forms;
using BTL_LTTQ.BLL.Schedule;
using Excel = Microsoft.Office.Interop.Excel;
using BTL_LTTQ.DTO;


namespace BTL_LTTQ.GUI
{
    public partial class formLichGiangDay : Form
    {
        ScheduleBLL scheduleBLL = new ScheduleBLL();

        public formLichGiangDay()
        {
            InitializeComponent();
            btnExportSchedule.Click += btnExportSchedule_Click;

        }

        private void formLichGiangDay_Load(object sender, EventArgs e)
        {
            InitializeScheduleGrid(); // Chỉ chạy hàm tạo 5 ca
        }

        #region HÀM KHỞI TẠO LƯỚI

        /// <summary>
        /// Khởi tạo 5 ca học cố định và cài đặt giao diện cho lưới
        /// </summary>
        private void InitializeScheduleGrid()
        {
            dgvSchedule.Rows.Clear();

            // Ngăn người dùng sort các cột
            foreach (DataGridViewColumn col in dgvSchedule.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;

            // === ĐỔ DỮ LIỆU CỐ ĐỊNH CHO 5 CA ===
            dgvSchedule.Rows.Add("Ca 1", "7h00 - 9h30");
            dgvSchedule.Rows.Add("Ca 2", "9h35 - 12h00");
            dgvSchedule.Rows.Add("Ca 3", "13h00 - 15h30");
            dgvSchedule.Rows.Add("Ca 4", "15h35 - 18h00");
            dgvSchedule.Rows.Add("Ca 5", "18h30 - 21h00");

            // === SỬA LỖI: Dùng "colCa" (từ file Designer) thay vì "colTiet" ===
            dgvSchedule.Columns["colCa"].HeaderText = "Ca";
            dgvSchedule.Columns["colCa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Căn giữa cột giờ
            dgvSchedule.Columns["colGio"].HeaderText = "Giờ";
            dgvSchedule.Columns["colGio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Tăng chiều cao từng dòng để hiển thị nhiều dòng text
            foreach (DataGridViewRow row in dgvSchedule.Rows)
                row.Height = 60;

            // Style cho các ô môn học
            var cellStyle = new DataGridViewCellStyle
            {
                WrapMode = DataGridViewTriState.True,
                Alignment = DataGridViewContentAlignment.TopLeft
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
        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                // 0. Kiểm tra mã GV trước để thông báo ngay nếu còn trống
                string maGV = txtMaGV.Text.Trim();
                if (string.IsNullOrWhiteSpace(maGV))
                {
                    MessageBox.Show("Vui lòng nhập mã giảng viên!");
                    txtMaGV.Focus();
                    return;
                }

                // 1. Kiểm tra combobox trước (tránh lỗi)
                if (cboHocKy.SelectedItem == null ||
                    cboNamHoc.SelectedItem == null ||
                    cboTuan.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn học kỳ, năm học và tuần!");
                    return;
                }

                // 2. Lấy dữ liệu từ combobox
                int hocKy = int.Parse(cboHocKy.SelectedItem.ToString());
                int namHoc = int.Parse(cboNamHoc.SelectedItem.ToString());
                int tuan = int.Parse(cboTuan.SelectedItem.ToString());

                // 3. Lấy khoảng tuần
                var (tuanStart, tuanEnd) = scheduleBLL.GetWeekRange(hocKy, namHoc, tuan);

                // 4. Lấy lịch
                var list = scheduleBLL.LoadSchedule(maGV, tuanStart, tuanEnd);

                // 5. Xoá lưới + add lại 5 ca
                InitializeScheduleGrid();

                // 6. Đổ dữ liệu vào lưới
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
                        dgvSchedule.Rows[rowIndex].Cells[colIndex].Value =
                            $"{item.MonHoc}\nPhòng: {item.Phong}\n({item.NgayBD:dd/MM} - {item.NgayKT:dd/MM})";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
   

        private void btnExportSchedule_Click(object sender, EventArgs e)
            {
                if (dgvSchedule.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!");
                    return;
                }

                Excel.Application excel = new Excel.Application();
                excel.Visible = false;
                Excel.Workbook wb = excel.Workbooks.Add(Type.Missing);
                Excel.Worksheet ws = (Excel.Worksheet)wb.ActiveSheet;

                ws.Name = "LichGiangDay";

                // Ghi header
                for (int col = 0; col < dgvSchedule.Columns.Count; col++)
                {
                    ws.Cells[1, col + 1] = dgvSchedule.Columns[col].HeaderText;
                }

                // Ghi dữ liệu
                for (int row = 0; row < dgvSchedule.Rows.Count; row++)
                {
                    for (int col = 0; col < dgvSchedule.Columns.Count; col++)
                    {
                        ws.Cells[row + 2, col + 1] = dgvSchedule.Rows[row].Cells[col].Value?.ToString();
                    }
                }

                // Chọn nơi lưu file
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel files (*.xlsx)|*.xlsx";
                sfd.FileName = "Lich_Giang_Day.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    wb.SaveAs(sfd.FileName);
                    wb.Close();
                    excel.Quit();
                    MessageBox.Show("Xuất Excel thành công!");
                }
            }




    #endregion

    // Tất cả các hàm khác liên quan đến BLL, tìm kiếm, 
    // tải ComboBox... đã được tạm thời loại bỏ.
}
}