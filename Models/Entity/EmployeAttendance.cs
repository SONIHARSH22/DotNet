using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Models.Entity
{
    public class EmployeAttendance
    {
        [Key]
        public int Id { get; set; }
        public int EmployeId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int AttendanceType { get; set; }

        public AttendanceTypes? AttendanceTypes { get; set; } 
    }
}