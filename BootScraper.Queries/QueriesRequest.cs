namespace BootScraper.Queries
{
    public class QueriesRequest
    {
        public readonly string StoreAddressDataLocation;
        public readonly int RequestedDelay;
        public readonly string ServiceUrl;
        public readonly string ProductId;
        public readonly string? County;

        public QueriesRequest(string storeAddressDataLocation, int requestedDelay, string serviceUrl, string productId, string? county)
        {
            StoreAddressDataLocation = storeAddressDataLocation;
            RequestedDelay = requestedDelay;
            ServiceUrl = serviceUrl;
            ProductId = productId;
            County = county;
        }
    }
}
