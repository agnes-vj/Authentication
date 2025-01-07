using System.Text.Json;

namespace ConferenceManager.Data
{
    public interface IEventsData
    {
        List<Event> GetAllEvents();
        Event GetEventById(int id);
    }

    public class EventsData : IEventsData
    {
        public List<Event> GetAllEvents()
        {
            string json = File.ReadAllText("Data/EventsJson.json");
            return JsonSerializer.Deserialize<List<Event>>(json);
        }

        public Event GetEventById(int id)
        {
            string json = File.ReadAllText("Data/EventsJson.json");
            var events = JsonSerializer.Deserialize<List<Event>>(json);
            return events.FirstOrDefault(e => e.Id == id);
        }
    }
}
