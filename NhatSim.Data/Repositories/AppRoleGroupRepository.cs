using NhatSim.Data.Infrastructure;
using NhatSim.Model.Models;

namespace NhatSim.Data.Repositories
{
    public interface IAppRoleGroupRepository : IRepository<AppRoleGroup>
    {
    }

    public class AppRoleGroupRepository : RepositoryBase<AppRoleGroup>, IAppRoleGroupRepository
    {
        public AppRoleGroupRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}