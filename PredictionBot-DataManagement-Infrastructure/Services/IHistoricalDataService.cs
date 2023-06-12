using PredictionBot_DataManagement_Domain.Dtos;

namespace PredictionBot_DataManagement_Infrastructure.Services
{
    public interface IHistoricalDataService
    {
        void CreateHistoricalData(HistoricalDataDto historicalDataDto);
    }
}