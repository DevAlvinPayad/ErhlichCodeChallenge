using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
namespace DataManagement.Pizza
{
    public class PizzaServices : IPizzaServices
    {
        private readonly DataManagementDBContext _dbContext;
        public PizzaServices(DataManagementDBContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task SavePizzasAsync(IEnumerable<PizzaModel> pizzas)
        {
            //Validate and Retrieve List of Existing record
            var existingPizzas = await _dbContext.Pizzas.Where(p => pizzas.Select(np => np.PizzaId).Contains(p.PizzaId)).ToListAsync();
            var existingPizzaIds = existingPizzas.Select(p => p.PizzaId).ToHashSet();

            //Filter out new record to save in database
            var pizzasToAdd = pizzas.Where(np => !existingPizzaIds.Contains(np.PizzaId)).ToList();

            _dbContext.Pizzas.AddRange(pizzasToAdd);
            _dbContext.SaveChanges();
        }
    }
}
