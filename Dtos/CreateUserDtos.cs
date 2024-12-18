using System.ComponentModel.DataAnnotations;

namespace aspCoreEmptyApp.Dtos;
public record class CreateUser([Required][StringLength(4)] string Username, [Required][Range(18, 100)] int Age);
