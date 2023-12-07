using CsvHelper;
using System.Globalization;
using BootScraper.Console.Common;

namespace BootScraper.Console.Commands
{
    internal static class OutputCsv
    {
        internal static void AddStockStatus(string outputLocation, string stockLevel, StoreAddressModel storeAddress, bool quietMode)
        {
            using var stream = File.Open(outputLocation, FileMode.Append);
            using var writer = new StreamWriter(stream);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            var inStock = stockLevel == "G";
            var outputStockDataModel = new OutputStockStatusModel
            {
                StoreAddress = storeAddress,
                DateLastChecked = DateTime.UtcNow,
                InStock = inStock
            };
            csv.WriteRecord(outputStockDataModel);
            csv.NextRecord();

            if (!quietMode)
            {
                var stockStatus = inStock ? "In Stock" : "Out of Stock";
                System.Console.WriteLine(storeAddress.Line1 + " " + 
                                         storeAddress.Line2 + " " + 
                                         storeAddress.Line3 + " " + 
                                         storeAddress.Postcode + ": " + 
                                         stockStatus);
            }
        }
    }
}
