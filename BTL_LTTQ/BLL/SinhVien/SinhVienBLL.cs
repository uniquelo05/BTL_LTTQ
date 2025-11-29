// BLL/SinhVienBLL.cs
using BTL_LTTQ.DAL;
using BTL_LTTQ.DTO;
using System.Data;

namespace BTL_LTTQ.BLL
{
    public class SinhVienBLL
    {
        private SinhVienDAL dal = new SinhVienDAL();

        public DataTable TimKiem(string maKhoa, string maLop, string maSV, string maGV, string loaiTaiKhoan)
        {
            return dal.TimKiem(maKhoa, maLop, maSV, maGV, loaiTaiKhoan);
        }
        public DataTable LayKhoa() => dal.LayKhoa();
        public DataTable LayTatCaLopTinChi(string maGV, string loaiTaiKhoan)
        {
            return dal.LayTatCaLopTinChi(maGV, loaiTaiKhoan);
        }
        public DataTable LayLopTinChiTheoKhoa(string maKhoa, string maGV, string loaiTaiKhoan)
        {
            return dal.LayLopTinChiTheoKhoa(maKhoa, maGV, loaiTaiKhoan);
        }
        public bool Them(SinhVienDTO sv) => dal.Them(sv);
        public bool Sua(SinhVienDTO sv) => dal.Sua(sv);
        public bool Xoa(string maSV, string maLop) => dal.Xoa(maSV, maLop);
        public bool KiemTraSVTrongLop(string maSV, string maLop)
        {
            return dal.KiemTraSVTrongLop(maSV, maLop);
        }

        public SinhVienDTO LaySinhVienTheoMa(string maSV)
        {
            return dal.LaySinhVienTheoMa(maSV);
        }
    }
}