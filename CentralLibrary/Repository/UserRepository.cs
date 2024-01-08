using CentralLibrary.Model;
using CentralLibrary.Repository.Base;
using CentralLibrary.Settings;
using Microsoft.EntityFrameworkCore;

namespace CentralLibrary.Repository
{
    public class UserRepository : IUserRepository
    {
        public LibraryDbContext Context { get; set; }

        public UserRepository(LibraryDbContext context) 
        {
            Context = context;    
        }

        public List<User> GetAll()
        {
            return Context.Users.Include(u => u.Address).ToList();
        }

        public void InsertUser(User user)
        {
            Context.Users.Add(user);
            Context.SaveChanges();
        }

        public User GetByJmbg(string jmbg)
        {
            return Context.Users.Include(x => x.Address).Where(x => x.JMBG == jmbg).SingleOrDefault();
        }

        public User GetById(Guid id)
        {
            return Context.Users.Include(x => x.Address).Where(x => x.Id == id).SingleOrDefault();
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
