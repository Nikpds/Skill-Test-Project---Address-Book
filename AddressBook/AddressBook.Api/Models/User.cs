namespace AddressBook.Api.Models
{
    public class User : Entity
    {
        public string Lastname { get; set; }

        public string Firstname { get; set; }

        public string Email { get; set; }

        public virtual AddressInfo AddressInfo { get; set; }
    }
}
