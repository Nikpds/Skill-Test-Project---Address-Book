using AddressBook.Api.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace AddressBook.Api.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        T Insert(T entity);

        T Update(T entity);

        bool Delete(T entity);

        IQueryable<T> FindAll(params Expression<Func<T, object>>[] includes);

        IQueryable<T> Find(Expression<Func<T, bool>> expression);

    }
}
