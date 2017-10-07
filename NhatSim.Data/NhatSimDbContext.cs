using System.Data.Entity;
using NhatSim.Model.Models;

namespace NhatSim.Data
{
    public class NhatSimDbContext : DbContext
    {
        public NhatSimDbContext() : base("NhatSimConnect")
        {
            // Cài đặt để khi incluce bảng cha thì tự động include luôn bảng con của nó.
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Agent> Agents { set; get; }
        public DbSet<AgentLevel> AgentLevels { set; get; }
        public DbSet<FirstNumber> FirstNumbers { set; get; }
        public DbSet<SimNetwork> SimNetworks { set; get; }
        public DbSet<SimStore> SimStores { set; get; }

        public static NhatSimDbContext Create()
        {
            return new NhatSimDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {

        }
    }
}