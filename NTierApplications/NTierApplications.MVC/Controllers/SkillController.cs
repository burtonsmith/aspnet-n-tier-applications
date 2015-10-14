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
    public class SkillController : BaseController
    {
	    private readonly ISkillService _skillService;

	    public SkillController(ISkillService skillService)
	    {
		    _skillService = skillService;
	    }

        // GET: Skill
        public ActionResult Index()
        {
	        var skills = _skillService.GetAll();

	        var viewModel = Mapper.Map<IEnumerable<SkillViewModel>>(skills);

            return View(viewModel);
        }

        // GET: Skill/Details/5
        public ActionResult Details(int id)
        {
			if (id == default(int))
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var skill = _skillService.GetById(id);

			if (skill == null)
				return HttpNotFound();

			var viewModel = Mapper.Map<SkillViewModel>(skill);

			return View(viewModel);
		}

        // GET: Skill/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Skill/Create
        [HttpPost]
        public ActionResult Create(SkillViewModel viewModel)
        {
            try
            {
				if (!ModelState.IsValid)
					return View(viewModel);

				var skill = Mapper.Map<Skill>(viewModel);

				_skillService.Add(skill);

				return RedirectToAction("Index");
			}
            catch
            {
                return View(viewModel);
            }
        }

        // GET: Skill/Edit/5
        public ActionResult Edit(int id)
        {
			if (id == default(int))
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var skill = _skillService.GetById(id);

			if (skill == null)
				return HttpNotFound();

			var viewModel = Mapper.Map<SkillViewModel>(skill);

			return View(viewModel);
		}

        // POST: Skill/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SkillViewModel viewModel)
        {
            try
            {
				if (!ModelState.IsValid)
					return View(viewModel);

				var skill = Mapper.Map<Skill>(viewModel);

				_skillService.Update(skill);

				return RedirectToAction("Index");
			}
            catch
            {
                return View(viewModel);
            }
        }

        // GET: Skill/Delete/5
        public ActionResult Delete(int id)
        {
			if (id == default(int))
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var skill = _skillService.GetById(id);

			if (skill == null)
				return HttpNotFound();

			var viewModel = Mapper.Map<SkillViewModel>(skill);

			return View(viewModel);
		}

        // POST: Skill/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, SkillViewModel viewModel)
        {
            try
            {
                _skillService.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(viewModel);
            }
        }
    }
}
