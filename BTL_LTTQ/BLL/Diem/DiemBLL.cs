// Trong file BLL/Diem/DiemBLL.cs
// Giữ nguyên logic đã sửa để nhất quán với DiemDAL

using System;
using System.Data;
using BTL_LTTQ.DAL.Diem;
using BTL_LTTQ.DTO;

namespace BTL_LTTQ.BLL.Diem
{
    internal class DiemBLL
    {
        private DiemDAL dal = new DiemDAL();

        public DataTable LayDanhSach(string maGV, string loaiTaiKhoan)
        {
            return dal.GetAll(maGV, loaiTaiKhoan);
        }

        public string ThemDiem(Score diem, string maGV, string loaiTaiKhoan)
        {
            // Bỏ kiem tra TenSV vi da xoa khoi DTO
            if (string.IsNullOrWhiteSpace(diem.MaSV) ||
                string.IsNullOrWhiteSpace(diem.MaLop))
                return "Mã lớp hoặc Mã sinh viên không được để trống.";

            // Kiểm tra giá trị điểm hợp lệ (0-10)
            if (diem.DiemCc < 0 || diem.DiemCc > 10 ||
                diem.DiemGK < 0 || diem.DiemGK > 10 ||
                diem.DiemThi < 0 || diem.DiemThi > 10)
                return "Điểm phải nằm trong khoảng từ 0 đến 10.";

            // CheckExist nay phai dung MaLop va MaSV
            if (dal.CheckExist(diem.MaLop, diem.MaSV))
                return "Sinh viên này đã có điểm trong lớp này!";

            // Gọi DAL để thêm điểm, kiểm tra quyền của giảng viên
            bool result = dal.Insert(diem, maGV, loaiTaiKhoan);
            if (!result)
            {
                return "Bạn không có quyền thêm điểm vào lớp này!";
            }

            return "Thêm thành công!";
        }

        public string SuaDiem(Score diem)
        {
            // Kiểm tra khóa chính
            if (string.IsNullOrWhiteSpace(diem.MaSV) || string.IsNullOrWhiteSpace(diem.MaLop))
                return "Không tìm thấy Mã lớp hoặc Mã sinh viên để cập nhật.";

            // Kiểm tra giá trị điểm hợp lệ (0-10)
            if (diem.DiemCc < 0 || diem.DiemCc > 10 ||
                diem.DiemGK < 0 || diem.DiemGK > 10 ||
                diem.DiemThi < 0 || diem.DiemThi > 10)
                return "Điểm phải nằm trong khoảng từ 0 đến 10.";

            return dal.Update(diem) ? "Sửa thành công!" : "Sửa thất bại!";
        }

        // **Đã sửa lỗi**: Đổi tên hàm và thêm MaLop để xóa chính xác
        public string XoaDiem(string MaLop, string MaSV) // Nhận: MaLop, MaSV
        {
            // ... kiểm tra tồn tại
            if (!dal.CheckExist(MaLop, MaSV))
                return "Không tìm thấy bản ghi điểm này để xóa!";

            // SỬA: Đổi thứ tự tham số thành (MaLop, MaSV) để khớp với DAL mới
            return dal.Delete(MaLop, MaSV) ? "Xóa thành công!" : "Xóa thất bại!";
        }
        //tìm kiếm theo mã lớp tc/ mã sv  
        public DataTable TimKiem(string maLop, string maSV, string maGV, string loaiTaiKhoan)
        {
            return dal.Search(maLop, maSV, maGV, loaiTaiKhoan);
        }

    }
}