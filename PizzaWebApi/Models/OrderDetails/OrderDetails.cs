namespace PizzaWebApi.Models.OrderDetails
{
    public class OrderDetails
    {
        public int OrderDetaisId { get; set; }
        public int OrderId { get; set; }
        public string PizzaId { get; set; }
        public int Quantity { get; set; }
    }
}
