using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaWebApi.DataManagement.OrdersDetails
{
    public interface IOrdersDetailsServices
    {
        public Task SaveOrderDetailsAsync(IEnumerable<OrdersDetailsModel> ordersDetails);
    }
}
