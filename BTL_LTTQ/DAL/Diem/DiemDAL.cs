using BTL_LTTQ.DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BTL_LTTQ.DAL.Diem
{
    internal class DiemDAL
    {
        // Lấy toàn bộ danh sách điểm
        public DataTable GetAll(string maGV, string loaiTaiKhoan)
        {
            string query = @"SELECT DISTINCT d.MaSV, sv.TenSV, d.MaLop, d.DiemCC, d.DiemGK, d.DiemThi, d.DiemKTHP
                             FROM Diem d 
                             JOIN SinhVien sv ON d.MaSV = sv.MaSV
                             JOIN LopTinChi ltc ON d.MaLop = ltc.MaLop
                             JOIN PhanCongGiangDay pc ON ltc.MaLop = pc.MaLop
                             WHERE d.DiemKTHP IS NOT NULL";

            if (loaiTaiKhoan != "Admin")
            {
                query += " AND pc.MaGV = @MaGV";
            }

            SqlParameter[] parameters = loaiTaiKhoan == "Admin" ? new SqlParameter[] { } : new SqlParameter[]
            {
                new SqlParameter("@MaGV", maGV)
            };

            return DatabaseConnection.ExecuteQuery(query, parameters);
        }

        // Thêm mới điểm
        public bool Insert(Score diem, string maGV, string loaiTaiKhoan)
        {
            if (loaiTaiKhoan != "Admin")
            {
                string checkQuery = @"SELECT COUNT(*) FROM PhanCongGiangDay WHERE MaLop = @MaLop AND MaGV = @MaGV";
                int count = (int)DatabaseConnection.ExecuteScalar(checkQuery, new[] {
                    new SqlParameter("@MaLop", diem.MaLop),
                    new SqlParameter("@MaGV", maGV)
                });
                if (count == 0) return false;
            }

            string query = @"
                INSERT INTO Diem (MaLop, MaSV, DiemCC, DiemGK, DiemThi, DiemKTHP)
                SELECT @MaLop, @MaSV, @DiemCc, @DiemGK, @DiemThi,
                ROUND(((@DiemCc * 0.1 + @DiemGK * 0.9) * mh.HeSoDQT + @DiemThi * mh.HeSoThi), 2)
                FROM LopTinChi ltc
                JOIN MonHoc mh ON ltc.MaMH = mh.MaMH
                WHERE ltc.MaLop = @MaLop";

            SqlParameter[] parameters = {
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
                UPDATE d SET 
                    d.DiemCC = @DiemCc,
                    d.DiemGK = @DiemGK,
                    d.DiemThi = @DiemThi,
                    d.DiemKTHP = ROUND(((@DiemCc * 0.1 + @DiemGK * 0.9) * mh.HeSoDQT + @DiemThi * mh.HeSoThi), 2)
                FROM Diem d
                JOIN LopTinChi ltc ON d.MaLop = ltc.MaLop
                JOIN MonHoc mh ON ltc.MaMH = mh.MaMH
                WHERE d.MaLop = @MaLop AND d.MaSV = @MaSV";

            SqlParameter[] parameters = {
                new SqlParameter("@DiemCc", diem.DiemCc),
                new SqlParameter("@DiemGK", diem.DiemGK),
                new SqlParameter("@DiemThi", diem.DiemThi),
                new SqlParameter("@MaLop", diem.MaLop),
                new SqlParameter("@MaSV", diem.MaSV)
            };

            return DatabaseConnection.ExecuteNonQuery(query, parameters) > 0;
        }

        // Xóa điểm - ĐÃ TỐI ƯU HÓA
        public bool Delete(string MaLop, string MaSV)
        {
            // Xóa trực tiếp dựa trên khóa chính
            string query = "DELETE FROM Diem WHERE MaLop = @MaLop AND MaSV = @MaSV";

            SqlParameter[] parameters = {
                new SqlParameter("@MaLop", MaLop),
                new SqlParameter("@MaSV", MaSV)
            };

            // Trả về true nếu có ít nhất 1 dòng bị xóa
            return DatabaseConnection.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool CheckExist(string MaLop, string MaSV)
        {
            string query = "SELECT COUNT(*) FROM Diem WHERE MaLop = @MaLop AND MaSV = @MaSV";
            int count = (int)DatabaseConnection.ExecuteScalar(query, new[] {
                new SqlParameter("@MaLop", MaLop),
                new SqlParameter("@MaSV", MaSV)
            });
            return count > 0;
        }

        public DataTable Search(string maLop, string maSV, string maGV, string loaiTaiKhoan)
        {
            string query = @"SELECT DISTINCT d.MaSV, sv.TenSV, d.MaLop, d.DiemCC, d.DiemGK, d.DiemThi, d.DiemKTHP
                             FROM Diem d
                             JOIN SinhVien sv ON d.MaSV = sv.MaSV
                             JOIN LopTinChi ltc ON d.MaLop = ltc.MaLop
                             JOIN PhanCongGiangDay pc ON ltc.MaLop = pc.MaLop
                             WHERE d.DiemKTHP IS NOT NULL";

            if (loaiTaiKhoan != "Admin") query += " AND pc.MaGV = @MaGV";

            query += " AND (@MaLop IS NULL OR @MaLop = '' OR d.MaLop LIKE @MaLop) " +
                     " AND (@MaSV IS NULL OR @MaSV = '' OR d.MaSV LIKE @MaSV)";

            SqlParameter[] parameters = {
                new SqlParameter("@MaGV", maGV ?? (object)DBNull.Value),
                new SqlParameter("@MaLop", string.IsNullOrWhiteSpace(maLop) ? (object)DBNull.Value : "%" + maLop + "%"),
                new SqlParameter("@MaSV", string.IsNullOrWhiteSpace(maSV) ? (object)DBNull.Value : "%" + maSV + "%")
            };

            return DatabaseConnection.ExecuteQuery(query, parameters);
        }
    }
}