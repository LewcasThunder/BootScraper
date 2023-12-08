using Newtonsoft.Json;
using BootScraper.Console.Common;

namespace BootScraper.Console.Queries.CallStockAPI
{
    internal static class CallStockApi
    {
        internal static StockResponseModel Post(string serviceUrl, string productId, IEnumerable<StoreAddressModel> paddedChunk)
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
            response.EnsureSuccessStatusCode();
            var responseString = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<StockResponseModel>(responseString);
        }
    }
}
