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
    public class NamePrefixController : BaseController
    {
	    private readonly INamePrefixService _namePrefixService;

	    public NamePrefixController(INamePrefixService namePrefixService)
	    {
		    _namePrefixService = namePrefixService;
	    }

        // GET: NamePrefix
        public ActionResult Index()
        {
	        var prefixes = _namePrefixService.GetAll();

	        var viewModel = Mapper.Map<IEnumerable<NamePrefixViewModel>>(prefixes);

            return View(viewModel);
        }

        // GET: NamePrefix/Details/5
        public ActionResult Details(int id)
        {
			if (id == default(int))
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var prefix = _namePrefixService.GetById(id);

			if (prefix == null)
				return HttpNotFound();

			var viewModel = Mapper.Map<NamePrefixViewModel>(prefix);

			return View(viewModel);
		}

        // GET: NamePrefix/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NamePrefix/Create
        [HttpPost]
        public ActionResult Create(NamePrefixViewModel viewModel)
        {
            try
            {
				if (!ModelState.IsValid)
					return View(viewModel);

				var prefix = Mapper.Map<NamePrefix>(viewModel);

				_namePrefixService.Add(prefix);

				return RedirectToAction("Index");
			}
            catch
            {
                return View(viewModel);
            }
        }

        // GET: NamePrefix/Edit/5
        public ActionResult Edit(int id)
        {
			if (id == default(int))
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var prefix = _namePrefixService.GetById(id);

			if (prefix == null)
				return HttpNotFound();

			var viewModel = Mapper.Map<NamePrefixViewModel>(prefix);

			return View(viewModel);
        }

        // POST: NamePrefix/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, NamePrefixViewModel viewModel)
        {
            try
            {
				if (!ModelState.IsValid)
					return View(viewModel);

				var prefix = Mapper.Map<NamePrefix>(viewModel);

				_namePrefixService.Update(prefix);

				return RedirectToAction("Index");
			}
            catch
            {
                return View(viewModel);
            }
        }

        // GET: NamePrefix/Delete/5
        public ActionResult Delete(int id)
        {
			if (id == default(int))
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var prefix = _namePrefixService.GetById(id);

			if (prefix == null)
				return HttpNotFound();

			var viewModel = Mapper.Map<NamePrefixViewModel>(prefix);

			return View(viewModel);
		}

        // POST: NamePrefix/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, NamePrefixViewModel viewModel)
        {
            try
            {
                _namePrefixService.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(viewModel);
            }
        }
    }
}
