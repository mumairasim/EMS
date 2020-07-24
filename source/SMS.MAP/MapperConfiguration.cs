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
using ReqWorksheet = SMS.REQUESTDATA.RequestModels.Worksheet;
using DTOWorksheet = SMS.DTOs.DTOs.Worksheet;
using Class = SMS.DATA.Models.Class;
using DTOClass = SMS.DTOs.DTOs.Class;
using ReqClass = SMS.REQUESTDATA.RequestModels.Class;
using Course = SMS.DATA.Models.Course;
using DTOCourse = SMS.DTOs.DTOs.Course;
using ReqCourse = SMS.REQUESTDATA.RequestModels.Course;
using DTOPerson = SMS.DTOs.DTOs.Person;
using DTOSchool = SMS.DTOs.DTOs.School;
using DTOStudent = SMS.DTOs.DTOs.Student;
using RequestStudent = SMS.REQUESTDATA.RequestModels.Student;
using DTOStudentDiary = SMS.DTOs.DTOs.StudentDiary;
using DTOStudentFinanceDetails = SMS.DTOs.DTOs.StudentFinanceDetail;
using DTOStudentFinances = SMS.DTOs.DTOs.Student_Finances;

using Person = SMS.DATA.Models.Person;
using ReqPerson = SMS.REQUESTDATA.RequestModels.Person;
using School = SMS.DATA.Models.School;
using ReqSchool = SMS.REQUESTDATA.RequestModels.School;
using Student = SMS.DATA.Models.Student;
using LessonPlan = SMS.DATA.Models.LessonPlan;
using DTOLessonPlan = SMS.DTOs.DTOs.LessonPlan;
using ReqLessonPlan = SMS.REQUESTDATA.RequestModels.LessonPlan;
using Employee = SMS.DATA.Models.Employee;
using DTOEmployee = SMS.DTOs.DTOs.Employee;
using RequestEmployee= SMS.REQUESTDATA.RequestModels.Employee;
using Designation = SMS.DATA.Models.Designation;
using DTODesignation = SMS.DTOs.DTOs.Designation;
using RequestDesignation = SMS.REQUESTDATA.RequestModels.Designation;
using DBFile = SMS.DATA.Models.File;
using DTOFile = SMS.DTOs.DTOs.File;
using DBUserInfo = SMS.DATA.Models.NonDbContextModels.UserInfo;
using DTOUserInfo = SMS.DTOs.DTOs.UserInfo;
using DTOStudentAttendance = SMS.DTOs.DTOs.StudentAttendance;
using RequestStudentAttendance = SMS.REQUESTDATA.RequestModels.StudentAttendance;
using DTOStudentAttendanceDetail = SMS.DTOs.DTOs.StudentAttendanceDetail;
using RequestStudentAttendanceDetail = SMS.REQUESTDATA.RequestModels.StudentAttendanceDetail;
using DTOAttendanceStatus = SMS.DTOs.DTOs.AttendanceStatus;
using ReqAttendanceStatus = SMS.REQUESTDATA.RequestModels.AttendanceStatus;
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
using RequestTeacherDiary = SMS.REQUESTDATA.RequestModels.TeacherDiary;
using DBStudentDiary = SMS.DATA.Models.StudentDiary;

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

            CreateMap<RequestStudent, DTOStudent>();

            CreateMap<DTOPerson, DTOPerson>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<ReqPerson, DTOPerson>();

            CreateMap<DBStudentFinances, DTOStudentFinances>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<RequestStudentFinance, DTOStudentFinances>()
    .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<DBStudentFinanceDetails, DTOStudentFinanceDetails>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));


            CreateMap<RequestStudentFinanceDetail, DTOStudentFinanceDetails>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));
            

            CreateMap<DBEmployeeFinanceInfo, DTOEmployeeFinanceInfo>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<ReqPerson, DTOPerson>();
            CreateMap<Person, DTOPerson>();
            CreateMap<DTOPerson, DTOPerson>()
               .ForAllMembers(o => o.Condition((source, destination, member) => member != null));


            CreateMap<ReqClass, DTOClass>();
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
            

            CreateMap<ReqCourse, DTOCourse>();
            CreateMap<Course, DTOCourse>();
            CreateMap<DTOCourse, DTOCourse>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));


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

            CreateMap<RequestTeacherDiary, DTOTeacherDiary>();

            CreateMap<DBFile, DTOFile>();
            CreateMap<DTOFile, DTOFile>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<Employee, DTOEmployee>();
            CreateMap<DTOEmployee, DTOEmployee>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            

            CreateMap<RequestEmployee, DTOEmployee>();

            CreateMap<Designation, DTODesignation>();
            CreateMap<DTODesignation, DTODesignation>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<RequestDesignation, DTODesignation>();

            CreateMap<StudentAttendance, DTOStudentAttendance>();
            CreateMap<DTOStudentAttendance, DTOStudentAttendance>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));
            CreateMap<ReqAttendanceStatus, DTOAttendanceStatus>();
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

            CreateMap<DBStudentDiary, DTOStudentDiary>();
            CreateMap<DBStudentDiary, DTOStudentDiary>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<Period, DTOPeriod>();
            CreateMap<DTOPeriod, DTOPeriod>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<StudentDiary, DTOStudentDiary>();
            CreateMap<DTOStudentDiary, DTOStudentDiary>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<RequestStudentDiary, DTOStudentDiary>();

            #endregion

            #region DTO to DB


            //DTO to Db
            CreateMap<DTOStudent, Student>();
            CreateMap<DTOStudent, RequestStudent>();
            CreateMap<DTOPerson, ReqPerson>();
            CreateMap<DTOPerson, Person>();
            CreateMap<DTOPerson, ReqPerson>();
            CreateMap<DTOClass, Class>();
            CreateMap<DTOStudentDiary, StudentDiary>();
            CreateMap<DTOStudentDiary, RequestStudentDiary>();
            CreateMap<DTOClass, ReqClass>();
            CreateMap<DTOSchool, School>();
            CreateMap<DTOSchool, ReqSchool>();
            CreateMap<DTOCourse, Course>();
            CreateMap<DTOCourse, ReqCourse>();
            CreateMap<DTOWorksheet, DBWorksheet>();
            CreateMap<DTORequestType, DBRequestType>();
            CreateMap<DTORequestStatus, DBRequestStatus>();
            CreateMap<DTOWorksheet, ReqWorksheet>();
            CreateMap<DTOLessonPlan, LessonPlan>();
            CreateMap<DTOLessonPlan, ReqLessonPlan>();
            CreateMap<DTOTeacherDiary, TeacherDiary>();
            CreateMap<DTOTeacherDiary, RequestTeacherDiary>();
            CreateMap<DTOEmployee, Employee>();
            CreateMap<DTOEmployee, RequestEmployee >();
            CreateMap<DTODesignation, Designation>();
            CreateMap<DTODesignation, RequestDesignation>();

            CreateMap<DTOStudentFinances, DBStudentFinances>();
            CreateMap<DTOStudentFinances, RequestStudentFinance>();
            CreateMap<DTOStudentFinanceDetails, DBStudentFinanceDetails>();
            CreateMap<DTOStudentFinanceDetails, RequestStudentFinanceDetail>();
            CreateMap<DTOFile, DBFile>();
            CreateMap<DTOUserInfo, DBUserInfo>();
            CreateMap<DTOStudentFinance, DBStudentFinance>();
            CreateMap<DTOEmployeeFinanceInfo, DBEmployeeFinanceInfo>();
            CreateMap<DTOAttendanceStatus, ReqAttendanceStatus>();
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
            CreateMap<DTOStudentDiary, DBStudentDiary>();

            #endregion

            #region Others
            CreateMap<DTOUserInfo, DTOPerson>();
            CreateMap<DTOUserInfo, DTOPerson>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));
            CreateMap<DTOUserInfo, DTOPerson>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PersonId));

            CreateMap<DTOTeacherDiary, TeacherDiary>();
            CreateMap<DTOStudentDiary, StudentDiary>();

            #endregion
        }
    }
}
