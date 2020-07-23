using System;
using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.DTOs.ReponseDTOs;
using SMS.REQUESTDATA.Infrastructure;
using SMS.Services.Infrastructure;
using TimeTableDetail = SMS.DATA.Models.TimeTableDetail;
using DTOTimeTableDetail = SMS.DTOs.DTOs.TimeTableDetail;
using RequestTimeTableDetail = SMS.REQUESTDATA.RequestModels.TimeTableDetail;

namespace SMS.Services.Implementation
{
    public class TimeTableDetailService : ITimeTableDetailService
    {
        private readonly IRepository<TimeTableDetail> _repository;
        private readonly IRequestRepository<RequestTimeTableDetail> _requestRepository;
        private readonly IMapper _mapper;
        private readonly IPeriodService _periodService;
        public TimeTableDetailService(IRepository<TimeTableDetail> repository, IMapper mapper, IRequestRepository<RequestTimeTableDetail> requestRepository, IPeriodService periodService)
        {
            _repository = repository;
            _requestRepository = requestRepository;
            _mapper = mapper;
            _periodService = periodService;
        }
        #region SMS Section
        public GenericApiResponse Create(DTOTimeTableDetail dtoTimeTableDetail)
        {
            try
            {
                dtoTimeTableDetail.CreatedDate = DateTime.Now;
                dtoTimeTableDetail.IsDeleted = false;
                dtoTimeTableDetail.Id = Guid.NewGuid();
                var timeTableDetail = _repository.Add(_mapper.Map<DTOTimeTableDetail, TimeTableDetail>(dtoTimeTableDetail));
                if (dtoTimeTableDetail.Periods != null)
                    foreach (var period in dtoTimeTableDetail.Periods)
                    {
                        period.TimeTableDetailId = timeTableDetail.Id;
                        _periodService.Create(period);
                    }

                return PrepareSuccessResponse("success", "");
            }
            catch (Exception e)
            {
                return PrepareFailureResponse("error", e.Message);
            }
        }
        private GenericApiResponse PrepareFailureResponse(string errorMessage, string descriptionMessage)
        {
            return new GenericApiResponse
            {
                StatusCode = "400",
                Message = errorMessage,
                Description = descriptionMessage
            };
        }
        private GenericApiResponse PrepareSuccessResponse(string message, string descriptionMessage)
        {
            return new GenericApiResponse
            {
                StatusCode = "200",
                Message = message,
                Description = descriptionMessage
            };
        }
        #endregion

        #region RequestSMS Section
        public GenericApiResponse RequestCreate(DTOTimeTableDetail dtoTimeTableDetail)
        {
            try
            {
                dtoTimeTableDetail.CreatedDate = DateTime.Now;
                dtoTimeTableDetail.IsDeleted = false;
                dtoTimeTableDetail.Id = Guid.NewGuid();
                var timeTableDetail = _requestRepository.Add(_mapper.Map<DTOTimeTableDetail, RequestTimeTableDetail>(dtoTimeTableDetail));
                if (dtoTimeTableDetail.Periods != null)
                    foreach (var period in dtoTimeTableDetail.Periods)
                    {
                        period.TimeTableDetailId = timeTableDetail.Id;
                        _periodService.Create(period);
                    }

                return RequestPrepareSuccessResponse("success", "");
            }
            catch (Exception e)
            {
                return RequestPrepareFailureResponse("error", e.Message);
            }
        }
        private GenericApiResponse RequestPrepareFailureResponse(string errorMessage, string descriptionMessage)
        {
            return new GenericApiResponse
            {
                StatusCode = "400",
                Message = errorMessage,
                Description = descriptionMessage
            };
        }
        private GenericApiResponse RequestPrepareSuccessResponse(string message, string descriptionMessage)
        {
            return new GenericApiResponse
            {
                StatusCode = "200",
                Message = message,
                Description = descriptionMessage
            };
        }
        #endregion
    }
}
