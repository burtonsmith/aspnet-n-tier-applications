using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using NTierApplications.Domain.Entities;
using NTierApplications.Domain.ServiceInterfaces;
using NTierApplications.MVC.Models;
using StructureMap;

namespace NTierApplications.MVC.Controllers
{
    public class UserRoleController : Controller
    {
	    //private readonly IUserRoleService _roleService;

	    //public UserRoleController(IUserRoleService roleService)
	    //{
		   // _roleService = roleService;
	    //}

	    
	    // GET: UserRole
        public ActionResult Index()
		{
	        var roles = _roleService.Roles;

			var viewModel = Mapper.Map<IEnumerable<UserRoleViewModel>>(roles);
            return View(viewModel);
        }

        // GET: UserRole/Details/5
        public async Task<ActionResult> Details(int id)
        {
	        var role = await _roleService.FindByIdAsync(id);
	        var viewModel = Mapper.Map<UserRoleViewModel>(role);
            return View(viewModel);
        }

        // GET: UserRole/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserRole/Create
        [HttpPost]
        public async Task<ActionResult> Create(UserRoleViewModel viewModel)
        {
            try
            {
	            if (!ModelState.IsValid)
		            return View(viewModel);

	            var role = Mapper.Map<UserRole>(viewModel);
                var exists = _roleService.Roles.Any(x => x.Name == role.Name);
                if (!exists)
	            {
					await _roleService.CreateAsync(role);

					return RedirectToAction("Index");
				}

				ModelState.AddModelError("", "A role with name already exists.");
				return View(viewModel);
            }
            catch
            {
				ModelState.AddModelError("", "An error has occured. This role was not created.");
                return View(viewModel);
            }
        }

        // GET: UserRole/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
			var role = await _roleService.FindByIdAsync(id);
			var viewModel = Mapper.Map<UserRoleViewModel>(role);
			return View(viewModel);
		}

        // POST: UserRole/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, UserRoleViewModel viewModel)
        {
            try
            {
				if (!ModelState.IsValid)
					return View(viewModel);

				var role = Mapper.Map<UserRole>(viewModel);
				var exists = _roleService.Roles.Any(x => x.Name == role.Name);
				if (!exists)
				{
					await _roleService.UpdateAsync(role);

					return RedirectToAction("Index");
				}

				ModelState.AddModelError("", "A role with that name already exists.");
				return View(viewModel);
			}
            catch
            {
				ModelState.AddModelError("", "An error has occured. This role was not updated.");
                return View(viewModel);
            }
        }

        // GET: UserRole/Delete/5
        public async Task<ViewResult> Delete(int id)
        {
			var role = await _roleService.FindByIdAsync(id);
			var viewModel = Mapper.Map<UserRoleViewModel>(role);
			return View(viewModel);
		}

        // POST: UserRole/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, UserRoleViewModel viewModel)
        {
            try
            {
	            var role = await _roleService.FindByIdAsync(id);

	            if (role.Users.Any())
	            {
		            ModelState.AddModelError("", "This role cannot be deleted. It has " + role.Users.Count() + " user(s) associated to it.");
		            return View(viewModel);
	            }

	            await _roleService.DeleteAsync(role);

                return RedirectToAction("Index");
            }
            catch
            {
				ModelState.AddModelError("", "An error has occured. This role was not deleted.");
                return View();
            }
        }

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (_roleService != null)
				{
					_roleService.Dispose();
				}
			}

			base.Dispose(disposing);
		}
    }
}
