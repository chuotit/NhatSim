namespace NhatSim.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using NhatSim.Model.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<NhatSim.Data.NhatSimDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NhatSim.Data.NhatSimDbContext context)
        {
            //var manager = new UserManager<AppUser>(new UserStore<AppUser>(new NhatSimDbContext()));

            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new NhatSimDbContext()));

            //var user = new AppUser()
            //{
            //    UserName = "admin",
            //    Email = "nhatsim.com@gmail.com",
            //    EmailConfirmed = true,
            //    BirthDay = DateTime.Now,
            //    FullName = "Admin"

            //};

            //manager.Create(user, "a123456");

            //if (!roleManager.Roles.Any())
            //{
            //    roleManager.Create(new IdentityRole { Name = "Admin" });
            //    roleManager.Create(new IdentityRole { Name = "User" });
            //}

            //var adminUser = manager.FindByEmail("nhatsim.com@gmail.com");

            //manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }
    }
}
