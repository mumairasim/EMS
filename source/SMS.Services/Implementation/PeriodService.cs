using System;
using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.DTOs.ReponseDTOs;
using SMS.Services.Infrastructure;
using SMS.REQUESTDATA.Infrastructure;
using Period = SMS.DATA.Models.Period;
using DTOPeriod = SMS.DTOs.DTOs.Period;
using RequestPeriod = SMS.REQUESTDATA.RequestModels.Period;

namespace SMS.Services.Implementation
{
    public class PeriodService : IPeriodService
    {
        private readonly IRepository<Period> _repository;
        private readonly IRequestRepository<RequestPeriod> _requestRepository;
        private readonly IMapper _mapper;
        public PeriodService(IRepository<Period> repository, IRequestRepository<RequestPeriod> requestRepository, IMapper mapper)
        {
            _repository = repository;
            _requestRepository = requestRepository;
            _mapper = mapper;
        }
        #region SMS Section
        public GenericApiResponse Create(DTOPeriod dtoPeriod)
        {
            try
            {
                if (dtoPeriod.StartTime != null && dtoPeriod.EndTime != null && dtoPeriod.CourseId != null &&
                    dtoPeriod.TeacherId != null)
                {
                    dtoPeriod.CreatedDate = DateTime.Now;
                    dtoPeriod.IsDeleted = false;
                    if (dtoPeriod.Id == Guid.Empty)
                    {
                        dtoPeriod.Id = Guid.NewGuid();
                    }
                    HelpingMethodForRelationship(dtoPeriod);
                    _repository.Add(_mapper.Map<DTOPeriod, Period>(dtoPeriod));
                    return PrepareSuccessResponse("success", "");
                }

                return PrepareFailureResponse("Error", "Incomplete Data");
            }
            catch (Exception e)
            {
                return PrepareFailureResponse("error", e.Message);
            }

        }
        private void HelpingMethodForRelationship(DTOPeriod dtoTimeTableDetail)
        {
            dtoTimeTableDetail.CourseId = dtoTimeTableDetail.Course.Id;
            dtoTimeTableDetail.Course = null;
            dtoTimeTableDetail.TeacherId = dtoTimeTableDetail.Employee.Id;
            dtoTimeTableDetail.Employee = null;
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
        public GenericApiResponse RequestCreate(DTOPeriod dtoPeriod)
        {
            try
            {
                if (dtoPeriod.StartTime != null && dtoPeriod.EndTime != null && dtoPeriod.CourseId != null &&
                    dtoPeriod.TeacherId != null)
                {
                    dtoPeriod.CreatedDate = DateTime.Now;
                    dtoPeriod.IsDeleted = false;
                    dtoPeriod.Id = Guid.NewGuid();
                    RequestHelpingMethodForRelationship(dtoPeriod);
                    _requestRepository.Add(_mapper.Map<DTOPeriod, RequestPeriod>(dtoPeriod));
                    return RequestPrepareSuccessResponse("success", "");
                }

                return RequestPrepareFailureResponse("Error", "Incomplete Data");
            }
            catch (Exception e)
            {
                return RequestPrepareFailureResponse("error", e.Message);
            }

        }
        private void RequestHelpingMethodForRelationship(DTOPeriod dtoTimeTableDetail)
        {
            dtoTimeTableDetail.CourseId = dtoTimeTableDetail.Course.Id;
            dtoTimeTableDetail.Course = null;
            dtoTimeTableDetail.TeacherId = dtoTimeTableDetail.Employee.Id;
            dtoTimeTableDetail.Employee = null;
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
