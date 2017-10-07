using NhatSim.Data.Infrastructure;
using NhatSim.Model.Models;

namespace NhatSim.Data.Repositories
{
    public interface IFirstNumberRepository : IRepository<FirstNumber>
    {
    }

    public class FirstNumberRepository : RepositoryBase<FirstNumber>, IFirstNumberRepository
    {
        public FirstNumberRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}