using EF.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.ConsoleApp.DataContexts
{
    class DefaultAppDbConnection : DbContext
    {
        public DefaultAppDbConnection() : base("EFConsoleAppDbConnection")
        {

        }

        public DbSet<Dish> Dishes { get; set; }
    }
}
