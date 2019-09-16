using System.Collections.Generic;

namespace AddressBook.Api.Views
{
    public class UserView
    {
        public string Id { get; set; }

        public string Lastname { get; set; }

        public string Firstname { get; set; }

        public string Email { get; set; }

        public IEnumerable<AddressInfoView> Addresses { get; set; }

        public UserView()
        {
            Addresses = new HashSet<AddressInfoView>();
        }
    }
}
