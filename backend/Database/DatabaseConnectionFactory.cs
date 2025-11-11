using Npgsql;

namespace backend.Database
{
    public class DatabaseConnectionFactory {
        private readonly string _connectionString;

        private DatabaseConnectionFactory(IConfiguration connectionString)
        {
            _connectionString = connectionString.GetConnectionString("CafeConnection") ?? throw new InvalidOperationException("No cafe connection string found");
        }

        public NpgsqlConnection CreateConnection()
        {
            var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            return conn;
        }
     }

}