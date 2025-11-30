using System;
using System.Data;
using BTL_LTTQ.DAL.Diem;
using BTL_LTTQ.DTO;

namespace BTL_LTTQ.BLL.Diem
{
    internal class DiemBLL
    {
        private DiemDAL dal = new DiemDAL();

        // Hàm hỗ trợ làm sạch chuỗi (xóa khoảng trắng và dấu *)
        private string CleanInput(string input)
        {
            if (string.IsNullOrEmpty(input)) return "";
            return input.Replace("*", "").Trim();
        }

        public DataTable LayDanhSach(string maGV, string loaiTaiKhoan)
        {
            return dal.GetAll(maGV, loaiTaiKhoan);
        }

        public string ThemDiem(Score diem, string maGV, string loaiTaiKhoan)
        {
            // Làm sạch input trước khi xử lý
            diem.MaSV = CleanInput(diem.MaSV);
            diem.MaLop = CleanInput(diem.MaLop);

            if (string.IsNullOrWhiteSpace(diem.MaSV) || string.IsNullOrWhiteSpace(diem.MaLop))
                return "Mã lớp hoặc Mã sinh viên không được để trống.";

            if (diem.DiemCc < 0 || diem.DiemCc > 10 ||
                diem.DiemGK < 0 || diem.DiemGK > 10 ||
                diem.DiemThi < 0 || diem.DiemThi > 10)
                return "Điểm phải từ 0 đến 10.";

            if (dal.CheckExist(diem.MaLop, diem.MaSV))
                return "Sinh viên này đã có điểm trong lớp này!";

            bool result = dal.Insert(diem, maGV, loaiTaiKhoan);
            return result ? "Thêm thành công!" : "Bạn không có quyền thêm điểm vào lớp này!";
        }

        public string SuaDiem(Score diem)
        {
            diem.MaSV = CleanInput(diem.MaSV);
            diem.MaLop = CleanInput(diem.MaLop);

            if (string.IsNullOrWhiteSpace(diem.MaSV) || string.IsNullOrWhiteSpace(diem.MaLop))
                return "Không tìm thấy Mã lớp hoặc Mã sinh viên.";

            if (diem.DiemCc < 0 || diem.DiemCc > 10 ||
                diem.DiemGK < 0 || diem.DiemGK > 10 ||
                diem.DiemThi < 0 || diem.DiemThi > 10)
                return "Điểm phải từ 0 đến 10.";

            return dal.Update(diem) ? "Sửa thành công!" : "Sửa thất bại!";
        }

        // ĐÃ SỬA: Loại bỏ CheckExist, gọi Delete trực tiếp
        public string XoaDiem(string MaLop, string MaSV)
        {
            // 1. Làm sạch input (quan trọng nhất để sửa lỗi của bạn)
            MaLop = CleanInput(MaLop);
            MaSV = CleanInput(MaSV);

            if (string.IsNullOrWhiteSpace(MaLop) || string.IsNullOrWhiteSpace(MaSV))
                return "Mã lớp hoặc Mã SV không hợp lệ!";

            // 2. Gọi lệnh Xóa luôn. 
            // Nếu xóa được (tồn tại và xóa xong) -> trả về true -> "Thành công"
            // Nếu không có gì để xóa (không tồn tại) -> trả về false -> "Thất bại"
            bool result = dal.Delete(MaLop, MaSV);

            return result ? "Xóa thành công!" : "Xóa thất bại (hoặc không tìm thấy điểm)!";
        }

        public DataTable TimKiem(string maLop, string maSV, string maGV, string loaiTaiKhoan)
        {
            return dal.Search(CleanInput(maLop), CleanInput(maSV), maGV, loaiTaiKhoan);
        }
    }
}