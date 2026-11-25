using System;
using MySql.Data.MySqlClient;
using AttendanceSystem.Models;

namespace AttendanceSystem.DAL
{
    public class UserRepository
    {
        public User? Authenticate(string username, string password)
        {
            try
            {
                using (var conn = MySqlDbHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT id, username, full_name, role FROM users WHERE username = @user AND password_hash = @pass LIMIT 1";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", username);
                        cmd.Parameters.AddWithValue("@pass", password);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new User
                                {
                                    Id = reader.GetInt32("id"),
                                    Username = reader.GetString("username"),
                                    FullName = reader.GetString("full_name"),
                                    Role = reader.GetString("role")
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Нэвтрэх үед өгөгдлийн сантай холбогдоход алдаа гарлаа: " + ex.Message);
            }

            return null;
        }
    }
}