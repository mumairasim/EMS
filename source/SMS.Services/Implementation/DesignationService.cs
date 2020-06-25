using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.DATA.Models;
using SMS.REQUESTDATA.Infrastructure;
using SMS.Services.Infrastructure;
using DTODesignation = SMS.DTOs.DTOs.Designation;
using ReqDesignation = SMS.REQUESTDATA.RequestModels.Designation;

namespace SMS.Services.Implementation
{
    public class DesignationService : IDesignationService
    {
        private readonly IRepository<Designation> _repository;
        private readonly IRequestRepository<ReqDesignation> _requestRepository;
        private IMapper _mapper;
        public DesignationService(IRepository<Designation> repository, IMapper mapper, IRequestRepository<ReqDesignation> requestRepository)
        {
            _repository = repository;
            _requestRepository = requestRepository;
            _mapper = mapper;
        }
        #region SMS Section
        public List<DTODesignation> Get()
        {
            var designations = _repository.Get().Where(d => d.IsDeleted == false).ToList();
            var designationList = new List<DTODesignation>();
            foreach (var designation in designations)
            {
                designationList.Add(_mapper.Map<Designation, DTODesignation>(designation));
            }
            return designationList;
        }
        public DTODesignation Get(Guid? id)
        {
            if (id == null) return null;
            var designationRecord = _repository.Get().FirstOrDefault(d => d.Id == id &&  d.IsDeleted == false);
            if (designationRecord == null) return null;

            return _mapper.Map<Designation, DTODesignation>(designationRecord);
        }
        public Guid Create(DTODesignation dtoDesignation)
        {
            dtoDesignation.CreatedDate = DateTime.UtcNow;
            dtoDesignation.IsDeleted = false;
            dtoDesignation.Id = Guid.NewGuid();
            _repository.Add(_mapper.Map<DTODesignation, Designation>(dtoDesignation));
            return dtoDesignation.Id;
        }
        public void Update(DTODesignation dtoDesignation)
        {
            var designation = Get(dtoDesignation.Id);
            dtoDesignation.UpdateDate = DateTime.UtcNow;
            var mergedDesignation = _mapper.Map(dtoDesignation, designation);
            _repository.Update(_mapper.Map<DTODesignation, Designation>(mergedDesignation));
        }
        public void Delete(Guid? id)
        {
            if (id == null)
                return;
            var designation = Get(id);
            designation.IsDeleted = true;
            designation.DeletedDate = DateTime.UtcNow;
            _repository.Update(_mapper.Map<DTODesignation, Designation>(designation));
        }
        #endregion

        #region SMS Request Section
       
        public List<DTODesignation> RequestGet()
        {
            var designations = _requestRepository.Get().Where(d => d.IsDeleted == false).ToList();
            var designationList = new List<DTODesignation>();
            foreach (var designation in designations)
            {
                designationList.Add(_mapper.Map<ReqDesignation, DTODesignation>(designation));
            }
            return designationList;
        }
        public DTODesignation RequestGet(Guid? id)
        {
            if (id == null) return null;
            
            var designationRecord = _requestRepository.Get().FirstOrDefault(d => d.Id == id && d.IsDeleted == false);
            if (designationRecord == null) return null;

            return _mapper.Map<ReqDesignation, DTODesignation>(designationRecord);
        }
        public Guid RequestCreate(DTODesignation dtoDesignation)
        {
            dtoDesignation.CreatedDate = DateTime.UtcNow;
            dtoDesignation.IsDeleted = false;
            dtoDesignation.Id = Guid.NewGuid();
            _requestRepository.Add(_mapper.Map<DTODesignation, ReqDesignation>(dtoDesignation));
            return dtoDesignation.Id;
        }
        public void RequestUpdate(DTODesignation dtoDesignation)
        {
            var designation = RequestGet(dtoDesignation.Id);
            dtoDesignation.UpdateDate = DateTime.UtcNow;
            var mergedDesignation = _mapper.Map(dtoDesignation, designation);
            _requestRepository.Update(_mapper.Map<DTODesignation, ReqDesignation>(mergedDesignation));
        }
        public void RequestDelete(Guid? id)
        {
            if (id == null)
                return;
            var designation = RequestGet(id);
            designation.IsDeleted = true;
            designation.DeletedDate = DateTime.UtcNow;
            _requestRepository.Update(_mapper.Map<DTODesignation, ReqDesignation>(designation));
        }
        
        #endregion
    }
}
