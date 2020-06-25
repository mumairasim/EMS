using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.DATA.Models;
using SMS.Services.Infrastructure;
using SMS.REQUESTDATA.Infrastructure;
using RequestPerson = SMS.REQUESTDATA.RequestModels.Person;
using DTOPerson = SMS.DTOs.DTOs.Person;

namespace SMS.Services.Implementation
{
    public class PersonService : IPersonService
    {
        private readonly IRepository<Person> _repository;
        private readonly IRequestRepository<RequestPerson> _requestRepository;
        private IMapper _mapper;
        public PersonService(IRepository<Person> repository, IRequestRepository<RequestPerson> requestRepository, IMapper mapper)
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
            dtoPerson.Id = Guid.NewGuid();
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

        #region RequestSMS Section
        public List<DTOPerson> RequestGet()
        {
            var people = _requestRepository.Get().ToList();
            var peopleList = new List<DTOPerson>();
            foreach (var person in people)
            {
                peopleList.Add(_mapper.Map<RequestPerson, DTOPerson>(person));
            }
            return peopleList;
        }
        public DTOPerson RequestGet(Guid? id)
        {
            if (id == null) return null;
            var personRecord = _requestRepository.Get().FirstOrDefault(p => p.Id == id);
            if (personRecord == null) return null;

            return _mapper.Map<RequestPerson, DTOPerson>(personRecord);
        }

        public Guid RequestCreate(DTOPerson dtoPerson)
        {
            dtoPerson.CreatedDate = DateTime.UtcNow;
            dtoPerson.IsDeleted = false;
            dtoPerson.Id = Guid.NewGuid();
            _requestRepository.Add(_mapper.Map<DTOPerson, RequestPerson>(dtoPerson));
            return dtoPerson.Id;
        }
        public void RequestUpdate(DTOPerson dtoPerson)
        {
            var person = Get(dtoPerson.Id);
            dtoPerson.UpdateDate = DateTime.UtcNow;
            var mergedPerson = _mapper.Map(dtoPerson, person);
            _requestRepository.Update(_mapper.Map<DTOPerson, RequestPerson>(mergedPerson));
        }
        public void RequestDelete(Guid? id)
        {
            if (id == null)
                return;
            var person = Get(id);
            person.IsDeleted = true;
            person.DeletedDate = DateTime.UtcNow;
            _requestRepository.Update(_mapper.Map<DTOPerson, RequestPerson>(person));
        }
        #endregion
    }
}
