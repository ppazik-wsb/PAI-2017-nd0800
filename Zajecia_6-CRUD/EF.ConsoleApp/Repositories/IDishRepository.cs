using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF.ConsoleApp.Models;

namespace EF.ConsoleApp.Repositories
{
    public interface IDishRepository : IRepository<Dish>
    {
        List<Dish> GetByName(String name);
    }
}
