using System;
using System.Collections.Generic;
using SMS.DTOs.DTOs;
using DTOStudentAttendanceDetail = SMS.DTOs.DTOs.StudentAttendanceDetail;
namespace SMS.Services.Infrastructure
{
    public interface IStudentAttendanceDetailService
    {
        #region SMS section
        DTOStudentAttendanceDetail Get(Guid? id);
        Guid Create(DTOStudentAttendanceDetail dtoStudentAttendance);
        void Create(List<DTOStudentAttendanceDetail> dtoStudentAttendanceDetailList, string createdBy, Guid id);
        void Update(DTOStudentAttendanceDetail dtoStudentAttendance);
        void Delete(Guid? id, string deletedBy);
        List<DTOStudentAttendanceDetail> GetByStudentAttendanceId(Guid? studentId);
        #endregion

        #region RequestSMS section
        DTOStudentAttendanceDetail RequestGet(Guid? id);
        Guid RequestCreate(DTOStudentAttendanceDetail dtoStudentAttendance);
        void RequestCreate(List<DTOStudentAttendanceDetail> dtoStudentAttendanceDetailList, string createdBy, Guid id);
        void RequestUpdate(DTOStudentAttendanceDetail dtoStudentAttendance);
        void RequestDelete(Guid? id, string deletedBy);
        List<DTOStudentAttendanceDetail> RequestGetByStudentAttendanceId(Guid? studentId);
        #endregion
    }
}
