using System.Text.Json.Serialization;

namespace PizzaWebApi.Models.OrderDetails
{
    public class OrderDetailsRequest
    {
        [JsonPropertyName("order_details_id")]
        public int OrderDetaisId { get; set; }

        [JsonPropertyName("order_id")]
        public int OrderId { get; set; }

        [JsonPropertyName("pizza_id")]
        public string PizzaId { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
    }
}
