using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
namespace PizzaWebApi.DataManagement.PizzaType
{
    public class PizzaTypeServices : IPizzaTypeServices
    {
        private readonly DataManagementDBContext _dbContext;
        public PizzaTypeServices(DataManagementDBContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task SavePizzaTypeAsync(IEnumerable<PizzaTypeModel> pizzaType)
        {
            //Validate and Retrieve List of Existing record
            var existingPizzaTypes = await _dbContext.PizzaType.Where(p => pizzaType.Select(np => np.PizzaTypeId).Contains(p.PizzaTypeId)).ToListAsync();
            var existingPizzaTypesIs = existingPizzaTypes.Select(p => p.PizzaTypeId).ToHashSet();

            //Filter out new record to save in database
            var newPizzaType = pizzaType.Where(np => !existingPizzaTypesIs.Contains(np.PizzaTypeId)).ToList();

            _dbContext.PizzaType.AddRange(newPizzaType);
            _dbContext.SaveChanges();
        }
    }
}
