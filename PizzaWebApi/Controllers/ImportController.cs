using Microsoft.AspNetCore.Mvc;
using PizzaWebApi.Services;
using PizzaWebApi.Models.Pizza;
using PizzaWebApi.DataManagement.Pizza;

namespace PizzaWebApi.Controllers
{
    [Route("api/[controller]")]
    public class ImportController : Controller
    {
        private readonly ICSVServices _csvServices;
        //private readonly IPizzaServices _pizzaServices;
        //public ImportController(ICSVServices csvServices, IPizzaServices pizzaServices) 
        //{
        //    _csvServices = csvServices;
        //    _pizzaServices = pizzaServices;
        //}

        public ImportController(ICSVServices csvServices)
        {
            _csvServices = csvServices;
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
                IEnumerable<PizzaRequest> pizza = _csvServices.ReadPizzaFromCsv(stream);

                //Save Pizza into the database
                PizzaServices pizzaServices = new PizzaServices();
                await _pizzaServices.SavePizzasAsync(pizza.Select(s => new PizzaModel
                {
                    PizzaId = s.pizza_id,
                    Size = s.size,
                    PizzaTypeId = s.pizza_type_id,
                    Price = s.price
                }));


                return Ok(pizza);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
