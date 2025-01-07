using ConferenceManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceManager.Controllers
{
    [ApiController]
    [Route("/api/[Controller]")]
    public class EventsController : ControllerBase
    {
        private IEventsService _eventsService;
        public EventsController(IEventsService eventsService)
        {
            _eventsService = eventsService;
        }

        [HttpGet]
        public IActionResult GetAllEvents()
        {
            return Ok(_eventsService.GetAllEvents());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetEventById(int id)
        {
            return Ok(_eventsService.GetEventById(id));
        }
    }
}
