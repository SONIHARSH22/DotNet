using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Models.Entity
{
    public class AttendanceTypes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string? AttendanceType { get; set; }

        public ICollection<EmployeAttendance>? EmployeAttendances { get; set; }

    }
}