using RestaurantManagement.BusinessService.Interface;
using RestaurantManagement.Common.Constants;
using RestaurantManagement.Common.Enums;
using RestaurantManagement.Models.Entity;
using RestaurantManagement.Models.Request;
using RestaurantManagement.Models.Response;
using RestaurantManagement.DataService.Interface;

namespace RestaurantManagement.BusinessService.Implementation;

public class BookTableService : IBookTableService
{
    private readonly IBookTableDataService _tableBookingDataService;

    public BookTableService(IBookTableDataService tableBookingDataService)
    {
        _tableBookingDataService = tableBookingDataService;
    }

    /// <summary>
    /// Retrieves a list of all tables.
    /// </summary>
    /// <returns>A list of Tables objects representing all tables.</returns>
   public ApiResponse<List<Tables>> GetAllTables()
    {
        try
        {
            var GetAllTables = _tableBookingDataService.GetAllTables();
            if (GetAllTables == null)
            {
                return ApiResponse<List<Tables>>.CreateResponse(ResponseCode.BadRequest, ReturnMessage.TABLE_NOT_FOUND);
            }
            return new ApiResponse<List<Tables>>(ResponseCode.Ok, ReturnMessage.SUCCESSFUL, GetAllTables);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return ApiResponse<List<Tables>>.CreateResponse(ResponseCode.InternalServerError, ReturnMessage.ERROR_OCCURRED);
        }
    }

    /// <summary>
    /// Retrieves a list of all available tables.
    /// </summary>
    /// <returns>A list of Tables objects representing available tables.</returns>
    public ApiResponse<List<Tables>> GetAvailableTables()
    {
        try
        {
            var GetAllAvaiableTables = _tableBookingDataService.GetAvailableTables();
            if (GetAllAvaiableTables == null)
            {
                return ApiResponse<List<Tables>>.CreateResponse(ResponseCode.BadRequest, ReturnMessage.TABLE_NOT_FOUND);
            }
            return new ApiResponse<List<Tables>>(ResponseCode.Ok, ReturnMessage.SUCCESSFUL, GetAllAvaiableTables);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return ApiResponse<List<Tables>>.CreateResponse(ResponseCode.InternalServerError, ReturnMessage.ERROR_OCCURRED);
        }
    }

    /// <summary>
    /// Books a table based on the provided table booking input.
    /// </summary>
    /// <param name="tableBookingInput">The input containing the table ID to book.</param>
    /// <returns>A string message indicating the result of the booking.</returns>
 
    public ApiResponse<Tables> BookTable(TableIdRequest tableBookingInput)
    {
        try
        {
            var existingTable = _tableBookingDataService.GetTableById(tableBookingInput.TableId);

            if (existingTable == null)
            {
                return ApiResponse<Tables>.CreateResponse(ResponseCode.NotFound, ReturnMessage.TABLE_NOT_FOUND);
            }

            if (existingTable.IsOccupied)
            {
                return ApiResponse<Tables>.CreateResponse(ResponseCode.BadRequest, ReturnMessage.TABLE_ALREADY_OCCUPIED);
            }

            existingTable.IsOccupied = true;
            _tableBookingDataService.UpdateTable(existingTable);

            return new ApiResponse<Tables>(ResponseCode.Ok, ReturnMessage.TABLE_BOOKED_SUCCESSFULLY, existingTable);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return ApiResponse<Tables>.CreateResponse(ResponseCode.InternalServerError, ReturnMessage.ERROR_OCCURRED);
        }
    }
    /// <summary>
    /// Cancels a table booking based on the provided table ID input.
    /// </summary>
    /// <param name="tableIdInput">The input containing the table ID to cancel the booking for.</param>
    /// <returns>A string message indicating the result of the cancellation.</returns>
    public ApiResponse<Tables> CancelTableBooking(TableIdRequest tableIdInput)
    {
        try
        {
            var existingTable = _tableBookingDataService.GetTableById(tableIdInput.TableId);

            if (existingTable == null)
            {
                return ApiResponse<Tables>.CreateResponse(ResponseCode.NotFound, ReturnMessage.TABLE_NOT_FOUND);
            }

            if (!existingTable.IsOccupied)
            {
                return ApiResponse<Tables>.CreateResponse(ResponseCode.BadRequest, ReturnMessage.TABLE_NOT_OCCUPIED);
            }

            existingTable.IsOccupied = false;
            _tableBookingDataService.UpdateTable(existingTable);

            return new ApiResponse<Tables>(ResponseCode.Ok, ReturnMessage.TABLE_CANCELLED_SUCCESSFULLY, existingTable);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return ApiResponse<Tables>.CreateResponse(ResponseCode.InternalServerError, ReturnMessage.ERROR_OCCURRED);
        }
    }
}