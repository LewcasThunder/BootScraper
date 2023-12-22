using System.Globalization;
using CsvHelper;

namespace BootScraper.Queries
{
    public static class InputFromCsv
    {
        public static IEnumerable<StoreAddressModel> Execute(string inputStoreData, string county)
        {
            if (county == null)
            {
                using var reader = new StreamReader(inputStoreData);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                return csv.GetRecords<StoreAddressModel>().ToList();
            }
            else
            {
                using var reader = new StreamReader(inputStoreData);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                return csv.GetRecords<StoreAddressModel>().Where(store =>
                    {
                        return store.Line1.ToLower() == county.ToLower() ||
                               store.Line2.ToLower() == county.ToLower() ||
                               store.Line3.ToLower() == county.ToLower();
                    })
                    .ToList();
            }
        }
    }
}
