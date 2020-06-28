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

            CreateMap<CreateCasherDto, Casher>()
                .ForMember(dest => dest.Department, obj => obj.MapFrom(src => src.Department))
                .ForPath(dest => dest.Department.Id, obj => obj.MapFrom(src => src.Department.Id))
                .ForMember(dest => dest.Name, obj => obj.MapFrom(src => src.Name))
                .ForMember(dest => dest.Address, obj => obj.MapFrom(src => src.Address))
                .ForMember(dest => dest.Phone, obj => obj.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Salary, obj => obj.MapFrom(src => src.Salary))
                .ForMember(dest => dest.HiredDate, obj => obj.MapFrom(src => src.HiredDate))
                .ReverseMap();

            CreateMap<Department, DepartmentDto>();
            CreateMap<CreateDepartmentDto,Department>();
            CreateMap<UpdateDepartmentDto, Department>();
        }
    }
}
