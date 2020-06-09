using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.DATA.Models;
using SMS.DTOs.DTOs;
using SMS.Services.Infrastructure;
using School= SMS.DATA.Models.School;
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
        public SchoolsList Get(int pageNumber, int pageSize)
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
            var schoolRecord = _repository.Get().FirstOrDefault(cl => cl.Id == id && cl.IsDeleted == false);
            var schools = _mapper.Map<School, DTOSchool>(schoolRecord);
            return schools;
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
            var mergedSchool = _mapper.Map(dtoSchool, school) ;
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

    }
}
