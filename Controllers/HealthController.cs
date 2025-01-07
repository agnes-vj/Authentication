using Microsoft.AspNetCore.Mvc;

namespace ConferenceManager.Controllers
{
    [ApiController]
    [Route("/api/[Controller]")]
    public class HealthController : Controller
    {
        [HttpGet]
        public IActionResult getHealth()
        {
            return Ok("Welcome!");
        }
    }
}
