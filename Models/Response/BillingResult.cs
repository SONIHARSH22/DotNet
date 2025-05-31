namespace RestaurantManagement.Models.Response
{
    public class BillingResult
    {
        public decimal GrandTotal { get; set; }
        public List<BillingResponse>? BillDetails { get; set; }
        public string? message { get; set; }
    }
}
