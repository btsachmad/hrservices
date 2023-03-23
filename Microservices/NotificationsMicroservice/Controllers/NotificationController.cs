using AutoMapper;
using NotificationAPI.Dto;
using NotificationAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NotificationAPI.Controllers
{
    [Route("api/notification")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Notification")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public NotificationController(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<NotificationDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            var notifications = _notificationService.GetAll();
            List<NotificationDto> notificationDtos = new List<NotificationDto>();
            foreach (var notification in notifications)
            {
                notificationDtos.Add(_mapper.Map<NotificationDto>(notification));
            }

            return Ok(notificationDtos);
        }

        [HttpGet("{nik}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<NotificationDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAllByEmail(string nik)
        {
            var notificationsByNik = _notificationService.GetAllByNIK(nik);
            List<NotificationDto> notificationDtos = new List<NotificationDto>();
            foreach (var notification in notificationsByNik)
            {
                notificationDtos.Add(_mapper.Map<NotificationDto>(notification));
            }

            return Ok(notificationDtos);
        }

        [HttpGet("detail/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NotificationDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public NotificationDto GetDetail(Guid id)
        {
            var notificationDetail = _notificationService.GetNotificationDetail(id);
            return _mapper.Map<NotificationDto>(notificationDetail);
        }
    }
}
