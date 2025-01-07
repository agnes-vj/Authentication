using System.Text.Json.Serialization;

namespace ConferenceManager
{
    public class Attendance
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("userId")]
        public int UserId { get; set; }
        [JsonPropertyName("eventId")]
        public int EventId { get; set; }
    }
}
