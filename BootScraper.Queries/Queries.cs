namespace BootScraper.Queries
{
    public static class Queries
    {
        public static QueriesResponse Execute(QueriesRequest queriesRequest)
        {
            var inputAddresses = InputFromCsv.Execute(queriesRequest.StoreAddressDataLocation, queriesRequest.County);
            var outputStockData = new List<Stocklevel>();
            foreach (var paddedChunk in ChunkAddresses(inputAddresses))
            {
                var responseModel = CallStockApi.Post(queriesRequest.ServiceUrl, queriesRequest.ProductId, paddedChunk);
                foreach (var stockLevel in responseModel.stockLevels)
                {
                    outputStockData.Add(stockLevel);
                }

                Thread.Sleep(queriesRequest.RequestedDelay);
            }

            return new QueriesResponse(outputStockData, inputAddresses);
        }

        private static IEnumerable<StoreAddressModel[]> ChunkAddresses(IEnumerable<StoreAddressModel> storeData)
        {
            var chunkedStoreData = storeData.Chunk(10).ToList();

            var paddedChunks = new List<StoreAddressModel[]>();

            foreach (var chunk in chunkedStoreData)
            {
                var chunkList = chunk.ToList();
                while (chunkList.Count < 10)
                {
                    chunkList.Add(new StoreAddressModel { StoreId = -1 });
                }

                paddedChunks.Add(chunkList.ToArray());
            }

            return paddedChunks;
        }
    }
}
