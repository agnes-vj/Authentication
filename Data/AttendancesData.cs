using Microsoft.IdentityModel.Tokens;

namespace ConferenceManager.Data
{
    public interface IAttendancesData
    {
        List<Attendance> GetAllAttendances();
        public Attendance getAttendanceById(int attendanceId, int userId);
        Attendance SaveAttendance(Attendance attendance);
    }

    public class AttendancesData : IAttendancesData
    {
        public static List<Attendance> Attendances = new();
        public List<Attendance> GetAllAttendances()
        {
            return Attendances;
        }
        public Attendance getAttendanceById(int attendanceId, int userId)
        {
            Attendance? attendance = Attendances.FirstOrDefault(a => a.Id == attendanceId);
            if (attendance == null)
                throw new Exception($"Attendance {attendanceId} does not exists");
            if (attendance.UserId != userId)
                throw new Exception("You are not Authorised to view this Attendance");
            return attendance;
        }
        public Attendance SaveAttendance(Attendance attendance)
        {
            Attendances.Add(attendance);
            return attendance;
        }
    }
}
