﻿using ConferenceManager.Data;
using System.Diagnostics.Eventing.Reader;

namespace ConferenceManager.Services
{
    public interface IEventsService
    {
        List<Event> GetAllEvents();
        Event GetEventById(int id);
        public List<Event> SaveEvents(List<Event> events);
    }

    public class EventsService : IEventsService
    {
        private IEventsData _eventsData;
        public EventsService(IEventsData eventData)
        {
            _eventsData = eventData;
        }

        public List<Event> GetAllEvents()
        {
            return _eventsData.GetAllEvents();
        }

        public Event GetEventById(int id)
        {
            return _eventsData.GetEventById(id);
        }

        public List<Event> SaveEvents(List<Event> events)
        {
            return _eventsData.SaveEvents(events);
        }
    }
}
