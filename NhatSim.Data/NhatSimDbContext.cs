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

        public static NhatSimDbContext Create()
        {
            return new NhatSimDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {

        }
    }
}