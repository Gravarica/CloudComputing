using CentralLibrary.Dto;
using CentralLibrary.Model;

namespace CentralLibrary.Service.Base
{
    public interface IUserService
    {
        public User Register(RegisterDTO dto);

        public List<User> GetAll();

        public bool CheckIfExists(string jmbg);

        public bool RentBook(Guid id);

        public bool ReturnBook(Guid id);
    }
}
