using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF.ConsoleApp.DataContexts;
using EF.ConsoleApp.Models;

namespace EF.ConsoleApp.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private DefaultAppDbConnection context = new DefaultAppDbConnection();
        // private Repository<Dish> dishRepository;
        private DishRepository dishRepository;

        // public Repository<Dish> DishRepository
        public DishRepository DishRepository
        {
                    // return this.dishRepository ?? new Repository<Dish>(context);
            get { return dishRepository ?? (dishRepository = new DishRepository(context)); }
        }
        
        public void Save()
        {
            context.SaveChanges();
        }

        // Dispose Pattern - czasami warto użyć
        // zobacz: https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/dispose-pattern

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
