using RestaurantManagement.Models.Entity;
using RestaurantManagement.Models.Request;
using RestaurantManagement.Models.Response;

namespace RestaurantManagement.BusinessService.Interface;

public interface IOrderFoodService
{
    /// <summary>
    /// Retrieves a list of all available food items.
    /// </summary>
    /// <returns>A list of Menu objects representing all food items.</returns>
    ApiResponse<List<Menus>> GetAllFoodItems();

    /// <summary>
    /// Places an order for food based on the provided order request.
    /// </summary>
    /// <param name="orderRequest">The request containing order details.</param>
    /// <returns>An OrderResponse object indicating the result of the order placement.</returns>
    ApiResponse<OrderResponse> OrderFood(OrderRequest orderRequest);

    /// <summary>
    /// Retrieves a list of recent orders for a specific customer.
    /// </summary>
    /// <param name="customerId">The ID of the customer.</param>
    /// <returns>A list of OrderResponse objects representing the customer's recent orders.</returns>
    ApiResponse<List<OrderResponse>> SeeYourRecentOrders(int customerId);

    /// <summary>
    /// Updates the quantity of an existing order.
    /// </summary>
    /// <param name="orderId">The ID of the order to update.</param>
    /// <param name="customerId">The ID of the customer who placed the order (for authorization).</param>
    /// <param name="quantity">The new quantity for the order.</param>
    /// <returns>An OrderResponse object indicating the result of the update.</returns>
    ApiResponse<OrderResponse> UpdateOrder(UpdateOrderRequest updateOrder);

    /// <summary>
    /// Cancels an existing order.
    /// </summary>
    /// <param name="orderId">The ID of the order to cancel.</param>
    /// <param name="customerId">The ID of the customer who placed the order (for authorization).</param>
    /// <returns>An OrderResponse object indicating the result of the cancellation.</returns>
    ApiResponse<OrderResponse> CancelOrder(int orderId, int customerId);

    /// <summary>
    /// Retrieves a list of food items belonging to a specific category.
    /// </summary>
    /// <param name="category">The category of food items to retrieve.</param>
    /// <returns>A list of Menu objects representing the food items in the specified category.</returns>
    ApiResponse<List<Menus>> GetFoodItemsByCategory(string category);
}