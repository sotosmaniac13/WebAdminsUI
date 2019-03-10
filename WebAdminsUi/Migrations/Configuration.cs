namespace WebAdminsUi.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebAdminsUi.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebAdminsUi.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "WebAdminsUi.Models.ApplicationDbContext";
        }

        protected override void Seed(WebAdminsUi.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            if (!context.Roles.Any(r => r.Name == "SimpleUser"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Id = "0", Name = "SimpleUser" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Manager"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Id = "1", Name = "Manager" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Analyst"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Id = "2", Name = "Analyst" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Architect"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Id = "3", Name = "Architect" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Programmer"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Id = "4", Name = "Programmer" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Tester"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Id = "5", Name = "Tester" };

                manager.Create(role);
            }


            if (!context.Users.Any(u => u.UserName == "manager"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "manager", Status = UserStatus.Active };

                manager.Create(user, "Manager1@");
                manager.AddToRole(user.Id, "Manager");
            }
        }
    }
}
