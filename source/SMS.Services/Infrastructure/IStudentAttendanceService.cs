using System;
using SMS.DTOs.DTOs;
using SMS.DTOs.ReponseDTOs;
using DTOStudentAttendance = SMS.DTOs.DTOs.StudentAttendance;
namespace SMS.Services.Infrastructure
{
    public interface IStudentAttendanceService
    {
        StudentsAttendanceList Get(int pageNumber, int pageSize);
        StudentsAttendanceList Get(Guid? classId, Guid? schoolId, int pageNumber, int pageSize);
        DTOStudentAttendance Get(Guid? id);
        StudentAttendanceResponse Create(DTOStudentAttendance dtoStudentAttendance);
        void Update(DTOStudentAttendance dtoStudentAttendance);
        void Delete(Guid? id, string deletedBy);
    }
}
