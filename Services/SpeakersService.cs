using ConferenceManager.Data;

namespace ConferenceManager.Services
{
    public interface ISpeakersService
    {
        List<Speaker> GetAllSpeakers();
    }

    public class SpeakersService : ISpeakersService
    {
        private ISpeakersData _speakersData;
        public SpeakersService(ISpeakersData speakersData)
        {
            _speakersData = speakersData;
        }
        public List<Speaker> GetAllSpeakers()
        {
            return _speakersData.GetAllSpeakers();
        }
    }
}
