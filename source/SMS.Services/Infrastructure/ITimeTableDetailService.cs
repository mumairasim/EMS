using SMS.DTOs.ReponseDTOs;
using DTOTimeTableDetail = SMS.DTOs.DTOs.TimeTableDetail;

namespace SMS.Services.Infrastructure
{
    public interface ITimeTableDetailService
    {
        #region SMS
        GenericApiResponse Create(DTOTimeTableDetail timeTableDetail);
        #endregion

        #region RequestSMS
        GenericApiResponse RequestCreate(DTOTimeTableDetail timeTableDetail);
        #endregion
    }
}





