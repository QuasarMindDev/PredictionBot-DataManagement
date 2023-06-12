using Database;
using PredictionBot_DataManagement_Domain.Models;

namespace PredictionBot_DataManagement_Infrastructure.Database.Repository
{
    public class HistoricalDataRepository : Repository<HistoricalData>, IHistoricalDataRepository
    {
        public HistoricalDataRepository(DataManagementDbContext context) : base(context)
        {
        }
    }
}