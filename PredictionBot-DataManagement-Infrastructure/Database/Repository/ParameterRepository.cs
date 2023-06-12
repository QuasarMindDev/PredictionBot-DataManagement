using Database;
using PredictionBot_DataManagement_Domain.Models;

namespace PredictionBot_DataManagement_Infrastructure.Database.Repository
{
    public class ParameterRepository : Repository<Parameter>, IParameterRepository
    {
        public ParameterRepository(DataManagementDbContext context) : base(context)
        {
        }
    }
}