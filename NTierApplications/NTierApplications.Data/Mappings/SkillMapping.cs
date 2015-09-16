using System.Data.Entity.ModelConfiguration;
using NTierApplications.Domain.Entities;

namespace NTierApplications.Data.Mappings
{
	public class SkillMapping : EntityTypeConfiguration<Skill>
	{
		public SkillMapping()
		{
			Property(x => x.Name)
				.IsRequired()
				.HasMaxLength(50)
				;
		}
	}
}