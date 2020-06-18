﻿using System;
using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.Services.Infrastructure;
using TimeTable = SMS.DATA.Models.TimeTable;
using DTOTimeTable = SMS.DTOs.DTOs.TimeTable;
using SMS.DTOs.ReponseDTOs;

namespace SMS.Services.Implementation
{
    public class TimeTableService : ITimeTableService
    {
        private readonly IRepository<TimeTable> _repository;
        private readonly IMapper _mapper;
        private readonly ITimeTableDetailService _timeTableDetailService;
        public TimeTableService(IRepository<TimeTable> repository, IMapper mapper, ITimeTableDetailService timeTableDetailService)
        {
            _repository = repository;
            _mapper = mapper;
            _timeTableDetailService = timeTableDetailService;
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
    }
}