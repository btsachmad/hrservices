using NotificationAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace NotificationAPI.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<Employee> Employees { get; set; }
    }
}
