using System.Globalization;
using CsvHelper;

namespace BootScraper.Commands
{
    public static class Commands
    {
        public static void Execute(CommandsRequest commandsRequest)
        {
            if (!File.Exists(commandsRequest.OutputLocation))
                CreateCsvHeader<CommandOutputModel>(commandsRequest.OutputLocation);

            var output = commandsRequest.OutputModel;
            if (commandsRequest.DeduplicateOutput)
                output = commandsRequest.OutputModel.DistinctBy(row => row.StoreId).ToList();

            foreach (var outputRow in output)
            {
                using var stream = File.Open(commandsRequest.OutputLocation, FileMode.Append);
                using var writer = new StreamWriter(stream);
                using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
                csv.WriteRecord(outputRow);
                csv.NextRecord();

                if (commandsRequest.Quiet) return;
                var stockStatus = outputRow.StockLevel ? "In Stock" : "Out of Stock";
                Console.WriteLine(outputRow.Line1 + " " +
                                         outputRow.Line2 + " " +
                                         outputRow.Line3 + " " +
                                         outputRow.Postcode + ": " +
                                         stockStatus);
            }
        }

        private static void CreateCsvHeader<T>(string? outputLocation)
        {
            using var stream = File.Open(outputLocation, FileMode.Append);
            using var writer = new StreamWriter(stream);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            {
                csv.WriteHeader<T>();
                csv.NextRecord();
            }
        }
    }
}
