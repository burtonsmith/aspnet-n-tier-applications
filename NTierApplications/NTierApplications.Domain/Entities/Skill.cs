using System.Collections.Generic;

namespace NTierApplications.Domain.Entities
{
    public class Skill : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Employee> Contacts { get; set; }
    }
}