using PredictionBot_DataManagement_Infrastructure.Models.TwelveData.HistoricalData;

namespace DataModuleInfrastructure.Services
{
    public interface ITwelveDataService
    {
        Task<HistoricalDataDto> DataSeries(string currency, string interval);
    }
}