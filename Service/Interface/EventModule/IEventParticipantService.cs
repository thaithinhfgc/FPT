using Data.Model.EventModule;
using Data.Model.UserModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface.EventModule
{
    public interface IEventParticipantService
    {
        public void PaticipantEvent(EventParticipant eventParticipant);
        public void RemovePaticipant(EventParticipant eventParticipant);
        public EventParticipant GetEventParticipant(string userId, string eventId);
        public List<EventParticipant> GetEventParticipantByUser(string userId);
        public List<User> GetEventParticipantByEvent(string eventId);
    }
}
