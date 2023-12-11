using BootScraper.Common;
using Newtonsoft.Json;

namespace BootScraper.Queries.CallStockAPI
{
    public static class CallStockApi
    {
        public static StockResponseModel Post(string serviceUrl, string productId, IEnumerable<StoreAddressModel> paddedChunk)
        {
            var requestData = new StockRequestModel
            {
                productIdList = new[] { productId },
                storeIdList = paddedChunk.Select(chunk => chunk.StoreId).ToArray()
            };

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, serviceUrl);

            var serializeObject = JsonConvert.SerializeObject(requestData);
            request.Content = new StringContent(serializeObject, null, "application/json");

            var response = client.SendAsync(request).Result;
            response.EnsureSuccessStatusCode(); var responseString = response.Content.ReadAsStringAsync().Result;
            var stockResponseModel = JsonConvert.DeserializeObject<StockResponseModel>(responseString);

            return new StockResponseModel{ stockLevels = stockResponseModel.stockLevels.Where(stock => stock.productId == productId).ToArray()};
        }
    }
}
