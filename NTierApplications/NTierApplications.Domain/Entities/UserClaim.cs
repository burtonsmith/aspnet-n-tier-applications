namespace NTierApplications.Domain.Entities
{
	public class UserClaim : BaseEntity
	{
		public int UserId { get; set; }
		public string ClaimType { get; set; }
		public string ClaimValue { get; set; }

		public User User { get; set; }
	}
}
