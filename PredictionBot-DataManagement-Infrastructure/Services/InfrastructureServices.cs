using Database;
using DataModuleInfrastructure.Services;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PredictionBot_DataManagement_Infrastructure.Database.Repository;
using System.Reflection;
using TwelveDataServices;

namespace PredictionBot_DataManagement_Infrastructure.Services
{
    public static class InfrastructureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            AddDatabaseServices(services, configuration);
            AddDatabaseRepositories(services);
            AddDataFetchingServices(services);
            AddMapperServices(services);
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

        private static IServiceCollection AddDataFetchingServices(IServiceCollection services)
        {
            services.AddHttpClient("GetData");
            services.AddScoped<ITwelveDataService, TwelveDataService>();
            services.AddScoped<IHistoricalDataService, HistoricalDataService>();
            return services;
        }

        private static IServiceCollection AddMapperServices(IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());
            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();
            return services;
        }
    }
}