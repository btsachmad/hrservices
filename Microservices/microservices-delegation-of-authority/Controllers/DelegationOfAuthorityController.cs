using AutoMapper;
using HRServicesAPI.Dto;
using HRServicesAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HRServicesAPI.Controllers
{
    [Route("api/delegation-of-authority")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "HRServicesAPISpec")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class DelegationOfAuthorityController : ControllerBase
    {
        private readonly IDelegationOfAuthorityService _delegationOfAuthorityService;

        public DelegationOfAuthorityController(IDelegationOfAuthorityService delegationOfAuthorityService)
        {
             _delegationOfAuthorityService = delegationOfAuthorityService;
        }

        [HttpGet("get-all/delegationOfAuthorities")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<DelegationOfAuthorityDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAllDelegationOfAuthorities()
        {
            var delegationOfAuthorities = _delegationOfAuthorityService.GetAllDelegationOfAuthority();

            return Ok(delegationOfAuthorities);
        }
        
        [HttpPost("create/delegation-of-authority")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DelegationOfAuthorityDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateDelegationOfAuthoritiy([FromBody]DelegationOfAuthorityDto delegationOfAuthority)
        {
            var result = _delegationOfAuthorityService.CreateDelegationOfAuthority(delegationOfAuthority);
            return Ok(result);
        }

        [HttpGet("get/delegation-of-authority/{nik}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<DelegationOfAuthorityDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetDelegationOfAuthorityByNik(string nik)
        {
            var result = _delegationOfAuthorityService.GetDelegationOfAuthorityByNik(nik);
            return Ok(result);
        }

        [HttpPut("update/delegation-of-authority")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DelegationOfAuthorityDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateDelegationOfAuthority([FromBody] DelegationOfAuthorityDto delegationOfAuthority)
        {
            var result = _delegationOfAuthorityService.UpdateDelegationOfAuthority(delegationOfAuthority);
            return Ok(result);
        }
    }
}
