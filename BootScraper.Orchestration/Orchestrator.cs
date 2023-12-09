using BootScraper.Commands;
using BootScraper.Common;
using BootScraper.Queries.CallStockAPI;
using BootScraper.Queries.LoadStockLevelData;
using BootScraper.Queries.LoadStoreData;

namespace BootScraper.Orchestration
{
    public static class Orchestrator
    {
        public static void Run(StockLevelRequest options)
        {
            var inputAddresses = InputFromCsv.Execute(options);

            foreach (var paddedChunk in ChunkAddresses(inputAddresses))
            {
                var responseModel = CallStockApi.Post(options.ServiceUrl, options.ProductId, paddedChunk);
                OutputCsv.Execute(responseModel, paddedChunk, options);
                
                Thread.Sleep(options.RequestedDelay);
            }

            if (options.DeduplicateOutput)
                OutputDeduplicatedCsv.Execute(LoadStockLevelData.Run(options), options);
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
