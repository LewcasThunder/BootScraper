using System.Globalization;
using BootScraper.Common;
using CsvHelper;

namespace BootScraper.Commands
{
    public static class OutputCsv
    {
        public static void Execute(StockResponseModel responseModel, StoreAddressModel[] paddedChunk, StockLevelRequest options)
        {
            foreach (var stockLevel in responseModel.stockLevels)
            {
                AddStockStatus(options.OutputLocation, stockLevel.stockLevel,
                    paddedChunk.First(store => store.StoreId == stockLevel.storeId), options);
            }
        }

        private static void AddStockStatus(string outputLocation, string stockLevel, StoreAddressModel storeAddress, StockLevelRequest options)
        {
            if (!File.Exists(options.OutputLocation))
                CommandHelpers.CreateCsvHeader<OutputStockStatusModel>(outputLocation);
            
            using var stream = File.Open(outputLocation, FileMode.Append);
            using var writer = new StreamWriter(stream);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            if (!File.Exists(options.OutputLocation)) csv.WriteHeader<OutputStockStatusModel>();
            var inStock = stockLevel == "G";
            var outputStockDataModel = new OutputStockStatusModel
            {
                StoreAddress = storeAddress,
                DateTimeLastChecked = DateTime.UtcNow,
                InStock = inStock
            };
            csv.WriteRecord(outputStockDataModel);
            csv.NextRecord();

            if (!options.Quiet)
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
