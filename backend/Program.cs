using backend.Database;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
builder.Services.AddSingleton<DatabaseConnectionFactory>();
builder.Services.AddSingleton<MigrationRunner>();

using (var scope = app.Services.CreateScope())
{
    var migrationRunner = scope.ServiceProvider.GetRequiredService<MigrationRunner>();
    await migrationRunner.ApplyMigrationsAsync();
}

app.Run();
