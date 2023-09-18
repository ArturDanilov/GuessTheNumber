using Microsoft.AspNetCore.Mvc;
using GuessTheNumber.BusinessLogic;

namespace GuessTheNumber.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : Controller
    {
        [HttpGet]
        public IActionResult CheckApi()
        {
            return Ok("API works correctly!");
        }
    }
}