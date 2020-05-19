using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SMS.DTOs.DTOs;
using SMS.DATA.Infrastructure;
using SMS.Services.Infrastructure;
using Class = SMS.DATA.Models.Class;
using DTOClass = SMS.DTOs.DTOs.Class;


namespace SMS.Services.Implementation
{
    public class ClassService : IClassService
    {
        private readonly IRepository<Class> _repository;
        private readonly IMapper _mapper;
        public ClassService(IRepository<Class> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Create(DTOClass dtoClass)
        {
            dtoClass.CreatedDate = DateTime.Now;
            dtoClass.IsDeleted = false;
            dtoClass.Id = Guid.NewGuid();
            dtoClass.School = null;
            _repository.Add(_mapper.Map<DTOClass, Class>(dtoClass));
        }
        public List<DTOClass> Get(int pageNumber, int pageSize)
        {
            var clasess = _repository.Get().Where(cl => cl.IsDeleted == false).OrderByDescending(st => st.Id).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            var classList = new List<DTOClass>();
            foreach (var Classes in clasess)
            {
                classList.Add(_mapper.Map<Class, DTOClass>(Classes));
            }
            return classList;
        }
        public DTOClass Get(Guid? id)
        {
            var classRecord = _repository.Get().FirstOrDefault(cl => cl.Id == id && cl.IsDeleted == false);
            var classes = _mapper.Map<Class, DTOClass>(classRecord);

            return classes;
        }
        public void Update(DTOClass dtoClass)
        {
            var Classes = Get(dtoClass.SchoolId);
            dtoClass.UpdateDate = DateTime.Now;
            var mergedClass = _mapper.Map(dtoClass, Classes);
            _repository.Update(_mapper.Map<DTOClass, Class>(mergedClass));
        }
        public void Delete(Guid? id, string DeletedBy)
        {
            if (id == null)
                return;
            var classes = Get(id);
            classes.IsDeleted = true;
            classes.DeletedBy = DeletedBy;
            classes.DeletedDate = DateTime.Now;
            _repository.Update(_mapper.Map<DTOClass, Class>(classes));
        }
        private void HelpingMethodForRelationship(DTOClass dtoClass)
        {
            dtoClass.SchoolId = dtoClass.School.Id;
            dtoClass.School = null;
        }
    }
}




