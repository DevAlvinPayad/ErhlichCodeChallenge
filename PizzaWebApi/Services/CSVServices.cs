using CsvHelper;
using PizzaWebApi.Models.Pizza;
using System.Globalization;

namespace PizzaWebApi.Services
{
    public class CSVServices : ICSVServices
    {
        public IEnumerable<PizzaRequest> ReadPizzaFromCsv(Stream csvStream)
        {
            using var reader = new StreamReader(csvStream);
            using var csv = new CsvReader(reader, new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture));

            
            var obj = csv.GetRecords<PizzaRequest>().ToList();
            
            return obj;
        }
    }
}
