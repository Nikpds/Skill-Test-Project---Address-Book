using AddressBook.Api.Models;
using AddressBook.Api.Views;
using System.Linq;

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
                Addresses = user.Addresses.Select(addr => AddressToView(addr)).ToList(),
                Firstname = user.Firstname,
                Lastname = user.Lastname
            };
        }

        public static User UserViewToDomain(this UserView user)
        {
            User domain = new User();
            domain.Id = user.Id;
            domain.Email = user.Email;
            domain.Addresses = user.Addresses.Select(addr => AddressInfoViewToDomain(addr)).ToList();
            domain.Firstname = user.Firstname;
            domain.Lastname = user.Lastname;

            return domain;
        }

        public static AddressInfoView AddressToView(this AddressInfo add)
        {
            return new AddressInfoView()
            {
                Id = add.Id,
                Address = add.Address,
                Lat = add.Lat,
                Lon = add.Lon,
                UserId = add.UserId
            };
        }

        public static AddressInfo AddressInfoViewToDomain(this AddressInfoView add)
        {
            AddressInfo domain = new AddressInfo();
            domain.Id = add.Id;
            domain.Address = add.Address;
            domain.Lat = add.Lat;
            domain.Lon = add.Lon;
            domain.UserId = add.UserId;

            return domain;
        }

    }
}
