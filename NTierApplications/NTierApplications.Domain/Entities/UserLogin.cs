namespace NTierApplications.Domain.Entities
{
	public class UserLogin : BaseEntity
	{
		public string LoginProvider { get; set; }
		public string ProviderKey { get; set; }
		public int UserId { get; set; }

		public User User { get; set; }
	}
}
