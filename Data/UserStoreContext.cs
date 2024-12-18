using Microsoft.EntityFrameworkCore;
using aspCoreEmptyApp.Entities;
namespace aspCoreEmptyApp.Data;
public class UserStoreContext(DbContextOptions<UserStoreContext> options) : DbContext(options)
{
    public DbSet<User> User => Set<User>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new { Id = "1", Username = "khattab", Age = 20 },
            new { Id = "2", Username = "sami", Age = 20 },
            new { Id = "3", Username = "khaled", Age = 20 },
            new { Id = "4", Username = "omaia", Age = 20 }
        );
    }
}