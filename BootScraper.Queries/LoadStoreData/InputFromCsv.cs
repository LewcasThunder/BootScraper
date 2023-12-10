using System.Globalization;
using BootScraper.Common;
using CsvHelper;

namespace BootScraper.Queries.LoadStoreData
{
    public static class InputFromCsv
    {
        public static IEnumerable<StoreAddressModel> Execute(BootScraperRequest options)
        {
            if (options.County == null)
            {
                using var reader = new StreamReader(options.InputStoreData);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                return csv.GetRecords<StoreAddressModel>().ToList();
            }
            else
            {
                using var reader = new StreamReader(options.InputStoreData);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                return csv.GetRecords<StoreAddressModel>().Where(store =>
                    {
                        var county = options.County.ToLower();
                        return store.Line1.ToLower() == county ||
                               store.Line2.ToLower() == county ||
                               store.Line3.ToLower() == county;
                    })
                    .ToList();
            }
        }
    }
}
