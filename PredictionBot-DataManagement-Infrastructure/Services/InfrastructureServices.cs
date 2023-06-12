using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PredictionBot_DataManagement_Infrastructure.Services
{
    public static class InfrastructureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            AddDatabaseServices(services, configuration);
            return services;
        }

        private static IServiceCollection AddDatabaseServices(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DataManagementDbConnection");
            services.AddDbContext<DataManagementDbContext>(options => options.UseMySql(connectionString,
                                                                      ServerVersion.AutoDetect(connectionString),
                                                                      context => context.MigrationsAssembly(typeof(DataManagementDbContext).Assembly.FullName)));

            var serviceProvider = services.BuildServiceProvider();
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<DataManagementDbContext>().Database.EnsureCreated();
            }
            return services;
        }
    }
}