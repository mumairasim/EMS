using SMS.DTOs.DTOs;
using SMS.Services.Infrastructure;
using System.Collections.Generic;
using AutoMapper;

namespace SMS.Services.Implementation
{
    public class RequestManagementService : IRequestManagementService
    {
        private readonly IStudentService _studentService;
        private readonly IEmployeeService _employeeService;
        private readonly ICourseService _courseService;
        private readonly IClassService _classService;
        private readonly ILessonPlanService _lessonPlanService;
        private readonly IStudentAttendanceService _studentAttendanceService;
        private readonly IStudentDiaryService _studentDiaryService;
        private readonly ITeacherDiaryService _teacherDiaryService;
        private readonly IWorksheetService _worksheetService;
        private readonly ITimeTableService _timeTableService;
        private readonly IStudentFinanceService _studentFinanceService;
        private readonly IEmployeeFinanceService _employeeFinanceService;
        private readonly IMapper _mapper;

        public RequestManagementService(IStudentService studentService, IEmployeeService employeeService, ICourseService courseService, IClassService classService, ILessonPlanService lessonPlanService, IStudentAttendanceService studentAttendanceService, IStudentDiaryService studentDiaryService, ITeacherDiaryService teacherDiaryService, IWorksheetService worksheetService, ITimeTableService timeTableService, IStudentFinanceService studentFinanceService, IEmployeeFinanceService employeeFinanceService, IMapper mapper)
        {
            _employeeService = employeeService;
            _courseService = courseService;
            _classService = classService;
            _lessonPlanService = lessonPlanService;
            _studentAttendanceService = studentAttendanceService;
            _studentDiaryService = studentDiaryService;
            _teacherDiaryService = teacherDiaryService;
            _worksheetService = worksheetService;
            _timeTableService = timeTableService;
            _studentFinanceService = studentFinanceService;
            _employeeFinanceService = employeeFinanceService;
            _mapper = mapper;
            _studentService = studentService;
        }

        public IEnumerable<CommonRequestModel> GetAllRequests()
        {
            var commonRequestList = new List<CommonRequestModel>();
            //commonRequestList.AddRange(_mapper.Map<List<Student>, List<CommonRequestModel>>(_studentService.Get(1, 10)?.Students));
            //commonRequestList.AddRange(_mapper.Map<List<Employee>, List<CommonRequestModel>>(_employeeService.Get(1, 10)?.Employees));
            //commonRequestList.AddRange(_mapper.Map<List<Course>, List<CommonRequestModel>>(_courseService.GetAll()));
            //commonRequestList.AddRange(_mapper.Map<List<Class>, List<CommonRequestModel>>(_classService.Get()));
            commonRequestList.AddRange(_mapper.Map<List<LessonPlan>, List<CommonRequestModel>>(_lessonPlanService.Get(1, 10)?.LessonPlans));
            commonRequestList.AddRange(_mapper.Map<List<StudentAttendance>, List<CommonRequestModel>>(_studentAttendanceService.Get(1, 10)?.StudentsAttendances));
            commonRequestList.AddRange(_mapper.Map<List<StudentDiary>, List<CommonRequestModel>>(_studentDiaryService.Get()));
            commonRequestList.AddRange(_mapper.Map<List<TeacherDiary>, List<CommonRequestModel>>(_teacherDiaryService.Get(1, 10)?.TeacherDiaries));
            commonRequestList.AddRange(_mapper.Map<List<Worksheet>, List<CommonRequestModel>>(_worksheetService.GetAll()));
            //commonRequestList.AddRange(_mapper.Map<List<TimeTable>, List<CommonRequestModel>>(_timeTableService.Get()));
            commonRequestList.AddRange(_mapper.Map<List<Student_Finances>, List<CommonRequestModel>>(_studentFinanceService.GetAll()));
            //commonRequestList.AddRange(_mapper.Map<List<EmployeeFinance>, List<CommonRequestModel>>(_employeeFinanceService.Get));
            return commonRequestList;
        }

    }
}
