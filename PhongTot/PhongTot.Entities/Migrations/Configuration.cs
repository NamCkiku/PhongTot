namespace PhongTot.Entities.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PhongTot.Entities.Models.RoomsEntity>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PhongTot.Entities.Models.RoomsEntity context)
        {
            CreateUser(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
        private void CreateUser(RoomsEntity context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new RoomsEntity()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new RoomsEntity()));

            var user = new ApplicationUser()
            {
                UserName = "admin",
                Email = "tranhoangnam11373@gmail.com",
                EmailConfirmed = true,
                BirthDay = DateTime.Now,
                FullName = "Trần Hoàng Nam"

            };

            manager.Create(user, "admin123");

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var adminUser = manager.FindByEmail("tranhoangnam11373@gmail.com");

            manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }
    }
}
