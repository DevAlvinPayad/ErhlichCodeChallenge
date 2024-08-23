using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagement.Pizza
{
    public interface IPizzaServices
    {
        public Task SavePizzasAsync(IEnumerable<PizzaModel> pizzas);
    }
}
