namespace Tedusop.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
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
            CreatSlide(context);
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
        private void CreatSlide(TeduShopDbContext context)
        {
            if (context.Slides.Count() == 0)
            {
                List<Slide> slide = new List<Slide>()
                {
                new Slide(){
                    Name="silde1",
                    DisplayOrder=1,
                    Status=true,
                    Url="#",
                    Image="/Assets/Client/images/bag.jpg",
                    Content=@"<h2>FLAT 50% 0FF</h2>
                                <label>FOR ALL PURCHASE <b>VALUE</b></label>
                                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et </ p >
                                < span class=""on-get"">GET NOW</span>"},
                 new Slide(){
                    Name="silde2",
                    DisplayOrder=2,
                    Status=true,
                    Url="#",
                    Image="/Assets/Client/images/bag.jpg",
                    Content=@"<h2>FLAT 50% 0FF</h2>
                                <label>FOR ALL PURCHASE <b>VALUE</b></label>
                                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et </p>
                                <span class=""on-get"">GET NOW</span>"},
                  new Slide(){
                    Name="silde3",
                    DisplayOrder=3,
                    Status=true,
                    Url="#",
                    Image="/Assets/Client/images/bag.jpg",
                    Content=@" <h2>FLAT 50% 0FF</h2>
                                <label>FOR ALL PURCHASE <b>VALUE</b></label>
                                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et </p>
                                <span class=""on-get"">GET NOW</span>"},
                };
                context.Slides.AddRange(slide);
                context.SaveChanges();
            }
        }
    }
}
