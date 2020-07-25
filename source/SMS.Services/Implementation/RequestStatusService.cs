using System.Collections.Generic;
using AutoMapper;
using SMS.REQUESTDATA.Infrastructure;
using SMS.Services.Infrastructure;
using System.Linq;
using DTORequestStatus = SMS.DTOs.DTOs.RequestStatus;
using RequestStatus = SMS.REQUESTDATA.RequestModels.RequestStatus;


namespace SMS.Services.Implementation
{
    public class RequestStatusService : IRequestStatusService
    {
        #region Properties
        private readonly IRequestRepository<RequestStatus> _requestRepository;
        private IMapper _mapper;
        #endregion

        #region Init

        public RequestStatusService(IMapper mapper, IRequestRepository<RequestStatus> requestRepository)
        {
            _requestRepository = requestRepository;
            _mapper = mapper;
        }

        #endregion

        /// <summary>
        /// Retruns a Single Record of a Worksheet of SMS Request
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DTORequestStatus RequestGetByName(string name)
        {
            if (name == null)
            {
                return null;
            }

            var reqStatus = _requestRepository.Get().FirstOrDefault(x => x.Type == name && (x.IsDeleted == false || x.IsDeleted == null));
            var reqStatusDto = _mapper.Map<RequestStatus, DTORequestStatus>(reqStatus);

            return reqStatusDto;
        }
        public List<DTORequestStatus> RequestGetAll()
        {
            var reqStatus = _requestRepository.Get().Where(x => x.IsDeleted == false || x.IsDeleted == null).ToList();
            var reqStatusDto = _mapper.Map<List<RequestStatus>, List<DTORequestStatus>>(reqStatus);
            return reqStatusDto;
        }
    }
}
