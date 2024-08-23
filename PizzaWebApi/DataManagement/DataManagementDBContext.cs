using Microsoft.EntityFrameworkCore;
using PizzaWebApi.DataManagement.Pizza;
using PizzaWebApi.DataManagement.PizzaType;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations.Schema;
using PizzaWebApi.DataManagement.Orders;
using PizzaWebApi.DataManagement.OrdersDetails;

namespace PizzaWebApi.DataManagement
{
    public class DataManagementDBContext : DbContext
    {
        //private readonly IConfiguration _config;

        //public DataManagementDBContext(IConfiguration config)
        //{
        //    _config = config;
        //}
        public DataManagementDBContext()
        {
          
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConfigurationManager config = new ConfigurationManager();
            optionsBuilder.UseSqlServer(config.GetConnectionString("PizzaDbConnectionString"));
        }

        public virtual DbSet<PizzaModel> Pizzas { get; set; }
        public virtual DbSet<PizzaTypeModel> PizzaType { get; set; }
        public virtual DbSet<OrdersModel> Orders { get; set; }
        public virtual DbSet<OrdersDetailsModel> OrderDetails { get; set; }
    }
}

