using BTL_LTTQ.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BTL_LTTQ.DAL.Diem
{
    internal class DiemDAL
    {
        // ✅ SỬA: Lấy toàn bộ danh sách điểm theo MaGV
        public DataTable GetAll(string maGV, string loaiTaiKhoan)
        {
            string query = @"
                SELECT DISTINCT d.MaSV, sv.TenSV, d.MaLop, d.DiemCC, d.DiemGK, d.DiemThi, d.DiemKTHP
                FROM Diem d 
                INNER JOIN SinhVien sv ON d.MaSV = sv.MaSV
                INNER JOIN LopTinChi ltc ON d.MaLop = ltc.MaLop";

            // Chỉ JOIN PhanCongGiangDay khi cần kiểm tra quyền
            if (loaiTaiKhoan != "Admin" && loaiTaiKhoan != "Quản trị viên")
            {
                query += @"
                INNER JOIN PhanCongGiangDay pc ON ltc.MaLop = pc.MaLop
                WHERE pc.MaGV = @MaGV";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaGV", maGV ?? (object)DBNull.Value)
                };

                return DatabaseConnection.ExecuteQuery(query, parameters);
            }
            else
            {
                // Admin xem tất cả
                return DatabaseConnection.ExecuteQuery(query);
            }
        }

        // Thêm mới điểm (GIỮ NGUYÊN)
        public bool Insert(Score diem, string maGV, string loaiTaiKhoan)
        {
            // Kiểm tra nếu không phải Admin thì phải xác nhận lớp thuộc về giảng viên
            if (loaiTaiKhoan != "Admin" && loaiTaiKhoan != "Quản trị viên")
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

        // Cập nhật điểm (GIỮ NGUYÊN)
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

        // Xóa điểm (GIỮ NGUYÊN)
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

        // Kiểm tra sinh viên đã có điểm trong lớp chưa (GIỮ NGUYÊN)
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

        // ✅ SỬA: Tìm kiếm theo mã lớp, mã SV và MaGV
        public DataTable Search(string maLop, string maSV, string maGV, string loaiTaiKhoan)
        {
            string query = @"
                SELECT DISTINCT d.MaSV, sv.TenSV, d.MaLop, d.DiemCC, d.DiemGK, d.DiemThi, d.DiemKTHP
                FROM Diem d
                INNER JOIN SinhVien sv ON d.MaSV = sv.MaSV
                INNER JOIN LopTinChi ltc ON d.MaLop = ltc.MaLop";

            List<SqlParameter> paramList = new List<SqlParameter>();
            List<string> conditions = new List<string>();

            // Kiểm tra quyền giảng viên
            if (loaiTaiKhoan != "Admin" && loaiTaiKhoan != "Quản trị viên")
            {
                query += " INNER JOIN PhanCongGiangDay pc ON ltc.MaLop = pc.MaLop";
                conditions.Add("pc.MaGV = @MaGV");
                paramList.Add(new SqlParameter("@MaGV", maGV ?? (object)DBNull.Value));
            }

            // Tìm theo Mã lớp
            if (!string.IsNullOrWhiteSpace(maLop))
            {
                conditions.Add("d.MaLop = @MaLop");
                paramList.Add(new SqlParameter("@MaLop", maLop));
            }

            // Tìm theo Mã SV
            if (!string.IsNullOrWhiteSpace(maSV))
            {
                conditions.Add("d.MaSV = @MaSV");
                paramList.Add(new SqlParameter("@MaSV", maSV));
            }

            // Ghép điều kiện WHERE
            if (conditions.Count > 0)
            {
                query += " WHERE " + string.Join(" AND ", conditions);
            }

            query += " ORDER BY d.MaSV, d.MaLop";

            return DatabaseConnection.ExecuteQuery(query, paramList.ToArray());
        }
    }
}