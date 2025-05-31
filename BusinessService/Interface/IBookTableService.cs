using RestaurantManagement.Models.Entity;
using RestaurantManagement.Models.Request;
using RestaurantManagement.Models.Response;

namespace RestaurantManagement.BusinessService.Interface;

public interface IBookTableService
{
    /// <summary>
    /// Retrieves a list of all tables.
    /// </summary>
    /// <returns>A list of Tables objects representing all tables.</returns>
    ApiResponse<List<Tables>> GetAllTables();

    /// <summary>
    /// Retrieves a list of all available tables.
    /// </summary>
    /// <returns>A list of Tables objects representing available tables.</returns>
    ApiResponse<List<Tables>> GetAvailableTables();

    /// <summary>
    /// Books a table based on the provided table booking input.
    /// </summary>
    /// <param name="tableBookingInput">The input containing the table ID to book.</param>
    /// <returns>A string message indicating the result of the booking.</returns>
    ApiResponse<Tables> BookTable(TableIdRequest tableBookingInput);

    /// <summary>
    /// Cancels a table booking based on the provided table ID input.
    /// </summary>
    /// <param name="tableIdInput">The input containing the table ID to cancel the booking for.</param>
    /// <returns>A string message indicating the result of the cancellation.</returns>
    ApiResponse<Tables> CancelTableBooking(TableIdRequest tableIdInput);
}