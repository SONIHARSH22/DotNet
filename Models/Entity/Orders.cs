using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace RestaurantManagement.Models.Entity
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int TableId { get; set; }
        public int MenuId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDateTime { get; set; } = DateTime.Now;
        public bool IsCustomerActive { get; set; }
        public int OrderStatus { get; set; }

        [ForeignKey("UserId")]
        public virtual Users? user { get; set; }

        [ForeignKey("TableId")]
        public virtual Tables? Tables { get; set; }

        [ForeignKey("MenuId")]
        public virtual Menus? Menus { get; set; }

    }
}