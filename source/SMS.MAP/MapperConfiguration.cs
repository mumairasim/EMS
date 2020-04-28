using AutoMapper;
using SMS.DATA.Models;
using Student = SMS.DATA.Models.Student;
using DTOStudent = SMS.DTOs.DTOs.Student;

namespace SMS.MAP
{
    public class MapperConfigurationInternal : Profile
    {
        public MapperConfigurationInternal()
        {
            CreateMap<Person, DTOStudent>();
            CreateMap<Student, DTOStudent>();
             //.ForMember(dest => dest.PersonId, act => act.MapFrom(src => src.PersonId));
            CreateMap<DTOStudent, Student>();
            CreateMap<DTOStudent, Person>();
        }
    }
}
