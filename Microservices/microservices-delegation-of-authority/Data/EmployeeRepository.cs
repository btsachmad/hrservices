using HRServicesAPI.Dto;
using HRServicesAPI.Entities;

namespace HRServicesAPI.Data
{

    public interface IEmployeeRepository
    {
        List<Employee> GetAll();
        Task<Employee> AddEmployee(EmployeeDto employee);
        Object Query(string s, string sort, int? queryPage);
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

        public async Task<Employee> AddEmployee(EmployeeDto employee)
        {
            var Newemployee = new Employee()
            {
                NIK= employee.NIK,
                Name = employee.Name,
                Gender = employee.Gender,
                StartWork = employee.StartWork,
                LengthOfWork = employee.LengthOfWork.ToString(),
                PositionID = new Guid(employee.PositionID),
             };
           
            
           _dbContext.Employees.Add(Newemployee);
            await _dbContext.SaveChangesAsync();
            return Newemployee;

        }

        public Object Query(string s, string sort, int? queryPage)
        {
            var query = (from emp in _dbContext.Employees select emp);
            if (!string.IsNullOrEmpty(s))
            {
                query = query.Where(emp => emp.Name.Contains(s));
            }

            if (sort == "asc")
            {
                query = query.OrderBy(emp => emp.CreatedAt);
            }
            else if( sort == "desc")
            {
                query = query.OrderByDescending(emp => emp.CreatedAt);
            }

            int perPage = 5;
            int page = queryPage.GetValueOrDefault(1) == 0 ? 1 : queryPage.GetValueOrDefault(1);

            return new
            {
                data = query.Take(perPage).Skip((page - 1) * perPage),
            };
        }
    }

}
