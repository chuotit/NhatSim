using NhatSim.Data.Infrastructure;
using NhatSim.Model.Models;

namespace NhatSim.Data.Repositories
{
    public interface ISimStoreRepository : IRepository<SimStore>
    {
    }

    public class SimStoreRepository : RepositoryBase<SimStore>, ISimStoreRepository
    {
        public SimStoreRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}