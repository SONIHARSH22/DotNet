using RestaurantManagement.Models.Entity;
using RestaurantManagement.Models.Response;

namespace RestaurantManagement.DataService.Interface
{
    public interface IAdminManagementDataService
    {
        /// <summary>
        /// Retrieves a list of all pending orders for admin review.
        /// </summary>
        /// <returns>A list of pending orders.</returns>
        List<OrderResponse> SeeAllPendingOrder();

        /// <summary>
        /// Retrieves user details based on the employee ID.
        /// </summary>
        /// <param name="employeeId">The ID of the employee.</param>
        /// <returns>The user details if found, otherwise null.</returns>
        Users? GetUserById(int employeeId);

        /// <summary>
        /// Checks if the provided attendance type ID is valid.
        /// </summary>
        /// <param name="attendanceTypeId">The ID of the attendance type.</param>
        /// <returns>True if the attendance type is valid, otherwise false.</returns>
        bool IsAttendanceTypeValid(int attendanceTypeId);

        /// <summary>
        /// Saves the attendance record of an employee.
        /// </summary>
        /// <param name="attendanceRecord">The attendance record to be saved.</param>
        /// <returns>True if the attendance record is successfully saved, otherwise false.</returns>
        bool SaveAttendance(EmployeAttendance attendanceRecord);

        /// <summary>
        /// Retrieves order analysis data to determine the most sold items within a specific year and month.
        /// </summary>
        /// <param name="year">The year for analysis.</param>
        /// <param name="month">The month for analysis.</param>
        /// <returns>An object containing order analysis results.</returns>
        OrderAnalysisResponse GetOrderAnalysisData(int year, int month);
    }
}