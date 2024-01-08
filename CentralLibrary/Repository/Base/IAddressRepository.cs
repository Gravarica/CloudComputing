using CentralLibrary.Model;

namespace CentralLibrary.Repository.Base
{
    public interface IAddressRepository
    {
        List<Address> GetAll();
    }
}
