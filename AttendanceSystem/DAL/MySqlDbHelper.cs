using MySql.Data.MySqlClient;

namespace AttendanceSystem.DAL
{
    public static class MySqlDbHelper
    {
        private static string _connectionString = "Server=localhost;Database=attendance_db;Uid=root;Pwd=;";

        public static string ConnectionString
        {
            get => _connectionString;
            set => _connectionString = string.IsNullOrWhiteSpace(value)
                ? throw new ArgumentException("Connection string cannot be empty.", nameof(value))
                : value;
        }

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}