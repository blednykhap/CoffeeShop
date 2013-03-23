using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using Core;
using Core.Models;

namespace Core.Repositories
{
    public interface IBaseRepository<T> : IDisposable
    {
        T Get(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetList(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();

        bool Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }

    public class BaseRepository<T> : IBaseRepository<T> where T : Entity, new()
    {
        private CoffeeShopDBContext context;

        public BaseRepository(CoffeeShopDBContext context)
        {
            this.context = context;
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate).SingleOrDefault();
        }

        public IEnumerable<T> GetList(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>();
        }

        public bool Create(T entity)
        {
            context.Set<T>().Add(entity);
            return SaveChanges();
        }

        public bool Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            return SaveChanges();
        }

        public bool Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            return SaveChanges();
        }

        private bool SaveChanges()
        {
            try
            {
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }

    }
}
