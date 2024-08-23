using Microsoft.EntityFrameworkCore;
using PizzaWebApi.DataManagement;
using PizzaWebApi.DataManagement.Orders;
using PizzaWebApi.DataManagement.OrdersDetails;
using PizzaWebApi.DataManagement.Pizza;
using PizzaWebApi.DataManagement.PizzaType;
using PizzaWebApi.Services;


namespace PizzaWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddSingleton<ICSVServices, CSVServices>();
            //builder.Services.AddSingleton<IPizzaServices, PizzaServices>();
            //builder.Services.AddSingleton<IPizzaTypeServices, PizzaTypeServices>();
            //builder.Services.AddSingleton<IOrdersServices, OrdersServices>();
            //builder.Services.AddSingleton<IOrdersDetailsServices, OrdersDetailsServices>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //    .ConfigureWebHostDefaults(webBuilder =>
        //    {
        //        webBuilder.UseStartup<Startup>();
        //    });
    }
}












//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//builder.Services.AddSingleton<ICSVServices, CSVServices>();
//builder.Services.AddScoped<IPizzaServices, PizzaServices>();
//builder.Services.AddScoped<IPizzaTypeServices, PizzaTypeServices>();
//builder.Services.AddScoped<IOrdersServices, OrdersServices>();

//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
