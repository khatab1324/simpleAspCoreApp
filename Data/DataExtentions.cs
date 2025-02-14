using Microsoft.EntityFrameworkCore;

namespace aspCoreEmptyApp.Data;

public static class DataExtentions
{
    public static async Task MigrateDbAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<UserStoreContext>();
        await dbContext.Database.MigrateAsync();
    }

}
