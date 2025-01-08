using ConferenceManager.Data;

namespace ConferenceManager.Services
{
    public interface IAttendancesService
    {
        Attendance? SaveAttendance(int eventId, int userId);
    }

    public class AttendancesService : IAttendancesService
    {
        
        private IAttendancesData _attendancesData;
        private IEventsService _eventsService;
        public AttendancesService(IAttendancesData attendancesData, IEventsService eventService)
        {
            _attendancesData = attendancesData;
            _eventsService = eventService;
        }
        public Attendance? SaveAttendance(int  eventId, int userId)
        {
            List<int> eventIds = _eventsService.GetAllEvents()
                           .Select(e => e.Id)
                           .ToList();
            if (!eventIds.Contains(eventId))
            {
                return null;
            }

            var attendances = _attendancesData.GetAllAttendances();
            Attendance att = new Attendance() { UserId = userId, EventId = eventId };
            if (attendances
                    .Where(a => a.EventId == att.EventId && a.UserId == att.UserId)
                    .Select(a => a.UserId)
                    .Contains(att.UserId))
            {
                return null;
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
