// LoginDAL.cs
using System;
using System.Data.SqlClient;
using BTL_LTTQ.DTO;

namespace BTL_LTTQ.DAL
{
    public class LoginDAL
    {
        public UserInfo Login(string username, string password)
        {
            try
            {
                string query = @"SELECT MaTK, TenDangNhap, LoaiTaiKhoan, MaGV 
                                 FROM TaiKhoan 
                                 WHERE TenDangNhap = @Username AND MatKhau = @Password";

                SqlParameter[] parameters = {
                    new SqlParameter("@Username", username),
                    new SqlParameter("@Password", password)
                };

                using (var connection = DatabaseConnection.GetConnection())
                {
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddRange(parameters);
                        connection.Open();

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new UserInfo
                                {
                                    MaTK = reader["MaTK"].ToString(),
                                    TenDangNhap = reader["TenDangNhap"].ToString(),
                                    LoaiTaiKhoan = reader["LoaiTaiKhoan"].ToString(),
                                    MaGV = reader["MaGV"] != DBNull.Value ? reader["MaGV"].ToString() : null
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi đăng nhập: " + ex.Message);
            }

            return null;
        }
    }
}