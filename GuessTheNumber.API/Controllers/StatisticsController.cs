using Microsoft.AspNetCore.Mvc;
using GuessTheNumber.BusinessLogic;

namespace GuessTheNumber.API.Controllers
{
    [ApiController]
    [Route("statistics")]
    public class StatisticsController : Controller
    {
        private readonly ITopStatisticsService _topStatisticsService;

        public StatisticsController(ITopStatisticsService topStatisticsService)
        {
            _topStatisticsService = topStatisticsService;   
        }

        [HttpGet("top-5-players")]
        public async Task<IActionResult> GetTopFive()
        {
            var topPlayers = await _topStatisticsService.GetTopPlayersAsync();
            return Ok(topPlayers);
        }
    }
}