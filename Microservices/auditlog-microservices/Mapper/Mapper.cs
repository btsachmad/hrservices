﻿using AutoMapper;
using HRServicesAPI.Dto;
using HRServicesAPI.Entities;

namespace HRServicesAPI.Mapper
{
    public class AppMapper : Profile
    {
        public AppMapper()
        {
            CreateMap<User, UserRead>().ReverseMap();

            CreateMap<Audit, AuditRead>().ReverseMap();
            CreateMap<Audit, AuditRequest>().ReverseMap();
        }
    }
}
