using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using NTierApplications.Domain.Entities;
using NTierApplications.MVC.Filters.ModelDataProviders;
using NTierApplications.MVC.Infrastructure.Mapping;

namespace NTierApplications.MVC.Models
{
    public class EmployeeEditViewModel :    ICreateMapping<Employee>, 
                                            IDepartmentSelectList,
                                            INamePrefixSelectList,
                                            ILocationSelectList,
                                            ISkillsList
    {
        public int Id { get; set; }

        [Display(Name = "Name Prefix")]
        public int NamePrefixId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(75)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        [Required]
        [Display(Name = "E-Mail")]
        [MaxLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Website")]
        [MaxLength(255)]
        [DataType(DataType.Url)]
        public string WebSite { get; set; }

        [Required]
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Location")]
        public int LocationId { get; set; }

        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        public IEnumerable<Skill> Skills { get; set; }

        [MaxLength(500)]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        public IEnumerable<Skill> SkillsList { get; set; }
        public IEnumerable<int> NewSkills { get; set; }
        public SelectListItem[] DepartmentSelectListItems { get; set; }
        public SelectListItem[] NamePrefixSelectListItems { get; set; }
        public SelectListItem[] LocationSelectListItems { get; set; }
    }
}