using System.Data.Entity.ModelConfiguration;
using NTierApplications.Domain.Entities;

namespace NTierApplications.Data.Mappings
{
    public class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            Property(x => x.UserName)
                .IsRequired()
                ;
        }
    }
}