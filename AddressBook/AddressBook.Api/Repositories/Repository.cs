using AddressBook.Api.DataContext;
using AddressBook.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Api.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly SqlExpressContext _ctx;

        public Repository(SqlExpressContext ctx)
        {
            _ctx = ctx;
        }

        public Task<bool> Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> Get(string entityId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
