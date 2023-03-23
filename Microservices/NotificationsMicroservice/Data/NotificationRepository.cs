using NotificationAPI.Entities;

namespace NotificationAPI.Data
{
    public interface INotificationRepository
    {
        List<Notification> GetAll();

        List<Notification> GetAllByEmployeeId(Guid employeeId);

        Notification GetById(Guid id);
    }
    public class NotificationRepository : INotificationRepository
    {
        private readonly DatabaseContext _dbContext;

        public NotificationRepository(DatabaseContext databaseContext)
        {
            _dbContext = databaseContext;
        }

        public List<Notification> GetAll()
        {
            var notifications = _dbContext.Notifications.ToList();
            return notifications;
        }

        public List<Notification> GetAllByEmployeeId(Guid employeeId)
        {
            var notifications = _dbContext.Notifications.Where(n => n.EmplayeeId.Equals(employeeId)).ToList();
            return notifications;
        }

        public Notification GetById(Guid id)
        {
            var notification = _dbContext.Notifications.Where(n => n.Id.Equals(id)).FirstOrDefault();
            return notification;
        }
    }
}
