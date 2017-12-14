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
            return Ok();
        }

        public IHttpActionResult Post(EventCreate model)
        {
            return Ok();
        }

        public IHttpActionResult Put(EventEdit model)
        {
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
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
