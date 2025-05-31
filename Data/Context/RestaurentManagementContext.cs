using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Models.Entity;
namespace RestaurantManagement.Data.Context
{
    public class RestaurentManagementContext : DbContext
    {
        public RestaurentManagementContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Users> user { get; set; }
        public DbSet<Menus> menu { get; set; }
        public DbSet<Orders> order { get; set; }
        public DbSet<Tables> table { get; set; }
        public DbSet<Roles> role { get; set; }
        public DbSet<AttendanceTypes> attendancetypes { get; set; }
        public DbSet<EmployeAttendance> employeattendance { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}