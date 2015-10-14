using System.Linq;
using System.Web.Mvc;
using NTierApplications.Domain.ServiceInterfaces;
using System.Collections.Generic;
using NTierApplications.Domain.Entities;

namespace NTierApplications.MVC.Filters.ModelDataProviders
{
	public class SkillListPopulatorAttribute : ActionFilterAttribute
	{
        public ISkillService SkillService { get; set; }

	    public override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			var viewResult = filterContext.Result as ViewResult;

			if (viewResult != null && viewResult.Model is ISkillsList)
			{
                ((ISkillsList)viewResult.Model).SkillsList = SkillService.GetAll().ToList();
			}
		}
    }

    public interface ISkillsList
	{
		IEnumerable<Skill> SkillsList { get; set; }
	}
}