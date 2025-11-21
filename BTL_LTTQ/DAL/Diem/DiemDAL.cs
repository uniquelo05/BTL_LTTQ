using BTL_LTTQ.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BTL_LTTQ.DAL.Diem
{
    internal class DiemDAL
    {
        // Lấy toàn bộ danh sách điểm
        public DataTable GetAll()
        {
            string query = @"SELECT d.MaSV, sv.TenSV, d.MaLop, d.DiemCC, d.DiemGK, d.DiemThi, d.DiemKTHP
                             FROM Diem d 
                             JOIN SinhVien sv ON d.MaSV = sv.MaSV";
            return DatabaseConnection.ExecuteQuery(query);
        }

        // Thêm mới điểm
        public bool Insert(Score diem)
        {
            string query = @"
                INSERT INTO Diem (MaLop, MaSV, DiemCC, DiemGK, DiemThi, DiemKTHP)
                SELECT 
                    @MaLop, 
                    @MaSV, 
                    @DiemCc, 
                    @DiemGK, 
                    @DiemThi,
                    ROUND(((@DiemCc * 0.1 + @DiemGK * 0.9) * mh.HeSoDQT + @DiemThi * mh.HeSoThi), 2)
                FROM LopTinChi ltc
                JOIN MonHoc mh ON ltc.MaMH = mh.MaMH
                WHERE ltc.MaLop = @MaLop";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaLop", diem.MaLop),
                new SqlParameter("@MaSV", diem.MaSV),
                new SqlParameter("@DiemCc", diem.DiemCc),
                new SqlParameter("@DiemGK", diem.DiemGK),
                new SqlParameter("@DiemThi", diem.DiemThi)
            };

            return DatabaseConnection.ExecuteNonQuery(query, parameters) > 0;
        }

        // Cập nhật điểm
        public bool Update(Score diem)
        {
            string query = @"
                UPDATE d
                SET 
                    d.DiemCC = @DiemCc,
                    d.DiemGK = @DiemGK,
                    d.DiemThi = @DiemThi,
                    d.DiemKTHP = ROUND(((@DiemCc * 0.1 + @DiemGK * 0.9) * mh.HeSoDQT + @DiemThi * mh.HeSoThi), 2)
                FROM Diem d
                JOIN LopTinChi ltc ON d.MaLop = ltc.MaLop
                JOIN MonHoc mh ON ltc.MaMH = mh.MaMH
                WHERE d.MaLop = @MaLop AND d.MaSV = @MaSV";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DiemCc", diem.DiemCc),
                new SqlParameter("@DiemGK", diem.DiemGK),
                new SqlParameter("@DiemThi", diem.DiemThi),
                new SqlParameter("@MaLop", diem.MaLop),
                new SqlParameter("@MaSV", diem.MaSV)
            };

            return DatabaseConnection.ExecuteNonQuery(query, parameters) > 0;
        }

        // Xóa điểm
        public bool Delete(string MaSV, string MaLop)
        {
            string query = "DELETE FROM Diem WHERE MaLop = @MaLop AND MaSV = @MaSV";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaSV", MaSV),
                new SqlParameter("@MaLop", MaLop)
            };

            return DatabaseConnection.ExecuteNonQuery(query, parameters) > 0;
        }

        // Kiểm tra sinh viên đã có điểm trong lớp chưa
        public bool CheckExist(string MaSV, string MaLop)
        {
            string query = "SELECT COUNT(*) FROM Diem WHERE MaLop = @MaLop AND MaSV = @MaSV";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaLop", MaLop),
                new SqlParameter("@MaSV", MaSV)
            };

            int count = (int)DatabaseConnection.ExecuteScalar(query, parameters);
            return count > 0;
        }

        // Tìm kiếm theo mã lớp, mã SV (có thể kết hợp hoặc chỉ 1 trong 2)
        public DataTable Search(string maLop, string maSV)
        {
            string query = @"SELECT d.MaSV, sv.TenSV, d.MaLop, d.DiemCC, d.DiemGK, d.DiemThi, d.DiemKTHP
                             FROM Diem d
                             JOIN SinhVien sv ON d.MaSV = sv.MaSV
                             WHERE ( @MaLop IS NULL OR @MaLop = '' OR d.MaLop = @MaLop )
                               AND ( @MaSV IS NULL OR @MaSV = '' OR d.MaSV = @MaSV )";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaLop", string.IsNullOrWhiteSpace(maLop) ? (object)DBNull.Value : maLop),
                new SqlParameter("@MaSV", string.IsNullOrWhiteSpace(maSV) ? (object)DBNull.Value : maSV)
            };

            return DatabaseConnection.ExecuteQuery(query, parameters);
        }
    }
}