using AutoMapper;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Dto
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Casher, CasherDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ApplicationUser.Id))
                .ForMember(dest => dest.FrindlyName, opt => opt.MapFrom(src => src.ApplicationUser.FriendlyName))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department.Name))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Salary, opt => opt.MapFrom(src => src.Salary + " E.G"));
        }
    }
}
