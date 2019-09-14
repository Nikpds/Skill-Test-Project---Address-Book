using AddressBook.Api.DataContext;
using AddressBook.Api.Repositories;
using AddressBook.Api.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Api.Services
{

    public interface IUserService
    {
        Task<UserView> AddUser(UserView user);

        Task<UserView> UpdateUser(UserView user);

        Task<bool> DeleteUser(string userId);

        Task<IEnumerable<UserView>> GetUsers();

        Task<UserView> GetUser(string id);
    }

    public class UserService : IUserService
    {
        private readonly ISqlExpressContext _ctx;

        public UserService(ISqlExpressContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<UserView> AddUser(UserView user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteUser(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<UserView> GetUser(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserView>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<UserView> UpdateUser(UserView user)
        {
            throw new NotImplementedException();
        }
    }
}
