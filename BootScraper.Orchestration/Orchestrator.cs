using BootScraper.Commands;
using BootScraper.Common;
using BootScraper.Queries.CallStockAPI;
using BootScraper.Queries.LoadStockLevelData;
using BootScraper.Queries.LoadStoreData;

namespace BootScraper.Orchestration
{
    public static class Orchestrator
    {
        public static IEnumerable<Stocklevel> Run(BootScraperRequest options)
        {
            var inputAddresses = InputFromCsv.Execute(options);
            var outputStockData = new List<Stocklevel>();
            foreach (var paddedChunk in ChunkAddresses(inputAddresses))
            {
                var responseModel = CallStockApi.Post(options.ServiceUrl, options.ProductId, paddedChunk);
                foreach (var stockLevel in responseModel.stockLevels)
                {
                    outputStockData.Add(stockLevel);
                }

                if (options.OutputLocation != null)
                    OutputCsv.Execute(responseModel, paddedChunk, options);
                
                Thread.Sleep(options.RequestedDelay);
            }

            if (options.DeduplicateOutput && options.OutputLocation != null)
                OutputDeduplicatedCsv.Execute(LoadStockLevelData.Run(options), options);

            return options.DeduplicateOutput ?  outputStockData.DistinctBy(stockData => stockData.storeId) : outputStockData;
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
