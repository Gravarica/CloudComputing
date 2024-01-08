using CentralLibrary.Model;

namespace CentralLibrary.Repository.Base
{
    public interface IUserRepository
    {
        List<User> GetAll();

        void InsertUser(User user);

        User GetByJmbg(string jmbg);

        User GetById(Guid id);

        void Save();
    }
}
