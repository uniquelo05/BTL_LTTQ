using BTL_LTTQ.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BTL_LTTQ.DAL.Diem
{
    internal class DiemDAL
    {
        // Lấy toàn bộ danh sách điểm theo MaGV
        public DataTable GetAll(string maGV, string loaiTaiKhoan)
        {
            string query = @"SELECT d.MaSV, sv.TenSV, d.MaLop, d.DiemCC, d.DiemGK, d.DiemThi, d.DiemKTHP
                             FROM Diem d 
                             JOIN SinhVien sv ON d.MaSV = sv.MaSV
                             JOIN LopTinChi ltc ON d.MaLop = ltc.MaLop
                             JOIN PhanCongGiangDay pc ON ltc.MaLop = pc.MaLop";

            if (loaiTaiKhoan != "Admin")
            {
                query += " WHERE pc.MaGV = @MaGV";
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
            // Kiểm tra nếu không phải Admin thì phải xác nhận lớp thuộc về giảng viên
            if (loaiTaiKhoan != "Admin")
            {
                string checkQuery = @"SELECT COUNT(*)
                                      FROM LopTinChi ltc
                                      JOIN PhanCongGiangDay pc ON ltc.MaLop = pc.MaLop
                                      WHERE ltc.MaLop = @MaLop AND pc.MaGV = @MaGV";

                SqlParameter[] checkParams = new SqlParameter[]
                {
                    new SqlParameter("@MaLop", diem.MaLop),
                    new SqlParameter("@MaGV", maGV)
                };

                int count = (int)DatabaseConnection.ExecuteScalar(checkQuery, checkParams);
                if (count == 0)
                {
                    return false; // Lớp không thuộc về giảng viên
                }
            }

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

        // Tìm kiếm theo mã lớp, mã SV và MaGV
        public DataTable Search(string maLop, string maSV, string maGV, string loaiTaiKhoan)
        {
            string query = @"SELECT d.MaSV, sv.TenSV, d.MaLop, d.DiemCC, d.DiemGK, d.DiemThi, d.DiemKTHP
                             FROM Diem d
                             JOIN SinhVien sv ON d.MaSV = sv.MaSV
                             JOIN LopTinChi ltc ON d.MaLop = ltc.MaLop
                             JOIN PhanCongGiangDay pc ON ltc.MaLop = pc.MaLop";

            if (loaiTaiKhoan != "Admin")
            {
                query += " WHERE pc.MaGV = @MaGV";
            }

            query += @" AND ( @MaLop IS NULL OR @MaLop = '' OR d.MaLop = @MaLop )
                        AND ( @MaSV IS NULL OR @MaSV = '' OR d.MaSV = @MaSV )";

            SqlParameter[] parameters = loaiTaiKhoan == "Admin" ? new SqlParameter[]
            {
                new SqlParameter("@MaLop", string.IsNullOrWhiteSpace(maLop) ? (object)DBNull.Value : maLop),
                new SqlParameter("@MaSV", string.IsNullOrWhiteSpace(maSV) ? (object)DBNull.Value : maSV)
            } : new SqlParameter[]
            {
                new SqlParameter("@MaGV", maGV),
                new SqlParameter("@MaLop", string.IsNullOrWhiteSpace(maLop) ? (object)DBNull.Value : maLop),
                new SqlParameter("@MaSV", string.IsNullOrWhiteSpace(maSV) ? (object)DBNull.Value : maSV)
            };

            return DatabaseConnection.ExecuteQuery(query, parameters);
        }
    }
}