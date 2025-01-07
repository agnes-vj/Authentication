using ConferenceManager.Data;

namespace ConferenceManager.Services
{
    public interface IAttendancesService
    {
        Attendance? SaveAttendance(Attendance att);
    }

    public class AttendancesService : IAttendancesService
    {
        private IAttendancesData _attendancesData;
        public AttendancesService(IAttendancesData attendancesData)
        {
            _attendancesData = attendancesData;
        }
        public Attendance? SaveAttendance(Attendance att)
        {
            var attendances = _attendancesData.GetAllAttendances();

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
