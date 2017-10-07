using NhatSim.Data.Infrastructure;
using NhatSim.Model.Models;

namespace NhatSim.Data.Repositories
{
    public interface IAgentRepository : IRepository<Agent>
    {
    }

    internal class AgentRepository : RepositoryBase<Agent>, IAgentRepository
    {
        public AgentRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}