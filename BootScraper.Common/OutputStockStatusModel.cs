namespace BootScraper.Common
{
    public class OutputStockStatusModel
    {
        public StoreAddressModel StoreAddress { get; set; }
        public bool InStock { get; set; }
        public DateTime DateTimeLastChecked { get; set; }
    }
}
