using HRServicesAPI.Data;
using HRServicesAPI.Dto;
using HRServicesAPI.Entities;

namespace HRServicesAPI.Services
{

    public interface IEmployeeService
    {
        List<Employee> GetAll();
        Task<Employee> AddEmployee(EmployeeDto employee);
        Object Query(string s,string sort,int page);
    }
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public List<Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }

        public Task<Employee> AddEmployee(EmployeeDto employee)
        {
            return _employeeRepository.AddEmployee(employee);
        }


        public Object Query(string s, string sort, int page)
        {
            return _employeeRepository.Query(s,sort,page);
        }
    }
}
