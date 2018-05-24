using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace MVC.DAL.DAL
{
    public interface IBaseRepository<T, U>
    {
        bool Add(T entity);
        bool Update(T entity);
        bool Remove(T entity);
        T Get(U id);
        List<T> GetList();
        int Count();
    }
}
