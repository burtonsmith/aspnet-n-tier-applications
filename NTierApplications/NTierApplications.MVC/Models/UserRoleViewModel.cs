using NTierApplications.Domain.Entities;
using NTierApplications.MVC.Infrastructure.Mapping;

namespace NTierApplications.MVC.Models
{
	public class UserRoleViewModel : ICreateMapping<UserRole>
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}