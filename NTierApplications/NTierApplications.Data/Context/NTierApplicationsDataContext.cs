using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NTierApplications.Data.Initializers;
using NTierApplications.Domain.Entities;

namespace NTierApplications.Data.Context
{
	public class NTierApplicationsDataContext : DbContext
	{
		public DbSet<Department> Departments { get; set; }
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Location> Locations { get; set; }
		public DbSet<NamePrefix> NamePrefixes { get; set; }
		public DbSet<Skill> Skills { get; set; }

		public NTierApplicationsDataContext(string conntectionString) : base(conntectionString)
		{
            Database.SetInitializer(new NTierApplicationsCreateDatabaseIfNotExists());
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
