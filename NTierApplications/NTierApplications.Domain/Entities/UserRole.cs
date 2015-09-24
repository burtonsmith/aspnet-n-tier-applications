using System.Collections.Generic;
using Microsoft.AspNet.Identity;

namespace NTierApplications.Domain.Entities
{
	public class UserRole : BaseEntity, IRole<int>
	{
		public string Name { get; set; }

		public virtual ICollection<User> Users { get; set; }
	}
}
