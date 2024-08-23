using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagement.PizzaType
{
    public interface IPizzaTypeServices
    {
        public Task SavePizzaTypeAsync(IEnumerable<PizzaTypeModel> pizzaType);
    }
}
