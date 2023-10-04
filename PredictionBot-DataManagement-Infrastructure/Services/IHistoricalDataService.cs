using PredictionBot_DataManagement_Domain.Dtos.HistoricalData;
using PredictionBot_DataManagement_Infrastructure.Models.TwelveData.HistoricalData;

namespace PredictionBot_DataManagement_Infrastructure.Services
{
    public interface IHistoricalDataService
    {
        void CreateHistoricalData(HistoricalDataDto historicalDataDto);

        Task<HistoricalDataDatabaseDto> GetHistoricalData(HistoricalDataRequestDto metadata);
    }
}