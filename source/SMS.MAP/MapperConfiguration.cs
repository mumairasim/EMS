﻿using AutoMapper;
using SMS.DTOs.DTOs;
using AttendanceStatus = SMS.DATA.Models.AttendanceStatus;
using Class = SMS.DATA.Models.Class;
using Course = SMS.DATA.Models.Course;
using StudentDiary = SMS.DATA.Models.StudentDiary;
using DBStudentFinanceDetails = SMS.DATA.Models.StudentFinanceDetail;
using DBStudentFinances = SMS.DATA.Models.Student_Finances;
using DBWorksheet = SMS.DATA.Models.Worksheet;
using DTOWorksheet = SMS.DTOs.DTOs.Worksheet;
using DTOClass = SMS.DTOs.DTOs.Class;
using DTOCourse = SMS.DTOs.DTOs.Course;
using DTOPerson = SMS.DTOs.DTOs.Person;
using DTOSchool = SMS.DTOs.DTOs.School;
using DTOStudent = SMS.DTOs.DTOs.Student;
using DTOStudentDiary = SMS.DTOs.DTOs.StudentDiary;
using DTOStudentFinanceDetails = SMS.DTOs.DTOs.StudentFinanceDetail;
using DTOStudentFinances = SMS.DTOs.DTOs.Student_Finances;

using Person = SMS.DATA.Models.Person;
using School = SMS.DATA.Models.School;
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
using DTOStudentAttendanceDetail = SMS.DTOs.DTOs.StudentAttendanceDetail;
using DTOAttendanceStatus = SMS.DTOs.DTOs.AttendanceStatus;
using DBFinanceType = SMS.DATA.Models.FinanceType;
using DTOFinanceType = SMS.DTOs.DTOs.FinanceType;
using DBEmployeeFinanceDetail = SMS.DATA.Models.EmployeeFinanceDetail;
using DTOEmployeeFinanceDetail = SMS.DTOs.DTOs.EmployeeFinanceDetail;
using DBEmployeeFinance = SMS.DATA.Models.EmployeeFinance;
using DTOEmployeeFinance = SMS.DTOs.DTOs.EmployeeFinance;

using DTORequestType = SMS.DTOs.DTOs.RequestType;

using DTORequestStatus = SMS.DTOs.DTOs.RequestStatus;

using TeacherDiary = SMS.DATA.Models.TeacherDiary;
using DTOTeacherDiary = SMS.DTOs.DTOs.TeacherDiary;
using DBStudentDiary = SMS.DATA.Models.StudentDiary;

using DBStudentFinance = SMS.DATA.Models.NonDbContextModels.StudentFinanceInfo;
using DTOStudentFinance = SMS.DTOs.DTOs.StudentFinanceInfo;

using DBEmployeeFinanceInfo = SMS.DATA.Models.NonDbContextModels.EmployeeFinanceInfo;
using DTOEmployeeFinanceInfo = SMS.DTOs.DTOs.EmployeeFinanceInfo;


using DTOTimeTable = SMS.DTOs.DTOs.TimeTable;
using DTOTimeTableDetail = SMS.DTOs.DTOs.TimeTableDetail;
using DTOPeriod = SMS.DTOs.DTOs.Period;
using Period = SMS.DATA.Models.Period;
using StudentAttendance = SMS.DATA.Models.StudentAttendance;
using StudentAttendanceDetail = SMS.DATA.Models.StudentAttendanceDetail;
using TimeTable = SMS.DATA.Models.TimeTable;
using TimeTableDetail = SMS.DATA.Models.TimeTableDetail;




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
            CreateMap<DTOPerson, DTOPerson>()
               .ForAllMembers(o => o.Condition((source, destination, member) => member != null));


            CreateMap<Class, DTOClass>();
            CreateMap<DTOClass, DTOClass>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<School, DTOSchool>();
            CreateMap<DTOSchool, DTOSchool>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));


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
            CreateMap<DTOCourse, DTOCourse>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));


            CreateMap<DBWorksheet, DTOWorksheet>();
            CreateMap<DTORequestType, DTORequestType>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<DTORequestStatus, DTORequestStatus>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));


            CreateMap<LessonPlan, DTOLessonPlan>();
            CreateMap<DTOLessonPlan, DTOLessonPlan>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

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

            CreateMap<DBStudentDiary, DTOStudentDiary>();
            CreateMap<DBStudentDiary, DTOStudentDiary>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<Period, DTOPeriod>();
            CreateMap<DTOPeriod, DTOPeriod>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<StudentDiary, DTOStudentDiary>();
            CreateMap<DTOStudentDiary, DTOStudentDiary>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));


            #endregion

            #region DTO to DB


            //DTO to Db
            CreateMap<DTOStudent, Student>();
            CreateMap<DTOPerson, Person>();
            CreateMap<DTOClass, Class>();
            CreateMap<DTOStudentDiary, StudentDiary>();
            CreateMap<DTOSchool, School>();
            CreateMap<DTOCourse, Course>();
            CreateMap<DTOWorksheet, DBWorksheet>();
            CreateMap<DTOLessonPlan, LessonPlan>();
            CreateMap<DTOTeacherDiary, TeacherDiary>();
            CreateMap<DTOEmployee, Employee>();
            CreateMap<DTODesignation, Designation>();

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

            #region ToCommonRequestModel
            CreateMap<DTOStudent, CommonRequestModel>()
                .ForMember(destination => destination.RequestFor,
                    opts => opts.MapFrom(source => "Student"))
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));
            CreateMap<DTOEmployee, CommonRequestModel>()
                .ForMember(destination => destination.RequestFor,
                    opts => opts.MapFrom(source => "Employee"))
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));
            CreateMap<DTOCourse, CommonRequestModel>()
                .ForMember(destination => destination.RequestFor,
                    opts => opts.MapFrom(source => "Course"))
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));
            CreateMap<DTOClass, CommonRequestModel>()
                .ForMember(destination => destination.RequestFor,
                    opts => opts.MapFrom(source => "Class"))
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));
            CreateMap<DTOLessonPlan, CommonRequestModel>()
                .ForMember(destination => destination.RequestFor,
                    opts => opts.MapFrom(source => "LessonPlan"))
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));
            CreateMap<DTOStudentAttendance, CommonRequestModel>()
                .ForMember(destination => destination.RequestFor,
                    opts => opts.MapFrom(source => "StudentAttendance"))
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));
            CreateMap<DTOStudentDiary, CommonRequestModel>()
                .ForMember(destination => destination.RequestFor,
                    opts => opts.MapFrom(source => "StudentDiary"))
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));
            CreateMap<DTOTeacherDiary, CommonRequestModel>()
                .ForMember(destination => destination.RequestFor,
                    opts => opts.MapFrom(source => "TeacherDiary"))
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));
            CreateMap<DTOWorksheet, CommonRequestModel>()
                .ForMember(destination => destination.RequestFor,
                    opts => opts.MapFrom(source => "Worksheet"))
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));
            CreateMap<DTOTimeTable, CommonRequestModel>()
                .ForMember(destination => destination.RequestFor,
                    opts => opts.MapFrom(source => "TimeTable"))
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));
            CreateMap<DTOStudentFinance, CommonRequestModel>()
                .ForMember(destination => destination.RequestFor,
                    opts => opts.MapFrom(source => "StudentFinance"))
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));
            CreateMap<DTOEmployeeFinance, CommonRequestModel>()
                .ForMember(destination => destination.RequestFor,
                    opts => opts.MapFrom(source => "EmployeeFinance"))
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));
            #endregion
        }
    }
}
