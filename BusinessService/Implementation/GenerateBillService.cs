using RestaurantManagement.BusinessService.Interface;
using RestaurantManagement.Common.Constants;
using RestaurantManagement.Common.Enums;
using RestaurantManagement.Models.Entity;
using RestaurantManagement.Models.Response;
using RestaurantManagement.DataService.Interface;

namespace RestaurantManagement.BusinessService.Implementation;

public class GenerateBillService : IGenerateBillService
{
    private readonly IGenerateBillDataService _customerBillingDataService;

    public GenerateBillService(IGenerateBillDataService customerBillingDataService)
    {
        _customerBillingDataService = customerBillingDataService;
    }
    /// <summary>
    /// Generates bill for user by taking its customerid
    /// </summary>
    /// <param name="customerId"></param>
    /// <returns></returns>
    public ApiResponse<BillingResult> GenerateBill(int customerId)
    {
        try
        {
            Users? user = _customerBillingDataService.GetUserById(customerId);
            if (user == null)
            {
                return ApiResponse<BillingResult>.CreateResponse(ResponseCode.NotFound,ReturnMessage.INVALID_CUSTOMER_ID);
            }

            List<Orders> existingOrders = _customerBillingDataService.GetCustomerOrders(customerId);
            if (existingOrders.Count == 0)
            {
                return ApiResponse<BillingResult>.CreateResponse(ResponseCode.Ok, ReturnMessage.NO_ORDER_FOUND);
            }

            decimal total = 0;
            List<BillingResponse> billDetails = new List<BillingResponse>();

            foreach (Orders order in existingOrders)
            {
                decimal orderTotal = order.Price * order.Quantity;
                total += orderTotal;

                billDetails.Add(new BillingResponse
                {
                    OrderId = order.OrderId,
                    UserId = order.UserId,
                    Name = _customerBillingDataService.GetMenuItemName(order.MenuId) ?? "",
                    Quantity = order.Quantity,
                    Price = (int)order.Price
                });
                order.OrderStatus = (int)OrderStatus.Served;

            }

            _customerBillingDataService.UpdateOrders(existingOrders);

            _customerBillingDataService.FreeTable(existingOrders[0].TableId);

            _customerBillingDataService.SaveChanges();

            return new ApiResponse<BillingResult>
            (
                ResponseCode.Ok,ReturnMessage.BILL_GENERATED_SUCCESSFULLY,

                new BillingResult
                {
                    GrandTotal = total,
                    BillDetails = billDetails,
                    message = ReturnMessage.BILL_GENERATED_SUCCESSFULLY
                }
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return ApiResponse<BillingResult>.CreateResponse(ResponseCode.InternalServerError, ReturnMessage.ERROR_OCCURRED);
        }
    }
}