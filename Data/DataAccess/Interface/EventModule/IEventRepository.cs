using Data.Model.EventModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccess.Interface.EventModule
{
    public interface IEventRepository
    {
        public void CreateEvent(Event @event);
        public void UpdateEvent(Event @event);
        public Event GetEvent(string evenId);
        public List<Event> GetEvents();
    }
}
