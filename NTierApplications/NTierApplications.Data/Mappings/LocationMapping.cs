using System.Data.Entity.ModelConfiguration;
using NTierApplications.Domain.Entities;

namespace NTierApplications.Data.Mappings
{
	public class LocationMapping : EntityTypeConfiguration<Location>
	{
		public LocationMapping()
		{
			Property(x => x.Name)
				.IsRequired()
				.HasMaxLength(50)
				;

			Property(x => x.Address)
				.IsRequired()
				.HasMaxLength(100)
				;

			Property(x => x.State)
				.IsRequired()
				.HasMaxLength(2)
				;

			Property(x => x.Zip)
				.IsRequired()
				;
		}
	}
}