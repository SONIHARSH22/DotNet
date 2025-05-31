using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RestaurantManagement.Models.Entity
{
    public class Menus
    {
        [Key]
        public int MenuId { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        [JsonIgnore]
        public int AvailableQuantity { get; set; }
        public string? Category { get; set; }
        [JsonIgnore]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [JsonIgnore]
        public virtual ICollection<Orders> Orders { get; set; } = new List<Orders>();
    }
}