using System.Data.Entity.ModelConfiguration;
using NTierApplications.Domain.Entities;

namespace NTierApplications.Data.Mappings
{
	public class EmployeeMapping : EntityTypeConfiguration<Employee>
	{
		public EmployeeMapping()
		{
			Property(x => x.FirstName)
				.IsRequired()
				.HasMaxLength(50)
				;

			Property(x => x.LastName)
				.IsRequired()
				.HasMaxLength(75)
				;

			Property(x => x.JobTitle)
				.IsRequired()
				.HasMaxLength(100)
				;

			Property(x => x.Email)
				.HasMaxLength(100)
				;

			Property(x => x.WebSite)
				.HasMaxLength(255)
				;

			Property(x => x.PhoneNumber)
				;

			Property(x => x.Notes)
				.HasMaxLength(500)
				;
		}
	}
}