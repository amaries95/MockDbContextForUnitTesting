using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MockDbContextForUnitTesting.Api.MockDbContextForUnitTesting.Data.Repositories;
using MockDbContextForUnitTesting.Api.MockDbContextForUnitTesting.Domain.Repositories;

namespace MockDbContextForUnitTesting.Api.MockDbContextForUnitTesting.Data
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services,  IConfiguration configuration)
        {
            services.AddDbContext<ProjectProjectDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("MockDbContextForUnitTesting")));
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
