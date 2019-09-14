using AddressBook.Api.Models;
using AddressBook.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Api.DataContext
{
    public interface ISqlExpressContext
    {
        IRepository<User> Users { get; }

        IRepository<AddressInfo> AddressInfo { get; }
    }
}
