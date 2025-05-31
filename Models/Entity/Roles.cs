using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Models.Entity
{
    public class Roles
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.None)] 
        public string? RoleId { get; set; }
        public string? Name { get; set; }
        public ICollection<Users>? user { get; set; }

    }
}