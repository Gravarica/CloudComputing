using CentralLibrary.Model;
using CentralLibrary.Repository.Base;
using CentralLibrary.Settings;

namespace CentralLibrary.Repository
{
    public class AddressRepository : IAddressRepository
    {

        public LibraryDbContext Context { get; set; }

        public AddressRepository(LibraryDbContext context) 
        {
            Context = context;
        }
        public List<Address> GetAll()
        {
            return Context.Addresses.ToList();
        }
    }
}
