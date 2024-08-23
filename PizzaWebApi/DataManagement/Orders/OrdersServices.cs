using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
namespace PizzaWebApi.DataManagement.Orders
{
    public class OrdersServices : IOrdersServices
    {
        private readonly DataManagementDBContext _dbContext;
        public OrdersServices(DataManagementDBContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task SaveOrdersAsync(IEnumerable<OrdersModel> orders)
        {
            //Validate and Retrieve List of Existing record
            var existingOrders = await _dbContext.Orders.Where(p => orders.Select(np => np.OrderId).Contains(p.OrderId)).ToListAsync();
            var existingOrderIds = existingOrders.Select(p => p.OrderId).ToHashSet();

            //Filter out new record to save in database
            var newOrders = orders.Where(np => !existingOrderIds.Contains(np.OrderId)).ToList();

            _dbContext.Orders.AddRange(newOrders);
            _dbContext.SaveChanges();
        }
    }
}
