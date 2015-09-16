using System.Data.Entity.ModelConfiguration;
using NTierApplications.Domain.Entities;

namespace NTierApplications.Data.Mappings
{
	public class DepartmentMapping : EntityTypeConfiguration<Department>
	{
		public DepartmentMapping()
		{
			this.Property(x => x.Name)
				.IsRequired()
				.HasMaxLength(100)
				;
		}
	}
}