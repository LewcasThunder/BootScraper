using BootScraper.Common;
using Microsoft.AspNetCore.Http.Timeouts;
using Microsoft.AspNetCore.Mvc;

namespace BootScraper.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenerateStockReportController : ControllerBase
    {
        private readonly ILogger<GenerateStockReportController> _logger;

        public GenerateStockReportController(ILogger<GenerateStockReportController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [RequestTimeout(1800000)]
        public void Post([FromBody]StockLevelRequest request)
        {
            Orchestration.Orchestrator.Run(request);
        }
    }
}
