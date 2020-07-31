using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.DATA.Models;
using SMS.REQUESTDATA.Infrastructure;
using SMS.Services.Infrastructure;
using SMS.REQUESTDATA.Infrastructure;
using RequestPerson = SMS.REQUESTDATA.RequestModels.Person;
using DTOPerson = SMS.DTOs.DTOs.Person;
using ReqPerson = SMS.REQUESTDATA.RequestModels.Person;


namespace SMS.Services.Implementation
{
    public class PersonService : IPersonService
    {
        private readonly IRepository<Person> _repository;
        private readonly IRequestRepository<ReqPerson> _requestRepository;
        private IMapper _mapper;
        public PersonService(IRepository<Person> repository, IMapper mapper, IRequestRepository<ReqPerson> requestRepository)
        {
            _repository = repository;
            _requestRepository = requestRepository;
            _mapper = mapper;
        }
        #region SMS Section
        public List<DTOPerson> Get()
        {
            var people = _repository.Get().ToList();
            var peopleList = new List<DTOPerson>();
            foreach (var person in people)
            {
                peopleList.Add(_mapper.Map<Person, DTOPerson>(person));
            }
            return peopleList;
        }
        public DTOPerson Get(Guid? id)
        {
            if (id == null) return null;
            var personRecord = _repository.Get().FirstOrDefault(p => p.Id == id);
            if (personRecord == null) return null;

            return _mapper.Map<Person, DTOPerson>(personRecord);
        }

        public Guid Create(DTOPerson dtoPerson)
        {
            dtoPerson.CreatedDate = DateTime.UtcNow;
            dtoPerson.IsDeleted = false;

            if (dtoPerson.Id == Guid.Empty)
            {
                dtoPerson.Id = Guid.NewGuid();
            }
            _repository.Add(_mapper.Map<DTOPerson, Person>(dtoPerson));
            return dtoPerson.Id;
        }
        public void Update(DTOPerson dtoPerson)
        {
            var person = Get(dtoPerson.Id);
            dtoPerson.UpdateDate = DateTime.UtcNow;
            var mergedPerson = _mapper.Map(dtoPerson, person);
            _repository.Update(_mapper.Map<DTOPerson, Person>(mergedPerson));
        }
        public void Delete(Guid? id)
        {
            if (id == null)
                return;
            var person = Get(id);
            person.IsDeleted = true;
            person.DeletedDate = DateTime.UtcNow;
            _repository.Update(_mapper.Map<DTOPerson, Person>(person));
        }
        #endregion

        #region SMS Request Section
        public List<DTOPerson> RequestGet()
        {
            var people = _requestRepository.Get().ToList();
            var peopleList = new List<DTOPerson>();
            foreach (var person in people)
            {
                peopleList.Add(_mapper.Map<ReqPerson, DTOPerson>(person));
            }
            return peopleList;
        }
        public DTOPerson RequestGet(Guid? id)
        {
            if (id == null) return null;
            var personRecord = _requestRepository.Get().FirstOrDefault(p => p.Id == id);
            if (personRecord == null) return null;

            return _mapper.Map<ReqPerson, DTOPerson>(personRecord);
        }

        public Guid RequestCreate(DTOPerson dtoPerson)
        {
            dtoPerson.CreatedDate = DateTime.UtcNow;
            dtoPerson.IsDeleted = false;
            dtoPerson.Id = Guid.NewGuid();
            _requestRepository.Add(_mapper.Map<DTOPerson, ReqPerson>(dtoPerson));
            return dtoPerson.Id;
        }
        public void RequestUpdate(DTOPerson dtoPerson)
        {
            var person = RequestGet(dtoPerson.Id);
            dtoPerson.UpdateDate = DateTime.UtcNow;
            var mergedPerson = _mapper.Map(dtoPerson, person);
            _requestRepository.Update(_mapper.Map<DTOPerson, ReqPerson>(mergedPerson));
        }
        public void RequestDelete(Guid? id)
        {
            if (id == null)
                return;
            var person = RequestGet(id);
            person.IsDeleted = true;
            person.DeletedDate = DateTime.UtcNow;
            _requestRepository.Update(_mapper.Map<DTOPerson, ReqPerson>(person));
        }
        #endregion
    }
}
