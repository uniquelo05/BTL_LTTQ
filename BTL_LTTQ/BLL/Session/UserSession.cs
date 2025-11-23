// UserSession.cs
using BTL_LTTQ.DTO;
using System;

namespace BTL_LTTQ.BLL.Session
{
    public class UserSession
    {
        private static UserSession _instance;
        public static UserSession Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserSession();
                }
                return _instance;
            }
        }

        public string MaTK { get; private set; }
        public string TenDangNhap { get; private set; }
        public string LoaiTaiKhoan { get; private set; }
        public string MaGV { get; private set; }
        public DateTime LoginTime { get; private set; }

        // Alias cho TenDangNhap để tương thích
        public string Username => TenDangNhap;

        private UserSession() { }

        public void Set(UserInfo user)
        {
            MaTK = user.MaTK;
            TenDangNhap = user.TenDangNhap;
            LoaiTaiKhoan = user.LoaiTaiKhoan;
            MaGV = user.MaGV;
            LoginTime = DateTime.Now;
        }

        public void Clear()
        {
            MaTK = null;
            TenDangNhap = null;
            LoaiTaiKhoan = null;
            MaGV = null;
            LoginTime = DateTime.MinValue;
        }

        // Static method để clear session
        public static void ClearSession()
        {
            Instance.Clear();
        }

        public static bool IsLoggedIn => Instance.TenDangNhap != null;
        
        public bool IsAdmin() => LoaiTaiKhoan == "Admin";
        
        public bool IsGiangVien() => LoaiTaiKhoan == "Giảng viên";

        public string GetDisplayInfo()
        {
            return $"Tên đăng nhập: {TenDangNhap}\nLoại tài khoản: {LoaiTaiKhoan}";
        }

        public static string GetDisplayInfoStatic()
        {
            return Instance.GetDisplayInfo();
        }
    }
}