using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
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