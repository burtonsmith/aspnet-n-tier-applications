using System.Data.Entity.ModelConfiguration;
using NTierApplications.Domain.Entities;

namespace NTierApplications.Data.Mappings
{
	public class NamePrefixMapping : EntityTypeConfiguration<NamePrefix>
	{
		public NamePrefixMapping()
		{
			Property(x => x.Prefix)
				.IsRequired()
				.HasMaxLength(10)
				;
		}
	}
}