using Database;
using PredictionBot_DataManagement_Domain.Models;

namespace PredictionBot_DataManagement_Infrastructure.Database.Repository
{
    public class SymbolRepository : Repository<Symbol>, ISymbolRepository
    {
        public SymbolRepository(DataManagementDbContext context) : base(context)
        {
        }
    }
}