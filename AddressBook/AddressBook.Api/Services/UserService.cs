using AddressBook.Api.DataContext;
using AddressBook.Api.Models;
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
        UserView AddUser(UserView user);

        UserView UpdateUser(UserView user);

        bool DeleteUser(string userId);

        IEnumerable<UserView> GetUsers();

        UserView GetUser(string id);
    }

    public class UserService : IUserService
    {
        private readonly IRepository<User> _repo;

        public UserService(IRepository<User> repo)
        {
            _repo = repo;
        }

        public UserView AddUser(UserView user)
        {
            User domainUser = DomainToViewMaps.UserViewToUser(user);

            domainUser = _repo.Insert(domainUser);

            user = DomainToViewMaps.UserToView(domainUser);

            return user;
        }

        public bool DeleteUser(string userId)
        {
            var entity = _repo.Find(x => x.Id == userId).SingleOrDefault();

            bool isDeleted = _repo.Delete(entity);

            return isDeleted;
        }

        public UserView GetUser(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserView> GetUsers()
        {
            throw new NotImplementedException();
        }

        public UserView UpdateUser(UserView user)
        {
            throw new NotImplementedException();
        }
    }
}
