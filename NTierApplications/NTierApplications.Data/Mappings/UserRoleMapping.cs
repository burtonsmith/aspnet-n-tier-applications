using System.Data.Entity.ModelConfiguration;
using NTierApplications.Domain.Entities;

namespace NTierApplications.Data.Mappings
{
    public class UserRoleMapping : EntityTypeConfiguration<UserRole>
    {
        public UserRoleMapping()
        {
            Property(x => x.Name)
                .IsRequired()
                ;
        }
    }
}