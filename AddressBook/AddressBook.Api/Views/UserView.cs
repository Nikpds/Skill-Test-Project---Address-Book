namespace AddressBook.Api.Views
{
    public class UserView
    {
        public string Id { get; set; }

        public string Lastname { get; set; }

        public string Firstname { get; set; }

        public string Email { get; set; }

        public AddressInfoView AddressInfo { get; set; }
    }
}
