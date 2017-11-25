using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.ConsoleApp.Repositories
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T Get(int id);
        T Delete(int id);
        T Add(T entity);

        void SaveChanges();
    }
}
