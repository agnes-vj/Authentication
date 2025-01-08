using ConferenceManager.Data;
using Microsoft.Extensions.Logging;

namespace ConferenceManager.Services
{
    public interface ISpeakersService
    {
        List<Speaker> GetAllSpeakers();
        Speaker DeleteSpeakerById(int speakerId);
        public Speaker AddSpeaker(Speaker speaker);
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
        public Speaker AddSpeaker(Speaker speaker)
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
            return _speakersData.AddSpeaker(speaker);

        }
        public List<Speaker> GetAllSpeakers()
        {
            return _speakersData.GetAllSpeakers();
        }
        public Speaker DeleteSpeakerById(int speakerId)
        {
            return _speakersData.DeleteSpeakerById(speakerId);
        }
    }
}
