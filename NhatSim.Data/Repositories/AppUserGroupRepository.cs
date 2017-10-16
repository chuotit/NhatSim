using NhatSim.Data.Infrastructure;
using NhatSim.Model.Models;

namespace NhatSim.Data.Repositories
{
    public interface IAppUserGroupRepository : IRepository<AppUserGroup>
    {
    }

    public class AppUserGroupRepository : RepositoryBase<AppUserGroup>, IAppUserGroupRepository
    {
        public AppUserGroupRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}