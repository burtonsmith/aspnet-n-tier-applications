using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NTierApplications.MVC.Filters.ModelDataProviders;

namespace NTierApplications.MVC.Controllers
{
    [DepartmentSelectListPopulator, 
        NamePrefixSelectListPopulator,
        SkillListPopulator,
        LocationSelectListPopulator]
    public abstract class BaseController : Controller
    {
    }
}