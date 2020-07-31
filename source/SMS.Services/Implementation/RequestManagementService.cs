using SMS.DTOs.DTOs;
using SMS.Services.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System;

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
        private readonly IRequestTypeService _requestTypeService;
        private readonly IRequestStatusService _requestStatusService;
        private readonly IMapper _mapper;

        public RequestManagementService(IStudentService studentService, IEmployeeService employeeService, ICourseService courseService, IClassService classService, ILessonPlanService lessonPlanService, IStudentAttendanceService studentAttendanceService, IStudentDiaryService studentDiaryService, ITeacherDiaryService teacherDiaryService, IWorksheetService worksheetService, ITimeTableService timeTableService, IStudentFinanceService studentFinanceService, IEmployeeFinanceService employeeFinanceService, IMapper mapper, IRequestStatusService requestStatusService, IRequestTypeService requestTypeService)
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
            _requestStatusService = requestStatusService;
            _requestTypeService = requestTypeService;
            _studentService = studentService;
        }

        public IEnumerable<CommonRequestModel> GetAllRequests()
        {

            var type = Type.GetType("Worksheet");
            IBaseService<Worksheet> baseService;
            var commonRequestList = new List<CommonRequestModel>();
            commonRequestList.AddRange(_mapper.Map<List<Student>, List<CommonRequestModel>>(_studentService.RequestGet(1, 10)?.Students));
            commonRequestList.AddRange(_mapper.Map<List<Employee>, List<CommonRequestModel>>(_employeeService.RequestGet()));
            //commonRequestList.AddRange(_mapper.Map<List<Course>, List<CommonRequestModel>>(_courseService.()));
            //commonRequestList.AddRange(_mapper.Map<List<Class>, List<CommonRequestModel>>(_classService.Get()));
            commonRequestList.AddRange(_mapper.Map<List<LessonPlan>, List<CommonRequestModel>>(_lessonPlanService.RequestGet()));
            commonRequestList.AddRange(_mapper.Map<List<StudentAttendance>, List<CommonRequestModel>>(_studentAttendanceService.RequestGet(1, 10)?.StudentsAttendances));
            commonRequestList.AddRange(_mapper.Map<List<StudentDiary>, List<CommonRequestModel>>(_studentDiaryService.RequestGet()));
            commonRequestList.AddRange(_mapper.Map<List<TeacherDiary>, List<CommonRequestModel>>(_teacherDiaryService.RequestGet(1, 10)?.TeacherDiaries));
            commonRequestList.AddRange(_mapper.Map<List<Worksheet>, List<CommonRequestModel>>(baseService.RequestGetAll().ToList()));
            //commonRequestList.AddRange(_mapper.Map<List<TimeTable>, List<CommonRequestModel>>(_timeTableService.RequestGet() ?.TimeTables));
            commonRequestList.AddRange(_mapper.Map<List<Student_Finances>, List<CommonRequestModel>>(_studentFinanceService.RequestGetAll()));
            //commonRequestList.AddRange(_mapper.Map<List<EmployeeFinance>, List<CommonRequestModel>>(_employeeFinanceService.Get));
            return MapRequestTypeAndStatus(commonRequestList);
        }

        private IEnumerable<CommonRequestModel> MapRequestTypeAndStatus(IEnumerable<CommonRequestModel> commonRequestList)
        {
            var requestTypes = _requestTypeService.RequestGetAll();
            var requestStatuses = _requestStatusService.RequestGetAll();
            foreach (var commonRequest in commonRequestList)
            {
                commonRequest.RequestType =
                    requestTypes.FirstOrDefault(rt => commonRequest.RequestTypeId != null && rt.Id == commonRequest.RequestTypeId.Value);
                commonRequest.RequestStatus =
                    requestStatuses.FirstOrDefault(rs => commonRequest.RequestStatusId != null && rs.Id == commonRequest.RequestStatusId.Value);
            }

            return commonRequestList;
        }


    }
}
