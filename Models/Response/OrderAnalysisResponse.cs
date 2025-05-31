using System.Text.Json.Serialization;

namespace RestaurantManagement.Models.Response
{
    public class OrderAnalysisResponse
    {
        public Dictionary<string, int>? OrderedItems { get; set; }
        public string? ErrorMessage { get; set; }
        [JsonIgnore]
        public bool IsSuccess { get; set; }
    }
}