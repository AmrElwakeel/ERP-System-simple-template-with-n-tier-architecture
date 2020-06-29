using AutoMapper;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Dto.CasherDto;
using ERP.Dto.DepartmentDto;

namespace ERP.Dto
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Casher, CasherViewDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FrindlyName, opt => opt.MapFrom(src => src.ApplicationUser.FriendlyName))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department.Name))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Salary, opt => opt.MapFrom(src => src.Salary + " E.G"));

            CreateMap<CreateCasherDto, Casher>()
                .ForMember(dest => dest.Dept_Id, obj => obj.MapFrom(src => src.Dept))
                //.ForPath(dest => dest.Department, obj => obj.MapFrom(src => src.Department))
                .ForMember(dest => dest.Name, obj => obj.MapFrom(src => src.Name))
                .ForMember(dest => dest.Address, obj => obj.MapFrom(src => src.Address))
                .ForMember(dest => dest.Phone, obj => obj.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Salary, obj => obj.MapFrom(src => src.Salary))
                .ForMember(dest => dest.HiredDate, obj => obj.MapFrom(src => src.HiredDate))
                .ForMember(dest => dest.HiredDate, obj => obj.MapFrom(src => src.HiredDate))
                .ReverseMap();

            CreateMap<Department, DepartmentViewDto>();
            CreateMap<CreateDepartmentDto,Department>();
            CreateMap<UpdateDepartmentDto, Department>();
        }
    }
}
