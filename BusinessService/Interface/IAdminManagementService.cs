using RestaurantManagement.Models.Request;
using RestaurantManagement.Models.Response;

namespace RestaurantManagement.BusinessService.Interface;

public interface IAdminManagementService
{
    /// <summary>
    /// Retrieves a list of all pending orders for the admin.
    /// </summary>
    /// <returns>An ApiResponse containing a list of pending orders.</returns>
    ApiResponse<List<OrderResponse>> SeeAllPendingOrder();

    /// <summary>
    /// Records the attendance of an employee.
    /// </summary>
    /// <param name="markAttendance">The request object containing employee ID and attendance type ID.</param>
    /// <returns>An ApiResponse containing a success or failure message.</returns>
    ApiResponse<string> RecordAttendance(MarkAttendanceRequest markAttendance);

    /// <summary>
    /// Analyzes order trends to determine the most sold item in a given month and year.
    /// </summary>
    /// <param name="year">The year for analysis.</param>
    /// <param name="month">The month for analysis.</param>
    /// <returns>An ApiResponse containing the order analysis details.</returns>
    ApiResponse<OrderAnalysisResponse> OrderAnalysis(int year, int month);
}