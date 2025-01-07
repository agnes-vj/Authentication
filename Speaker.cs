using System.Text.Json.Serialization;

namespace ConferenceManager
{
    public class Speaker
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("eventId")]
        public int EventId { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; } = "";
    }
}
