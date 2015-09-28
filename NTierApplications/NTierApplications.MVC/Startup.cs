using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(NTierApplications.MVC.Startup))]
namespace NTierApplications.MVC
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			ConfigureAuth(app);
		}
	}
}