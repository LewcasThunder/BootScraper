using CsvHelper;
using System.Globalization;
using BootScraper.Console.Common;

namespace BootScraper.Console.Queries.LoadStoreData
{
    internal static class InputFromCsv
    {
        internal static IEnumerable<StoreAddressModel> Execute()
        {
            using var reader = new StreamReader("Queries\\LoadStoreData\\StoreData.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return csv.GetRecords<StoreAddressModel>().ToList();
        }
    }
}
