using System.Data.Entity.ModelConfiguration;
using NTierApplications.Domain.Entities;

namespace NTierApplications.Data.Mappings
{
    public class UserLoginMapping : EntityTypeConfiguration<UserLogin>
    {
        public UserLoginMapping()
        {
            Property(x => x.LoginProvider)
                .IsRequired()
                ;

            Property(x => x.ProviderKey)
                .IsRequired()
                ;

            Property(x => x.UserId)
                .IsRequired()
                ;
        }
    }
}