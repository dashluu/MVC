using MVC.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace MVC.DAL.DAL
{
    public abstract class BaseRepository<T, C, U> : IBaseRepository<T, U>
        where T : class
        where C : DbContext, new()
    {
        protected C context;

        public BaseRepository()
        {
            context = new C();
        }

        public bool Add(T entity)
        {
            try
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int Count()
        {
            try
            {
                int listCount = context.Set<T>().Count();
                return listCount;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<T> GetList()
        {
            try
            {
                List<T> blogEntityList = context.Set<T>().ToList();
                return blogEntityList;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public abstract T Get(U id);

        public bool Remove(T entity)
        {
            try
            {
                context.Set<T>().Remove(entity);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(T entity)
        {
            try
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
