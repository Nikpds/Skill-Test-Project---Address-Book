using AddressBook.Api.Models;
using AddressBook.Api.Views;

namespace AddressBook.Api.Services
{
    public static class Validators
    {
        public static bool IsValid(this UserView u)
        {
            return !string.IsNullOrEmpty(u.Lastname) &&
                !string.IsNullOrEmpty(u.Email) &&
                !string.IsNullOrEmpty(u.Firstname);
        }

        public static bool IsValid(this AddressInfoView b)
        {
            return !string.IsNullOrEmpty(b.Address) &&
                !string.IsNullOrEmpty(b.Region) &&
                !string.IsNullOrEmpty(b.Town);
        }
    }
}
