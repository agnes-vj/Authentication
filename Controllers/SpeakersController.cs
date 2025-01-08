using Microsoft.AspNetCore.Mvc;
using ConferenceManager.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

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
        [Authorize]
        [HttpPost]
        public IActionResult AddSpeaker(Speaker speaker)
        {           
            var roles = HttpContext.User.Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value);
            
            if (roles.Contains("Admin"))
            {
                try
                {
                    return Ok(_speakersService.AddSpeaker(speaker));
                }
                catch (Exception ex)
                {
                    return NotFound(ex.Message);
                }
               
            }
            else
            {
                return Forbid();
            }
        }
    }
}
