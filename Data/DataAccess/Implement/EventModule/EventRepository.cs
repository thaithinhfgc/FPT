using Data.DataAccess.Interface.EventModule;
using Data.Database;
using Data.Model.EventModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccess.Implement.EventModule
{
    public class EventRepository : IEventRepository
    {
        private readonly Context context;
        public EventRepository(Context context)
        {
            this.context = context;
        }

        public void CreateEvent(Event @event)
        {
            context.Events.Add(@event);
            context.SaveChanges();
        }

        public Event GetEvent(string evenId)
        {
            var @event = context.Events.FirstOrDefault(x => x.Id == evenId);
            return @event;
        }

        public List<Event> GetEvents()
        {
            var events = context.Events.ToList();
            return events;
        }

        public void UpdateEvent(Event @event)
        {
            context.Events.Update(@event);
            context.SaveChanges();
        }
    }
}
