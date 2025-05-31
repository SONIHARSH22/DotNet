using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantManagement.Models.Entity;

namespace RestaurantManagement.Data.Configuration
{
    public class EmployeAttendanceConfiguration : IEntityTypeConfiguration<EmployeAttendance>
    {
        public void Configure(EntityTypeBuilder<EmployeAttendance> builder)
        {
            builder.HasOne(employe => employe.AttendanceTypes)
            .WithMany(attendance => attendance.EmployeAttendances)
            .HasForeignKey(employe => employe.AttendanceType);
        }
    }
}
