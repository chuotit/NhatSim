using NhatSim.Data.Infrastructure;
using NhatSim.Model.Models;

namespace NhatSim.Data.Repositories
{
    public interface ISimNetworkRepository : IRepository<SimNetwork>
    {
    }

    public class SimNetworkRepository : RepositoryBase<SimNetwork>, ISimNetworkRepository
    {
        public SimNetworkRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}