using aspCoreEmptyApp.Routes;
using aspCoreEmptyApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("MySqlConn");
builder.Services.AddDbContext<UserStoreContext>(options =>
    options.UseMySql(connectionString, Serv erVersion.AutoDetect(connectionString)));
var app = builder.Build();

UserRoutes.MapUserRoutes(app);

await app.MigrateDbAsync();
app.Run();

// using (var scope = app.Services.CreateScope())
// {
//     var dbContext = scope.ServiceProvider.GetRequiredService<UserStoreContext>();
//     try
//     {
//         Console.WriteLine("Testing database connection...");
//         dbContext.Database.CanConnect();
//         Console.WriteLine("Database connection successful!");
//     }
//     catch (Exception ex)
//     {
//         Console.WriteLine($"Database connection failed: {ex.Message}");
//     }
// }