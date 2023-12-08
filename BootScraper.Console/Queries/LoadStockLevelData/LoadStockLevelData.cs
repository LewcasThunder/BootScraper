using BootScraper.Console.Common;
using CsvHelper;
using System.Globalization;

namespace BootScraper.Console.Queries.LoadStockLevelData
{
    internal static class LoadStockLevelData
    {
        internal static List<OutputStockStatusModel> Run(CommandLineOptions options)
        {
            using var reader = new StreamReader(options.OutputLocation);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return csv.GetRecords<OutputStockStatusModel>()
                .DistinctBy(row => row.StoreAddress.StoreId)
                .ToList();
        }
    }
}
