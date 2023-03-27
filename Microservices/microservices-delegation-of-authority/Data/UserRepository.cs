using HRServicesAPI.Entities;

namespace HRServicesAPI.Data
{
    public interface IUserRepository
    {
        List<User> GetAll();
       
    }

    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _dbContext;

        public UserRepository(DatabaseContext databaseContext)
        {
            _dbContext = databaseContext;
        }

        public List<User> GetAll()
        {
            var users = _dbContext.Users.ToList();
            return users;
        }

      

    }
}
