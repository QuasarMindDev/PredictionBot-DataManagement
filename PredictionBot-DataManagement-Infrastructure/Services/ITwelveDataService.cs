using PredictionBot_DataManagement_Domain.Dtos;

namespace DataModuleInfrastructure.Services
{
    public interface ITwelveDataService
    {
        Task<HistoricalDataDto> DataSeries(string currency, string interval);
    }
}