using Data.DataAccess.Interface.EventModule;
using Data.Model.EventModule;
using Data.Model.UserModule;
using Service.Interface.EventModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implement.EventModule
{
    public class EventParticipantService : IEventParticipantService
    {
        private readonly IEventParticipantRepository eventParticipantRepository;
        public EventParticipantService(IEventParticipantRepository eventParticipantRepository)
        {
            this.eventParticipantRepository = eventParticipantRepository;
        }

        public EventParticipant GetEventParticipant(string userId, string eventId)
        {
            throw new NotImplementedException();
        }

        public List<User> GetEventParticipantByEvent(string eventId)
        {
            throw new NotImplementedException();
        }

        public List<EventParticipant> GetEventParticipantByUser(string eventId)
        {
            throw new NotImplementedException();
        }

        public void PaticipantEvent(EventParticipant eventParticipant)
        {
            eventParticipantRepository.PaticipantEvent(eventParticipant);
        }

        public void RemovePaticipant(EventParticipant eventParticipant)
        {
            eventParticipantRepository.RemovePaticipant(eventParticipant);
        }
    }
}
