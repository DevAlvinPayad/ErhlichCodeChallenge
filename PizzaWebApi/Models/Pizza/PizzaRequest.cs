using System.Text.Json.Serialization;

namespace PizzaWebApi.Models.Pizza
{
    public class PizzaRequest
    {
        [JsonPropertyName("pizza_id")]
        public string pizza_id { get; set; }

        [JsonPropertyName("pizza_type_id")]
        public string pizza_type_id { get; set; }

        [JsonPropertyName("size")]
        public string size { get; set; }

        [JsonPropertyName("price")]
        public decimal price { get; set; }
    }
}
