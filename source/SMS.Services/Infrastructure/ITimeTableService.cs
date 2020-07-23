using System;
using SMS.DTOs.DTOs;
using SMS.DTOs.ReponseDTOs;
using DTOTimeTable = SMS.DTOs.DTOs.TimeTable;

namespace SMS.Services.Infrastructure
{
    public interface ITimeTableService
    {
        TimeTableList Get(Guid? schoolId, Guid? classId, int pageNumber, int pageSize);
        GenericApiResponse Create(DTOTimeTable teacherDiary);
    }
}





