using ConferenceManager.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        [HttpGet]
        public IActionResult AdminGetAllAttendances()
        {
            var roles = HttpContext.User.Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value);

            if (roles.Contains("Admin"))
            {
                return Ok(_attendancesService.GetAllAttendances());
            }
            else
            {
                return Forbid();
            }
        }

        [Authorize]
        [HttpGet("{attendanceId}")]

        public IActionResult GetAttendanceById(int attendanceId)
        {
            int userId = int.Parse(HttpContext.User.Claims.First().Value);
            Attendance requestedAttendance;
            try
            {
                requestedAttendance = _attendancesService.GetAttendanceById(attendanceId, userId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(requestedAttendance);

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

