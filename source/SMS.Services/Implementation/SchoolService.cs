using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.DATA.Models;
using SMS.REQUESTDATA.Infrastructure;
using SMS.DTOs.DTOs;
using SMS.Services.Infrastructure;
using School= SMS.DATA.Models.School;
using DTOSchool = SMS.DTOs.DTOs.School;
using ReqSchool = SMS.REQUESTDATA.RequestModels.School;

namespace SMS.Services.Implementation
{
    public class SchoolService : ISchoolService
    {
        private readonly IRepository<School> _repository;
        private readonly IRequestRepository<ReqSchool> _requestRepository;
        private readonly IMapper _mapper;
        public SchoolService(IRepository<School> repository, IMapper mapper, IRequestRepository<ReqSchool> requestRepository)
        {
            _repository = repository;
            _requestRepository = requestRepository;
            _mapper = mapper;
        }

        #region SMS Section
        public List<DTOSchool> Get()
        {
            var schools = _repository.Get().Where(cl => cl.IsDeleted == false).OrderByDescending(st => st.Id).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            var SchoolCount = _repository.Get().Where(st => st.IsDeleted == false).Count();
            var schoolTempList = new List<DTOSchool>();
            foreach (var Schools in schools)
            {
                schoolTempList.Add(_mapper.Map<School, DTOSchool>(Schools));
            }
            var schoolsList = new SchoolsList()
            {
                Schools = schoolTempList,
                SchoolsCount = SchoolCount
            };
            return schoolsList;
        }
        public DTOSchool Get(Guid? id)
        {
            if (id == null) return null;
            var schoolRecord = _repository.Get().FirstOrDefault(s => s.Id == id);
            if (schoolRecord == null) return null;

            return _mapper.Map<School, DTOSchool>(schoolRecord);
        }
        public void Create(DTOSchool dtoSchool)
        {
            dtoSchool.CreatedDate = DateTime.UtcNow;
            dtoSchool.IsDeleted = false;
            dtoSchool.Id = Guid.NewGuid();
            _repository.Add(_mapper.Map<DTOSchool, School>(dtoSchool));
        }
        public void Update(DTOSchool dtoSchool)
        {
            var school = Get(dtoSchool.Id);
            dtoSchool.UpdateDate = DateTime.UtcNow;
            var mergedSchool = _mapper.Map(dtoSchool, school);
            _repository.Update(_mapper.Map<DTOSchool, School>(mergedSchool));
        }
        public void Delete(Guid? id, string DeletedBy)
        {
            if (id == null)
                return;
            var school = Get(id);
            school.IsDeleted = true;
            school.DeletedBy = DeletedBy;

            school.DeletedDate = DateTime.UtcNow;
            _repository.Update(_mapper.Map<DTOSchool, School>(school));
        }
        #endregion

        #region SMS Request Section
        public List<DTOSchool> RequestGet()
        {
            var schools = _requestRepository.Get().ToList();
            var schoolList = new List<DTOSchool>();
            foreach (var school in schools)
            {
                schoolList.Add(_mapper.Map<ReqSchool, DTOSchool>(school));
            }
            return schoolList;
        }
        public DTOSchool RequestGet(Guid? id)
        {
            if (id == null) return null;
            var schoolRecord = _requestRepository.Get().FirstOrDefault(s => s.Id == id);
            if (schoolRecord == null) return null;

            return _mapper.Map<ReqSchool, DTOSchool>(schoolRecord);
        }
        public Guid RequestCreate(DTOSchool dtoSchool)
        {
            dtoSchool.CreatedDate = DateTime.UtcNow;
            dtoSchool.IsDeleted = false;
            dtoSchool.Id = Guid.NewGuid();
            _requestRepository.Add(_mapper.Map<DTOSchool, ReqSchool>(dtoSchool));
            return dtoSchool.Id;
        }
        public void RequestUpdate(DTOSchool dtoSchool)
        {
            var school = RequestGet(dtoSchool.Id);
            dtoSchool.UpdateDate = DateTime.UtcNow;
            var mergedSchool = _mapper.Map(dtoSchool, school);
            _requestRepository.Update(_mapper.Map<DTOSchool, ReqSchool>(mergedSchool));
        }
        public void RequestDelete(Guid? id)
        {
            if (id == null)
                return;
            var school = RequestGet(id);
            school.IsDeleted = true;
            school.DeletedDate = DateTime.UtcNow;
            _requestRepository.Update(_mapper.Map<DTOSchool, ReqSchool>(school));
        }
        #endregion

    }
}
