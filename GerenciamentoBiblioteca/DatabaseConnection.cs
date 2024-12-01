using MySql.Data.MySqlClient;

namespace GerenciamentoBiblioteca
{
    public static class DatabaseConnection
    {
        private static MySqlConnection _connection;
        private static readonly string _connectionString = "Server=localhost;Database=Biblioteca;User ID=root;Password=123456;";

        public static MySqlConnection GetConnection()
        {
            if (_connection == null || _connection.State == System.Data.ConnectionState.Closed)
            {
                _connection = new MySqlConnection(_connectionString);
            }
            return _connection;
        }
    }
}
