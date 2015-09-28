using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using NTierApplications.Domain.Entities;
using NTierApplications.Domain.ServiceInterfaces;
using NTierApplications.MVC.Models;

namespace NTierApplications.MVC.Controllers
{
    public class LocationController : Controller
    {
	    private readonly ILocationService _locationService;

	    public LocationController(ILocationService locationService)
	    {
		    _locationService = locationService;
	    }

        // GET: Location
        public ActionResult Index()
        {
	        var locations = _locationService.GetAll();

	        var viewModel = Mapper.Map<IEnumerable<Location>, IEnumerable<LocationViewModel>>(locations);

            return View(viewModel);
        }

        // GET: Location/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Location/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(LocationViewModel viewModel)
        {
            try
            {
				if (!ModelState.IsValid)
					return View(viewModel);

				var location = Mapper.Map<LocationViewModel, Location>(viewModel);

				_locationService.Add(location);

				return RedirectToAction("Index");
			}
            catch
            {
                return View();
            }
        }

        // GET: Location/Edit/5
        public ActionResult Edit(int id)
        {
			if (id == default(int))
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var location = _locationService.GetById(id);

			if (location == null)
				return HttpNotFound();

			var viewModel = Mapper.Map<Location, LocationViewModel>(location);

			return View(viewModel);
		}

        // POST: Location/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, LocationViewModel viewModel)
        {
            try
            {
				if (!ModelState.IsValid)
					return View(viewModel);

				var location = Mapper.Map<LocationViewModel, Location>(viewModel);

				_locationService.Update(location);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Location/Delete/5
        public ActionResult Delete(int id)
        {
			if (id == default(int))
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var location = _locationService.GetById(id);

			if (location == null)
				return HttpNotFound();

			var viewModel = Mapper.Map<Location, LocationViewModel>(location);

			return View(viewModel);
		}

        // POST: Location/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, LocationViewModel viewModel)
        {
            try
            {
				_locationService.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(viewModel);
            }
        }
    }
}
