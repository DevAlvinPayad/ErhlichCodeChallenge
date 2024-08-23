using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaWebApi.DataManagement.Orders
{
    [Table(name: "Orders")]
    public class OrdersModel
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}

