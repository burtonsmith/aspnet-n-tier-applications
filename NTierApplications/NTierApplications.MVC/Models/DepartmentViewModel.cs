using NTierApplications.Domain.Entities;
using NTierApplications.MVC.Infrastructure.Mapping;

namespace NTierApplications.MVC.Models
{
    public class DepartmentViewModel : ICreateMapping<Department>
    {
        public int Id { get; set; }
        public string Name { get; set; }
	    public bool HasEmployees { get; set; }
    }
}