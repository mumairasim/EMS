using AutoMapper;
using SMS.DATA.Models;
using Class = SMS.DATA.Models.Class;
using Course = SMS.DATA.Models.Course;
using StudentDiary = SMS.DATA.Models.StudentDiary;
using RequestStudentDiary = SMS.REQUESTDATA.RequestModels.StudentDiary;
using DBStudentFinanceDetails = SMS.DATA.Models.StudentFinanceDetail;
using RequestStudentFinanceDetail = SMS.REQUESTDATA.RequestModels.StudentFinanceDetail;
using DBStudentFinances = SMS.DATA.Models.Student_Finances;
using DBWorksheet = SMS.DATA.Models.Worksheet;
using DTOClass = SMS.DTOs.DTOs.Class;
using DTOCourse = SMS.DTOs.DTOs.Course;
using DTOPerson = SMS.DTOs.DTOs.Person;
using DTOSchool = SMS.DTOs.DTOs.School;
using DTOStudent = SMS.DTOs.DTOs.Student;
using RequestStudent = SMS.REQUESTDATA.RequestModels.Student;
using DTOStudentDiary = SMS.DTOs.DTOs.StudentDiary;
using DTOStudentFinanceDetails = SMS.DTOs.DTOs.StudentFinanceDetail;
using DTOStudentFinances = SMS.DTOs.DTOs.Student_Finances;
using DTOWorksheet = SMS.DTOs.DTOs.Worksheet;
using Person = SMS.DATA.Models.Person;
using RequestPerson = SMS.REQUESTDATA.RequestModels.Person;
using School = SMS.DATA.Models.School;
using ReqSchool = SMS.REQUESTDATA.RequestModels.School;
using Student = SMS.DATA.Models.Student;
using LessonPlan = SMS.DATA.Models.LessonPlan;
using DTOLessonPlan = SMS.DTOs.DTOs.LessonPlan;
using Employee = SMS.DATA.Models.Employee;
using DTOEmployee = SMS.DTOs.DTOs.Employee;
using Designation = SMS.DATA.Models.Designation;
using DTODesignation = SMS.DTOs.DTOs.Designation;
using DBFile = SMS.DATA.Models.File;
using DTOFile = SMS.DTOs.DTOs.File;
using DBUserInfo = SMS.DATA.Models.NonDbContextModels.UserInfo;
using DTOUserInfo = SMS.DTOs.DTOs.UserInfo;
using DTOStudentAttendance = SMS.DTOs.DTOs.StudentAttendance;
using RequestStudentAttendance = SMS.REQUESTDATA.RequestModels.StudentAttendance;
using DTOStudentAttendanceDetail = SMS.DTOs.DTOs.StudentAttendanceDetail;
using RequestStudentAttendanceDetail = SMS.REQUESTDATA.RequestModels.StudentAttendanceDetail;
using DTOAttendanceStatus = SMS.DTOs.DTOs.AttendanceStatus;
using DBFinanceType = SMS.DATA.Models.FinanceType;
using DTOFinanceType = SMS.DTOs.DTOs.FinanceType;
using DBEmployeeFinanceDetail = SMS.DATA.Models.EmployeeFinanceDetail;
using DTOEmployeeFinanceDetail = SMS.DTOs.DTOs.EmployeeFinanceDetail;
using DBEmployeeFinance = SMS.DATA.Models.EmployeeFinance;
using DTOEmployeeFinance = SMS.DTOs.DTOs.EmployeeFinance;

using TeacherDiary = SMS.DATA.Models.TeacherDiary;
using DTOTeacherDiary = SMS.DTOs.DTOs.TeacherDiary;
using RequestTeacherDiary = SMS.REQUESTDATA.RequestModels.TeacherDiary;
using DBStudentFinance = SMS.DATA.Models.NonDbContextModels.StudentFinanceInfo;
using RequestStudentFinance = SMS.REQUESTDATA.RequestModels.Student_Finances;
using DTOStudentFinance = SMS.DTOs.DTOs.StudentFinanceInfo;

using DBEmployeeFinanceInfo = SMS.DATA.Models.NonDbContextModels.EmployeeFinanceInfo;
using DTOEmployeeFinanceInfo = SMS.DTOs.DTOs.EmployeeFinanceInfo;


using DTOTimeTable = SMS.DTOs.DTOs.TimeTable;
using RequestTimeTable = SMS.REQUESTDATA.RequestModels.TimeTable;
using DTOTimeTableDetail = SMS.DTOs.DTOs.TimeTableDetail;
using RequestTimeTableDetail = SMS.REQUESTDATA.RequestModels.TimeTableDetail;
using DTOPeriod = SMS.DTOs.DTOs.Period;
using RequestPeriod = SMS.REQUESTDATA.RequestModels.Period;



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

            CreateMap<LessonPlan, DTOLessonPlan>();
            CreateMap<DTOLessonPlan, DTOLessonPlan>()
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

            CreateMap<Designation, DTODesignation>();
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
            CreateMap<DTOStudent, RequestStudent>();
            CreateMap<DTOPerson, RequestPerson>();
            CreateMap<DTOPerson, Person>();
            CreateMap<DTOClass, Class>();
            CreateMap<DTOStudentDiary, StudentDiary>();
            CreateMap<DTOStudentDiary, RequestStudentDiary>();
            CreateMap<DTOSchool, School>();
            CreateMap<DTOSchool, ReqSchool>();
            CreateMap<DTOCourse, Course>();
            CreateMap<DTOWorksheet, DBWorksheet>();
            CreateMap<DTOLessonPlan, LessonPlan>();
            CreateMap<DTOTeacherDiary, TeacherDiary>();
            CreateMap<DTOTeacherDiary, RequestTeacherDiary>();
            CreateMap<DTOEmployee, Employee>();
            CreateMap<DTODesignation, Designation>();
            CreateMap<DTOStudentFinances, DBStudentFinances>();
            CreateMap<DTOStudentFinances, RequestStudentFinance>();
            CreateMap<DTOStudentFinanceDetails, DBStudentFinanceDetails>();
            CreateMap<DTOStudentFinanceDetails, RequestStudentFinanceDetail>();
            CreateMap<DTOFile, DBFile>();
            CreateMap<DTOUserInfo, DBUserInfo>();
            CreateMap<DTOStudentFinance, DBStudentFinance>();
            CreateMap<DTOEmployeeFinanceInfo, DBEmployeeFinanceInfo>();
            CreateMap<DTOAttendanceStatus, AttendanceStatus>();
            CreateMap<DTOStudentAttendance, StudentAttendance>();
            CreateMap<DTOStudentAttendance, RequestStudentAttendance>();
            CreateMap<DTOStudentAttendanceDetail, StudentAttendanceDetail>();
            CreateMap<DTOStudentAttendanceDetail, RequestStudentAttendanceDetail>();
            CreateMap<DTOEmployeeFinance, DBEmployeeFinance>();
            CreateMap<DTOEmployeeFinanceDetail, DBEmployeeFinanceDetail>();
            CreateMap<DTOFinanceType, DBFinanceType>();
            CreateMap<DTOTimeTable, TimeTable>();
            CreateMap<DTOTimeTable, RequestTimeTableDetail>();
            CreateMap<DTOTimeTable, RequestTimeTable>();
            CreateMap<DTOTimeTableDetail, TimeTableDetail>();
            CreateMap<DTOPeriod, Period>();
            CreateMap<DTOPeriod, RequestPeriod>();

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
