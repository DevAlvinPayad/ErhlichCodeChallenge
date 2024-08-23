using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace PizzaWebApi.DataManagement.OrdersDetails
{
    public class OrdersDetailsServices : IOrdersDetailsServices
    {
        private readonly DataManagementDBContext _dbContext;
        public OrdersDetailsServices(DataManagementDBContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task SaveOrderDetailsAsync(IEnumerable<OrdersDetailsModel> ordersDetails)
        {
            //Validate and Retrieve List of Existing record
            var existingOrders = await _dbContext.Orders.Where(p => ordersDetails.Select(np => np.OrderId).Contains(p.OrderId)).ToListAsync();
            var existingOrderIds = existingOrders.Select(p => p.OrderId).ToHashSet();

            //Filter out new record to save in database
            var newOrders = ordersDetails.Where(np => !existingOrderIds.Contains(np.OrderId)).ToList();

            _dbContext.OrderDetails.AddRange(newOrders);
            _dbContext.SaveChanges();
        }
    }
}
