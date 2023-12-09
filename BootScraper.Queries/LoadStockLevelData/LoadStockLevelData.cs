using System.Globalization;
using BootScraper.Common;
using CsvHelper;

namespace BootScraper.Queries.LoadStockLevelData
{
    public static class LoadStockLevelData
    {
        public static List<OutputStockStatusModel> Run(StockLevelRequest options)
        {
            using var reader = new StreamReader(options.OutputLocation);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return csv.GetRecords<OutputStockStatusModel>()
                .DistinctBy(row => row.StoreAddress.StoreId)
                .ToList();
        }
    }
}
