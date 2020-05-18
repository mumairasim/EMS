using AutoMapper;
using Class = SMS.DATA.Models.Class;
using Course = SMS.DATA.Models.Course;
using DBStudentFinanceDetails = SMS.DATA.Models.StudentFinanceDetail;
using DBStudentFinances = SMS.DATA.Models.Student_Finances;
using DBWorksheet = SMS.DATA.Models.Worksheet;
using DTOClass = SMS.DTOs.DTOs.Class;
using DTOCourse = SMS.DTOs.DTOs.Course;
using DTOPerson = SMS.DTOs.DTOs.Person;
using DTOSchool = SMS.DTOs.DTOs.School;
using DTOStudent = SMS.DTOs.DTOs.Student;
using DTOStudentFinanceDetails = SMS.DTOs.DTOs.StudentFinanceDetail;
using DTOStudentFinances = SMS.DTOs.DTOs.Student_Finances;
using DTOWorksheet = SMS.DTOs.DTOs.Worksheet;
using Person = SMS.DATA.Models.Person;
using School = SMS.DATA.Models.School;
using Student = SMS.DATA.Models.Student;
using LessonPlan = SMS.DATA.Models.LessonPlan;
using DTOLessonPlan = SMS.DTOs.DTOs.LessonPlan;
using Employee = SMS.DATA.Models.Employee;
using DTOEmployee = SMS.DTOs.DTOs.Employee;


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
            CreateMap<DTOClass, DTOClass>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<School, DTOSchool>();
            CreateMap<DTOSchool, DTOSchool>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<Course, DTOCourse>();

            CreateMap<DBWorksheet, DTOWorksheet>();

            CreateMap<LessonPlan, DTOLessonPlan>();
            CreateMap<DTOLessonPlan, DTOLessonPlan>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<Employee, DTOEmployee>();
            CreateMap<DTOEmployee, DTOEmployee>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

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
            CreateMap<DTOLessonPlan, LessonPlan>();
            CreateMap<DTOEmployee, Employee>();
            CreateMap<DTOStudentFinances, DBStudentFinances>();
            CreateMap<DTOStudentFinanceDetails, DBStudentFinanceDetails>();

            #endregion
        }
    }
}
