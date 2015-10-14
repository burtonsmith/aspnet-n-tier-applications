using System.ComponentModel.DataAnnotations;
using NTierApplications.Domain.Entities;
using NTierApplications.MVC.Infrastructure.Mapping;

namespace NTierApplications.MVC.Models
{
    public class DepartmentViewModel : ICreateMapping<Department>
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Department Name")]
        public string Name { get; set; }
    }
}