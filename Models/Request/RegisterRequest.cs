using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Models.Request;

public class RegisterRequest
{
    public string? Name { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Password { get; set; }
    public string? Role { get; set; } 
}