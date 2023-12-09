using System.Globalization;
using BootScraper.Common;
using CsvHelper;

namespace BootScraper.Commands
{
    public static class OutputDeduplicatedCsv
    {
        public static void Execute(IEnumerable<OutputStockStatusModel> stockLevels, StockLevelRequest options)
        {
            var deduplicatedFileName = options.OutputLocation.Replace(".csv", "-deduplicated.csv");

            using var stream = File.Open(deduplicatedFileName, FileMode.Append);
            using var writer = new StreamWriter(stream);
            using var outputCsv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            outputCsv.WriteRecords(stockLevels);
        }
    }
}
