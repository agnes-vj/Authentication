using ConferenceManager.Data;

namespace ConferenceManager.Services
{
    public interface IAttendancesService
    {
        List<Attendance> GetAllAttendances();
        Attendance SaveAttendance(int eventId, int userId);
        public Attendance GetAttendanceById(int attendanceId, int userId);
    }

    public class AttendancesService : IAttendancesService
    {
        
        private IAttendancesData _attendancesData;
        private IEventsService _eventsService;
        private IUsersService _usersService;
        public AttendancesService(IAttendancesData attendancesData, IUsersService usersService, IEventsService eventsService)
        {
            _attendancesData = attendancesData;
            _eventsService = eventsService;
            _usersService = usersService;
        }
        public List<Attendance> GetAllAttendances()
        {
            return _attendancesData.GetAllAttendances();
        }
        public Attendance GetAttendanceById(int attendanceId,int userId)
        {            
           return _attendancesData.GetAttendanceById(attendanceId, userId);            
        }
        public Attendance SaveAttendance(int eventId, int userId)
        {
            if (!_usersService.DoesUserExist(userId))
            {
                throw new Exception($"User {userId} does not exist.");
            }

            List<int> eventIds = _eventsService.GetAllEvents()
                           .Select(e => e.Id)
                           .ToList();
            if (!eventIds.Contains(eventId))
            {
                throw new Exception($"Event {eventId} does not exist at this conference.");
            }

            var attendances = _attendancesData.GetAllAttendances();
            Attendance att = new Attendance() { UserId = userId, EventId = eventId };
            if (attendances
                    .Where(a => a.EventId == att.EventId && a.UserId == att.UserId)
                    .Select(a => a.UserId)
                    .Contains(att.UserId))
            {
                throw new Exception($"The attendance of user {userId} at event {eventId} has already been logged.");
            }
            else
            {
                if (attendances.Count != 0)
                {
                    att.Id = attendances[^1].Id + 1;
                }
                else
                {
                    att.Id = 1;
                }
                _attendancesData.SaveAttendance(att);
                return att;
            }
        }
    }
}
