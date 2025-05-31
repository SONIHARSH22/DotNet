using RestaurantManagement.Models.Response;

namespace RestaurantManagement.BusinessService.Interface;

public interface IGenerateBillService
{
    /// <summary>
    /// Generates a bill for a user based on their customer ID.
    /// </summary>
    /// <param name="customerId">The unique identifier of the customer.</param>
    /// <returns>An ApiResponse containing the billing details.</returns>
    ApiResponse<BillingResult> GenerateBill(int customerId);
}