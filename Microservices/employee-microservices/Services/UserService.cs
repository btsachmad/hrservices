using HRServicesAPI.Data;
using HRServicesAPI.Entities;

namespace HRServicesAPI.Services
{
    public interface IUserService
    {
        List<User> GetAll();
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepository)
        {
            _userRepo = userRepository;
        }

        public List<User> GetAll()
        {
            return _userRepo.GetAll();
        }
    }
}
