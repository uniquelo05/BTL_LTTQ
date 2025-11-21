// DTO/LopTC_DTO.cs
using System;

namespace BTL_LTTQ.DTO
{
    public class LopTC_DTO
    {
        public string MaLop { get; set; }
        public string MaMH { get; set; }
        public int? HocKy { get; set; }
        public int? NamHoc { get; set; }

        // ĐÃ SỬA: Đổi từ string TinhTrang sang bool TinhTrangLop
        public bool TinhTrangLop { get; set; }
    }
}