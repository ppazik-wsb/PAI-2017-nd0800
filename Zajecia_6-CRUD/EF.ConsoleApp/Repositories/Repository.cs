using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.ConsoleApp.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbSet<T> DbSet { get; set; }

        protected DbContext Context;

        public Repository(DbContext context)
        {
            this.Context = context;
            DbSet = context.Set<T>();
        }

        public T Add(T entity)
        {
            return DbSet.Add(entity);
        }

        public T Delete(int id)
        {
            return DbSet.Remove(Get(id));
        }

        public T Get(int id)
        {
            return DbSet.Find(id);
        }

        public List<T> GetAll()
        {
            return DbSet.ToList();
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}
