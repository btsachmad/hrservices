using NotificationAPI.Data;
using NotificationAPI.Entities;

namespace NotificationAPI.Services
{
    public interface INotificationService
    {
        List<Notification> GetAll();

        List<Notification> GetAllByNIK(string nik);

        Notification GetNotificationDetail(Guid id);
    }
    public class NotificationService
    {
        private readonly INotificationRepository _notificationRepo;

        private readonly IEmployeeRepository _employeeRepository;

        public NotificationService(INotificationRepository notificationRepository, IEmployeeRepository employeeRepository)
        {
            _notificationRepo = notificationRepository;
            _employeeRepository = employeeRepository;
        }

        public List<Notification> GetAll()
        {
            return _notificationRepo.GetAll();
        }

        public List<Notification> GetAllByNIK(string nik)
        {
            var employee = _employeeRepository.GetAllByNIK(nik);
            return _notificationRepo.GetAllByEmployeeId(employee.Id);
        }

        public Notification GetNotificationDetail(Guid id)
        {
            return _notificationRepo.GetById(id);
        }
    }
}
