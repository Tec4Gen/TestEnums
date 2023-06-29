using Microsoft.EntityFrameworkCore;
using PgMapEnumsTestApi.EF;
using PgMapEnumsTestApi.EF.Enums;

namespace Takara.Infra.EF
{
	public class MyDbContext : DbContext
	{
		public MyDbContext() { }
		public MyDbContext(DbContextOptions<MyDbContext> options)
		: base(options) { }

		public virtual DbSet<User> Users { get; set; }	

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder
				.HasPostgresEnum<UserRoles>("authentication", "user_roles");

			modelBuilder.Entity<User>(entity =>
			{
				entity
					.HasKey(e => e.Id)
					.HasName("pk_user_id");

				entity.ToTable("users", "authentication");

				entity
					.Property(e => e.Id)
					.IsRequired()
					.HasColumnName("user_id");

				entity
					.Property(e => e.Name)
					.IsRequired()
					.HasColumnName("name");

				entity
					.Property(e => e.UserRole)
					.IsRequired()
					.HasColumnName("user_role");
			});
		}
	}
}
