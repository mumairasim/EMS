﻿using AutoMapper;

using Student = SMS.DATA.Models.Student;
using DTOStudent = SMS.DTOs.DTOs.Student;
using Person = SMS.DATA.Models.Person;
using DTOPerson = SMS.DTOs.DTOs.Person;
using Class = SMS.DATA.Models.Class;
using DTOClass = SMS.DTOs.DTOs.Class;
using School = SMS.DATA.Models.School;
using DTOSchool = SMS.DTOs.DTOs.School;
using LessonPlan = SMS.DATA.Models.LessonPlan;
using DTOLessonPlan = SMS.DTOs.DTOs.LessonPlan;


namespace SMS.MAP
{
    public class MapperConfigurationInternal : Profile
    {
        public MapperConfigurationInternal()
        {
            #region DB to DTO


            //Db to DTO
            CreateMap<Student, DTOStudent>();
            CreateMap<DTOStudent, DTOStudent>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<DTOPerson, DTOPerson>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<Person, DTOPerson>();
            CreateMap<Class, DTOClass>();
            CreateMap<School, DTOSchool>();

            CreateMap<LessonPlan, DTOLessonPlan>();
            CreateMap<DTOLessonPlan, DTOLessonPlan>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            #endregion
            #region DTO to DB


            //.ForMember(dest => dest.PersonId, act => act.MapFrom(src => src.PersonId));
            //DTO to Db
            CreateMap<DTOStudent, Student>();
            CreateMap<DTOPerson, Person>();
            CreateMap<DTOClass, Class>();
            CreateMap<DTOSchool, School>();
            CreateMap<DTOLessonPlan, LessonPlan>();

            #endregion
        }
    }
}
