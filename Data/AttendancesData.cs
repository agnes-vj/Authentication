namespace ConferenceManager.Data
{
    public interface IAttendancesData
    {
        List<Attendance> GetAllAttendances();
        public Attendance GetAttendanceById(int attendanceId, int userId);
        Attendance SaveAttendance(Attendance attendance);
    }

    public class AttendancesData : IAttendancesData
    {
        public static List<Attendance> Attendances = new();
        public List<Attendance> GetAllAttendances()
        {
            return Attendances;
        }
        public Attendance GetAttendanceById(int attendanceId, int userId)
        {
            Attendance? attendance = Attendances.FirstOrDefault(a => a.Id == attendanceId);
            if (attendance == null)
                throw new Exception($"Attendance {attendanceId} does not exist");
            if (attendance.UserId != userId)
                throw new Exception("You are not authorised to view this attendance");
            return attendance;
        }
        public Attendance SaveAttendance(Attendance attendance)
        {
            Attendances.Add(attendance);
            return attendance;
        }
    }
}
