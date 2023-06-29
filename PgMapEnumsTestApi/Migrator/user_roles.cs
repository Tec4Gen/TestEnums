using FluentMigrator;

namespace Takara.Infra.Database.types
{
	[Migration(2)]
	public class CreateEnumOneUserRoles : Migration
	{
		public override void Up()
		{
			Execute.Sql(@"CREATE TYPE authentication.user_roles AS ENUM ('Client')");
		}

		public override void Down()
		{
			Execute.Sql(@"DROP TYPE authentication.user_roles;");
		}
	}
}
