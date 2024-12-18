
using aspCoreEmptyApp.Dtos;
using aspCoreEmptyApp.Entities;

namespace aspCoreEmptyApp.Mapping;

static class UserMapping
{
    public static User ToEntity(this User newUser)
    {
        return new()
        {
            Id = newUser.Id,
            Username = newUser.Username,
            Age = newUser.Age
        };
    }
    public static User ToEntity(this UpdateUser newUser, string id)
    {
        return new()
        {
            Id = id,
            Username = newUser.Username,
            Age = newUser.Age
        };
    }
    public static UserDtos ToDtos(this User newUser)
    {
        return new(
               newUser.Id,
               newUser.Username,
               newUser.Age);
    }
}