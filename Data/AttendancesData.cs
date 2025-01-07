using Microsoft.IdentityModel.Tokens;

namespace ConferenceManager.Data
{
    public interface IAttendancesData
    {
        List<Attendance> GetAllAttendances();
        Attendance SaveAttendance(Attendance attendance);
    }

    public class AttendancesData : IAttendancesData
    {
        public static List<Attendance> Attendances = new();
        public List<Attendance> GetAllAttendances()
        {
            return Attendances;
        }
        public Attendance SaveAttendance(Attendance attendance)
        {
            Attendances.Add(attendance);
            return attendance;
        }
    }
}
