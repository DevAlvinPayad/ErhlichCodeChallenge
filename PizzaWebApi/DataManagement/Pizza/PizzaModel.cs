using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaWebApi.DataManagement.Pizza
{
    [Table(name: "Pizza")]
    public class PizzaModel
    {
        [Key]
        public string PizzaId { get; set; }
        public string PizzaTypeId { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
    }
}
