using RestaurantManagement.Common.Enums;

namespace RestaurantManagement.Models.Response
{
    /// <summary>
    /// ApiResponse class
    /// </summary>
    /// <remarks>
    /// Constructor For ApiResponse
    /// </remarks>
    /// <param name="statusCode"></param>
    /// <param name="message"></param>
    /// <param name="data"></param>
    public class ApiResponse<T>(ResponseCode responseCode, string message, T? data)
    {
        public ResponseCode responseCode { get; set; } = responseCode;
        public string Message { get; set; } = message;
        public T? Data { get; set; } = data;
        public string? Token { get; set; }

        public static ApiResponse<T> CreateResponse(ResponseCode responseCode, string message, T data = default)
        {
            return new ApiResponse<T>(responseCode, message, data);
        }
    }
}
