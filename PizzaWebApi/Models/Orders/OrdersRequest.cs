using System.Text.Json.Serialization;

namespace PizzaWebApi.Models.Orders
{
    public class OrdersRequest
    {
        [JsonPropertyName("order_id")]
        public int OrderId { get; set; }

        [JsonPropertyName("date")]
        public DateOnly Date { get; set; }

        [JsonPropertyName("time")]        
        public TimeOnly Time { get; set; }
    }
}
