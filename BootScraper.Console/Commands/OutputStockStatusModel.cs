using BootScraper.Console.Common;

namespace BootScraper.Console.Commands
{
    public class OutputStockStatusModel
    {
        public StoreAddressModel StoreAddress { get; set; }
        public int Pharmacy { get; set; }
        public bool InStock { get; set; }
        public DateTime DateLastChecked { get; set; }
    }
}
