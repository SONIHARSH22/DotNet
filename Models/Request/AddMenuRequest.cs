namespace RestaurantManagement.Models.Request;

public class AddMenuRequest
{
    public string? Name { get; set; }
    public decimal? Price { get; set; }
    public string? Description { get; set; }
    public int AvailableQuantity { get; set; }
    public string? Category { get; set; }
}