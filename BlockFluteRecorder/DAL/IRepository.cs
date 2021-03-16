using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockFluteRecorder.DAL
{
    interface IRepository<T> : IDisposable
        where T : class
    {
        IEnumerable<T> FindAll();
        T FindById(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Save();
    }
}
