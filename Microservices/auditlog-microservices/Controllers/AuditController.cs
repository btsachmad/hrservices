using AutoMapper;
using HRServicesAPI.Dto;
using HRServicesAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HRServicesAPI.Controllers
{
    [Route("api/audit")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "HRServicesAPISpec")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class AuditController : ControllerBase
    {
        private readonly IAuditService _auditService;
        private readonly IMapper _mapper;

        public AuditController(IAuditService auditService, IMapper mapper)
        {
            _auditService = auditService;
            _mapper = mapper;
        }

        [HttpGet("audits")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AuditRead>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAll([FromQuery] QueryParams query)
        {
            var audits = _auditService.GetAll(query);
            List<AuditRead> auditReads = new List<AuditRead>();
            foreach (var audit in audits)
            {
                auditReads.Add(_mapper.Map<AuditRead>(audit));
            }

            return Ok(auditReads);
        }

        [HttpPost("audits")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuditRead))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Add(AuditRequest request)
        {
            var audit = await _auditService.Add(request);
            var result = new AuditRead();

            if (audit != null)
            {
                AuditRead auditReads = new AuditRead();
                result = _mapper.Map<AuditRead>(audit);
            }

            return Ok(result);
        }
    }
}
