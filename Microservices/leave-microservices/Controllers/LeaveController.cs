using AutoMapper;
using HRServicesAPI.Dto;
using HRServicesAPI.Entities;
using HRServicesAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRServicesAPI.Controllers
{
    [Route("api/leaves")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "HRServicesAPISpec")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class LeaveController : ControllerBase
    {
        private readonly ILeaveService _leaveService;
        private readonly IMapper _mapper;

        public LeaveController(ILeaveService leaveService, IMapper mapper)
        {
            _leaveService = leaveService;
            _mapper = mapper;
        }

        [HttpGet("leaves/list/employees")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<LeaveRead>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetListByNik(
            [FromQuery(Name = "nik")] string nik,
            [FromQuery(Name = "search")] string? search = null,
            [FromQuery(Name = "page")] int? page = 1,
            [FromQuery(Name = "pageSize")] int? pageSize = 10
        )
        {
            // TODO: Get employee by nik from employee service
            Guid employee = new Guid();

            var result = await _leaveService.GetListByNik(employee, search, page, pageSize);

            return Ok(result);
        }

        [HttpGet("leaves/list/reviewer")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<LeaveRead>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetListByLevel(
            [FromQuery(Name = "level")] int level,
            [FromQuery(Name = "search")] string? search = null,
            [FromQuery(Name = "page")] int? page = 1,
            [FromQuery(Name = "pageSize")] int? pageSize = 10
        )
        {
            var result = await _leaveService.GetListByReviewer(level, search, page, pageSize);

            return Ok(result);
        }

        [HttpPost("leaves")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Leave))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(LeaveCreate body)
        {
            var leave = await _leaveService.Create(body);
            var result = new LeaveRead();

            if (leave != null)
            {
                LeaveRead leaveRead = new LeaveRead();
                result = _mapper.Map<LeaveRead>(leave);
            }

            return Ok(result);
        }

        [HttpPost("leaves/approve")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Leave))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Approve(LeaveApprove body)
        {
            var leave = await _leaveService.Approve(body);
            var result = new LeaveRead();

            if (leave != null)
            {
                LeaveRead leaveRead = new LeaveRead();
                result = _mapper.Map<LeaveRead>(leave);
            }

            return Ok(result);
        }
        
        [HttpPost("leaves/reject")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Leave))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Reject(LeaveReject body)
        {
            var leave = await _leaveService.Reject(body);
            var result = new LeaveRead();

            if (leave != null)
            {
                LeaveRead leaveRead = new LeaveRead();
                result = _mapper.Map<LeaveRead>(leave);
            }

            return Ok(result);
        }
    }
}
