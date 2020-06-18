using SMS.DTOs.ReponseDTOs;
using DTOTimeTable = SMS.DTOs.DTOs.TimeTable;

namespace SMS.Services.Infrastructure
{
    public interface ITimeTableService
    {
        GenericApiResponse Create(DTOTimeTable teacherDiary);
    }
}





