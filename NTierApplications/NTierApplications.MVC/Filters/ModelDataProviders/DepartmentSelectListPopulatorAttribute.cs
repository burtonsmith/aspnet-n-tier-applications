using System.Linq;
using System.Web.Mvc;
using NTierApplications.Domain.ServiceInterfaces;

namespace NTierApplications.MVC.Filters.ModelDataProviders
{
	public class DepartmentSelectListPopulatorAttribute : ActionFilterAttribute
	{
        public IDepartmentService DepartmentService { get; set; }

	    public override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			var viewResult = filterContext.Result as ViewResult;

			if (viewResult != null && viewResult.Model is IDepartmentSelectList)
			{
				((IDepartmentSelectList) viewResult.Model).DepartmentSelectListItems = GetDepartments();
			}
		}

        private SelectListItem[] GetDepartments()
        {
            var departments = DepartmentService.GetAll().ToList();

            return departments.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToArray();
        }
    }

    public interface IDepartmentSelectList
	{
		SelectListItem[] DepartmentSelectListItems { get; set; }
	}
}