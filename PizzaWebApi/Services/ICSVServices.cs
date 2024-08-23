using PizzaWebApi.Enums;
using PizzaWebApi.Models.OrderDetails;
using PizzaWebApi.Models.Orders;
using PizzaWebApi.Models.Pizza;
using PizzaWebApi.Models.PizzaType;

namespace PizzaWebApi.Services
{
    public interface ICSVServices
    {
        public IEnumerable<Object> ReadFromCsv(Stream csvStream, ExportTypes exportType);
    }
}
