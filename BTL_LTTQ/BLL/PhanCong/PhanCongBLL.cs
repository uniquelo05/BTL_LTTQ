// BLL/PhanCongBLL.cs
using BTL_LTTQ.DAL;
using BTL_LTTQ.DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BTL_LTTQ.BLL
{
    public class PhanCongBLL
    {
        private PhanCongDAL dal = new PhanCongDAL();

        public DataTable LayTatCa() => dal.LayTatCa();

        public bool Them(PhanCongDTO pc)
        {
            if (dal.KiemTraLopDaPhanCong(pc.MaLop))
            {
                return false;
            }

            bool result = dal.Them(pc);
            
            if (result)
            {
                dal.CapNhatTinhTrangLop(pc.MaLop, true);
            }

            return result;
        }

        public bool Sua(PhanCongDTO pc, string maLopCu)
        {
            if (pc.MaLop != maLopCu && dal.KiemTraLopDaPhanCong(pc.MaLop))
            {
                return false;
            }

            bool result = dal.Sua(pc, maLopCu);

            if (result && pc.MaLop != maLopCu)
            {
                dal.CapNhatTinhTrangLop(maLopCu, false);
                dal.CapNhatTinhTrangLop(pc.MaLop, true);
            }

            return result;
        }

        public bool Xoa(string maPC, string maLop)
        {
            bool result = dal.Xoa(maPC, maLop);

            if (result)
            {
                dal.CapNhatTinhTrangLop(maLop, false);
            }

            return result;
        }

        public bool KiemTraMaPCTrung(string maPC) => dal.KiemTraMaPCTrung(maPC);
        public bool KiemTraTrungLichGV(string maGV, DateTime? ngayBD, DateTime? ngayKT, byte thu, byte caHoc, string maPC = null)
            => dal.KiemTraTrungLichGV(maGV, ngayBD, ngayKT, thu, caHoc, maPC);
        public bool KiemTraTrungPhong(string maPhong, DateTime? ngayBD, DateTime? ngayKT, byte thu, byte caHoc, string maPC = null)
            => dal.KiemTraTrungPhong(maPhong, ngayBD, ngayKT, thu, caHoc, maPC);
        public bool KiemTraLopDaPhanCong(string maLop) => dal.KiemTraLopDaPhanCong(maLop);

        // === CÁC PHƯƠNG THỨC HỖ TRỢ ===
        public DataTable LayKhuVuc()
        {
            string query = "SELECT MaKhuVuc, TenKhuVuc FROM KhuVuc";
            return DatabaseConnection.ExecuteQuery(query);
        }

        public DataTable LayPhongTheoKhuVuc(string maKhuVuc)
        {
            string query = "SELECT MaPhong FROM PhongHoc WHERE MaKhuVuc = @MaKhuVuc";
            return DatabaseConnection.ExecuteQuery(query, new[] { new SqlParameter("@MaKhuVuc", maKhuVuc) });
        }

        public DataTable LayKhoa()
        {
            string query = "SELECT MaKhoa, TenKhoa FROM Khoa";
            return DatabaseConnection.ExecuteQuery(query);
        }

        public DataTable LayMonHocTheoKhoa(string maKhoa)
        {
            string query = "SELECT MaMH, TenMH FROM MonHoc WHERE MaKhoa = @MaKhoa";
            return DatabaseConnection.ExecuteQuery(query, new[] { new SqlParameter("@MaKhoa", maKhoa) });
        }

        public DataTable LayMonHoc()
        {
            string query = "SELECT MaMH, TenMH FROM MonHoc";
            return DatabaseConnection.ExecuteQuery(query);
        }

        public DataTable LayGiangVien()
        {
            string query = "SELECT MaGV, TenGV FROM GiangVien";
            return DatabaseConnection.ExecuteQuery(query);
        }

        // ✅ SỬA: Tạo TenLop từ MaLop + TenMH
        public DataTable LayLopTinChiChuaPhanCong(string maMH)
        {
            string query = @"
                SELECT ltc.MaLop, 
                       ltc.MaLop + ' - ' + mh.TenMH AS TenLop
                FROM LopTinChi ltc
                INNER JOIN MonHoc mh ON ltc.MaMH = mh.MaMH
                WHERE ltc.MaMH = @MaMH
                  AND ltc.TinhTrangLop = 0
                ORDER BY ltc.MaLop";
            return DatabaseConnection.ExecuteQuery(query, new[] { new SqlParameter("@MaMH", maMH) });
        }

        // ✅ SỬA: Tạo TenLop từ MaLop + TenMH
        public DataTable LayLopTinChiDaPhanCong(string maMH)
        {
            string query = @"
                SELECT ltc.MaLop, 
                       ltc.MaLop + ' - ' + mh.TenMH AS TenLop
                FROM LopTinChi ltc
                INNER JOIN MonHoc mh ON ltc.MaMH = mh.MaMH
                WHERE ltc.MaMH = @MaMH
                  AND ltc.TinhTrangLop = 1
                ORDER BY ltc.MaLop";
            return DatabaseConnection.ExecuteQuery(query, new[] { new SqlParameter("@MaMH", maMH) });
        }
    }
}