using Microsoft.AspNetCore.Mvc;
using ConferenceManager.Services;

namespace ConferenceManager.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class SpeakersController : ControllerBase
    {
        private ISpeakersService _speakersService;
        public SpeakersController(ISpeakersService speakersService)
        {
            _speakersService = speakersService;
        }

        [HttpGet]
        public IActionResult GetAllSpeakers()
        {
            return Ok(_speakersService.GetAllSpeakers());
        }
    }
}
