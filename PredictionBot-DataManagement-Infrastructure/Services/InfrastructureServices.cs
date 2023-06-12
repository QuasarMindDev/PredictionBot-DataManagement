using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PredictionBot_DataManagement_Infrastructure.Database.Repository;

namespace PredictionBot_DataManagement_Infrastructure.Services
{
    public static class InfrastructureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            AddDatabaseServices(services, configuration);
            AddDatabaseRepositories(services);
            return services;
        }

        private static IServiceCollection AddDatabaseRepositories(IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<ICalculatedParametersHistoricalDataRepository, CalculatedParametersHistoricalDataRepository>();
            services.AddTransient<ICalculatedParametersHistoricalDataMappingRepository, CalculatedParametersHistoricalDataMappingRepository>();
            services.AddTransient<ICurrencyRepository, CurrencyRepository>();
            services.AddTransient<IExchangeRepository, ExchangeRepository>();
            services.AddTransient<IHistoricalDataRepository, HistoricalDataRepository>();
            services.AddTransient<IIntervalRepository, IntervalRepository>();
            services.AddTransient<IParameterRepository, ParameterRepository>();
            services.AddTransient<ISymbolRepository, SymbolRepository>();
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