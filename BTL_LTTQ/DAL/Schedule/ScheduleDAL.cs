using BTL_LTTQ.DTO;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BTL_LTTQ.DAL.Schedule
{
    public class ScheduleDAL
    {
        private readonly SqlConnection conn;

        public ScheduleDAL()
        {
            conn = DatabaseConnection.GetConnection();
        }

        // =============================
        // LẤY NGÀY BẮT ĐẦU – KẾT THÚC HỌC KỲ
        // =============================
        public (DateTime, DateTime) GetHocKyRange(int hocKy, int namHoc)
        {
            string sql = @"SELECT NgayBatDau, NgayKetThuc 
                           FROM HocKy WHERE HocKy = @hk AND NamHoc = @nh";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@hk", hocKy);
            cmd.Parameters.AddWithValue("@nh", namHoc);

            conn.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            DateTime bd = DateTime.MinValue;
            DateTime kt = DateTime.MinValue;

            if (rd.Read())
            {
                bd = rd.GetDateTime(0);
                kt = rd.GetDateTime(1);
            }
            conn.Close();

            return (bd, kt);
        }

        // =============================
        // LẤY LỊCH GIẢNG DẠY THEO TUẦN
        // =============================
        public List<ScheduleDTO> GetSchedule(
            string maGV, DateTime tuanStart, DateTime tuanEnd)
        {
            List<ScheduleDTO> list = new List<ScheduleDTO>();

            string sql = @"
            SELECT PC.MaPC, PC.MaGV, PC.MaLop, PC.Thu, PC.CaHoc,
                   PC.NgayBatDau, PC.NgayKetThuc,
                   MH.TenMH, PH.MaPhong
            FROM PhanCongGiangDay PC
            JOIN LopTinChi LTC ON PC.MaLop = LTC.MaLop
            JOIN MonHoc MH ON MH.MaMH = LTC.MaMH
            JOIN PhongHoc PH ON PH.MaPhong = PC.MaPhong
            WHERE PC.MaGV = @magv
              AND PC.NgayBatDau <= @tuanEnd
              AND PC.NgayKetThuc >= @tuanStart
            ORDER BY PC.Thu, PC.CaHoc";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@magv", maGV);
            cmd.Parameters.AddWithValue("@tuanStart", tuanStart);
            cmd.Parameters.AddWithValue("@tuanEnd", tuanEnd);

            conn.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                list.Add(new ScheduleDTO
                {
                    MaPC = rd["MaPC"].ToString(),
                    MaGV = rd["MaGV"].ToString(),
                    MaLop = rd["MaLop"].ToString(),
                    MonHoc = rd["TenMH"].ToString(),
                    Phong = rd["MaPhong"].ToString(),
                    Thu = Convert.ToInt32(rd["Thu"]),
                    CaHoc = Convert.ToInt32(rd["CaHoc"]),
                    NgayBD = Convert.ToDateTime(rd["NgayBatDau"]),
                    NgayKT = Convert.ToDateTime(rd["NgayKetThuc"])
                });
            }
            conn.Close();

            return list;
        }
    }
}
