namespace PizzaWebApi.Models.Pizza
{
    public class Pizza
    {
        public string PizzaId {  get; set; }
        public string PizzaTypeId { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
    }
}
