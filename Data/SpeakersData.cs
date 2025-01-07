using System.Text.Json;

namespace ConferenceManager.Data
{
    public interface ISpeakersData
    {
        List<Speaker> GetAllSpeakers();
    }

    public class SpeakersData : ISpeakersData
    {
        // write get all speakers
        public List<Speaker> GetAllSpeakers()
        {
            string json = File.ReadAllText("Data/SpeakersList.json");
            return JsonSerializer.Deserialize<List<Speaker>>(json);
        }
    }
}
