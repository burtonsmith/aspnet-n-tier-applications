using System.Collections.Generic;

namespace NTierApplications.Domain.Entities
{
    public class Department : BaseEntity
    {
	    public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}