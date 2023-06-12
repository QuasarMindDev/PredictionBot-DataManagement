using Database;
using PredictionBot_DataManagement_Domain.Models;

namespace PredictionBot_DataManagement_Infrastructure.Database.Repository
{
    public class CalculatedParametersHistoricalDataMappingRepository : Repository<CalculatedParametersHistoricalDataMapping>, ICalculatedParametersHistoricalDataMappingRepository
    {
        public CalculatedParametersHistoricalDataMappingRepository(DataManagementDbContext context) : base(context)
        {
        }
    }
}