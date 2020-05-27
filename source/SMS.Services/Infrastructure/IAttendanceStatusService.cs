using System;
using System.Collections.Generic;
using DTOAttendanceStatus = SMS.DTOs.DTOs.AttendanceStatus;
namespace SMS.Services.Infrastructure
{
    public interface IAttendanceStatusService
    {
        List<DTOAttendanceStatus> Get();
        DTOAttendanceStatus Get(Guid? id);
        Guid Create(DTOAttendanceStatus dtoDesignation);
        void Update(DTOAttendanceStatus dtoDesignation);
        void Delete(Guid? id);
    }
}
