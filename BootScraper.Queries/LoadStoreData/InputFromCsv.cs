using System.Globalization;
using BootScraper.Common;
using CsvHelper;

namespace BootScraper.Queries.LoadStoreData
{
    public static class InputFromCsv
    {
        public static IEnumerable<StoreAddressModel> Execute(StockLevelRequest options)
        {
            using var reader = new StreamReader(options.InputStoreData);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return csv.GetRecords<StoreAddressModel>().ToList();
        }
    }
}
