using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagement.Orders
{
    public interface IOrdersServices
    {
        public Task SaveOrdersAsync(IEnumerable<OrdersModel> orders);
    }
}
