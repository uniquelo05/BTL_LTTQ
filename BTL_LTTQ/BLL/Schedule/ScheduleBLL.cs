using BTL_LTTQ.DAL.Schedule;
using BTL_LTTQ.DTO;
using System;
using System.Collections.Generic;

namespace BTL_LTTQ.BLL.Schedule
{
    public class ScheduleBLL
    {
        private readonly ScheduleDAL dal = new ScheduleDAL();

        // Tính toán tuần từ học kỳ
        public (DateTime, DateTime) GetWeekRange(int hocKy, int namHoc, int week)
        {
            var (hkStart, hkEnd) = dal.GetHocKyRange(hocKy, namHoc);

            if (hkStart == DateTime.MinValue)
                throw new Exception("Không tìm thấy học kỳ!");

            DateTime tuanStart = hkStart.AddDays((week - 1) * 7);
            DateTime tuanEnd = tuanStart.AddDays(6);

            if (tuanEnd > hkEnd)
                tuanEnd = hkEnd;

            return (tuanStart, tuanEnd);
        }

        public List<ScheduleDTO> LoadSchedule(string maGV, DateTime tuanStart, DateTime tuanEnd)
        {
            return dal.GetSchedule(maGV, tuanStart, tuanEnd);
        }
    }
}
