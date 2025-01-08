using System.Text.Json;

namespace ConferenceManager.Data
{
    public interface ISpeakersData
    {
        List<Speaker> GetAllSpeakers();
        public Speaker AddSpeaker(Speaker speaker);
    }

    public class SpeakersData : ISpeakersData
    {
        // write get all speakers
        
        public List<Speaker> GetAllSpeakers()
        {
            string json = File.ReadAllText("Data/SpeakersList.json");
            return JsonSerializer.Deserialize<List<Speaker>>(json) ?? new();
        }
        public Speaker AddSpeaker(Speaker speaker)
        {
            string json = File.ReadAllText("Data/SpeakersList.json");
            List<Speaker> speakers = JsonSerializer.Deserialize<List<Speaker>>(json) ?? new();
            speakers.Add(speaker);
            File.WriteAllText("Data/SpeakersList.json", JsonSerializer.Serialize(speakers));
            return speaker;
        }
    }
}
