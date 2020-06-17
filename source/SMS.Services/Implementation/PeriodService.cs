using System;
using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.DTOs.ReponseDTOs;
using SMS.Services.Infrastructure;
using Period = SMS.DATA.Models.Period;
using DTOPeriod = SMS.DTOs.DTOs.Period;

namespace SMS.Services.Implementation
{
    public class PeriodService : IPeriodService
    {
        private readonly IRepository<Period> _repository;
        private readonly IMapper _mapper;
        public PeriodService(IRepository<Period> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public GenericApiResponse Create(DTOPeriod dtoPeriod)
        {
            try
            {
                dtoPeriod.CreatedDate = DateTime.Now;
                dtoPeriod.IsDeleted = false;
                dtoPeriod.Id = Guid.NewGuid();
                HelpingMethodForRelationship(dtoPeriod);
                _repository.Add(_mapper.Map<DTOPeriod, Period>(dtoPeriod));
                return PrepareSuccessResponse("success", "");
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

    }
}
