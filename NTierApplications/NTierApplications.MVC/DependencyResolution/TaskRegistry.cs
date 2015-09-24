using NTierApplications.MVC.Infrastructure.Tasks;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace NTierApplications.MVC.DependencyResolution
{
	public class TaskRegistry : Registry
	{
		public TaskRegistry()
		{
			Scan(scan =>
			{
				scan.AssembliesFromApplicationBaseDirectory();
				scan.AddAllTypesOf<IRunAfterEachRequest>();
				scan.AddAllTypesOf<IRunAtInit>();
				scan.AddAllTypesOf<IRunAtStartup>();
				scan.AddAllTypesOf<IRunOnEachRequest>();
				scan.AddAllTypesOf<IRunOnError>();
			});
		}
	}
}