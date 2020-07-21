using System;
using System.Collections.Generic;
using DTOAttendanceStatus = SMS.DTOs.DTOs.AttendanceStatus;
namespace SMS.Services.Infrastructure
{
    public interface IAttendanceStatusService
    {
        #region SMS Section
        List<DTOAttendanceStatus> Get();
        DTOAttendanceStatus Get(Guid? id);
        Guid Create(DTOAttendanceStatus dtoAttendanceStatus);
        void Update(DTOAttendanceStatus dtoAttendanceStatus);
        void Delete(Guid? id);
        #endregion

        #region SMS Request Section
        List<DTOAttendanceStatus> RequestGet();
        DTOAttendanceStatus RequestGet(Guid? id);
        Guid RequestCreate(DTOAttendanceStatus dtoAttendanceStatus);
        void RequestUpdate(DTOAttendanceStatus dtoAttendanceStatus);
        void RequestDelete(Guid? id);
        #endregion

    }
}
