using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Common.Constants;
using RestaurantManagement.Common.Enums;
using RestaurantManagement.Models.Response;

namespace RestaurantManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// Generates a standardized API response based on the service response status code.
        /// </summary>
        /// <param name="apiResponse">The response object containing status code and data.</param>
        /// <returns>An IActionResult representing the HTTP response.</returns>
        protected IActionResult GenerateResponse<T>(ApiResponse<T> apiResponse)
        {
            return apiResponse.responseCode switch
            {
                ResponseCode.Ok => Ok(apiResponse),
                ResponseCode.Created => StatusCode(201, apiResponse),
                ResponseCode.NoContent => NoContent(),
                ResponseCode.BadRequest => BadRequest(apiResponse),
                ResponseCode.Unauthorized => Unauthorized(apiResponse),
                ResponseCode.NotFound => NotFound(apiResponse),
                ResponseCode.Conflict => Conflict(apiResponse),
                ResponseCode.InternalServerError => StatusCode(500, apiResponse),
                _ => StatusCode(500, new ApiResponse<string>(ResponseCode.InternalServerError, ReturnMessage.ERROR_OCCURRED, null))
            };
        }
    }
}
