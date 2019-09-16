using System.Collections.Generic;

namespace AddressBook.Api.Models
{
    public class User : Entity
    {
        public string Lastname { get; set; }

        public string Firstname { get; set; }

        public string Email { get; set; }

        public virtual IEnumerable<AddressInfo> Addresses { get; set; }

        public User()
        {
            Addresses = new HashSet<AddressInfo>();
        }
    }
}
