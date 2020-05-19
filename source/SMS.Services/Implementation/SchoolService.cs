using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.DATA.Models;
using SMS.Services.Infrastructure;
using DTOSchool = SMS.DTOs.DTOs.School;

namespace SMS.Services.Implementation
{
    public class SchoolService : ISchoolService
    {
        private readonly IRepository<School> _repository;
        private IMapper _mapper;
        public SchoolService(IRepository<School> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public List<DTOSchool> Get(int pageNumber, int pageSize)
        {
            var Schools = _repository.Get().Where(cl => cl.IsDeleted == false).OrderByDescending(st => st.Id).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            var schoolList = new List<DTOSchool>();
            foreach (var schools in Schools)
            {
                schoolList.Add(_mapper.Map<School, DTOSchool>(schools));
            }
            return schoolList;
        }
        public DTOSchool Get(Guid? id)
        {
            if (id == null) return null;
            var schoolRecord = _repository.Get().FirstOrDefault(s => s.Id == id);
            if (schoolRecord == null) return null;

            return _mapper.Map<School, DTOSchool>(schoolRecord);
        }
        public Guid Create(DTOSchool dtoSchool)
        {
            dtoSchool.CreatedDate = DateTime.Now;
            dtoSchool.IsDeleted = false;
            dtoSchool.Id = Guid.NewGuid();
            _repository.Add(_mapper.Map<DTOSchool, School>(dtoSchool));
            return dtoSchool.Id;
        }
        public void Update(DTOSchool dtoSchool)
        {
            var school = Get(dtoSchool.Id);
            dtoSchool.UpdateDate = DateTime.Now;
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
            school.DeletedDate = DateTime.Now;

            _repository.Update(_mapper.Map<DTOSchool, School>(school));
        }

    }
}
