﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierApplications.Data.Context
{
	public class ContextFactory : IDbContextFactory<NTierApplicationsDataContext>
	{
		public NTierApplicationsDataContext Create()
		{
            return new NTierApplicationsDataContext(ConfigurationManager.ConnectionStrings["NTierApplicationsDataContext"].ToString());
		}
	}
}
