namespace AddressBook.Api.Models
{
    public class AddressInfo : Entity
    {
        public string Address { get; set; }

        public string Town { get; set; }

        public string Region { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
