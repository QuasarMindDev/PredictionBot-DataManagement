using DataModuleInfrastructure.Services;
using FluentValidation;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using PredictionBot_DataManagement_Domain.Commons;
using PredictionBot_DataManagement_Domain.Dtos.HistoricalData;
using PredictionBot_DataManagement_Domain.Models.HistoricalData;
using PredictionBot_DataManagement_Infrastructure.Common;
using PredictionBot_DataManagement_Infrastructure.Common.Validations.HistoricalData;
using PredictionBot_DataManagement_Infrastructure.Database;
using PredictionBot_DataManagement_Infrastructure.Database.Repository;
using System.Reflection;
using TwelveDataServices;

namespace PredictionBot_DataManagement_Infrastructure.Services
{
    public static class InfrastructureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            AddValidators(services);
            AddDatabaseServices(services);
            AddDatabaseRepositories(services);
            AddHttpClients(services);
            AddDataFetchingServices(services);
            AddMapperServices(services);
            return services;
        }

        private static IServiceCollection AddDatabaseRepositories(IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IMarketDataRepository, MarketDataRepository>();
            return services;
        }

        private static IServiceCollection AddDatabaseServices(IServiceCollection services)
        {
            services.AddSingleton<IMongoContext, MongoDbContext>();
            services.AddScoped<IDatabaseService, DatabaseService>();
            return services;
        }

        private static IServiceCollection AddDataFetchingServices(IServiceCollection services)
        {
            services.AddScoped<ITwelveDataService, TwelveDataService>();
            services.AddScoped<IMarketDataRepository, MarketDataRepository>();
            services.AddScoped<IMetadataRepository, MetadataDataRepository>();
            services.AddScoped<IHistoricalDataService, HistoricalDataService>();
            return services;
        }

        private static IServiceCollection AddHttpClients(IServiceCollection services)
        {
            services.AddHttpClient(Constant.GetDataHttpClientName);
            return services;
        }

        private static IServiceCollection AddValidators(IServiceCollection services)
        {
            services.AddScoped<IValidator<HistoricalDataRequestDto>, HistoricalDataRequestValidator>();
            services.AddScoped<IValidator<Metadata>, MetadataValidator>();
            services.AddScoped<IValidator<MarketData>, MarketDataValidator>();
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