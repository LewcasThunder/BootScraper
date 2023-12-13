using BootScraper.Orchestration;
using Microsoft.AspNetCore.Http.Timeouts;
using Microsoft.AspNetCore.Mvc;

namespace BootScraper.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenerateStockReportController : ControllerBase
    {
        [HttpPost]
        [RequestTimeout(1800000)]
        public BootScraperResponse Post([FromBody]BootScraperRequest request)
        {
            return Orchestrator.Run(request);
        }
    }
}
