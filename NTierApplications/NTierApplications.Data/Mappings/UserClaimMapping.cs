using System.Data.Entity.ModelConfiguration;
using NTierApplications.Domain.Entities;

namespace NTierApplications.Data.Mappings
{
    public class UserClaimMapping : EntityTypeConfiguration<UserClaim>
    {
        public UserClaimMapping()
        {
            Property(x => x.ClaimType)
                .IsRequired()
                ;

            Property(x => x.ClaimValue)
                .IsRequired()
                ;

            Property(x => x.UserId)
                .IsRequired()
                ;
        }
    }
}