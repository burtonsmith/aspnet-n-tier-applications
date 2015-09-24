using System.Runtime.Remoting.Channels;
using NTierApplications.MVC.Infrastructure.Tasks;
using StructureMap;

namespace NTierApplications.MVC.DependencyResolution
{
	using System.Web;

	using NTierApplications.MVC.App_Start;

	using StructureMap.Web.Pipeline;

	public class StructureMapScopeModule : IHttpModule
	{
		#region Public Methods and Operators

		public void Dispose()
		{
		}

		public void Init(HttpApplication context)
		{

			var scope = StructuremapMvc.StructureMapDependencyScope;
			var container = scope.GetCurrentNestedContainer();

			foreach (var task in container.GetAllInstances<IRunAtInit>())
			{
				task.Execute();
			}

			foreach (var task in container.GetAllInstances<IRunAtStartup>())
			{
				task.Execute();
			}

			context.BeginRequest += (sender, e) =>
			{
				container = scope.GetCurrentNestedContainer();

				//scope.CreateNestedContainer();
				foreach (var task in container.GetAllInstances<IRunOnEachRequest>())
				{
					task.Execute();
				}

			};
			context.BeginRequest += (sender, e) =>
			{
				container = scope.GetCurrentNestedContainer();

				foreach (var task in container.GetAllInstances<IRunOnEachRequest>())
				{
					task.Execute();
				}
			};
			context.Error += (sender, e) =>
			{
				container = scope.GetCurrentNestedContainer();

				foreach (var task in container.GetAllInstances<IRunOnError>())
				{
					task.Execute();
				}
			};
			context.EndRequest += (sender, e) =>
			{
				container = scope.GetCurrentNestedContainer();

				try
				{
					foreach (var task in container.GetAllInstances<IRunAfterEachRequest>())
					{
						task.Execute();
					}
				}
				finally
				{
					HttpContextLifecycle.DisposeAndClearAll();
					scope.DisposeNestedContainer();
				}
			};
		}

		#endregion
	}
}