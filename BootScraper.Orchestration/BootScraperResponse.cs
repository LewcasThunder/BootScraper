namespace BootScraper.Orchestration
{
    public class BootScraperResponse
    {
        public List<StockLevelData> StockLevelData { get; set; }
    }

    public class StockLevelData
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string Postcode { get; set; }
        public int StoreId { get; set; }
        public bool StockLevel { get; set; }
        public DateTime DateTimeLastSearched { get; set; }
    }
}
