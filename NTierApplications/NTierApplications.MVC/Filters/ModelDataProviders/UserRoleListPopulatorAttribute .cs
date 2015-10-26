using System.Linq;
using System.Web.Mvc;
using NTierApplications.Domain.ServiceInterfaces;
using System.Collections.Generic;
using NTierApplications.Domain.Entities;

namespace NTierApplications.MVC.Filters.ModelDataProviders
{
	public class UserRoleListPopulatorAttribute : ActionFilterAttribute
	{
        public IUserRoleService RoleService { get; set; }

	    public override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			var viewResult = filterContext.Result as ViewResult;

			if (viewResult != null && viewResult.Model is IUserRoleList)
			{
                ((IUserRoleList)viewResult.Model).UserRoleList = RoleService.Roles.ToList();
            }
		}
    }

    public interface IUserRoleList
	{
		IEnumerable<UserRole> UserRoleList { get; set; }
	}
}