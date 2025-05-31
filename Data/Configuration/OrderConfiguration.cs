using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantManagement.Models;
using RestaurantManagement.Models.Entity;

namespace RestaurantManagement.Data.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.HasOne(order => order.user)
                .WithMany(user => user.Orders)
                .HasForeignKey(order => order.UserId);

            builder.HasOne(order => order.Menus)
                .WithMany(menu => menu.Orders)
                .HasForeignKey(order => order.MenuId);

            builder.HasOne(order => order.Tables)
                .WithMany(table => table.Orders)
                .HasForeignKey(order => order.TableId);
        }
    }
}
