using NTierApplications.Domain.Entities;
using NTierApplications.MVC.Infrastructure.Mapping;

namespace NTierApplications.MVC.Models
{
    public class LocationViewModel : ICreateMapping<Location>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
    }
}