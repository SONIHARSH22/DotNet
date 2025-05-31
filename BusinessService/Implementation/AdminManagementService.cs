using RestaurantManagement.BusinessService.Interface;
using RestaurantManagement.Common.Constants;
using RestaurantManagement.Common.Enums;
using RestaurantManagement.DataService.Interface;
using RestaurantManagement.Models.Entity;
using RestaurantManagement.Models.Request;
using RestaurantManagement.Models.Response;

namespace RestaurantManagement.BusinessService.Implementation;

public class AdminManagementService : IAdminManagementService
{
    private readonly IAdminManagementDataService _adminManagementsDataService;

    public AdminManagementService(IAdminManagementDataService adminManagementsDataService)
    {
        _adminManagementsDataService = adminManagementsDataService;
    }

    public ApiResponse<List<OrderResponse>> SeeAllPendingOrder()
    {
        try
        {
            var orders = _adminManagementsDataService.SeeAllPendingOrder();
            if (orders == null)
            {
                return ApiResponse<List<OrderResponse>>.CreateResponse(ResponseCode.Ok, AdminConstants.NO_PENDING_ORDERS_FOUND);
            }
            return new ApiResponse<List<OrderResponse>>(ResponseCode.Ok, ReturnMessage.SUCCESSFUL, orders);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return ApiResponse<List<OrderResponse>>.CreateResponse(ResponseCode.InternalServerError, AdminConstants.ERROR_MESSAGE);
        }
    }

    public ApiResponse<string> RecordAttendance(MarkAttendanceRequest markAttendance)
    {
        try
        {
            var existingEmployee = _adminManagementsDataService.GetUserById(markAttendance.EmployeeId);

            if (existingEmployee == null)
            {
                return ApiResponse<string>.CreateResponse(ResponseCode.BadRequest, AdminConstants.EMPLOYEE_NOT_FOUND_MESSAGE);

            }

            if (!_adminManagementsDataService.IsAttendanceTypeValid(markAttendance.AttendanceTypeId))
            {
                return ApiResponse<string>.CreateResponse(ResponseCode.BadRequest, AdminConstants.ATTENDANCE_TYPE_NOT_FOUND_MESSAGE);
            }

            if (existingEmployee.RoleId == UserRoles.CUSTOMER)
            {
                return ApiResponse<string>.CreateResponse(ResponseCode.BadRequest, AdminConstants.CANNOT_MARK_ATTENDANCE_CUSTOMER);
            }

            var attendanceRecord = new EmployeAttendance
            {
                EmployeId = markAttendance.EmployeeId,
                AttendanceType = markAttendance.AttendanceTypeId,
                Date = DateTime.Now
            };

            bool isSaved = _adminManagementsDataService.SaveAttendance(attendanceRecord);

            if (!isSaved)
            {
                return ApiResponse<string>.CreateResponse(ResponseCode.BadRequest, AdminConstants.ATTENDANCE_RECORDING_ERROR);

            }

            return new ApiResponse<string>(ResponseCode.Ok, AdminConstants.ATTENDANCE_RECORDED_SUCCESSFUL, AdminConstants.ATTENDANCE_RECORDED_SUCCESSFUL);
        }
        catch (Exception)
        {
            return ApiResponse<string>.CreateResponse(ResponseCode.InternalServerError, AdminConstants.ERROR_MESSAGE);
        }
    }

    public ApiResponse<OrderAnalysisResponse> OrderAnalysis(int year, int month)
    {
        try
        {
            if (month < 1 || month > 12 || year > DateTime.Now.Year)
            {
                return ApiResponse<OrderAnalysisResponse>.CreateResponse(ResponseCode.BadRequest, AdminConstants.INVALID_MONTH_OR_YEAR);
            }

            var result = _adminManagementsDataService.GetOrderAnalysisData(year, month);

            if (!result.IsSuccess)
            {
                return  ApiResponse<OrderAnalysisResponse>.CreateResponse(ResponseCode.BadRequest, AdminConstants.NO_ORDER_FOR_MONTH_MESSAGE);
            }

            return new ApiResponse<OrderAnalysisResponse>(ResponseCode.Ok, ReturnMessage.SUCCESSFUL, result);
        }
        catch (Exception)
        {
            return ApiResponse<OrderAnalysisResponse>.CreateResponse(ResponseCode.InternalServerError, AdminConstants.ERROR_MESSAGE);
        }
    }
}