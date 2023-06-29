using Microsoft.EntityFrameworkCore;
using Npgsql;
using PgMapEnumsTestApi.EF.Enums;
using Takara.Infra.EF;

namespace PgMapEnumsTestApi.Ioc
{
	public static class EFConfigurationExtensions
	{
		public static IServiceCollection AddMyDbContext(this IServiceCollection services, IConfiguration configuration)
		{
			//services.AddNpgsqlDataSource(configuration["Settings:ConnectionString"], builder =>
			//{
			//    builder?.MapEnum<OneTimePasswordStatus>();
			//    builder?.MapEnum<UserRegistrationStatus>();
			//    builder?.MapEnum<UserRoles>();
			//});

			var dataSourceBuilder = new NpgsqlDataSourceBuilder(configuration["Settings:ConnectionString"]);

			dataSourceBuilder.MapEnum<UserRoles>();
			
			var dataSource = dataSourceBuilder.Build();

			return services.AddDbContext<MyDbContext>(options =>
			{
				options.UseNpgsql(dataSource);
			});
		}
	}
}