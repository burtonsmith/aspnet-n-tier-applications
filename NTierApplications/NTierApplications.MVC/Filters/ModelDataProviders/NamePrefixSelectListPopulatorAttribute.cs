using NTierApplications.Domain.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NTierApplications.MVC.Filters.ModelDataProviders
{
    public class NamePrefixSelectListPopulatorAttribute : ActionFilterAttribute
    {
        public INamePrefixService NamePrefixService { get; set; }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var viewResult = filterContext.Result as ViewResult;

            if (viewResult != null && viewResult.Model is INamePrefixSelectList)
            {
                ((INamePrefixSelectList)viewResult.Model).NamePrefixSelectListItems = GetPrefixes();
            }
        }

        private SelectListItem[] GetPrefixes()
        {
            var prefixes = NamePrefixService.GetAll();

            return prefixes.Select(x => new SelectListItem
            {
                Text = x.Prefix,
                Value = x.Id.ToString()
            }).ToArray();
        }
    }

    public interface INamePrefixSelectList
    {
        SelectListItem[] NamePrefixSelectListItems { get; set; }
    }

}
