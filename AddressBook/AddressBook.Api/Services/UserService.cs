using AddressBook.Api.Models;
using AddressBook.Api.Repositories;
using AddressBook.Api.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressBook.Api.Services
{

    public interface IUserService
    {
        UserView AddUser(UserView user);

        UserView UpdateUser(UserView user);

        bool DeleteUser(string userId);

        IEnumerable<UserView> GetUsers();
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
            User domainUser = DomainToViewMaps.UserViewToDomain(user);

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

        public IEnumerable<UserView> GetUsers()
        {
            var users = _repo.FindAll(i => i.Addresses).ToList();

            var usersView = from user in users
                            select DomainToViewMaps.UserToView(user);

            return usersView;
        }

        public UserView UpdateUser(UserView user)
        {
            throw new NotImplementedException();
        }
    }
}
