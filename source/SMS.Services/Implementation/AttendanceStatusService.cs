using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.DATA.Models;
using SMS.REQUESTDATA.Infrastructure;
using SMS.Services.Infrastructure;
using DTOAttendanceStatus = SMS.DTOs.DTOs.AttendanceStatus;
using ReqAttendanceStatus = SMS.REQUESTDATA.RequestModels.AttendanceStatus;

namespace SMS.Services.Implementation
{
    public class AttendanceStatusService : IAttendanceStatusService
    {
        private readonly IRepository<AttendanceStatus> _repository;
        private readonly IRequestRepository<ReqAttendanceStatus> _requestRepository;
        private IMapper _mapper;
        public AttendanceStatusService(IRepository<AttendanceStatus> repository, IRequestRepository<ReqAttendanceStatus> requestRepository, IMapper mapper)
        {
            _repository = repository;
            _requestRepository = requestRepository;
            _mapper = mapper;
        }
        #region SMS Section
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
            dtoAttendanceStatus.CreatedDate = DateTime.UtcNow;
            dtoAttendanceStatus.IsDeleted = false;
            dtoAttendanceStatus.Id = Guid.NewGuid();
            _repository.Add(_mapper.Map<DTOAttendanceStatus, AttendanceStatus>(dtoAttendanceStatus));
            return dtoAttendanceStatus.Id;
        }
        public void Update(DTOAttendanceStatus dtoAttendanceStatus)
        {
            var attendanceStatus = Get(dtoAttendanceStatus.Id);
            dtoAttendanceStatus.UpdateDate = DateTime.UtcNow;
            var mergedAttendanceStatus = _mapper.Map(dtoAttendanceStatus, attendanceStatus);
            _repository.Update(_mapper.Map<DTOAttendanceStatus, AttendanceStatus>(mergedAttendanceStatus));
        }
        public void Delete(Guid? id)
        {
            if (id == null)
                return;
            var attendanceStatus = Get(id);
            attendanceStatus.IsDeleted = true;
            attendanceStatus.DeletedDate = DateTime.UtcNow;
            _repository.Update(_mapper.Map<DTOAttendanceStatus, AttendanceStatus>(attendanceStatus));
        }
        #endregion

        
        #region SMS Request Section
        public List<DTOAttendanceStatus> RequestGet()
        {
            var attendanceStatusList = _requestRepository.Get().Where(asl => asl.IsDeleted != true).ToList();
            var attendanceStatusDtoList = new List<DTOAttendanceStatus>();
            foreach (var attendanceStatus in attendanceStatusList)
            {
                attendanceStatusDtoList.Add(_mapper.Map<ReqAttendanceStatus, DTOAttendanceStatus>(attendanceStatus));
            }
            return attendanceStatusDtoList;
        }
        public DTOAttendanceStatus RequestGet(Guid? id)
        {
            if (id == null) return null;
            var attendanceStatusRecord = _requestRepository.Get().FirstOrDefault(asl => asl.IsDeleted != true && asl.Id == id);
            if (attendanceStatusRecord == null) return null;

            return _mapper.Map<ReqAttendanceStatus, DTOAttendanceStatus>(attendanceStatusRecord);
        }
        public Guid RequestCreate(DTOAttendanceStatus dtoAttendanceStatus)
        {
            dtoAttendanceStatus.CreatedDate = DateTime.UtcNow;
            dtoAttendanceStatus.IsDeleted = false;
            dtoAttendanceStatus.Id = Guid.NewGuid();
            _requestRepository.Add(_mapper.Map<DTOAttendanceStatus, ReqAttendanceStatus>(dtoAttendanceStatus));
            return dtoAttendanceStatus.Id;
        }
        public void RequestUpdate(DTOAttendanceStatus dtoAttendanceStatus)
        {
            var attendanceStatus = RequestGet(dtoAttendanceStatus.Id);
            dtoAttendanceStatus.UpdateDate = DateTime.UtcNow;
            var mergedAttendanceStatus = _mapper.Map(dtoAttendanceStatus, attendanceStatus);
            _requestRepository.Update(_mapper.Map<DTOAttendanceStatus, ReqAttendanceStatus>(mergedAttendanceStatus));
        }
        public void RequestDelete(Guid? id)
        {
            if (id == null)
                return;
            var attendanceStatus = RequestGet(id);
            attendanceStatus.IsDeleted = true;
            attendanceStatus.DeletedDate = DateTime.UtcNow;
            _requestRepository.Update(_mapper.Map<DTOAttendanceStatus, ReqAttendanceStatus>(attendanceStatus));
        }
        #endregion
      

    }
}
