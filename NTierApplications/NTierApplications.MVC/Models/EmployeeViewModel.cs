using System.Web.Mvc;
using NTierApplications.Domain.Entities;
using NTierApplications.MVC.Filters;
using NTierApplications.MVC.Infrastructure.Mapping;

namespace NTierApplications.MVC.Models
{
    public class EmployeeViewModel : ICreateMapping<Employee>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string PhoneNumber { get; set; }
        public string Notes { get; set; }
        public int NamePrefixId { get; set; }
        public int LocationId { get; set; }
        public int DepartmentId { get; set; }

	    public SelectListItem[] DepartmentSelectListItems { get; set; }
    }
}