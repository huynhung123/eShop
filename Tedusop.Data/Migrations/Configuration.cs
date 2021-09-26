﻿namespace Tedusop.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Tedusop.Model.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Tedusop.Data.TeduShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Tedusop.Data.TeduShopDbContext context)
        {
        //    var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new TeduShopDbContext()));

        //    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new TeduShopDbContext()));

        //    var user = new ApplicationUser()
        //    {
        //        UserName = "tedu",
        //        Email = "tedu.international@gmail.com",
        //        EmailConfirmed = true,
        //        BirthDay = DateTime.Now,
        //        FullName = "Technology Education"

        //    };

        //    manager.Create(user, "123654$");

        //    if (!roleManager.Roles.Any())
        //    {
        //        roleManager.Create(new IdentityRole { Name = "Admin" });
        //        roleManager.Create(new IdentityRole { Name = "User" });
        //    }

        //    var adminUser = manager.FindByEmail("tedu.international@gmail.com");

        //    manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }
    }
}
