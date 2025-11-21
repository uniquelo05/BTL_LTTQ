using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_LTTQ.DTO
{
    public class ScheduleDTO
    {
        public string MaPC { get; set; }
        public string MaGV { get; set; }
        public string MaLop { get; set; }
        public string MonHoc { get; set; }
        public string Phong { get; set; }
        public int Thu { get; set; }
        public int CaHoc { get; set; }
        public DateTime NgayBD { get; set; }
        public DateTime NgayKT { get; set; }
    }
}
