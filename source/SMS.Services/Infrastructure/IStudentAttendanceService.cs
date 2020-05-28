using System;
using System.Collections.Generic;
using SMS.DTOs.DTOs;
using DTOStudentAttendance = SMS.DTOs.DTOs.StudentAttendance;
namespace SMS.Services.Infrastructure
{
    public interface IStudentAttendanceService
    {
        StudentsAttendanceList Get(int pageNumber, int pageSize);
        StudentsAttendanceList Get(Guid? classId, Guid? schoolId, int pageNumber, int pageSize);
        DTOStudentAttendance Get(Guid? id);
        Guid Create(DTOStudentAttendance dtoStudentAttendance);
        void Create(StudentsAttendanceList dtoStudentAttendanceList, string createdBy);
        void Update(DTOStudentAttendance dtoStudentAttendance);
        void Delete(Guid? id, string deletedBy);
    }
}
