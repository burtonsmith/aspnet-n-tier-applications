using System.Collections.Generic;

namespace NTierApplications.Domain.Entities
{
    public class NamePrefix : BaseEntity
    {
        public string Prefix { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}