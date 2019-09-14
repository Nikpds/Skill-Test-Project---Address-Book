using AddressBook.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AddressBook.Api.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> Insert(T entity);

        Task<T> Update(T entity);

        Task<T> Get(string entityId);

        Task<bool> Delete(T entity);

        Task<IEnumerable<T>> GetAll();
    }
}
