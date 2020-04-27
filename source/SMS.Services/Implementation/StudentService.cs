using System;
using System.Linq;
using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.DATA.Models;
using SMS.REQUESTDATA.Infrastructure;
using SMS.Services.Infrastructure;
using Student = SMS.DATA.Models.Student;
using RequestStudent = SMS.REQUESTDATA.RequestModels.Student;
using DTOStudent = SMS.DTOs.DTOs.Student;
using Person = SMS.DATA.Models.Person;
using RequestPerson = SMS.REQUESTDATA.RequestModels.Person;

namespace SMS.Services.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _repository;
        private readonly IRepository<Person> _personRepository;
        private readonly IRequestRepository<RequestStudent> _requestRepository;
        private IMapper _mapper;
        public StudentService(IRepository<Student> repository, IRepository<Person> personRepository, IRequestRepository<RequestStudent> requestRepository, IMapper mapper)
        {
            _repository = repository;
            _personRepository = personRepository;
            _requestRepository = requestRepository;
            _mapper = mapper;
        }
        public string Get()
        {
            var studentList = _repository.Get().ToList();
            var studentRequestList = _requestRepository.Get().ToList();
            return "Hello World";
        }

        public DTOStudent GetbyId(Guid id)
        {
            var personRecord = _personRepository.Get().FirstOrDefault(p => p.Id == id);
            if (personRecord == null)
            {
                return null;
            }
            var studentRecord = _repository.Get().FirstOrDefault(st => st.Id == personRecord.Id);
            var dto = _mapper.Map<DTOStudent>(personRecord);
            return _mapper.Map(studentRecord, dto);
        }
    }
}
