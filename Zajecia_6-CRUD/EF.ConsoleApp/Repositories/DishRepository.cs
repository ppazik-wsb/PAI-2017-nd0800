using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF.ConsoleApp.Models;

namespace EF.ConsoleApp.Repositories
{
    public class DishRepository : Repository<Dish>, IDishRepository
    {
        public List<Dish> GetByName(String name)
        {
            return DbSet.Where(a => a.DishName.Contains(name)).ToList();
        }

        public DishRepository(DbContext context) : base(context)
        {
        }
    }
}
