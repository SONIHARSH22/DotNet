using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Models.Entity;
using RestaurantManagement.Models.Request;
using RestaurantManagement.BusinessService.Interface;
using RestaurantManagement.Common.Constants;
using RestaurantManagement.Models.Response;


namespace RestaurantManagement.Controllers
{
    [Route(ApisEndpoints.API_CONTROLLER)]
    [ApiController]

    public class TableController : BaseController
    {
        private readonly IBookTableService _tableBookingService;

        public TableController(IBookTableService tableBookingBusinessService)
        {
            _tableBookingService = tableBookingBusinessService;
        }

        [HttpGet]
        [Route(ApisEndpoints.GET_ALL_TABLES)]
        public IActionResult GetAllTables()
        {   
          ApiResponse<List<Tables>> response = _tableBookingService.GetAllTables();
          return GenerateResponse(response);
        }

        [HttpGet]
        [Route(ApisEndpoints.SELECT_AVAILABLE_TABLE)]
        public IActionResult GetTables()
        {
                ApiResponse<List<Tables>> response = _tableBookingService.GetAvailableTables();
                return GenerateResponse(response);
        }

        [HttpPost]
        [Route(ApisEndpoints.BOOK_TABLE)]
        public IActionResult BookTable(TableIdRequest tableBookingCanceling)
        {
            ApiResponse<Tables> response = _tableBookingService.BookTable(tableBookingCanceling);
            return GenerateResponse(response);
        }

        [HttpPost]
        [Route(ApisEndpoints.CANCEL_TABLE)]
        public IActionResult CancelTable(TableIdRequest tableBookingCanceling)
        {
            ApiResponse<Tables> response = _tableBookingService.CancelTableBooking(tableBookingCanceling);
            return GenerateResponse(response);
        }
    }
}