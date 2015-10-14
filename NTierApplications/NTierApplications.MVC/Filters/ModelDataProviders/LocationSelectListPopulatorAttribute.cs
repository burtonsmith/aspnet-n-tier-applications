using System.Linq;
using System.Web.Mvc;
using NTierApplications.Domain.ServiceInterfaces;

namespace NTierApplications.MVC.Filters.ModelDataProviders
{
	public class LocationSelectListPopulatorAttribute : ActionFilterAttribute
	{
        public ILocationService LocationService { get; set; }

	    public override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			var viewResult = filterContext.Result as ViewResult;

			if (viewResult != null && viewResult.Model is ILocationSelectList)
			{
				((ILocationSelectList) viewResult.Model).LocationSelectListItems = GetDepartments();
			}
		}

        private SelectListItem[] GetDepartments()
        {
            var locations = LocationService.GetAll().ToList();

            return locations.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToArray();
        }
    }

    public interface ILocationSelectList
	{
		SelectListItem[] LocationSelectListItems { get; set; }
	}
}