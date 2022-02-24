using Data.Model.EventModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface.EventModule
{
    public interface IEventService
    {
        public void CreateEvent(Event @event);
        public void UpdateEvent(Event @event);
        public Event GetEvent(string evenId);
        public List<Event> GetEvents();
        public List<Event> GetUpComingEvents();
        public void UpdateEventStatus();
    }
}
