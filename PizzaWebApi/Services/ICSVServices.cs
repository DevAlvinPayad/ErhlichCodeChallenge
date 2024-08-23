using PizzaWebApi.Models.Pizza;

namespace PizzaWebApi.Services
{
    public interface ICSVServices
    {
        public IEnumerable<PizzaRequest> ReadPizzaFromCsv(Stream csvStream);
    }
}
