using System.Text.Json.Serialization;

namespace PizzaWebApi.Models.OrderDetails
{
    public class OrderDetailsRequest
    {
        [JsonPropertyName("order_details_id")]
        public int order_details_id { get; set; }

        [JsonPropertyName("order_id")]
        public int order_id { get; set; }

        [JsonPropertyName("pizza_id")]
        public string pizza_id { get; set; }

        [JsonPropertyName("quantity")]
        public int quantity { get; set; }
    }
}
