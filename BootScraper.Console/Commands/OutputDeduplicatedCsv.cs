using System.Globalization;
using BootScraper.Console.Common;
using CsvHelper;

namespace BootScraper.Console.Commands
{
    internal static class OutputDeduplicatedCsv
    {
        internal static void Execute(IEnumerable<OutputStockStatusModel> stockLevels, CommandLineOptions options)
        {
            var deduplicatedFileName = options.OutputLocation.Replace(".csv", "-deduplicated.csv");

            using var stream = File.Open(deduplicatedFileName, FileMode.Append);
            using var writer = new StreamWriter(stream);
            using var outputCsv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            outputCsv.WriteRecords(stockLevels);
        }
    }
}
