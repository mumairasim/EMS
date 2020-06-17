using SMS.DTOs.ReponseDTOs;
using DTOTimeTableDetail = SMS.DTOs.DTOs.TimeTableDetail;

namespace SMS.Services.Infrastructure
{
    public interface ITimeTableDetailService
    {
        GenericApiResponse Create(DTOTimeTableDetail timeTableDetail);
    }
}





