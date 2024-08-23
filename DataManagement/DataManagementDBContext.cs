using Microsoft.EntityFrameworkCore;
using DataManagement.Pizza;
using DataManagement.PizzaType;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations.Schema;
using DataManagement.Orders;
using DataManagement.OrdersDetails;

namespace DataManagement
{
    public class DataManagementDBContext : DbContext
    {
        private readonly IConfiguration _config;

        public DataManagementDBContext(IConfiguration config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("PizzaDbConnectionString"));
        }

        public virtual DbSet<PizzaModel> Pizzas { get; set; }
        public virtual DbSet<PizzaTypeModel> PizzaType { get; set; }
        public virtual DbSet<OrdersModel> Orders { get; set; }
        public virtual DbSet<OrdersDetailsModel> OrderDetails { get; set; }
    }
}

