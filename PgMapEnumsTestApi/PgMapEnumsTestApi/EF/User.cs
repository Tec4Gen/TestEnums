using PgMapEnumsTestApi.EF.Enums;

namespace PgMapEnumsTestApi.EF
{
	public class User
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public UserRoles UserRole { get; set; }
	}
}
