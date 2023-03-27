using AutoMapper;
using HRServicesAPI.Dto;
using HRServicesAPI.Entities;
using HRServicesAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace HRServicesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet("employees")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<EmployeeDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            var employees = _employeeService.GetAll();
            List<EmployeeDto> employeeDtos = new List<EmployeeDto>();
            foreach (var employee in employees)
            {
                employeeDtos.Add(_mapper.Map<EmployeeDto>(employee));
            }

            return Ok(employeeDtos);
        }

        [HttpPost("create-employee")]
        public async Task<IActionResult> CreateEmployee([FromBody]EmployeeDto employee)
        {
            Console.WriteLine("input name ", employee.Name);
            var NewEmployee = await _employeeService.AddEmployee(employee);
            return Ok(NewEmployee);
        }


        [HttpGet("employee/employees")]
        public IActionResult GetAllEmployee(
            [FromQuery(Name = "s")] string s,
             [FromQuery(Name = "sort")] string sort,
              [FromQuery(Name = "page")] int page

            )
        {
            return Ok(_employeeService.Query(s,sort,page));
        }

    }
}
