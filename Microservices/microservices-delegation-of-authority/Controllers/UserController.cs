using AutoMapper;
using HRServicesAPI.Dto;
using HRServicesAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRServicesAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "HRServicesAPISpec")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("users")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UserRead>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            List<UserRead> userReads = new List<UserRead>();
            foreach (var user in users)
            {
                userReads.Add(_mapper.Map<UserRead>(user));
            }

            return Ok(userReads);
        }
    }
}
