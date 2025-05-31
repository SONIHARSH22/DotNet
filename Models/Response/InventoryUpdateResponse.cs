namespace RestaurantManagement.Models.Response
{
    public class InventoryUpdateResponse
    {
        public int InventoryId { get; set; }
        public string? Name { get; set; }
        public int PreviousQuantity { get; set; }
        public int UpdatedQuantity { get; set; }
        public string? Category { get; set; }
        public string? Message { get; set; }
    }
}
