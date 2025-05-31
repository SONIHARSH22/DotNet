using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Models.Response;
using RestaurantManagement.BusinessService.Interface;
using RestaurantManagement.Common.Constants;
using RestaurantManagement.Models.Request;

namespace RestaurantManagement.Controllers
{
    [Route(ApisEndpoints.ADMIN_CONTROLLER_ROUTE)]
    [Authorize(Roles = UserRoles.ADMIN)]
    [ApiController]
    public class AdminManagementController : BaseController
    {
        private readonly IAdminManagementService _adminBusinessService;

        public AdminManagementController(IAdminManagementService adminBusinessService)
        {
            _adminBusinessService = adminBusinessService;
        }

        [HttpGet(ApisEndpoints.PENDING_ORDERS_ENDPOINT)]
        public IActionResult GetPendingOrders()
        {
            ApiResponse<List<OrderResponse>> pendingOrders = _adminBusinessService.SeeAllPendingOrder();
            return GenerateResponse(pendingOrders);
        }
        
        [HttpPost(ApisEndpoints.MARK_ATTENDANCE_ENDPOINT)]
        public IActionResult RecordAttendance(MarkAttendanceRequest markAttendance)
        {
            ApiResponse<string> pendingOrders = _adminBusinessService.RecordAttendance(markAttendance);
            return GenerateResponse(pendingOrders);
        }
   
        [HttpGet(ApisEndpoints.FOOD_ORDER_ANALYSIS_ENDPOINT)] 
        public IActionResult FoodOrderAnalysis(int year, int month)
        {
            ApiResponse<OrderAnalysisResponse> result = _adminBusinessService.OrderAnalysis(year, month);
            return GenerateResponse(result);
        }
    }
}