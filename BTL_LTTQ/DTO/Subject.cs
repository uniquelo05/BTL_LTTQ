using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_LTTQ.DTO
{
    public class Subject
    {
        public string MaMH { get; set; }
        public string TenMH { get; set; }
        public int SoTC { get; set; }
        public int SoTietLT { get; set; } // Renamed to align with table structure
        public int SoTietTH { get; set; } // Renamed to align with table structure
        public decimal HeSoDQT { get; set; } // Hệ số điểm quá trình
        public decimal HeSoThi { get; set; } // Hệ số điểm thi
        public string MaKhoa { get; set; }
        public string TenKhoa { get; set; } // Để hiển thị tên khoa

        public Subject()
        {
        }

        public Subject(string maMH, string tenMH, int soTC, int soTietLT, int soTietTH, decimal heSoDQT, decimal heSoThi, string maKhoa, string tenKhoa = "")
        {
            MaMH = maMH;
            TenMH = tenMH;
            SoTC = soTC;
            SoTietLT = soTietLT;
            SoTietTH = soTietTH;
            HeSoDQT = heSoDQT;
            HeSoThi = heSoThi;
            MaKhoa = maKhoa;
            TenKhoa = tenKhoa;
        }
    }

    public class Department
    {
        public string MaKhoa { get; set; }
        public string TenKhoa { get; set; }

        public Department()
        {
        }

        public Department(string maKhoa, string tenKhoa)
        {
            MaKhoa = maKhoa;
            TenKhoa = tenKhoa;
        }
    }
}
