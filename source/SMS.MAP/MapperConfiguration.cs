using AutoMapper;
using Class = SMS.DATA.Models.Class;
using Course = SMS.DATA.Models.Course;

using DBStudentFinances = SMS.DATA.Models.Student_Finances;
using DTOStudentFinances = SMS.DTOs.DTOs.Student_Finances;

using DBStudentFinanceDetails = SMS.DATA.Models.StudentFinanceDetail;
using DTOStudentFinanceDetails = SMS.DTOs.DTOs.StudentFinanceDetail;

using DBWorksheet = SMS.DATA.Models.Worksheet;
using DTOClass = SMS.DTOs.DTOs.Class;
using DTOCourse = SMS.DTOs.DTOs.Course;
using DTOPerson = SMS.DTOs.DTOs.Person;
using DTOSchool = SMS.DTOs.DTOs.School;
using DTOStudent = SMS.DTOs.DTOs.Student;
using DTOWorksheet = SMS.DTOs.DTOs.Worksheet;
using Person = SMS.DATA.Models.Person;
using School = SMS.DATA.Models.School;
using Student = SMS.DATA.Models.Student;

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


            CreateMap<DBStudentFinances, DTOStudentFinances>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<DBStudentFinanceDetails, DTOStudentFinanceDetails>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<Person, DTOPerson>();
            CreateMap<Class, DTOClass>();
            CreateMap<School, DTOSchool>();
            CreateMap<Course, DTOCourse>();
            CreateMap<DBWorksheet, DTOWorksheet>();

            #endregion

            #region DTO to DB


            //.ForMember(dest => dest.PersonId, act => act.MapFrom(src => src.PersonId));
            //DTO to Db
            CreateMap<DTOStudent, Student>();
            CreateMap<DTOPerson, Person>();
            CreateMap<DTOClass, Class>();
            CreateMap<DTOSchool, School>();
            CreateMap<DTOCourse, Course>();
            CreateMap<DTOWorksheet, DBWorksheet>();
            CreateMap<DTOStudentFinances, DBStudentFinances>();
            CreateMap<DTOStudentFinanceDetails, DBStudentFinanceDetails>();

            #endregion
        }
    }
}
