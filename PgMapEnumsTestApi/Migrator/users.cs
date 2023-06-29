using FluentMigrator;

namespace Migrator
{
	[Migration(3)]
	public class CreateTableUsers : AutoReversingMigration
	{
		public override void Up()
		{
			Create
				.Table("users")
				.InSchema("authentication")
				.WithColumn("user_id").AsInt64().Identity().NotNullable().PrimaryKey("pk_user_id")
				.WithColumn("name").AsString().NotNullable()
				.WithColumn("user_role").AsString().NotNullable().WithDefaultValue("Client");

			Insert.IntoTable("users").InSchema("authentication").Row(new { name = "SomeName" });
		}
	}
}
