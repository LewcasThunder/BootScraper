using CsvHelper.Configuration.Attributes;

namespace BootScraper.Queries.LoadStoreData
{
    public class StoreAddressModel
    {
        [Name("Line1")]
        public string Line1 { get; set; }
        [Name("Line2")]
        public string Line2 { get; set; }
        [Name("Line3")]
        public string Line3 { get; set; }
        [Name("Postcode")]
        public string Postcode { get; set; }
        [Name("StoreId")]
        public int StoreId { get; set; }
    }
}
