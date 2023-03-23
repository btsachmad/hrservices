using AutoMapper;
using NotificationAPI.Dto;
using NotificationAPI.Entities;

namespace NotificationAPI.Mapper
{
    public class AppMapper : Profile
    {
        public AppMapper()
        {
            CreateMap<Notification, NotificationDto>().ReverseMap();
        }
    }
}
