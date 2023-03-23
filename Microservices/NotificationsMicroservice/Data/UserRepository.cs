using NotificationAPI.Entities;

namespace NotificationAPI.Data
{
    public interface IUserRepository
    {
        List<User> GetAll();

        public User GetByEmail(string email);

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

        public User GetByEmail(string email)
        {
            var user = _dbContext.Users.Where(u => u.Email.Equals(email)).FirstOrDefault();
            return user;
        }

    }
}
