using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.BusinessService.Interface;
using RestaurantManagement.Models.Response;
using RestaurantManagement.Common.Constants;

namespace RestaurantManagement.Controllers;

[Route(ApisEndpoints.API_CONTROLLER)]
[ApiController]
public class BillingController : BaseController
{
    private readonly IGenerateBillService _billingBusinessService;

    public BillingController(IGenerateBillService billingBusinessService)
    {
        _billingBusinessService = billingBusinessService;
    }

    [HttpGet(ApisEndpoints.GENERATE_BILL)]
    public IActionResult GenerateBill(int customerId)
    {
        ApiResponse<BillingResult> bill = _billingBusinessService.GenerateBill(customerId);
        return GenerateResponse(bill);
    }
}