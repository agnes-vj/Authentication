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
            Attendance x;
            try
            {
                x = _attendancesService.SaveAttendance(eventId, userId);
                return Created("", x);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

