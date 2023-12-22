using BootScraper.Commands;
using BootScraper.Queries;

namespace BootScraper.Orchestration
{
    public static class Orchestrator
    {
        public static BootScraperResponse Run(BootScraperRequest options)
        {
            var queriesResponse = Queries.Queries.Execute(new QueriesRequest(options.InputStoreData,
                options.RequestedDelay, options.ServiceUrl,
                options.ProductId, options.County));

            var commandOutputModel = new List<CommandOutputModel>();
            foreach (var stockLevel in queriesResponse.StockLevels)
            {
                var address = queriesResponse.StoreAddresses.First(address => address.StoreId == stockLevel.storeId);
                commandOutputModel.Add(new CommandOutputModel
                {
                    Line1 = address.Line1,
                    Line2 = address.Line2,
                    Line3 = address.Line3,
                    Postcode = address.Postcode,
                    StoreId = address.StoreId,
                    StockLevel = stockLevel.stockLevel == "G",
                    DateTimeLastSearched = DateTime.UtcNow
                });
            }

            if (options.OutputLocation != null)
                Commands.Commands.Execute(new CommandsRequest(options.OutputLocation, options.Quiet,
                    options.DeduplicateOutput, commandOutputModel));

            var bootScraperStockLevel = new List<StockLevelData>();
            foreach (var stockLevel in queriesResponse.StockLevels)
            {
                var address = queriesResponse.StoreAddresses.First(address => address.StoreId == stockLevel.storeId);
                bootScraperStockLevel.Add(new StockLevelData
                {
                    Line1 = address.Line1,
                    Line2 = address.Line2,
                    Line3 = address.Line3,
                    Postcode = address.Postcode,
                    StoreId = address.StoreId,
                    StockLevel = stockLevel.stockLevel == "G",
                    DateTimeLastSearched = DateTime.UtcNow
                });
            }

            return new BootScraperResponse
            {
                StockLevelData = options.DeduplicateOutput ?
                    bootScraperStockLevel.DistinctBy(stockData => stockData.StoreId).Where(stock => stock.StockLevel == true).ToList() : bootScraperStockLevel
            };
        }
    }
}
