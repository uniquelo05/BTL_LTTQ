// LoginBLL.cs
using BTL_LTTQ.DAL;
using BTL_LTTQ.DTO;
using BTL_LTTQ.BLL.Session;

namespace BTL_LTTQ.BLL
{
    public class LoginBLL
    {
        private readonly LoginDAL _loginDAL;

        public LoginBLL()
        {
            _loginDAL = new LoginDAL();
        }

        public (bool Success, string Message) ProcessLogin(string username, string password)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(username) || username.Length < 3)
                return (false, "Tên đăng nhập phải có ít nhất 3 ký tự!");

            if (string.IsNullOrWhiteSpace(password) || password.Length < 3)
                return (false, "Mật khẩu phải có ít nhất 3 ký tự!");

            // Call DAL
            UserInfo user = _loginDAL.Login(username, password);

            if (user == null)
                return (false, "Tên đăng nhập hoặc mật khẩu không đúng!");

            // Set session
            UserSession.Instance.Set(user);

            return (true, "Đăng nhập thành công!");
        }
    }
}