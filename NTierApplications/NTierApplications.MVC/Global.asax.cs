using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using NTierApplications.MVC.DependencyResolution;
using NTierApplications.MVC.Infrastructure.Tasks;
using StructureMap;

namespace NTierApplications.MVC
{
	public class MvcApplication : System.Web.HttpApplication
	{
		public IContainer Container
		{
			get
			{
				return (IContainer)HttpContext.Current.Items["_Container"];
			}
			set
			{
				HttpContext.Current.Items["_Container"] = value;
			}
		}


		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			//AutoMapperConfig.Initialize(ObjectFactory.Container);


			//using (var container = ObjectFactory.Container.GetNestedContainer())
			//{
			//	foreach (var task in container.GetAllInstances<IRunAtInit>())
			//	{
			//		task.Execute();
			//	}

			//	foreach (var task in container.GetAllInstances<IRunAtStartup>())
			//	{
			//		task.Execute();
			//	}
			//}
		}

		//public void Application_BeginRequest()
		//{
		//	Container = ObjectFactory.Container.GetNestedContainer();

		//	foreach (var task in Container.GetAllInstances<IRunOnEachRequest>())
		//	{
		//		task.Execute();
		//	}
		//}

		//public void Application_Error()
		//{
		//	foreach (var task in Container.GetAllInstances<IRunOnError>())
		//	{
		//		task.Execute();
		//	}
		//}

		//public void Application_EndRequest()
		//{
		//	try
		//	{
		//		foreach (var task in Container.GetAllInstances<IRunAfterEachRequest>())
		//		{
		//			task.Execute();
		//		}
		//	}
		//	finally
		//	{
		//		Container.Dispose();
		//		Container = null;
		//	}
		//}

	}
}
