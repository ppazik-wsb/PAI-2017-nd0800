using System.Collections.Generic;
using DemoApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DemoApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DemoApp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DemoApp.Models.ApplicationDbContext context)
        {
            const string testRoleName = "user";
            const string testUserName = "test@test.com";
            
            const string testAdminRoleName = "foodAdmin";
            const string testAdminUserName = "admin@test.com";

            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var roleUser = new IdentityRole() { Name = testRoleName };
                var roleAdmin = new IdentityRole() { Name = testAdminRoleName };

                manager.Create(roleUser);
                manager.Create(roleAdmin);

                context.SaveChanges();
            }

            var userToAdd = new ApplicationUser()
            {
                UserName = testUserName,
                Email = testUserName,
                EmailConfirmed = true
            };
            var adminToAdd = new ApplicationUser()
            {
                UserName = testAdminUserName,
                Email = testAdminUserName,
                EmailConfirmed = true
            };

            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);


                var currentUser = context.Users.SingleOrDefault(u => u.UserName == testUserName);
                if (currentUser != null)
                {
                    manager.Delete(currentUser);
                }

                manager.Create(userToAdd, "Test123!@#");

                
                var currentAdminUser = context.Users.SingleOrDefault(u => u.UserName == testAdminUserName);
                if (currentAdminUser != null)
                {
                    manager.Delete(currentAdminUser);
                }

                manager.Create(adminToAdd, "Test123!@#");

                context.SaveChanges();

                manager.AddToRole(userToAdd.Id, testRoleName);
                manager.AddToRole(adminToAdd.Id, testAdminRoleName);

                context.SaveChanges();
            }
          
            {
                context.Foods.AddOrUpdate(d => d.Name,
                    new Food() { Name = "Pierogi z kapust¹", Price = 13.99, Hot = Food.HotLevel.Mild },
                    new Food() { Name = "Pierogi z miêsem", Price = 19.99, Hot = Food.HotLevel.Hot, Type = Food.FoodType.FoodType },
                    new Food() { Name = "Barszcz", Price = 6.30, Hot = Food.HotLevel.ExtraHot, Type = Food.FoodType.Soup },
                    new Food() { Name = "Uszka", Price = 19.90, Hot = Food.HotLevel.Medium },
                    new Food() { Name = "Karp", Price = 25.00, Hot = Food.HotLevel.Mild, Type = Food.FoodType.Fish },
                    new Food() { Name = "Œledzik", Price = 2.99, Hot = Food.HotLevel.ExtraHot, Type = Food.FoodType.Fish }
                    );

                context.SaveChanges();
            }

            {
                context.Orders.AddOrUpdate(o => o.OrderId,
                    new Order() { ApplicationUserId = userToAdd.Id, OrderDate = DateTime.Now, OrderItems  =  new List<Food>(
                        context.Foods.Where(d => d.Name.Contains("Pierogi")).ToList()) },
                    new Order() { ApplicationUserId = userToAdd.Id, OrderDate = DateTime.Now.AddDays(-1), OrderItems  =  new List<Food>(
                        context.Foods.Where(d => d.Name.Contains("Uszka")).ToList()) },
                    new Order()
                    {
                        ApplicationUserId = userToAdd.Id,
                        OrderDate = DateTime.Now.AddDays(-4),
                        OrderItems = new List<Food>(
                            context.Foods.Where(d => d.Name.Contains("Barszcz")).ToList())
                    },
                    new Order()
                    {
                        ApplicationUserId = userToAdd.Id,
                        OrderDate = DateTime.Now.AddDays(-8),
                        OrderItems = new List<Food>(
                            context.Foods.Where(d => d.Name.Contains("Karp")).ToList())
                    }
                    );
            }
        }
    }
}
