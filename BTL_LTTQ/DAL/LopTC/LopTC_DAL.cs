// DAL/LopTC_DAL.cs
using BTL_LTTQ.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BTL_LTTQ.DAL
{
    public class LopTC_DAL
    {
        public DataTable GetData()
        {
            // ĐÃ SỬA: Đổi TinhTrang -> TinhTrangLop
            string query = @"
                SELECT 
                    LTC.MaLop, LTC.MaMH, MH.TenMH, MH.MaKhoa, 
                    LTC.HocKy, LTC.NamHoc, LTC.TinhTrangLop 
                FROM LopTinChi AS LTC
                JOIN MonHoc AS MH ON LTC.MaMH = MH.MaMH";
            return DatabaseConnection.ExecuteQuery(query);
        }

        public DataTable SearchData(string maLop, int? namHoc, string maKhoa)
        {
            // ĐÃ SỬA: Đổi TinhTrang -> TinhTrangLop
            string baseQuery = @"
                SELECT 
                    LTC.MaLop, LTC.MaMH, MH.TenMH, MH.MaKhoa, 
                    LTC.HocKy, LTC.NamHoc, LTC.TinhTrangLop 
                FROM LopTinChi AS LTC
                JOIN MonHoc AS MH ON LTC.MaMH = MH.MaMH
                WHERE 1=1";

            List<SqlParameter> parameters = new List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(maLop))
            {
                baseQuery += " AND (LTC.MaLop LIKE @MaLop)";
                parameters.Add(new SqlParameter("@MaLop", "%" + maLop + "%"));
            }
            if (namHoc.HasValue)
            {
                baseQuery += " AND LTC.NamHoc = @NamHoc";
                parameters.Add(new SqlParameter("@NamHoc", namHoc.Value));
            }
            if (!string.IsNullOrWhiteSpace(maKhoa))
            {
                baseQuery += " AND MH.MaKhoa = @MaKhoa";
                parameters.Add(new SqlParameter("@MaKhoa", maKhoa));
            }

            return DatabaseConnection.ExecuteQuery(baseQuery, parameters.ToArray());
        }

        public int Insert(LopTC_DTO ltc)
        {
            // ĐÃ SỬA: Đổi TinhTrang -> TinhTrangLop
            string query = @"INSERT INTO LopTinChi (MaLop, MaMH, HocKy, NamHoc, TinhTrangLop) 
                             VALUES (@MaLop, @MaMH, @HocKy, @NamHoc, @TinhTrangLop)";

            SqlParameter[] parameters = {
                new SqlParameter("@MaLop", ltc.MaLop),
                new SqlParameter("@MaMH", ltc.MaMH),
                new SqlParameter("@HocKy", (object)ltc.HocKy ?? DBNull.Value),
                new SqlParameter("@NamHoc", (object)ltc.NamHoc ?? DBNull.Value),
                new SqlParameter("@TinhTrangLop", ltc.TinhTrangLop) // Sẽ là false (0)
            };
            return DatabaseConnection.ExecuteNonQuery(query, parameters);
        }

        public int Update(LopTC_DTO ltc)
        {
            // ĐÃ SỬA: Xóa TinhTrangLop khỏi câu UPDATE
            string query = @"UPDATE LopTinChi SET 
                                MaMH = @MaMH, 
                                HocKy = @HocKy, 
                                NamHoc = @NamHoc
                             WHERE MaLop = @MaLop";

            SqlParameter[] parameters = {
                new SqlParameter("@MaMH", ltc.MaMH),
                new SqlParameter("@HocKy", (object)ltc.HocKy ?? DBNull.Value),
                new SqlParameter("@NamHoc", (object)ltc.NamHoc ?? DBNull.Value),
                new SqlParameter("@MaLop", ltc.MaLop)
            };
            return DatabaseConnection.ExecuteNonQuery(query, parameters);
        }

        // --- Các hàm Xóa giữ nguyên ---
        public int Delete(string maLop)
        {
            string query = "DELETE FROM LopTinChi WHERE MaLop = @MaLop";
            SqlParameter[] param = { new SqlParameter("@MaLop", maLop) };
            return DatabaseConnection.ExecuteNonQuery(query, param);
        }

        public void DeletePhanCongByMaLop(string maLop)
        {
            string query = "DELETE FROM PhanCongGiangDay WHERE MaLop = @MaLop";
            SqlParameter[] param = { new SqlParameter("@MaLop", maLop) };
            DatabaseConnection.ExecuteNonQuery(query, param);
        }

        public void DeleteDiemByMaLop(string maLop)
        {
            string query = "DELETE FROM Diem WHERE MaLop = @MaLop";
            SqlParameter[] param = { new SqlParameter("@MaLop", maLop) };
            DatabaseConnection.ExecuteNonQuery(query, param);
        }
    }
}