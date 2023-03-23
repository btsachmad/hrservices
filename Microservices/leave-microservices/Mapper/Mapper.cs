using AutoMapper;
using HRServicesAPI.Dto;
using HRServicesAPI.Entities;

namespace HRServicesAPI.Mapper
{
    public class AppMapper : Profile
    {
        public AppMapper()
        {
            CreateMap<Leave, LeaveRead>().ReverseMap();
            CreateMap<Leave, LeaveCreate>().ReverseMap();
            CreateMap<Leave, LeaveApprove>().ReverseMap();
            CreateMap<Leave, LeaveReject>().ReverseMap();
        }
    }
}
