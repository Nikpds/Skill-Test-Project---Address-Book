using AddressBook.Api.Models;
using AddressBook.Api.Views;

namespace AddressBook.Api.Services
{
    public static class DomainToViewMaps
    {
        public static UserView UserToView(this User user)
        {
            return new UserView()
            {
                Id = user.Id,
                Email = user.Email,
                AddressInfo = null,
                Firstname = user.Firstname,
                Lastname = user.Lastname
            };
        }

        public static User UserViewToUser(this UserView user, User original = null)
        {
            original = original ?? new User();
            original.Id = user.Id;
            original.Email = user.Email;
            original.AddressInfo = null;
            original.Firstname = user.Firstname;
            original.Lastname = user.Lastname;

            return original;
        }

    }
}
