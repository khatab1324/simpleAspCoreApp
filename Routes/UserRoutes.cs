using aspCoreEmptyApp.Data;
using aspCoreEmptyApp.Dtos;
using aspCoreEmptyApp.Entities;
using aspCoreEmptyApp.Mapping;
using Microsoft.EntityFrameworkCore;
namespace aspCoreEmptyApp.Routes;
public static class UserRoutes
{
    private static List<UserDtos> users = [new("1", "khattab", 18), new("2", "jorje", 45), new("3", "samy", 20),];

    public static WebApplication? MapUserRoutes(WebApplication app)
    {
        var group = app.MapGroup("user");
        app.MapGet("/users", async (UserStoreContext dbContext) => await dbContext.User.Select(user => user.ToEntity()).AsNoTracking().ToListAsync()
        //we will not minuplate with these data becuase of this we will not track them 
        ).WithName("getUsers");

        group.MapGet("/{id}", async (string id, UserStoreContext dbContext) =>
        {
            User? result = null;
            result = await dbContext.User.FindAsync(id);
            return result is null ? Results.NotFound() : Results.Ok(result.ToDtos());
        }).WithName("getUser");

        group.MapPost("/", async (User newUser, UserStoreContext dbContext) =>//now we inject the UserStoreContext to use it and save data in the database
        {
            User user = newUser.ToEntity();

            dbContext.User.Add(user);//now we add the data to User field that in the UserStoreContext
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute("getUser", new { id = user.Id }, newUser.ToDtos());
        }).WithParameterValidation();


        group.MapPut("/{id}", async (UpdateUser UpdateUser, string id, UserStoreContext dbContext) =>
        {
            User? user = await dbContext.User.FindAsync(id);
            if (user is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(user).CurrentValues.SetValues(UpdateUser.ToEntity(id));
            await dbContext.SaveChangesAsync();
            return Results.CreatedAtRoute("getUsers", null, user.ToDtos());
        });
        return app;
    }

}