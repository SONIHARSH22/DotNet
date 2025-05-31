using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RestaurantManagement.Models.Entity
{
    public class Users
    {
        [Key, JsonIgnore]
        public int Id { get; set; }
        public string? Name { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        [ForeignKey("Roles")]
        public string? RoleId { get; set; }
        [JsonIgnore]
        public DateTime EnrolledDateTime { get; set; } = DateTime.Now;
        [JsonIgnore]
        public DateTime UpdatedDateTime { get; set; } 
        [JsonIgnore]
        public bool IsDeleted { get; set; }
        [JsonIgnore]
        public virtual ICollection<Orders> Orders { get; set; } = new List<Orders>();
        [JsonIgnore]
        public Roles? Roles { get; set; } 
    }
}