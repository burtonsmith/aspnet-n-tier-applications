using NTierApplications.Domain.Entities;
using NTierApplications.MVC.Infrastructure.Mapping;

namespace NTierApplications.MVC.Models
{
    public class NamePrefixViewModel : ICreateMapping<NamePrefix>
    {
        public int Id { get; set; }
        public string Prefix { get; set; }

    }
}