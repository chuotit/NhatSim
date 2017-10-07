using NhatSim.Data.Infrastructure;
using NhatSim.Model.Models;

namespace NhatSim.Data.Repositories
{
    public interface IAgentLevelRepository : IRepository<AgentLevel>
    {
    }

    internal class AgentLevelRepository : RepositoryBase<AgentLevel>, IAgentLevelRepository
    {
        public AgentLevelRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}