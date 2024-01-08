using AutoMapper;
using CentralLibrary.Dto;
using CentralLibrary.Exceptions;
using CentralLibrary.Model;
using CentralLibrary.Repository.Base;
using CentralLibrary.Service.Base;

namespace CentralLibrary.Service
{
    public class UserService : IUserService
    {
        public IUserRepository UserRepository { get; set; }
        public IMapper Mapper { get; set; }

        public UserService(IUserRepository repository, IMapper mapper) 
        {
            UserRepository = repository;
            Mapper = mapper;
        }

        public User Register(RegisterDTO dto)
        {
            if (CheckIfExists(dto.Jmbg)) return null;

            var newUser = Mapper.Map<User>(dto);

            newUser.Id = new Guid();

            UserRepository.InsertUser(newUser);

            return newUser;
        }

        public List<User> GetAll()
        {
            return UserRepository.GetAll();
        }

        public bool CheckIfExists(string jmbg)
        {
            return UserRepository.GetByJmbg(jmbg) != null;
        }

        public bool RentBook(Guid id)
        {
            var user = UserRepository.GetById(id)??throw new UserNotFoundException("Specified user doesn't exist");
            var response = user.RentBook();
            UserRepository.Save();
            return response;
        }

        public bool ReturnBook(Guid id)
        {
            var user = UserRepository.GetById(id)??throw new UserNotFoundException("Specified user doesn't exist");
            var response = user.ReturnBook();
            UserRepository.Save();
            return response;
        }
    }
}
