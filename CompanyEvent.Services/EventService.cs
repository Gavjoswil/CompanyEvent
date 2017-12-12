using CompanyEvent.Data;
using CompanyEvent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEvent.Services
{
    public class EventService
    {
        private readonly Guid _userId;

        public EventService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateEvent(EventCreate model)
        {
            var entity =
                new Event()
                {
                    OwnerId = _userId,
                    Title = model.Title,
                    Overview = model.Overview,
                    Location = model.Location,
                    DateTime = model.DateTime
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Events.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EventListItem> GetEvents()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Events
                       .Where(e => e.OwnerId == _userId)
                       .Select(
                            e =>
                                new EventListItem
                                {
                                    EventId = e.EventId,
                                    Title = e.Title,
                                    DateTime = e.DateTime
                                });

                return query.ToArray();
            }
        }

        public EventDetail GetEventById(int eventId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Events
                        .Single(e => e.EventId == eventId && e.OwnerId == _userId);
                return
                    new EventDetail
                    {
                        EventId = entity.EventId,
                        Title = entity.Title,
                        Overview = entity.Overview,
                        Location = entity.Location,
                        DateTime = entity.DateTime
                    };
            }
        }

        public bool UpdateEvent(EventEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Events
                        .Single(e => e.EventId == model.EventId && e.OwnerId == _userId);

                entity.Title = model.Title;
                entity.Overview = model.Overview;
                entity.Location = model.Location;
                entity.DateTime = model.DateTime;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
