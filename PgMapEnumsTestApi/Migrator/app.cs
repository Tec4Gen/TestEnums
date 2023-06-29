using FluentMigrator;

namespace Migrator
{
	[Migration(1)]
	public class CreateSchemaAuthentication : AutoReversingMigration
	{
		public override void Up()
		{
			Create
				.Schema("authentication");
		}
	}
}
