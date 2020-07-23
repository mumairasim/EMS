using DTORequestStatus = SMS.DTOs.DTOs.RequestStatus;


namespace SMS.Services.Infrastructure
{
    public interface IRequestStatusService
    {
        /// <summary>
        /// Retruns a Single Record of a RequestStatus on SMS Request
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        DTORequestStatus RequestGetByName(string name);
    }
}
