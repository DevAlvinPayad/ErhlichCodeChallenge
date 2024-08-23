using System.Text.Json.Serialization;

namespace PizzaWebApi.Models.Orders
{
    public class OrdersRequest
    {
        [JsonPropertyName("order_id")]
        public int order_id { get; set; }

        [JsonPropertyName("date")]
        public DateOnly date { get; set; }

        [JsonPropertyName("time")]        
        public TimeOnly time { get; set; }
    }
}
