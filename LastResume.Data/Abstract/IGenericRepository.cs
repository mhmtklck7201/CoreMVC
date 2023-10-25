using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastResume.Data.Abstract
{
    public interface IGenericRepository<T>
    {
        T getById(int id);
        List<T> getAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
