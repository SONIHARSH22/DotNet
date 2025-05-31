using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantManagement.Models.Entity;

namespace RestaurantManagement.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasOne(user => user.Roles)
            .WithMany(role => role.user)
            .HasForeignKey(user => user.RoleId);
        }
    }
}
