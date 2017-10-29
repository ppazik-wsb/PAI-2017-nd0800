namespace EF.ConsoleApp.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<EF.ConsoleApp.DataContexts.DefaultAppDbConnection>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EF.ConsoleApp.DataContexts.DefaultAppDbConnection context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var initialDishes = new List<Dish>
            {
                new Dish { DishId = 1, DishName = "Pierogi ruskie (rêcznie lepione)", Price = 18.0, CreatedBy = "init" },
                new Dish { DishId = 2, DishName = "Naleœnik ze szpinakiem w sosie serowym", Price = 24.50, CreatedBy = "init" },
                new Dish { DishId = 3, DishName = "Kotlet schabowy, frytki, surówki", Price = 19.99, CreatedBy = "init" },
                new Dish { DishId = 4, DishName = "Golonka pieczona w piwie i miodzie", CreatedBy = "init" }
            };

            initialDishes.ForEach(s => context.Dishes.AddOrUpdate( q => q.DishName, s ));

            context.SaveChanges();
        }
    }
}
