namespace ConferenceManager
{
    public class User
    {
        public int UserId { get; set; }
        public List<int> AttendanceIds { get; set; } = new();
    }
}
