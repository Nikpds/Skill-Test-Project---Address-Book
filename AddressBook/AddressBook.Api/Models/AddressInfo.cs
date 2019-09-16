namespace AddressBook.Api.Models
{
    public class AddressInfo : Entity
    {
        public string Address { get; set; }

        public double Lat { get; set; }

        public double Lon { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
