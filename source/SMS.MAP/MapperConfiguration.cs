using System;
using AutoMapper;
using SMS.DATA.Models;
using Student = SMS.DATA.Models.Student;
using DTOStudent = SMS.DTOs.DTOs.Student;

namespace SMS.MAP
{
    public class MapperConfigurationInternal : Profile
    {
        protected void Configure()
        {
            CreateMap<Person, DTOStudent>();
            CreateMap<Student, DTOStudent>();
            // .ForMember(dest => dest.RegistrationNumber, act => act.MapFrom(src => src.UpdateDate.ToString()));
            CreateMap<DTOStudent, Student>();
        }
    }
}
