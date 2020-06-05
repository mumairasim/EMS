using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.DATA.Models;
using SMS.Services.Infrastructure;
using DTODesignation = SMS.DTOs.DTOs.Designation;

namespace SMS.Services.Implementation
{
    public class DesignationService : IDesignationService
    {
        private readonly IRepository<Designation> _repository;
        private IMapper _mapper;
        public DesignationService(IRepository<Designation> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public List<DTODesignation> Get()
        {
            var designations= _repository.Get().ToList();
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
            var designationRecord = _repository.Get().FirstOrDefault(d => d.Id == id);
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
    }
}
