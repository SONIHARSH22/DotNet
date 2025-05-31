using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Models.Entity;
using RestaurantManagement.Models.Request;
using RestaurantManagement.Models.Response;
using RestaurantManagement.BusinessService.Interface;
using RestaurantManagement.Common.Constants;


namespace RestaurantManagement.Controllers
{
    [Route(ApisEndpoints.API_CONTROLLER)]
    [ApiController]
    public class FoodOrderingController : BaseController
    {
        private readonly IOrderFoodService FoodOrderingService;

        public FoodOrderingController(IOrderFoodService foodOrderingBusinessService)
        {
            FoodOrderingService = foodOrderingBusinessService;
        }

        [HttpGet]
        [Route(ApisEndpoints.GET_ALL_MENU)]
        public IActionResult GetAllMenu()
        {
            ApiResponse<List<Menus>> response = FoodOrderingService.GetAllFoodItems();
            return GenerateResponse(response);
        }

        [HttpGet(ApisEndpoints.SEARCH_BY_CATEGORY)]
        public IActionResult GetFoodItemsByCategory(string category)
        {
            ApiResponse<List<Menus>> response = FoodOrderingService.GetFoodItemsByCategory(category);
            return GenerateResponse(response);
        }

        [HttpPost]
        [Route(ApisEndpoints.ORDER_FOOD)]
        public IActionResult OrderFood(OrderRequest orderRequest)
        {
            ApiResponse<OrderResponse> response = FoodOrderingService.OrderFood(orderRequest);
            return GenerateResponse(response);
        }

        [HttpGet]
        [Route(ApisEndpoints.SEE_YOUR_RECENT_ORDER)]
        public IActionResult SeeYourRecentOrder(int customerId)
        {
            ApiResponse<List<OrderResponse>> response = FoodOrderingService.SeeYourRecentOrders(customerId);
            return GenerateResponse(response);
        }

        [HttpPut]
        [Route(ApisEndpoints.UPDATE_ORDER)]
        public IActionResult UpdateOrder([FromBody] UpdateOrderRequest updateOrder)
        {
            ApiResponse<OrderResponse> response = FoodOrderingService.UpdateOrder(updateOrder);
            return GenerateResponse(response);
        }

        [HttpPut]
        [Route(ApisEndpoints.CANCEL_ORDER)]
        public IActionResult CancelOrder(int orderId, int customerId)
        {
            ApiResponse<OrderResponse> response = FoodOrderingService.CancelOrder(orderId, customerId);
            return GenerateResponse(response);
        }
    }
}