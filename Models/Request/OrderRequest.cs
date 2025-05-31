using System.Text.Json.Serialization;

namespace RestaurantManagement.Models.Request;

public class OrderRequest
{
    public int CustomerId { get; set; }
    public int TableId { get; set; }
    public int MenuId { get; set; }
    public int Quantity { get; set; }
    [JsonIgnore]
    public int Price { get; set; }
}