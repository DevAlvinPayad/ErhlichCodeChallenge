using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaWebApi.DataManagement.PizzaType
{
    [Table(name: "PizzaType")]
    public class PizzaTypeModel
    {
        [Key]
        public string PizzaTypeId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Ingredients { get; set; }
    }
}
