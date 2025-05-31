namespace RestaurantManagement.Models.Request;

public class MarkAttendanceRequest
{
    public int EmployeeId { get; set; }
    public int AttendanceTypeId { get; set; }
}