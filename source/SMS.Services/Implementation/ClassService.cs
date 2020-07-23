using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.REQUESTDATA.Infrastructure;
using SMS.Services.Infrastructure;
using Class = SMS.DATA.Models.Class;
using DTOClass = SMS.DTOs.DTOs.Class;
using ReqClass = SMS.REQUESTDATA.RequestModels.Class;


namespace SMS.Services.Implementation
{
    public class ClassService : IClassService
    {
        private readonly IRepository<Class> _repository;
        private readonly IRequestRepository<ReqClass> _requestRepository;
        private readonly IMapper _mapper;
        public ClassService(IRepository<Class> repository, IMapper mapper, IRequestRepository<ReqClass> requestRepository)
        {
            _repository = repository;
            _requestRepository = requestRepository;
            _mapper = mapper;
        }

        #region SMS Section
        public void Create(DTOClass dtoClass)
        {
            dtoClass.CreatedDate = DateTime.UtcNow;
            dtoClass.IsDeleted = false;
            dtoClass.Id = Guid.NewGuid();
            dtoClass.School = null;
            _repository.Add(_mapper.Map<DTOClass, Class>(dtoClass));
        }
        public List<DTOClass> Get()
        {
            var clasess = _repository.Get().Where(cl => cl.IsDeleted == false).ToList();
            var classList = new List<DTOClass>();
            foreach (var itemClass in clasess)
            {
                classList.Add(_mapper.Map<Class, DTOClass>(itemClass));
            }
            return classList;
        }
        public DTOClass Get(Guid? id)
        {
            var classRecord = _repository.Get().FirstOrDefault(cl => cl.Id == id && cl.IsDeleted == false);
            var classes = _mapper.Map<Class, DTOClass>(classRecord);

            return classes;
        }
        public List<DTOClass> GetBySchool(Guid? schoolId)
        {
            var classes = _repository.Get().Where(cl => cl.SchoolId == schoolId && cl.IsDeleted == false).ToList();
            var classList = new List<DTOClass>();
            foreach (var itemClass in classes)
            {
                classList.Add(_mapper.Map<Class, DTOClass>(itemClass));
            }
            return classList;
        }
        public void Update(DTOClass dtoClass)
        {
            var Classes = Get(dtoClass.SchoolId);
            dtoClass.UpdateDate = DateTime.UtcNow;
            var mergedClass = _mapper.Map(dtoClass, Classes);
            _repository.Update(_mapper.Map<DTOClass, Class>(mergedClass));
        }
        public void Delete(Guid? id)
        {
            if (id == null)
                return;
            var classes = Get(id);
            classes.IsDeleted = true;
            classes.DeletedDate = DateTime.UtcNow;
            _repository.Update(_mapper.Map<DTOClass, Class>(classes));
        }
        #endregion

        #region SMS Request Section
       
        public List<DTOClass> RequestGet()
        {
            var clasess = _requestRepository.Get().Where(cl => cl.IsDeleted == false).ToList();
            var classList = new List<DTOClass>();
            foreach (var itemClass in clasess)
            {
                classList.Add(_mapper.Map<ReqClass, DTOClass>(itemClass));
            }
            return classList;
        }
        public DTOClass RequestGet(Guid? id)
        {
            var classRecord = _requestRepository.Get().FirstOrDefault(cl => cl.Id == id && cl.IsDeleted == false);
            var classes = _mapper.Map<ReqClass, DTOClass>(classRecord);

            return classes;
        }
        //public List<DTOClass> RequestGetBySchool(Guid? schoolId)
        //{
        //    var classes = _repository.Get().Where(cl => cl.SchoolId == schoolId && cl.IsDeleted == false).ToList();
        //    var classList = new List<DTOClass>();
        //    foreach (var itemClass in classes)
        //    {
        //        classList.Add(_mapper.Map<Class, DTOClass>(itemClass));
        //    }
        //    return classList;
        //}

        public void RequestCreate(DTOClass dtoClass)
        {
            dtoClass.CreatedDate = DateTime.UtcNow;
            dtoClass.IsDeleted = false;
            dtoClass.Id = Guid.NewGuid();
            dtoClass.School = null;
            _requestRepository.Add(_mapper.Map<DTOClass, ReqClass>(dtoClass));
        }
        public void RequestUpdate(DTOClass dtoClass)
        {
            var Classes = RequestGet(dtoClass.SchoolId);
            dtoClass.UpdateDate = DateTime.UtcNow;
            var mergedClass = _mapper.Map(dtoClass, Classes);
            _requestRepository.Update(_mapper.Map<DTOClass, ReqClass>(mergedClass));
        }
        public void RequestDelete(Guid? id)
        {
            if (id == null)
                return;
            var classes = RequestGet(id);
            classes.IsDeleted = true;
            classes.DeletedDate = DateTime.UtcNow;
            _requestRepository.Update(_mapper.Map<DTOClass, ReqClass>(classes));
        }
        #endregion

    }
}




