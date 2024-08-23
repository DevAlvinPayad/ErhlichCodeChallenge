using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagement.OrdersDetails
{
    [Table(name: "OrdersDetails")]
    public class OrdersDetailsModel
    {
        [Key]
        public int OrderDetaisId { get; set; }
        public int OrderId { get; set; }
        public string PizzaId { get; set; }
        public int Quantity { get; set; }
    }
}

