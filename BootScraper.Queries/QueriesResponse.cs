using BootScraper.Queries.LoadStoreData;

namespace BootScraper.Queries
{
    public class QueriesResponse
    {
        public readonly IEnumerable<Stocklevel> StockLevels;
        public readonly IEnumerable<StoreAddressModel> StoreAddresses;

        public QueriesResponse(IEnumerable<Stocklevel> stockLevels, IEnumerable<StoreAddressModel> storeAddresses)
        {
            StockLevels = stockLevels;
            StoreAddresses = storeAddresses;
        }
    }
}
