using backend.Database;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
builder.Services.AddSingleton(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    return new DatabaseConnectionFactory(configuration);
});
builder.Services.AddSingleton<MigrationRunner>();

using (var scope = app.Services.CreateScope())
{
    var migrationRunner = scope.ServiceProvider.GetRequiredService<MigrationRunner>();
    await migrationRunner.ApplyMigrationsAsync();
}


app.Run();
