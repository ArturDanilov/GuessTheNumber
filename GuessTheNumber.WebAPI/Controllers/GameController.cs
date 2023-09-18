using Microsoft.AspNetCore.Mvc;
using GuessTheNumber.BusinessLogic;

namespace GuessTheNumber.WebAPI.Controllers
{
    [Route("api/[contrller]")]
    [ApiController]
    public class GameController : Controller
    {
        [HttpGet]
        public IActionResult CheckApi()
        {
            return Ok("API works correctly!");
        }
    }
}
