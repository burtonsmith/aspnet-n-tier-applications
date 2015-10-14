using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using NTierApplications.Domain.Entities;
using NTierApplications.MVC.Filters;
using NTierApplications.MVC.Infrastructure.Mapping;

namespace NTierApplications.MVC.Models
{
    public class EmployeeDisplayViewModel : ICreateMapping<Employee>
    {
        public int Id { get; set; }

        [Display(Name = "Name Prefix")]
        public string NamePrefixPrefix { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        [Display(Name = "E-Mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Website")]
        [DataType(DataType.Url)]
        public string WebSite { get; set; }

        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Location")]
        public string LocationName { get; set; }

        [Display(Name = "Department")]
        public string DepartmentName { get; set; }

        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        public IEnumerable<Skill> Skills { get; set; }

        public IEnumerable<Skill> SkillsList { get; set; }

    }
}