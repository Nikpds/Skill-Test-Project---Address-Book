using AddressBook.Api.Models;
using AddressBook.Api.Repositories;
using AddressBook.Api.Views;
using System.Linq;

namespace AddressBook.Api.Services
{

    public interface IAddressInfoService
    {
        AddressInfoView AddAddressBook(AddressInfoView address);

        bool DeleteAddressBook(string id);
    }

    public class AddressInfoService : IAddressInfoService
    {
        private readonly IRepository<AddressInfo> _repo;

        public AddressInfoService(IRepository<AddressInfo> repo)
        {
            _repo = repo;
        }

        public AddressInfoView AddAddressBook(AddressInfoView address)
        {
            AddressInfo domainAddress = DomainToViewMaps.AddressInfoViewToDomain(address);

            domainAddress = _repo.Insert(domainAddress);

            address = DomainToViewMaps.AddressToView(domainAddress);

            return address;
        }

        public bool DeleteAddressBook(string id)
        {
            var entity = _repo.Find(x => x.Id == id).SingleOrDefault();

            bool isDeleted = _repo.Delete(entity);

            return isDeleted;
        }
    }
}
