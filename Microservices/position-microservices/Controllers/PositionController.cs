using AutoMapper;
using HRServicesAPI.Dto;
using HRServicesAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HRServicesAPI.Controllers
{
    [Route("api/position")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "HRServicesAPISpec")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class PositionController : ControllerBase
    {
        private readonly IPositionService _positionService;
        private readonly IMapper _mapper;

        public PositionController(IPositionService positionService, IMapper mapper)
        {
            _positionService = positionService;
            _mapper = mapper;
        }

        [HttpGet("positions")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PositionRead>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            var positions = _positionService.GetAll();
            List<PositionRead> positionReads = new List<PositionRead>();
            foreach (var position in positions)
            {
                positionReads.Add(_mapper.Map<PositionRead>(position));
            }

            return Ok(positionReads);
        }

        [HttpGet("positions/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PositionRead))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDetail(Guid id)
        {
            var position = await _positionService.GetDetail(id);
            PositionRead positionReads = new PositionRead();
            var result = _mapper.Map<PositionRead>(position);

            return Ok(result);
        }

        [HttpGet("positions/activate/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PositionRead))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Activate(Guid id)
        {
            var position = await _positionService.Activate(id);
            PositionRead positionReads = new PositionRead();
            var result = _mapper.Map<PositionRead>(position);

            return Ok(result);
        }

        [HttpGet("positions/deactivate/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PositionRead))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Deactivate(Guid id)
        {
            var position = await _positionService.Deactivate(id);
            PositionRead positionReads = new PositionRead();
            var result = _mapper.Map<PositionRead>(position);

            return Ok(result);
        }

        [HttpPost("positions")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PositionRead))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Add(PositionRequest request)
        {
            var position = await _positionService.Add(request);
            var result = new PositionRead();

            if (position != null)
            {
                PositionRead positionReads = new PositionRead();
                result = _mapper.Map<PositionRead>(position);
            }

            return Ok(result);
        }

        [HttpPut("positions/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PositionRead))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(Guid id, PositionRequest request)
        {
            var position = await _positionService.Update(id, request);
            var result = new PositionRead();

            if (position != null)
            {
                PositionRead positionReads = new PositionRead();
                result = _mapper.Map<PositionRead>(position);
            }

            return Ok(result);
        }
    }
}
