using ConferenceManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceManager.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AttendancesController : ControllerBase
    {
        private IAttendancesService _attendancesService;
        public AttendancesController(IAttendancesService attendancesService)
        {
            _attendancesService = attendancesService;
        }
        [Authorize]
        [HttpPost]
        public IActionResult PostAttendance([FromBody] int eventId)
        {
            int userId = int.Parse(HttpContext.User.Claims.First().Value);
            Console.WriteLine(eventId);
            Attendance newAttendance = new Attendance() { EventId = eventId, UserId = userId};
            Attendance? x = _attendancesService.SaveAttendance(eventId, userId);
            if (x is null)
            {
                return BadRequest("Attendance record already exists or another error occurred, try again.");
            }
            else
            {
                return Created("", x);
            }
        }
    }
}

