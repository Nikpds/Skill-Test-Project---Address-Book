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

        public static bool IsValid(this AddressInfoView addr)
        {
            return !string.IsNullOrEmpty(addr.Address) &&
                CheckLatitue(addr.Lat) && CheckLongtitude(addr.Lon);
        }

        private static bool CheckLatitue(double value)
        {
            if (value < -90 || value > 90)
            {
                return false;
            }
            return true;
        }

        private static bool CheckLongtitude(double value)
        {
            if (value < -90 || value > 90)
            {
                return false;
            }
            return true;
        }
    }


}
