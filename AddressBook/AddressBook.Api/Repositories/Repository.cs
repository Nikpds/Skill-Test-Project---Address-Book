using AddressBook.Api.DataContext;
using AddressBook.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace AddressBook.Api.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private SqlExpressContext _ctx;

        public Repository(SqlExpressContext ctx)
        {
            _ctx = ctx;
        }

        public bool Delete(T entity)
        {
            if (entity == null) { return false; }

            _ctx.Remove(entity);

            _ctx.SaveChanges();

            return true;
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _ctx.Set<T>().Where(expression).AsNoTracking();
        }

        public IQueryable<T> FindAll(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query;

            if (includes != null)
            {
                query = includes.Aggregate(_ctx.Set<T>().AsNoTracking(),
                  (current, include) => current.Include(include));
            }
            else
            {
                query = _ctx.Set<T>().AsNoTracking();
            }


            return query;
        }

        public T Insert(T entity)
        {
            _ctx.Set<T>().Add(entity);

            _ctx.SaveChanges();

            return entity;
        }

        public T Update(T entity)
        {
            _ctx.Set<T>().Update(entity);

            _ctx.SaveChanges();

            return entity;
        }
    }
}
