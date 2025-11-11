using System.Collections.Generic;
using Npgsql;

namespace backend.Database
{
    public class MigrationRunner
    {
        private readonly DatabaseConnectionFactory _connectionFactory;
        private readonly string _migrationsFolder;
        public MigrationRunner(DatabaseConnectionFactory connectionFactory, string migrationsFolder)
        {
            _connectionFactory = connectionFactory;
            _migrationsFolder = migrationsFolder;
        }
        public async Task ApplyMigrationsAsync()
        {
            await using var conn = _connectionFactory.CreateConnection();
            await EnsureMigrationSchema(conn);
            var appliedMigrationNames = await ReadAppliedMigrations(conn);
            var migrations = Directory.GetFiles(_migrationsFolder, "*.sql").OrderBy(f => f).ToList();
            await ApplyNewMigrations(migrations, appliedMigrationNames, conn);


        }
        public async Task EnsureMigrationSchema(NpgsqlConnection conn)
        {
            var schemaFile = Path.Join(_migrationsFolder, "001_create_schema_migration");
            var migrationSchemaSql = await File.ReadAllTextAsync(schemaFile) ?? throw new InvalidOperationException("No migration schema file");
            await using var cmd = new NpgsqlCommand(migrationSchemaSql, conn);
            await cmd.ExecuteNonQueryAsync();
        }
        public async Task<HashSet<string>> ReadAppliedMigrations(NpgsqlConnection conn)
        {
            HashSet<string> appliedMigrationNames = new();

            var getAppliedSql = "SELECT filename FROM schema_migrations";

            await using (var cmd = new NpgsqlCommand(getAppliedSql, conn))
            await using (var reader = await cmd.ExecuteReaderAsync())
                while (await reader.ReadAsync())
                    appliedMigrationNames.Add(reader.GetString(0));

            return appliedMigrationNames;

        }
        public async Task ApplyNewMigrations(List<string> migrations, HashSet<string> appliedMigrationNames, NpgsqlConnection conn )
        {
            foreach (var migration in migrations)
            {
          
                if (appliedMigrationNames.Contains(migration)) continue;

                var sql = await File.ReadAllTextAsync(migration);
                await using (var cmd = new NpgsqlCommand(sql, conn))
                    await cmd.ExecuteNonQueryAsync();

                var recordSql = "INSERT INTO schema_migrations (filename) VALUES (@name)";
                await using (var cmd = new NpgsqlCommand(recordSql, conn))
                {
                    cmd.Parameters.AddWithValue("name", migration);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}