using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using NhatSim.Model.Models;

namespace NhatSim.Data
{
    public class NhatSimDbContext : IdentityDbContext<AppUser>
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

        public DbSet<AppGroup> AppGroups { set; get; }
        public DbSet<AppRole> AppRoles { set; get; }
        public DbSet<AppRoleGroup> AppRoleGroups { set; get; }
        public DbSet<AppUserGroup> AppUserGroups { set; get; }

        public DbSet<Function> Functions { set; get; }
        public DbSet<Permission> Permissions { set; get; }
        public DbSet<IdentityUserRole> UserRoles { set; get; }


        public DbSet<Error> Errors { set; get; }

        public static NhatSimDbContext Create()
        {
            return new NhatSimDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId }).ToTable("AppUserRoles");
            builder.Entity<IdentityUserLogin>().HasKey(i => i.UserId).ToTable("AppUserLogins");
            builder.Entity<IdentityRole>().ToTable("AppRoles");
            builder.Entity<IdentityUserClaim>().HasKey(i => i.UserId).ToTable("AppUserClaims");
            builder.Entity<IdentityUser>().ToTable("AppUsers");
        }
    }
}