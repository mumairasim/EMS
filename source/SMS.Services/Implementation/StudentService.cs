using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.Services.Infrastructure;
using Student = SMS.DATA.Models.Student;
using DTOStudent = SMS.DTOs.DTOs.Student;

namespace SMS.Services.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _repository;
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;
        public StudentService(IRepository<Student> repository, IPersonService personService, IMapper mapper)
        {
            _repository = repository;
            _personService = personService;
            _mapper = mapper;
        }
        public List<DTOStudent> Get()
        {
            var students = _repository.Get().Where(st => st.IsDeleted == false).ToList();
            var studentList = new List<DTOStudent>();
            foreach (var student in students)
            {
                studentList.Add(_mapper.Map<Student, DTOStudent>(student));
            }
            return studentList;
        }

        public DTOStudent Get(Guid? id)
        {
            var personRecord = _personService.Get(id);
            if (personRecord == null) return null;
            var studentRecord = _repository.Get().FirstOrDefault(st => st.PersonId == personRecord.Id && st.IsDeleted == false);
            var student = _mapper.Map<Student, DTOStudent>(studentRecord);
            //return _mapper.Map(studentRecord, dto); // just for example if need to map two sources in one model
            return student;
        }

        public void Create(DTOStudent dtoStudent)
        {
            dtoStudent.CreatedDate = DateTime.Now;
            dtoStudent.IsDeleted = false;
            dtoStudent.Id = Guid.NewGuid();
            dtoStudent.PersonId = _personService.Create(dtoStudent.Person);
            dtoStudent.Person = null;
            _repository.Add(_mapper.Map<DTOStudent, Student>(dtoStudent));
        }
        public void Update(DTOStudent dtoStudent)
        {
            var student = Get(dtoStudent.PersonId);
            dtoStudent.UpdateDate = DateTime.Now;
            var mergedStudent = _mapper.Map(dtoStudent, student);
            _personService.Update(mergedStudent.Person);
            _repository.Update(_mapper.Map<DTOStudent, Student>(mergedStudent));
        }
        public void Delete(Guid? id)
        {
            if (id == null)
                return;
            var student = Get(id);
            student.IsDeleted = true;
            student.DeletedDate = DateTime.Now;
            _personService.Delete(student.PersonId);
            _repository.Update(_mapper.Map<DTOStudent, Student>(student));
        }
    }
}
