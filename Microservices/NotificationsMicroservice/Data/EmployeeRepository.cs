using NotificationAPI.Entities;

namespace NotificationAPI.Data
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAll();

        Employee GetAllByNIK(string nik);
    }
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DatabaseContext _dbContext;

        public EmployeeRepository(DatabaseContext databaseContext)
        {
            _dbContext = databaseContext;
        }

        public List<Employee> GetAll()
        {
            var employees = _dbContext.Employees.ToList();
            return employees;
        }

        public Employee GetAllByNIK(string nik)
        {
            var employees = _dbContext.Employees.Where(e => e.NIK.Equals(nik)).FirstOrDefault();
            return employees;
        }
    }
}
