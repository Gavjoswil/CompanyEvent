using CompanyEvent.Models;
using CompanyEvent.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CompanyEvent.Api.Controllers
{
    [Authorize]
    public class EventController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            EventService eventService = CreateEventService();

            var events = eventService.GetEvents();

            return Ok(events);
        }

        public IHttpActionResult Get(int id)
        {
            EventService eventService = CreateEventService();

            var oneEvent = eventService.GetEventById(id);

            return Ok(oneEvent);
        }

        public IHttpActionResult Post(EventCreate cevent)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateEventService();

            if (!service.CreateEvent(cevent))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(EventEdit companyEvent)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateEventService();

            if (!service.UpdateEvent(companyEvent))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateEventService();

            if (!service.DeleteEvent(id))
                return InternalServerError();

            return Ok();
        }

        private EventService CreateEventService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var eventService = new EventService(userId);
            return eventService;
        }
    }
}
