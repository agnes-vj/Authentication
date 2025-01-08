using System.Text.Json;

namespace ConferenceManager.Data
{
    public interface ISpeakersData
    {
        List<Speaker> GetAllSpeakers();
        Speaker DeleteSpeakerById(int speakerId);
        public Speaker AddSpeaker(Speaker speaker);
    }

    public class SpeakersData : ISpeakersData
    {
        private string filepath = "Data/SpeakersList.json";
        public List<Speaker> GetAllSpeakers()
        {
            string json = File.ReadAllText(filepath);
            return JsonSerializer.Deserialize<List<Speaker>>(json) ?? new();
        }
        public Speaker AddSpeaker(Speaker speaker)
        {
            var speakers = GetAllSpeakers();
            speakers.Add(speaker);
            File.WriteAllText(filepath, JsonSerializer.Serialize(speakers));
            return speaker;
        }
        public Speaker DeleteSpeakerById(int speakerId)
        {
            var speakers = GetAllSpeakers();
            Speaker? speakerToDelete = speakers.FirstOrDefault(s => s.Id.Equals(speakerId));
            if (speakerToDelete is null)
            {
                throw new Exception($"There is no speaker with id {speakerId}");
            }
            else
            {
                speakers.Remove(speakerToDelete);
                File.WriteAllText(filepath, JsonSerializer.Serialize(speakers));
                return speakerToDelete;
            }
        }
    }
}
