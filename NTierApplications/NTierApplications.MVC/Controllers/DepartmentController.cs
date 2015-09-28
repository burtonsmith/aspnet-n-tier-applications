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
using WebGrease.Css.Extensions;

namespace NTierApplications.MVC.Controllers
{
	public class DepartmentController : Controller
	{
		private readonly IDepartmentService _departmentService;

		public DepartmentController(IDepartmentService departmentService)
		{
			_departmentService = departmentService;
		}

		// GET: Department
		public ActionResult Index()
		{
			var departments = _departmentService.GetAll().ToList();

			var viewModel = Mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentViewModel>>(departments);
			viewModel.ForEach(x => x.HasEmployees = departments.FirstOrDefault(y => y.Id == x.Id).Employees.Any());

			return View(viewModel);
		}

		// GET: Department/Create
		public ActionResult Create()
		{

			return View();
		}

		// POST: Department/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(DepartmentViewModel viewModel)
		{
			try
			{
				if (!ModelState.IsValid)
					return View(viewModel);

				var department = Mapper.Map<DepartmentViewModel, Department>(viewModel);

				_departmentService.Add(department);

				return RedirectToAction("Index");
			}
			catch
			{
				return View(viewModel);
			}
		}

		// GET: Department/Edit/5
		public ActionResult Edit(int id)
		{
			if (id == default(int))
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var department = _departmentService.GetById(id);

			if (department == null)
				return HttpNotFound();

			var viewModel = Mapper.Map<Department, DepartmentViewModel>(department);

			return View(viewModel);
		}

		// POST: Department/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, DepartmentViewModel viewModel)
		{
			try
			{
				if (!ModelState.IsValid)
					return View(viewModel);

				var department = Mapper.Map<DepartmentViewModel, Department>(viewModel);

				_departmentService.Update(department);

				return RedirectToAction("Index");
			}
			catch
			{
				return View(viewModel);
			}
		}

		// GET: Department/Delete/5
		public ActionResult Delete(int id)
		{
			if (id == default(int))
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var department = _departmentService.GetById(id);

			if (department == null)
				return HttpNotFound();

			var viewModlel = Mapper.Map<Department, DepartmentViewModel>(department);

			return View(viewModlel);
		}

		// POST: Department/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, DepartmentViewModel viewModel)
		{
			try
			{
				_departmentService.Delete(id);

				return RedirectToAction("Index");
			}
			catch
			{
				return View(viewModel);
			}
		}
	}
}
