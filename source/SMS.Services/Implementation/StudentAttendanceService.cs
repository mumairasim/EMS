using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.DTOs.DTOs;
using SMS.DTOs.ReponseDTOs;
using SMS.Services.Infrastructure;
using DTOStudentAttendance = SMS.DTOs.DTOs.StudentAttendance;
using StudentAttendance = SMS.DATA.Models.StudentAttendance;

namespace SMS.Services.Implementation
{
    public class StudentAttendanceService : IStudentAttendanceService
    {
        private readonly IRepository<StudentAttendance> _repository;
        private readonly IStudentAttendanceDetailService _studentAttendanceDetailService;
        private readonly IMapper _mapper;
        public StudentAttendanceService(IRepository<StudentAttendance> repository, IMapper mapper, IStudentAttendanceDetailService studentAttendanceDetailService)
        {
            _repository = repository;
            _mapper = mapper;
            _studentAttendanceDetailService = studentAttendanceDetailService;
        }
        public StudentsAttendanceList Get(int pageNumber, int pageSize)
        {
            var attendanceRecords = _repository.Get().Where(ar => ar.IsDeleted == false).OrderByDescending(ar => ar.CreatedDate).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            var attendanceCount = _repository.Get().Count(st => st.IsDeleted == false);
            var studentAttendanceList = new List<DTOStudentAttendance>();
            foreach (var studentAttendance in attendanceRecords)
            {
                studentAttendanceList.Add(_mapper.Map<StudentAttendance, DTOStudentAttendance>(studentAttendance));
            }
            var studentsAttendanceList = new StudentsAttendanceList()
            {
                StudentsAttendances = studentAttendanceList,
                StudentsAttendanceCount = attendanceCount
            };

            return studentsAttendanceList;
        }
        public DTOStudentAttendance Get(Guid? id)
        {
            if (id == null) return null;
            var studentAttendanceRecord = _repository.Get().FirstOrDefault(ar => ar.IsDeleted == false && ar.Id == id);
            if (studentAttendanceRecord == null) return null;
            var result = _mapper.Map<StudentAttendance, DTOStudentAttendance>(studentAttendanceRecord);
            result.StudentAttendanceDetail = _studentAttendanceDetailService.GetByStudentAttendanceId(studentAttendanceRecord.Id);
            return result;
        }
        public StudentsAttendanceList Get(Guid? classId, Guid? schoolId, int pageNumber, int pageSize)
        {
            var attendanceRecords = _repository.Get().Where(ar => ar.IsDeleted == false && ar.ClassId == classId && ar.SchoolId == schoolId).OrderByDescending(ar => ar.CreatedDate).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            var attendanceCount = _repository.Get().Count(st => st.IsDeleted == false);
            var studentAttendanceList = new List<DTOStudentAttendance>();
            foreach (var studentAttendance in attendanceRecords)
            {
                studentAttendanceList.Add(_mapper.Map<StudentAttendance, DTOStudentAttendance>(studentAttendance));
            }
            var studentsAttendanceList = new StudentsAttendanceList()
            {
                StudentsAttendances = studentAttendanceList,
                StudentsAttendanceCount = attendanceCount
            };

            return studentsAttendanceList;
        }
        public StudentsAttendanceList Search(Expression<Func<StudentAttendance, bool>> predicate, int pageNumber, int pageSize)
        {
            var attendanceRecords = _repository.Get().Where(predicate).OrderByDescending(ar => ar.CreatedDate).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            var attendanceCount = _repository.Get().Count(predicate);
            var studentAttendanceList = new List<DTOStudentAttendance>();
            foreach (var studentAttendance in attendanceRecords)
            {
                studentAttendanceList.Add(_mapper.Map<StudentAttendance, DTOStudentAttendance>(studentAttendance));
            }
            var studentsAttendanceList = new StudentsAttendanceList()
            {
                StudentsAttendances = studentAttendanceList,
                StudentsAttendanceCount = attendanceCount
            };

            return studentsAttendanceList;
        }
        public StudentAttendanceResponse Create(DTOStudentAttendance dtoStudentAttendance)
        {
            if (dtoStudentAttendance.AttendanceDate != null)
            {
                if (IsAttendanceExist(dtoStudentAttendance))
                    return PrepareFailureResponse(
                        dtoStudentAttendance.Id,
                        "AttendanceAlreadyExist",
                        "Attendance Record for Date: " + dtoStudentAttendance.AttendanceDate.Value.ToShortDateString() + " already exist and can not be created. Please Update if you want to edit attendance.");
                dtoStudentAttendance.CreatedDate = DateTime.UtcNow;
                dtoStudentAttendance.IsDeleted = false;
                dtoStudentAttendance.Id = Guid.NewGuid();
                _repository.Add(_mapper.Map<DTOStudentAttendance, StudentAttendance>(dtoStudentAttendance));
                _studentAttendanceDetailService.Create(dtoStudentAttendance.StudentAttendanceDetail,
                    dtoStudentAttendance.CreatedBy,
                    dtoStudentAttendance.Id);
                return PrepareSuccessResponse(
                    dtoStudentAttendance.Id,
                    "AttendanceCreated",
                    "Attendance Record for Date: " + dtoStudentAttendance.AttendanceDate.Value.ToShortDateString() + " has been successfully created.");
            }
            return null;
        }
        public void Update(DTOStudentAttendance dtoStudentAttendance)
        {
            var studentAttendance = Get(dtoStudentAttendance.Id);
            dtoStudentAttendance.UpdateDate = DateTime.UtcNow;
            foreach (var studentAttendanceItem in dtoStudentAttendance.StudentAttendanceDetail)
            {
                studentAttendanceItem.UpdateBy = dtoStudentAttendance.UpdateBy;
                _studentAttendanceDetailService.Update(studentAttendanceItem);
            }
            dtoStudentAttendance.StudentAttendanceDetail = null;
            var mergedStudentAttendance = _mapper.Map(dtoStudentAttendance, studentAttendance);
            _repository.Update(_mapper.Map<DTOStudentAttendance, StudentAttendance>(mergedStudentAttendance));
        }
        public void Delete(Guid? id, string deletedBy)
        {
            if (id == null)
                return;
            var studentAttendance = Get(id);
            studentAttendance.IsDeleted = true;
            studentAttendance.DeletedBy = deletedBy;
            studentAttendance.DeletedDate = DateTime.UtcNow;
            _repository.Update(_mapper.Map<DTOStudentAttendance, StudentAttendance>(studentAttendance));
        }

        private bool IsAttendanceExist(DTOStudentAttendance dtoStudentAttendance)
        {
            var attendanceRecord = _repository.Get()
                .FirstOrDefault(
                    aR => aR.ClassId == dtoStudentAttendance.ClassId &&
                          aR.SchoolId == dtoStudentAttendance.SchoolId &&
                          DbFunctions.TruncateTime(aR.AttendanceDate) == DbFunctions.TruncateTime(dtoStudentAttendance.AttendanceDate.Value));
            if (attendanceRecord != null)
            {
                return true;
            }

            return false;
        }

        private StudentAttendanceResponse PrepareFailureResponse(Guid id, string errorMessage, string descriptionMessage)
        {
            return new StudentAttendanceResponse
            {
                Id = id,
                StatusCode = "400",
                Message = errorMessage,
                Description = descriptionMessage
            };
        }
        private StudentAttendanceResponse PrepareSuccessResponse(Guid id, string message, string descriptionMessage)
        {
            return new StudentAttendanceResponse
            {
                Id = id,
                StatusCode = "200",
                Message = message,
                Description = descriptionMessage
            };
        }
    }
}
