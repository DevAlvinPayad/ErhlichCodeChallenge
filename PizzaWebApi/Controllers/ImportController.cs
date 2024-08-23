using Microsoft.AspNetCore.Mvc;
using PizzaWebApi.Services;
using PizzaWebApi.Models.Pizza;
using PizzaWebApi.DataManagement.Pizza;
using PizzaWebApi.DataManagement.PizzaType;
using PizzaWebApi.Models.PizzaType;
using PizzaWebApi.Models.Orders;
using PizzaWebApi.DataManagement.Orders;
using PizzaWebApi.DataManagement.OrdersDetails;
using PizzaWebApi.Models.OrderDetails;
using PizzaWebApi.Enums;

namespace PizzaWebApi.Controllers
{
    [Route("api/[controller]")]
    public class ImportController : Controller
    {
        private readonly ICSVServices _csvServices;
        private readonly IPizzaServices _pizzaServices;
        private readonly IPizzaTypeServices _pizzaTypeServices;
        private readonly IOrdersServices _ordersServices;
        private readonly IOrdersDetailsServices _orderDetailsServices;
        public ImportController(ICSVServices csvServices, IPizzaServices pizzaServices, IPizzaTypeServices pizzaTypeServices,IOrdersServices ordersServices,IOrdersDetailsServices ordersDetailsServices)
        {
            _csvServices = csvServices;
            _pizzaServices = pizzaServices;
            _pizzaTypeServices = pizzaTypeServices;
            _ordersServices = ordersServices;
            _orderDetailsServices = ordersDetailsServices;
        }

        [HttpPost("pizza")]
        public async Task<IActionResult> ImportPizza(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            if (file.ContentType != "text/csv")
            {
                return BadRequest("Uploaded file is not a CSV.");
            }

            try
            {
                using var stream = file.OpenReadStream();

                //convert csv data into IEnumerable
                var pizza = (IEnumerable<PizzaRequest>)_csvServices.ReadFromCsv(stream,ExportTypes.Pizzas);

                //Save Pizza into the database
                await _pizzaServices.SavePizzasAsync(pizza.Select(s => new PizzaModel
                {
                    PizzaId = s.pizza_id,
                    Size = s.size,
                    PizzaTypeId = s.pizza_type_id,
                    Price = s.price
                }));


                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("pizza-type")]
        public async Task<IActionResult> ImportPizzaType(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            if (file.ContentType != "text/csv")
            {
                return BadRequest("Uploaded file is not a CSV.");
            }

            try
            {
                using var stream = file.OpenReadStream();

                //convert csv data into IEnumerable
                var pizzaType = (IEnumerable<PizzaTypeRequest>)_csvServices.ReadFromCsv(stream,ExportTypes.PizzaTypes);

                //Save Pizza Type into the database
                await _pizzaTypeServices.SavePizzaTypeAsync(pizzaType.Select(s => new PizzaTypeModel
                {
                    PizzaTypeId = s.pizza_type_id,
                    Name = s.name,
                    Category = s.category,
                    Ingredients = s.ingredients     
                }));


                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("orders")]
        public async Task<IActionResult> ImportOrders(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            if (file.ContentType != "text/csv")
            {
                return BadRequest("Uploaded file is not a CSV.");
            }

            try
            {
                using var stream = file.OpenReadStream();

                //convert csv data into IEnumerable
                var orders = (IEnumerable<OrdersRequest>)_csvServices.ReadFromCsv(stream, ExportTypes.Orders);

                //Save Orders into the database
                await _ordersServices.SaveOrdersAsync(orders.Select(s => new OrdersModel
                {
                    OrderId = s.order_id,
                    OrderDate = s.date.ToDateTime(s.time)
                }));

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("order-details")]
        public async Task<IActionResult> ImportOrderDetails(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            if (file.ContentType != "text/csv")
            {
                return BadRequest("Uploaded file is not a CSV.");
            }

            try
            {
                using var stream = file.OpenReadStream();

                //convert csv data into IEnumerable
                var orderDetails = (IEnumerable<OrderDetailsRequest>)_csvServices.ReadFromCsv(stream, ExportTypes.OrderDetails);
                //Save Order Details into the database
                await _orderDetailsServices.SaveOrderDetailsAsync(orderDetails.Select(s => new OrdersDetailsModel
                {
                    OrderDetaisId = s.order_details_id,
                    OrderId = s.order_id,
                    PizzaId = s.pizza_id,
                    Quantity = s.quantity
                }));

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
