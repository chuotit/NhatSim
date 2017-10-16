using System.Collections.Generic;
using System.Linq;
using NhatSim.Data.Infrastructure;
using NhatSim.Model.Models;

namespace NhatSim.Data.Repositories
{
    public interface IAppRoleRepository : IRepository<AppRole>
    {
        IEnumerable<AppRole> GetListRoleByGroupId(int groupId);
    }

    public class AppRoleRepository : RepositoryBase<AppRole>, IAppRoleRepository
    {
        public AppRoleRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<AppRole> GetListRoleByGroupId(int groupId)
        {
            var query = from g in DbContext.AppRoles
                        join ug in DbContext.AppRoleGroups
                        on g.Id equals ug.RoleId
                        where ug.GroupId == groupId
                        select g;
            return query;
        }
    }
}