using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Net;
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
using WebGrease.Css.Extensions;

namespace NTierApplications.MVC.Controllers
{
    public class UserAdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserRoleService _roleService;

        public UserAdminController(IUserService userService, IUserRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        // GET: UserAdmin
        public ActionResult Index()
        {
            
            var users = _userService.Users;
            var viewModel = Mapper.Map<IEnumerable<UserViewModel>>(users);
            return View(viewModel);
        }

        // GET: UserAdmin/Details/5
        public ActionResult Details(int id)
        {
            if (id == default(int))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var user = _userService.FindByIdAsync(id);

            if (user == null)
                return HttpNotFound();

            var viewModel = Mapper.Map<UserViewModel>(user);
            GetRelatedData(viewModel);

            return View(viewModel);
        }

        // GET: UserAdmin/Create
        public ActionResult Create()
        {
            var viewModel = new UserViewModel();
            GetRelatedData(viewModel);
            return View(viewModel);
        }

        // POST: UserAdmin/Create
        [HttpPost]
        public async Task<ActionResult> Create(UserViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                GetRelatedData(viewModel);
                return View(viewModel);
            }

            try
            {
                var user = Mapper.Map<User>(viewModel);
                viewModel.SelectedRoles.ForEach(x=> user.UserRoles.Add(_roleService.FindByIdAsync(x).Result));
                await _userService.CreateAsync(user);
                return RedirectToAction("Index");
            }
            catch
            {
                GetRelatedData(viewModel);
                ModelState.AddModelError("", "An error occured. The User was not created.");
                return View(viewModel);
            }
        }

        // GET: UserAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == default(int))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var user = _userService.FindByIdAsync(id).Result;

            if (user == null)
                return HttpNotFound();

            var viewModel = Mapper.Map<UserViewModel>(user);
            GetRelatedData(viewModel);

            return View(viewModel);
        }

        // POST: UserAdmin/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, UserViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                GetRelatedData(viewModel);
                return View(viewModel);
            }

            try
            {
                var user = Mapper.Map(viewModel, _userService.FindByIdAsync(viewModel.Id).Result);
                viewModel.SelectedRoles.ForEach(x => user.UserRoles.Add(_roleService.FindByIdAsync(x).Result));
                await _userService.UpdateAsync(user);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                var error = e.Message;
                ModelState.AddModelError("", "An error occured. The User was not updated.");
                return View(viewModel);
            }
        }

        // GET: UserAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == default(int))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var user = _userService.FindByIdAsync(id).Result;

            if (user == null)
                return HttpNotFound();

            var viewModel = Mapper.Map<UserViewModel>(user);
            GetRelatedData(viewModel);

            return View(viewModel);
        }

        // POST: UserAdmin/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, UserViewModel viewModel)
        {
            try
            {
                var user = Mapper.Map<User>(viewModel);
                await _userService.DeleteAsync(user);

                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "An error has occured. This role was not deleted.");
                return View(viewModel);
            }
        }

        #region Helpers

        private void GetRelatedData(UserViewModel viewModel)
        {
            viewModel.UserRoleList = _roleService.Roles;
        }

        #endregion
    }
}
