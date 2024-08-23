using CsvHelper;
using PizzaWebApi.Enums;
using PizzaWebApi.Models.OrderDetails;
using PizzaWebApi.Models.Orders;
using PizzaWebApi.Models.Pizza;
using PizzaWebApi.Models.PizzaType;
using System.Globalization;
using System.Reflection.Metadata;

namespace PizzaWebApi.Services
{
    public class CSVServices : ICSVServices
    {
        public IEnumerable<Object> ReadFromCsv(Stream csvStream, ExportTypes exportType)
        {
            using var reader = new StreamReader(csvStream);
            using var csv = new CsvReader(reader, new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture));

            IEnumerable<Object> result = new List<Object>();
            switch(exportType)
            {
                case ExportTypes.Pizzas : 
                    result = csv.GetRecords<PizzaRequest>().ToList();
                    break;
                case ExportTypes.PizzaTypes:
                    result = csv.GetRecords<PizzaTypeRequest>().ToList();
                    break;
                case ExportTypes.Orders:
                    result = csv.GetRecords<OrdersRequest>().ToList();
                    break;
                case ExportTypes.OrderDetails:
                    result = csv.GetRecords<OrderDetailsRequest>().ToList();
                    break;
            };

            return result;
        }

    }
}
