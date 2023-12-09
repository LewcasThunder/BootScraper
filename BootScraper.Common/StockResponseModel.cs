namespace BootScraper.Common
{
    public class StockResponseModel
    {
        public Stocklevel[] stockLevels { get; set; }
    }

    public class Stocklevel
    {
        public int storeId { get; set; }
        public string productId { get; set; }
        public string stockLevel { get; set; }
    }
}
