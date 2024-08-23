using System.Text.Json.Serialization;

namespace PizzaWebApi.Models.PizzaType
{
    public class PizzaTypeRequest
    {
        [JsonPropertyName("pizza_type_id")]
        public string pizza_type_id { get; set; }
        [JsonPropertyName("name")]
        public string name { get; set; }
        [JsonPropertyName("category")]
        public string category { get; set; }
        [JsonPropertyName("ingredients")]
        public string ingredients { get; set; }
    }
}
