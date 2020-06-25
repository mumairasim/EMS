using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.DTOs.DTOs;
using SMS.REQUESTDATA.Infrastructure;
using SMS.Services.Infrastructure;
using TimeTable = SMS.DATA.Models.TimeTable;
using DTOTimeTable = SMS.DTOs.DTOs.TimeTable;
using RequestTimeTable = SMS.REQUESTDATA.RequestModels.TimeTable;
using SMS.DTOs.ReponseDTOs;

namespace SMS.Services.Implementation
{
    public class TimeTableService : ITimeTableService
    {
        private readonly IRepository<TimeTable> _repository;
        private readonly IRequestRepository<RequestTimeTable> _requestRepository;
        private readonly IMapper _mapper;
        private readonly ITimeTableDetailService _timeTableDetailService;
        public TimeTableService(IRepository<TimeTable> repository, IRequestRepository<RequestTimeTable> requestRepository, IMapper mapper, ITimeTableDetailService timeTableDetailService)
        {
            _repository = repository;
            _requestRepository = requestRepository;
            _mapper = mapper;
            _timeTableDetailService = timeTableDetailService;
        }
        #region SMS Section
        public TimeTableList Get(Guid? schoolId, Guid? classId, int pageNumber, int pageSize)
        {
            var timeTables = _repository.Get().Where(tt => tt.IsDeleted == false && tt.SchoolId==schoolId).OrderByDescending(lp => lp.CreatedDate).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            var timeTableCount = _repository.Get().Count(st => st.IsDeleted == false);
            var timeTableList = new List<DTOTimeTable>();
            foreach (var timeTable in timeTables)
            {
                timeTableList.Add(_mapper.Map<TimeTable, DTOTimeTable>(timeTable));
            }
            var timeTablesList = new TimeTableList()
            {
                TimeTables = timeTableList,
                TimeTablesCount = timeTableCount
            };
            return timeTablesList;
        }
        public GenericApiResponse Create(DTOTimeTable dtoTimeTable)
        {
            try
            {
                dtoTimeTable.CreatedDate = DateTime.Now;
                dtoTimeTable.IsDeleted = false;
                dtoTimeTable.Id = Guid.NewGuid();
                HelpingMethodForRelationship(dtoTimeTable);
                var timeTable = _repository.Add(_mapper.Map<DTOTimeTable, TimeTable>(dtoTimeTable));
                if (dtoTimeTable.TimeTableDetails != null)
                    foreach (var timeTableDetail in dtoTimeTable.TimeTableDetails)
                    {
                        timeTableDetail.TimeTableId = timeTable.Id;
                        timeTableDetail.CreatedBy = dtoTimeTable.CreatedBy;
                        _timeTableDetailService.Create(timeTableDetail);
                    }
                return PrepareSuccessResponse("success", "");
            }
            catch (Exception e)
            {
                return PrepareFailureResponse("error", e.Message);
            }

        }
        private void HelpingMethodForRelationship(DTOTimeTable dtoTimeTable)
        {
            dtoTimeTable.SchoolId = dtoTimeTable.School.Id;
            dtoTimeTable.School = null;
            dtoTimeTable.ClassId = dtoTimeTable.Class.Id;
            dtoTimeTable.Class = null;
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
        public TimeTableList RequestGet(Guid? schoolId, Guid? classId, int pageNumber, int pageSize)
        {
            var timeTables = _requestRepository.Get().Where(tt => tt.IsDeleted == false && tt.SchoolId == schoolId).OrderByDescending(lp => lp.CreatedDate).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            var timeTableCount = _requestRepository.Get().Count(st => st.IsDeleted == false);
            var timeTableList = new List<DTOTimeTable>();
            foreach (var timeTable in timeTables)
            {
                timeTableList.Add(_mapper.Map<RequestTimeTable, DTOTimeTable>(timeTable));
            }
            var timeTablesList = new TimeTableList()
            {
                TimeTables = timeTableList,
                TimeTablesCount = timeTableCount
            };
            return timeTablesList;
        }
        public GenericApiResponse RequestCreate(DTOTimeTable dtoTimeTable)
        {
            try
            {
                dtoTimeTable.CreatedDate = DateTime.Now;
                dtoTimeTable.IsDeleted = false;
                dtoTimeTable.Id = Guid.NewGuid();
                RequestHelpingMethodForRelationship(dtoTimeTable);
                var timeTable = _requestRepository.Add(_mapper.Map<DTOTimeTable, RequestTimeTable>(dtoTimeTable));
                if (dtoTimeTable.TimeTableDetails != null)
                    foreach (var timeTableDetail in dtoTimeTable.TimeTableDetails)
                    {
                        timeTableDetail.TimeTableId = timeTable.Id;
                        timeTableDetail.CreatedBy = dtoTimeTable.CreatedBy;
                        _timeTableDetailService.Create(timeTableDetail);
                    }
                return RequestPrepareSuccessResponse("success", "");
            }
            catch (Exception e)
            {
                return RequestPrepareFailureResponse("error", e.Message);
            }

        }
        private void RequestHelpingMethodForRelationship(DTOTimeTable dtoTimeTable)
        {
            dtoTimeTable.SchoolId = dtoTimeTable.School.Id;
            dtoTimeTable.School = null;
            dtoTimeTable.ClassId = dtoTimeTable.Class.Id;
            dtoTimeTable.Class = null;
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
