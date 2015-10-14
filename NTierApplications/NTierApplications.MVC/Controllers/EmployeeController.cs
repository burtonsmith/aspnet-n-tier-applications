using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using NTierApplications.Domain.Entities;
using NTierApplications.Domain.ServiceInterfaces;
using NTierApplications.MVC.Models;
using WebGrease.Css.Extensions;

namespace NTierApplications.MVC.Controllers
{
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService _employeeService;
        private readonly INamePrefixService _namePrefixService;
        private readonly ILocationService _locationService;
        private readonly IDepartmentService _departmentService;
        private readonly ISkillService _skillService;

        public EmployeeController(IEmployeeService employeeService, INamePrefixService namePrefixService, ILocationService locationService, IDepartmentService departmentService, ISkillService skillService)
        {
            _employeeService = employeeService;
            _namePrefixService = namePrefixService;
            _locationService = locationService;
            _departmentService = departmentService;
            _skillService = skillService;
        }

        // GET: Employee
        public ActionResult Index()
        {
            var employees = _employeeService.GetAll();

            var viewModel = Mapper.Map<IEnumerable<EmployeeDisplayViewModel>>(employees);

            return View(viewModel);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            var employee = _employeeService.GetById(id);
            var viewModel = Mapper.Map<EmployeeDisplayViewModel>(employee);

            return View(viewModel);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            var viewModel = new EmployeeEditViewModel();
            return View(viewModel);
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(EmployeeEditViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(viewModel);
                }


                var employee = Mapper.Map<Employee>(viewModel);
                viewModel.NewSkills.ForEach(x => employee.Skills.Add(_skillService.GetById(x)));

                _employeeService.Add(employee);

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(viewModel);
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            var employee = _employeeService.GetById(id);
            var viewModel = Mapper.Map<EmployeeEditViewModel>(employee);

            return View(viewModel);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EmployeeEditViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(viewModel);
                }

                // Different mapping format for Many-to-Many update.
                var employee = Mapper.Map(viewModel, _employeeService.GetById(viewModel.Id));
                viewModel.NewSkills.ForEach(x => employee.Skills.Add(_skillService.GetById(x)));

                _employeeService.Update(employee);

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(viewModel);
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            var employee = _employeeService.GetById(id);
            var viewModel = Mapper.Map<EmployeeDisplayViewModel>(employee);
            return View(viewModel);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EmployeeDisplayViewModel viewModel)
        {
            try
            {
                _employeeService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "An error has occured. This Employee was not deleted.");
                return View();
            }
        }
    }
}
