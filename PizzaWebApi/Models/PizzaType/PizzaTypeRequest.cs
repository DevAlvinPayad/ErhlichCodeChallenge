using System.Text.Json.Serialization;

namespace PizzaWebApi.Models.PizzaType
{
    public class PizzaTypeRequest
    {
        [JsonPropertyName("pizza_type_id")]
        public string PizzaTypeId { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("category")]
        public string Category { get; set; }
        [JsonPropertyName("ingredients")]
        public string Ingredients { get; set; }
    }
}
