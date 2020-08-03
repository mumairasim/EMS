using System;
using System.Linq.Expressions;
using SMS.DTOs.DTOs;
using SMS.DTOs.ReponseDTOs;
using SMS.REQUESTDATA.Infrastructure;
using DTOStudentAttendance = SMS.DTOs.DTOs.StudentAttendance;
using StudentAttendance = SMS.DATA.Models.StudentAttendance;
using RequestStudentAttendance = SMS.REQUESTDATA.RequestModels.StudentAttendance;

namespace SMS.Services.Infrastructure
{
    public interface IStudentAttendanceService
    {
        #region SMS Section
        StudentsAttendanceList Get(int pageNumber, int pageSize);
        StudentsAttendanceList Get(Guid? classId, Guid? schoolId, int pageNumber, int pageSize);
        StudentsAttendanceList Search(Expression<Func<StudentAttendance, bool>> predicate, int pageNumber, int pageSize);
        DTOStudentAttendance Get(Guid? id);
        StudentAttendanceResponse Create(DTOStudentAttendance dtoStudentAttendance);
        StudentAttendanceResponse Update(DTOStudentAttendance dtoStudentAttendance);
        void Delete(Guid? id, string deletedBy);
        #endregion

        #region RequestSMS Section
        StudentsAttendanceList RequestGet(int pageNumber, int pageSize);
        StudentsAttendanceList RequestGet(Guid? classId, Guid? schoolId, int pageNumber, int pageSize);
        StudentsAttendanceList RequestSearch(Expression<Func<RequestStudentAttendance, bool>> predicate, int pageNumber, int pageSize);
        DTOStudentAttendance RequestGet(Guid? id);
        StudentAttendanceResponse RequestCreate(DTOStudentAttendance dtoStudentAttendance);
        void RequestUpdate(DTOStudentAttendance dtoStudentAttendance);
        void RequestDelete(Guid? id/*, string deletedBy*/);
        #endregion
    }
}
