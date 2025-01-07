using System.Text.Json;

namespace ConferenceManager.Data
{
    public interface IEventsData
    {
        List<Event> GetAllEvents();
        Event GetEventById(int id);
        public List<Event> SaveEvents(List<Event> events);
    }

    public class EventsData : IEventsData
    {
        public static List<Event> Events = new List<Event>();

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

        public List<Event> SaveEvents(List<Event> events)
        {
            string json = File.ReadAllText("Data/EventsJson.json");
            Events = JsonSerializer.Deserialize<List<Event>>(json);

            foreach (var ev in events)
            {
                ev.Id = Events.Last().Id + 1;
                Events.Add(ev);               
            }
            return events;
        }
    }
}
