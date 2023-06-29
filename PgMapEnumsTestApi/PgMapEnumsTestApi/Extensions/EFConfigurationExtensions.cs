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
            /*
			 * It seems that I did everything according to the instructions, at the bottom there are two options for how I tried to run it. But none of them work. 
			 * I get a message saying that it is impossible to cast to int32 or else, a message saying "Can't cast database type text to UserRoles"
			 * I don't understand what I'm doing wrong anymore :(
			 */

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