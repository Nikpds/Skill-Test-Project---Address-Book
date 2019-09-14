using System;

namespace AddressBook.Api.Models
{
    public abstract class Entity
    {
        public string Id { get; set; }

        public DateTime Updated { get; set; }

        public DateTime Created { get; set; }

        public Entity()
        {
            Created = DateTime.UtcNow;
        }
    }
}
