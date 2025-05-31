using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RestaurantManagement.Models.Entity
{
    public class Tables
    {
        [Key]
        public int TableId { get; set; }
        public int SettingCapacity { get; set; }
        public bool IsOccupied { get; set; }
        [JsonIgnore]
        public virtual ICollection<Orders> Orders { get; set; } = new List<Orders>();
    }
}