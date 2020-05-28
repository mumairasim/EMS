using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.DTOs.DTOs;
using SMS.Services.Infrastructure;
using DTOStudentAttendance = SMS.DTOs.DTOs.StudentAttendance;
using StudentAttendance = SMS.DATA.Models.StudentAttendance;

namespace SMS.Services.Implementation
{
    public class StudentAttendanceService : IStudentAttendanceService
    {
        private readonly IRepository<StudentAttendance> _repository;
        private readonly IMapper _mapper;
        public StudentAttendanceService(IRepository<StudentAttendance> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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

            return _mapper.Map<StudentAttendance, DTOStudentAttendance>(studentAttendanceRecord);
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
        public Guid Create(DTOStudentAttendance dtoStudentAttendance)
        {
            dtoStudentAttendance.CreatedDate = DateTime.Now;
            dtoStudentAttendance.IsDeleted = false;
            dtoStudentAttendance.Id = Guid.NewGuid();
            _repository.Add(_mapper.Map<DTOStudentAttendance, StudentAttendance>(dtoStudentAttendance));
            return dtoStudentAttendance.Id;
        }
        public void Create(StudentsAttendanceList dtoStudentAttendanceList, string createdBy)
        {
            foreach (var studentAttendance in dtoStudentAttendanceList.StudentsAttendances)
            {
                studentAttendance.CreatedBy = createdBy;
                Create(studentAttendance);
            }

        }
        public void Update(DTOStudentAttendance dtoStudentAttendance)
        {
            var studentAttendance = Get(dtoStudentAttendance.Id);
            dtoStudentAttendance.UpdateDate = DateTime.Now;
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
            studentAttendance.DeletedDate = DateTime.Now;
            _repository.Update(_mapper.Map<DTOStudentAttendance, StudentAttendance>(studentAttendance));
        }
    }
}
