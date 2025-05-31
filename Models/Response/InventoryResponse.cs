namespace RestaurantManagement.Models.Response
{
    public class InventoryResponse
    {
        public int InventoryId { get; set; }
        public string? Name { get; set; }
        public int AvailableQuantity { get; set; }
        public string? Category { get; set; }
    }
}