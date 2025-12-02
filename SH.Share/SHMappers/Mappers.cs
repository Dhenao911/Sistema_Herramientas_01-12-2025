using AutoMapper;
using SH.Share.Dtos;
using SH.Share.Models;

namespace SH.Share.SHMappers
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Employee, EmployeeCreateDto>().ReverseMap();
            CreateMap<Employee, EmployeeCreateDto>().ReverseMap();
        }
    }
}