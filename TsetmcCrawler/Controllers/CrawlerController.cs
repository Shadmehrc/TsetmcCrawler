using Application.Services.ServiceInterface;
using Domain.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace TsetmcCrawler.Controllers
{
    [ApiController]
    [Route("Main")]
    public class CrawlerController : ControllerBase
    {
        private readonly ICrawlerService _crawlerService;

        public CrawlerController(ICrawlerService crawlerService)
        {
            _crawlerService = crawlerService;
        }

        //private readonly ILogger<CrawlerController> _logger;
        //public CrawlerController(ILogger<CrawlerController> logger)
        //{
        //    _logger = logger;
        //}

        [HttpPost]
        [Route("Start")]
        public ActionResult<bool> Start()
        {
           var result= _crawlerService.Start();
            return true;
        }
    }
}
