using CompanyEvent.Models;
using CompanyEvent.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyEvent.Web.Controllers
{
    [Authorize]
    public class EventController : Controller
    {

        private EventService CreateEventService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EventService(userId);
            return service;
        }

        public ActionResult Index()
        {
            var service = CreateEventService();

            var model = service.GetEvents();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventCreate model)
        {
            if (!ModelState.IsValid) return View(model);


            var service = CreateEventService();

            if (service.CreateEvent(model))
            {
                TempData["SaveResult"] = "Your Event was created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Event could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateEventService();
            var model = svc.GetEventById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateEventService();
            var detail = service.GetEventById(id);
            var model =
                new EventEdit
                {
                    EventId = detail.EventId,
                    Title = detail.Title,
                    Overview = detail.Overview,
                    Location = detail.Location,
                    DateTime = detail.DateTime
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EventEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.EventId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateEventService();

            if (service.UpdateEvent(model))
            {
                TempData["SaveResult"] = "Your Event was updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Event could not be updated");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateEventService();
            var model = svc.GetEventById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEvent(int id)
        {
            var service = CreateEventService();

            service.DeleteEvent(id);

            TempData["SaveResult"] = "Your Event was deleted";

            return RedirectToAction("Index");
        }
    }
}