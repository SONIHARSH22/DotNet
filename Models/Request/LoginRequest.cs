using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Models.Request;

public class LoginRequest
{
    [EmailAddress]
    public string? Email { get; set; }
    public string? Password { get; set; }
}