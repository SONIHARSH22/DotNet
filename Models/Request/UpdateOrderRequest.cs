namespace RestaurantManagement.Models.Request;

public class UpdateOrderRequest
{
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
}