using AutoMapper;
using SMS.DATA.Models;
using Class = SMS.DATA.Models.Class;
using Course = SMS.DATA.Models.Course;
using DBStudentFinanceDetails = SMS.DATA.Models.StudentFinanceDetail;
using DBStudentFinances = SMS.DATA.Models.Student_Finances;
using DBWorksheet = SMS.DATA.Models.Worksheet;
using ReqWorksheet = SMS.REQUESTDATA.RequestModels.Worksheet;
using DTOWorksheet = SMS.DTOs.DTOs.Worksheet;
using DTOClass = SMS.DTOs.DTOs.Class;
using DTOCourse = SMS.DTOs.DTOs.Course;
using DTOPerson = SMS.DTOs.DTOs.Person;
using DTOSchool = SMS.DTOs.DTOs.School;
using DTOStudent = SMS.DTOs.DTOs.Student;
using DTOStudentFinanceDetails = SMS.DTOs.DTOs.StudentFinanceDetail;
using DTOStudentFinances = SMS.DTOs.DTOs.Student_Finances;

using Person = SMS.DATA.Models.Person;
using School = SMS.DATA.Models.School;
using ReqSchool = SMS.REQUESTDATA.RequestModels.School;
using Student = SMS.DATA.Models.Student;
using LessonPlan = SMS.DATA.Models.LessonPlan;
using DTOLessonPlan = SMS.DTOs.DTOs.LessonPlan;
using ReqLessonPlan = SMS.REQUESTDATA.RequestModels.LessonPlan;
using Employee = SMS.DATA.Models.Employee;
using DTOEmployee = SMS.DTOs.DTOs.Employee;
using ReqEmployee = SMS.REQUESTDATA.RequestModels.Employee;
using Designation = SMS.DATA.Models.Designation;
using DTODesignation = SMS.DTOs.DTOs.Designation;
using ReqDesignation = SMS.REQUESTDATA.RequestModels.Designation;
using DBFile = SMS.DATA.Models.File;
using DTOFile = SMS.DTOs.DTOs.File;
using DBUserInfo = SMS.DATA.Models.NonDbContextModels.UserInfo;
using DTOUserInfo = SMS.DTOs.DTOs.UserInfo;
using DTOStudentAttendance = SMS.DTOs.DTOs.StudentAttendance;
using DTOStudentAttendanceDetail = SMS.DTOs.DTOs.StudentAttendanceDetail;
using DTOAttendanceStatus = SMS.DTOs.DTOs.AttendanceStatus;
using DBFinanceType = SMS.DATA.Models.FinanceType;
using DTOFinanceType = SMS.DTOs.DTOs.FinanceType;
using DBEmployeeFinanceDetail = SMS.DATA.Models.EmployeeFinanceDetail;
using DTOEmployeeFinanceDetail = SMS.DTOs.DTOs.EmployeeFinanceDetail;
using DBEmployeeFinance = SMS.DATA.Models.EmployeeFinance;
using DTOEmployeeFinance = SMS.DTOs.DTOs.EmployeeFinance;

using DBRequestType = SMS.REQUESTDATA.RequestModels.RequestType;
using DTORequestType = SMS.DTOs.DTOs.RequestType;

using DBRequestStatus = SMS.REQUESTDATA.RequestModels.RequestStatus;
using DTORequestStatus = SMS.DTOs.DTOs.RequestStatus;

using TeacherDiary = SMS.DATA.Models.TeacherDiary;
using DTOTeacherDiary = SMS.DTOs.DTOs.TeacherDiary;

using DBStudentFinance = SMS.DATA.Models.NonDbContextModels.StudentFinanceInfo;
using DTOStudentFinance = SMS.DTOs.DTOs.StudentFinanceInfo;

using DBEmployeeFinanceInfo = SMS.DATA.Models.NonDbContextModels.EmployeeFinanceInfo;
using DTOEmployeeFinanceInfo = SMS.DTOs.DTOs.EmployeeFinanceInfo;


using DTOTimeTable = SMS.DTOs.DTOs.TimeTable;
using DTOTimeTableDetail = SMS.DTOs.DTOs.TimeTableDetail;
using DTOPeriod = SMS.DTOs.DTOs.Period;

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

            CreateMap<DBEmployeeFinanceInfo, DTOEmployeeFinanceInfo>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<Person, DTOPerson>();

            CreateMap<Class, DTOClass>();
            CreateMap<DTOClass, DTOClass>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<School, DTOSchool>();
            CreateMap<DTOSchool, DTOSchool>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));


            CreateMap<ReqSchool, DTOSchool>();
            CreateMap<DTOSchool, DTOSchool>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<DBUserInfo, DTOUserInfo>();
            CreateMap<DTOUserInfo, DTOUserInfo>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<DBStudentFinance, DTOStudentFinance>();
            CreateMap<DTOStudentFinance, DTOStudentFinance>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<DBEmployeeFinanceInfo, DTOEmployeeFinanceInfo>();
            CreateMap<DTOEmployeeFinanceInfo, DTOEmployeeFinanceInfo>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<Course, DTOCourse>();

            CreateMap<DBWorksheet, DTOWorksheet>();
            CreateMap<ReqWorksheet, DTOWorksheet>();

            CreateMap<DBRequestType, DTORequestType>();
            CreateMap<DTORequestType, DTORequestType>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<DBRequestStatus, DTORequestStatus>();
            CreateMap<DTORequestStatus, DTORequestStatus>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));


            CreateMap<LessonPlan, DTOLessonPlan>();
            CreateMap<DTOLessonPlan, DTOLessonPlan>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<ReqLessonPlan, DTOLessonPlan>();
            CreateMap<DTOLessonPlan, DTOLessonPlan>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<DBEmployeeFinanceDetail, DTOEmployeeFinanceDetail>();
            CreateMap<DTOEmployeeFinanceDetail, DTOEmployeeFinanceDetail>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<TeacherDiary, DTOTeacherDiary>();
            CreateMap<DTOTeacherDiary, DTOTeacherDiary>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<DBFile, DTOFile>();
            CreateMap<DTOFile, DTOFile>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<Employee, DTOEmployee>();
            CreateMap<DTOEmployee, DTOEmployee>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<ReqEmployee, DTOEmployee>();
            CreateMap<DTOEmployee, DTOEmployee>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<Designation, DTODesignation>();
            CreateMap<DTODesignation, DTODesignation>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<ReqDesignation, DTODesignation>();
            CreateMap<DTODesignation, DTODesignation>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<StudentAttendance, DTOStudentAttendance>();
            CreateMap<DTOStudentAttendance, DTOStudentAttendance>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));
            CreateMap<AttendanceStatus, DTOAttendanceStatus>();
            CreateMap<DTOAttendanceStatus, DTOAttendanceStatus>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));
            CreateMap<StudentAttendanceDetail, DTOStudentAttendanceDetail>();
            CreateMap<DTOStudentAttendanceDetail, DTOStudentAttendanceDetail>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<DBFinanceType, DTOFinanceType>();
            CreateMap<DTOFinanceType, DTOFinanceType>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<TimeTable, DTOTimeTable>();
            CreateMap<DTOTimeTable, DTOTimeTable>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<TimeTableDetail, DTOTimeTableDetail>();
            CreateMap<DTOTimeTableDetail, DTOTimeTableDetail>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<Period, DTOPeriod>();
            CreateMap<DTOPeriod, DTOPeriod>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            #endregion

            #region DTO to DB


            //DTO to Db
            CreateMap<DTOStudent, Student>();
            CreateMap<DTOPerson, Person>();
            CreateMap<DTOClass, Class>();
            CreateMap<DTOSchool, School>();
            CreateMap<DTOSchool, ReqSchool>();
            CreateMap<DTOCourse, Course>();
            CreateMap<DTOWorksheet, DBWorksheet>();
            CreateMap<DTORequestType, DBRequestType>();
            CreateMap<DTORequestStatus, DBRequestStatus>();
            CreateMap<DTOWorksheet, ReqWorksheet>();
            CreateMap<DTOLessonPlan, LessonPlan>();
            CreateMap<DTOLessonPlan, ReqLessonPlan>();
            CreateMap<DTOTeacherDiary, TeacherDiary>();
            CreateMap<DTOEmployee, Employee>();
            CreateMap<DTOEmployee, ReqEmployee>();

            CreateMap<DTODesignation, Designation>();
            CreateMap<DTODesignation, ReqDesignation>();

            CreateMap<DTOStudentFinances, DBStudentFinances>();
            CreateMap<DTOStudentFinanceDetails, DBStudentFinanceDetails>();
            CreateMap<DTOFile, DBFile>();
            CreateMap<DTOUserInfo, DBUserInfo>();
            CreateMap<DTOStudentFinance, DBStudentFinance>();
            CreateMap<DTOEmployeeFinanceInfo, DBEmployeeFinanceInfo>();
            CreateMap<DTOAttendanceStatus, AttendanceStatus>();
            CreateMap<DTOStudentAttendance, StudentAttendance>();
            CreateMap<DTOStudentAttendanceDetail, StudentAttendanceDetail>();
            CreateMap<DTOEmployeeFinance, DBEmployeeFinance>();
            CreateMap<DTOEmployeeFinanceDetail, DBEmployeeFinanceDetail>();
            CreateMap<DTOFinanceType, DBFinanceType>();
            CreateMap<DTOTimeTable, TimeTable>();
            CreateMap<DTOTimeTableDetail, TimeTableDetail>();
            CreateMap<DTOPeriod, Period>();

            #endregion

            #region Others
            CreateMap<DTOUserInfo, DTOPerson>();
            CreateMap<DTOUserInfo, DTOPerson>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));
            CreateMap<DTOUserInfo, DTOPerson>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PersonId));

            CreateMap<DTOTeacherDiary, TeacherDiary>();
            #endregion
        }
    }
}
