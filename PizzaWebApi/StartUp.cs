using PizzaWebApi.DataManagement.Orders;
using PizzaWebApi.DataManagement.OrdersDetails;
using PizzaWebApi.DataManagement.Pizza;
using PizzaWebApi.DataManagement.PizzaType;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using PizzaWebApi.Services;

namespace PizzaWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<ICSVServices, CSVServices>();
            //services.AddSingleton<IPizzaServices, PizzaServices>();
            //services.AddSingleton<IPizzaTypeServices, PizzaTypeServices>();
            //services.AddSingleton<IOrdersServices, OrdersServices>();
            //services.AddSingleton<IOrdersDetailsServices,OrdersDetailsServices>();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app)
        {
           
            app.UseSwagger();
            app.UseSwaggerUI();
            

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
