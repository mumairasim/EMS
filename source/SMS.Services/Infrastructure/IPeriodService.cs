using SMS.DTOs.ReponseDTOs;
using DTOPeriod= SMS.DTOs.DTOs.Period;

namespace SMS.Services.Infrastructure
{
    public interface IPeriodService
    {
        #region SMS Section
        GenericApiResponse Create(DTOPeriod timeTableDetail);
        #endregion

        #region RequestSMS Section
        GenericApiResponse RequestCreate(DTOPeriod timeTableDetail);
        #endregion
    }
}





