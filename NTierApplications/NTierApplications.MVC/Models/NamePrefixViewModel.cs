using System.ComponentModel.DataAnnotations;
using NTierApplications.Domain.Entities;
using NTierApplications.MVC.Infrastructure.Mapping;

namespace NTierApplications.MVC.Models
{
    public class NamePrefixViewModel : ICreateMapping<NamePrefix>
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Prefix { get; set; }

    }
}