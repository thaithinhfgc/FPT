using Data.DataAccess.Interface.EventModule;
using Data.Database;
using Data.Model.EventModule;
using Data.Model.UserModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccess.Implement.EventModule
{
    public class EventParticipantRepository : IEventParticipantRepository
    {
        private readonly Context context;
        public EventParticipantRepository(Context context)
        {
            this.context = context;
        }

        public EventParticipant GetEventParticipant(string userId, string eventId)
        {
            var eventParticipant = context.EventParticipants.FirstOrDefault(x => x.EventId.Equals(eventId) && x.PaticipantId.Equals(userId));
            return eventParticipant;
        }

        public List<User> GetEventParticipantByEvent(string eventId)
        {
            var eventParticipants = context.EventParticipants.Where(x => x.Id.Equals(eventId)).ToList();
            var users = new List<User>();
            foreach (EventParticipant eventParticipant in eventParticipants)
            {
                users.Add(context.Users.FirstOrDefault(x => x.Id.Equals(eventParticipant.PaticipantId)));
            }
            return users;
        }

        public List<Event> GetEventParticipantByUser(string userId)
        {
            var eventParticipants = context.EventParticipants.Where(x => x.PaticipantId.Equals(userId)).ToList();
            var events = new List<Event>();
            foreach (EventParticipant eventParticipant in eventParticipants)
            {
                events.Add(context.Events.FirstOrDefault(x => x.Id.Equals(eventParticipant.EventId)));
            }
            return events;
        }

        public void PaticipantEvent(EventParticipant eventParticipant)
        {
            context.EventParticipants.Add(eventParticipant);
            context.SaveChanges();
        }

        public void RemovePaticipant(EventParticipant eventParticipant)
        {
            context.EventParticipants.Remove(eventParticipant);
            context.SaveChanges();
        }
    }
}
