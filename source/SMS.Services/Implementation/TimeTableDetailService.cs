using System;
using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.DTOs.ReponseDTOs;
using SMS.Services.Infrastructure;
using TimeTableDetail = SMS.DATA.Models.TimeTableDetail;
using DTOTimeTableDetail = SMS.DTOs.DTOs.TimeTableDetail;

namespace SMS.Services.Implementation
{
    public class TimeTableDetailService : ITimeTableDetailService
    {
        private readonly IRepository<TimeTableDetail> _repository;
        private readonly IMapper _mapper;
        private readonly IPeriodService _periodService;
        public TimeTableDetailService(IRepository<TimeTableDetail> repository, IMapper mapper, IPeriodService periodService)
        {
            _repository = repository;
            _mapper = mapper;
            _periodService = periodService;
        }
        public GenericApiResponse Create(DTOTimeTableDetail dtoTimeTableDetail)
        {
            try
            {
                dtoTimeTableDetail.CreatedDate = DateTime.Now;
                dtoTimeTableDetail.IsDeleted = false;
                dtoTimeTableDetail.Id = Guid.NewGuid();
                var timeTableDetail = _repository.Add(_mapper.Map<DTOTimeTableDetail, TimeTableDetail>(dtoTimeTableDetail));
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

    }
}
