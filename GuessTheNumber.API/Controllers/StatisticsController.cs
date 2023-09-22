using Microsoft.AspNetCore.Mvc;
using GuessTheNumber.BusinessLogic;

namespace GuessTheNumber.API.Controllers
{
    [ApiController]
    [Route("statistics")]
    public class StatisticsController : Controller
    {
        private readonly TopStatisticsService _topStatisticsService;

        public StatisticsController(TopStatisticsService topStatisticsService)
        {
            _topStatisticsService = topStatisticsService;   
        }

        [HttpGet("top-5-players")]
        public IActionResult GetTopFive()
        {
            var topPlayers = _topStatisticsService.GetTopPlayers();
            return Ok(topPlayers);
        }
    }
}