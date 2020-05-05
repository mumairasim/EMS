using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.Services.Infrastructure;
using Class = SMS.DATA.Models.Class;
using DTOClass = SMS.DTOs.DTOs.Class;


namespace SMS.Services.Implementation
{
    public class ClassService : IClassService
    {
        private readonly IRepository<Class> _repository;
        private readonly ISchoolService _schoolService;
        private readonly IMapper _mapper;
        public ClassService(IRepository<Class> repository, ISchoolService schoolService, IMapper mapper)
        {
            _repository = repository;
            _schoolService = schoolService;
            _mapper = mapper;
        }
       
        public void Create(DTOClass dtoClass)
        {
            dtoClass.CreatedDate = DateTime.Now;
            dtoClass.IsDeleted = false;
            dtoClass.Id = Guid.NewGuid();
            dtoClass.SchoolId = _schoolService.Create(dtoClass.School);
            dtoClass.School = null;
            _repository.Add(_mapper.Map<DTOClass, Class>(dtoClass));
        }
        public List<DTOClass> Get()
        {
            var clasess = _repository.Get().Where(cl => cl.IsDeleted == false).ToList();
            var classList = new List<DTOClass>();
            foreach (var Classes in clasess)
            {
                classList.Add(_mapper.Map<Class, DTOClass>(Classes));
            }
            return classList;
        }
        public DTOClass Get(Guid? id)
        {
            var schoolRecord = _schoolService.Get(id);
            if (schoolRecord == null) return null;
            var classRecord = _repository.Get().FirstOrDefault(cl => cl.SchoolId == schoolRecord.Id && cl.IsDeleted == false);
            var classes = _mapper.Map<Class, DTOClass>(classRecord);
            //return _mapper.Map(studentRecord, dto); // just for example if need to map two sources in one model
            return classes;
        }
        public void Update(DTOClass dtoClass)
        {
            var Classes = Get(dtoClass.SchoolId);
            dtoClass.UpdateDate = DateTime.Now;
            var mergedClass = _mapper.Map(dtoClass, Classes);
            _schoolService.Update(mergedClass.School);
            _repository.Update(_mapper.Map<DTOClass, Class>(mergedClass));
        }
        public void Delete(Guid? id)
        {
            if (id == null)
                return;
            var classes = Get(id);
            classes.IsDeleted = true;
            classes.DeletedDate = DateTime.Now;
            _schoolService.Delete(classes.SchoolId);
            _repository.Update(_mapper.Map<DTOClass, Class>(classes));
        }

    }
}




