using Database;
using PredictionBot_DataManagement_Domain.Models;

namespace PredictionBot_DataManagement_Infrastructure.Database.Repository
{
    public class IntervalRepository : Repository<Interval>, IIntervalRepository
    {
        public IntervalRepository(DataManagementDbContext context) : base(context)
        {
        }
    }
}