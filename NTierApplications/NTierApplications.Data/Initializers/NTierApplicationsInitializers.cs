using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTierApplications.Data.Context;

namespace NTierApplications.Data.Initializers
{
	public class NTierApplicationsCreateDatabaseIfNotExists : CreateDatabaseIfNotExists<NTierApplicationsDataContext>
	{
		protected override void Seed(NTierApplicationsDataContext context)
		{
			base.Seed(context);
			DbSeed.Seed(context);
		}
	}

	public class NTierApplicationsDropCreateDatabaseIfModelChanges : DropCreateDatabaseIfModelChanges<NTierApplicationsDataContext>
	{
		protected override void Seed(NTierApplicationsDataContext context)
		{
			base.Seed(context);
			DbSeed.Seed(context);
		}
	}

	public class NTierApplicationsDropCreateDatabaseAlways : DropCreateDatabaseAlways<NTierApplicationsDataContext>
	{
		protected override void Seed(NTierApplicationsDataContext context)
		{
			base.Seed(context);
			DbSeed.Seed(context);
		}
	}
}
