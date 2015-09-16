using System.Collections.Generic;

namespace NTierApplications.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string PhoneNumber { get; set; }
        public string Notes { get; set; }

        public int NamePrefixId { get; set; }
        public virtual NamePrefix NamePrefix { get; set; }

        public int LocationId { get; set; }
        public virtual Location Location { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }
    }
}