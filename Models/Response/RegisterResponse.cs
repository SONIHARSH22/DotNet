using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Models.Response
{
    public class RegisterResponse
    {
        public int Id { get; set; } 
        public string? Name { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Role { get; set; }
        public string? Message { get; set; }

    }
}