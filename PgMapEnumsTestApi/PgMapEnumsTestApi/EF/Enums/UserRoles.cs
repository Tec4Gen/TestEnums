using NpgsqlTypes;

namespace PgMapEnumsTestApi.EF.Enums
{
	public enum UserRoles
	{
		[PgName("Client")]
		Client
	}
}
