using SMS.DTOs.ReponseDTOs;
using DTOPeriod= SMS.DTOs.DTOs.Period;

namespace SMS.Services.Infrastructure
{
    public interface IPeriodService
    {
        GenericApiResponse Create(DTOPeriod timeTableDetail);
    }
}





