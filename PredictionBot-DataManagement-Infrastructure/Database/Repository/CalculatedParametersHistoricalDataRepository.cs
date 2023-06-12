using Database;
using PredictionBot_DataManagement_Domain.Models;

namespace PredictionBot_DataManagement_Infrastructure.Database.Repository
{
    public class CalculatedParametersHistoricalDataRepository : Repository<CalculatedParametersHistoricalData>, ICalculatedParametersHistoricalDataRepository
    {
        public CalculatedParametersHistoricalDataRepository(DataManagementDbContext context) : base(context)
        {
        }
    }
}