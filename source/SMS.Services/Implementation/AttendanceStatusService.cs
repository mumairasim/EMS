﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.DATA.Models;
using SMS.Services.Infrastructure;
using DTOAttendanceStatus = SMS.DTOs.DTOs.AttendanceStatus;

namespace SMS.Services.Implementation
{
    public class AttendanceStatusService : IAttendanceStatusService
    {
        private readonly IRepository<AttendanceStatus> _repository;
        private IMapper _mapper;
        public AttendanceStatusService(IRepository<AttendanceStatus> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public List<DTOAttendanceStatus> Get()
        {
            var attendanceStatusList = _repository.Get().Where(asl => asl.IsDeleted != true).ToList();
            var attendanceStatusDtoList = new List<DTOAttendanceStatus>();
            foreach (var attendanceStatus in attendanceStatusList)
            {
                attendanceStatusDtoList.Add(_mapper.Map<AttendanceStatus, DTOAttendanceStatus>(attendanceStatus));
            }
            return attendanceStatusDtoList;
        }
        public DTOAttendanceStatus Get(Guid? id)
        {
            if (id == null) return null;
            var attendanceStatusRecord = _repository.Get().FirstOrDefault(asl => asl.IsDeleted != true && asl.Id == id);
            if (attendanceStatusRecord == null) return null;

            return _mapper.Map<AttendanceStatus, DTOAttendanceStatus>(attendanceStatusRecord);
        }
        public Guid Create(DTOAttendanceStatus dtoAttendanceStatus)
        {
            dtoAttendanceStatus.CreatedDate = DateTime.Now;
            dtoAttendanceStatus.IsDeleted = false;
            dtoAttendanceStatus.Id = Guid.NewGuid();
            _repository.Add(_mapper.Map<DTOAttendanceStatus, AttendanceStatus>(dtoAttendanceStatus));
            return dtoAttendanceStatus.Id;
        }
        public void Update(DTOAttendanceStatus dtoAttendanceStatus)
        {
            var attendanceStatus = Get(dtoAttendanceStatus.Id);
            dtoAttendanceStatus.UpdateDate = DateTime.Now;
            var mergedAttendanceStatus = _mapper.Map(dtoAttendanceStatus, attendanceStatus);
            _repository.Update(_mapper.Map<DTOAttendanceStatus, AttendanceStatus>(mergedAttendanceStatus));
        }
        public void Delete(Guid? id)
        {
            if (id == null)
                return;
            var attendanceStatus = Get(id);
            attendanceStatus.IsDeleted = true;
            attendanceStatus.DeletedDate = DateTime.Now;
            _repository.Update(_mapper.Map<DTOAttendanceStatus, AttendanceStatus>(attendanceStatus));
        }
    }
}