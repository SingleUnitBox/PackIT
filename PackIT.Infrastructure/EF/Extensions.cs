using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PackIt.Domain.Repositories;
using PackIT.Application.Services;
using PackIT.Infrastructure.EF.Context;
using PackIT.Infrastructure.EF.Options;
using PackIT.Infrastructure.EF.Repositories;
using PackIT.Infrastructure.EF.Services;
using PackIT.Shared.Options;


namespace PackIT.Infrastructure.EF
{
    internal static class Extensions
    {
        public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPackingListRepository, PostgresPackingListRepository>();
            services.AddScoped<IPackingListReadService, PostgresPackingListReadService>();

            var options = configuration.GetOptions<PostgresOptions>("Postgres");

            services.AddDbContext<ReadDbContext>(c => c.UseNpgsql(options.ConnectionString));
            services.AddDbContext<WriteDbContext>(c => c.UseNpgsql(options.ConnectionString));

            return services;
        }

        public static IServiceCollection AddSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPackingListRepository, PostgresPackingListRepository>();
            services.AddScoped<IPackingListReadService, PostgresPackingListReadService>();

            var options = configuration.GetOptions<PostgresOptions>("SqlServer");

            services.AddDbContext<ReadDbContext>(c => c.UseSqlServer(options.ConnectionString));
            services.AddDbContext<WriteDbContext>(c => c.UseSqlServer(options.ConnectionString));

            return services;
        }
    }
}
