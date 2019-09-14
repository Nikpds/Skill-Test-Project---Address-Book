using AddressBook.Api.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Api.Services
{

    public interface IAddressInfoService
    {
        AddressInfoView AddAddressBook(AddressInfoView address);

        bool DeleteAddressBook(string id);
    }

    public class AddressInfoService : IAddressInfoService
    {
        public AddressInfoView AddAddressBook(AddressInfoView address)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAddressBook(string id)
        {
            throw new NotImplementedException();
        }
    }
}
