using BootScraper.Console.Commands;
using BootScraper.Console.Common;
using BootScraper.Console.Queries.CallStockAPI;
using BootScraper.Console.Queries.LoadStoreData;

namespace BootScraper.Console.Orchestration
{
    internal static class Orchestrator
    {
        internal static void Run(CommandLineOptions options)
        {
            var inputAddresses = InputFromCsv.Execute();

            foreach (var paddedChunk in ChunkAddresses(inputAddresses))
            {
                var responseModel = CallStockApi.Post(options.ServiceUrl, options.ProductId, paddedChunk);

                foreach (var stockLevel in responseModel.stockLevels)
                {
                    OutputCsv.AddStockStatus(options.OutputLocation, stockLevel.stockLevel,
                        paddedChunk.First(store => store.StoreId == stockLevel.storeId), options.Quiet);
                }
                Thread.Sleep(options.RequestedDelay);
            }
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
