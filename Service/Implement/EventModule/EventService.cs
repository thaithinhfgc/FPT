using Data.DataAccess.Interface.EventModule;
using Data.Model.EventModule;
using Service.Interface.EventModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implement.EventModule
{
    public class EventService : IEventService
    {
        private readonly IEventRepository eventRepository;
        public EventService(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }
        public void CreateEvent(Event @event)
        {
            eventRepository.CreateEvent(@event);
        }

        public Event GetEvent(string evenId)
        {
            return eventRepository.GetEvent(@evenId);
        }

        public List<Event> GetEvents()
        {
            return eventRepository.GetEvents();
        }

        public List<Event> GetUpComingEvents()
        {
            return eventRepository.GetUpComingEvents();
        }

        public void UpdateEvent(Event @event)
        {
            eventRepository.UpdateEvent(@event);
        }

        public void UpdateEventStatus()
        {
            eventRepository.UpdateEventStatus();
        }
    }
}
