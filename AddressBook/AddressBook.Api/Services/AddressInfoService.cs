using AddressBook.Api.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Api.Services
{

    public interface IAddressInfoService
    {
        Task<AddressInfoView> AddAddressBook(AddressInfoView address);

        Task<bool> DeleteAddressBook(string id);
    }

    public class AddressInfoService : IAddressInfoService
    {
        public async Task<AddressInfoView> AddAddressBook(AddressInfoView address)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAddressBook(string id)
        {
            throw new NotImplementedException();
        }
    }
}
