using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.DTOs.DTOs;
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
        public StudentsList Get(int pageNumber, int pageSize)
        {
            var students = _repository.Get().Where(st => st.IsDeleted == false).OrderByDescending(st => st.RegistrationNumber).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            var studentCount = _repository.Get().Count();
            var studentTempList = new List<DTOStudent>();
            foreach (var student in students)
            {
                studentTempList.Add(_mapper.Map<Student, DTOStudent>(student));
            }

            var studentsList = new StudentsList()
            {
                Students = studentTempList,
                StudentsCount = studentCount
            };

            return studentsList;
        }

        public DTOStudent Get(Guid? id)
        {
            if (id == null) return null;
            var studentRecord = _repository.Get().FirstOrDefault(st => st.Id == id && st.IsDeleted == false);
            var student = _mapper.Map<Student, DTOStudent>(studentRecord);
            return student;
        }

        public void Create(DTOStudent dtoStudent)
        {
            dtoStudent.CreatedDate = DateTime.Now;
            dtoStudent.IsDeleted = false;
            dtoStudent.Id = Guid.NewGuid();
            dtoStudent.PersonId = _personService.Create(dtoStudent.Person);
            HelpingMethodForRelationship(dtoStudent);
            _repository.Add(_mapper.Map<DTOStudent, Student>(dtoStudent));
        }
        public void Update(DTOStudent dtoStudent)
        {
            var student = Get(dtoStudent.Id);
            dtoStudent.UpdateDate = DateTime.Now;
            var mergedStudent = _mapper.Map(dtoStudent, student);
            _personService.Update(mergedStudent.Person);
            _repository.Update(_mapper.Map<DTOStudent, Student>(mergedStudent));
        }
        public void Delete(Guid? id, string DeletedBy)
        {
            if (id == null)
                return;
            var student = Get(id);
            student.IsDeleted = true;
            student.DeletedBy = DeletedBy;
            student.DeletedDate = DateTime.Now;
            _personService.Delete(student.PersonId);
            _repository.Update(_mapper.Map<DTOStudent, Student>(student));
        }

        private void HelpingMethodForRelationship(DTOStudent dtoStudent)
        {
            dtoStudent.SchoolId = dtoStudent.School.Id;
            dtoStudent.ClassId = dtoStudent.Class.Id;
            dtoStudent.Person = null;
            dtoStudent.Class = null;
            dtoStudent.School = null;
        }
    }
}
