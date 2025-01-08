using ConferenceManager.Data;
using Microsoft.Extensions.Logging;

namespace ConferenceManager.Services
{
    public interface ISpeakersService
    {
        List<Speaker> GetAllSpeakers();
        public Speaker addSpeaker(Speaker speaker);
    }

    public class SpeakersService : ISpeakersService
    {
        private ISpeakersData _speakersData;
        private IEventsService _eventsService;
        public SpeakersService(ISpeakersData speakersData, IEventsService eventService)
        {
            _speakersData = speakersData;
            _eventsService = eventService;
        }
        public Speaker addSpeaker(Speaker speaker)
        {
            List<int> eventIds = _eventsService.GetAllEvents()
                          .Select(e => e.Id)
                          .ToList();
            if (!eventIds.Contains(speaker.EventId))
            {
                throw new Exception($"Event {speaker.EventId} does not exist at this conference.");
            }
            List<Speaker> speakers = _speakersData.GetAllSpeakers();
            if (speakers.Count == 0)            
                speaker.Id = 1;
            else
                speaker.Id = speakers[^1].Id + 1;
            return _speakersData.addSpeaker(speaker);

        }
        public List<Speaker> GetAllSpeakers()
        {
            return _speakersData.GetAllSpeakers();
        }
    }
}
