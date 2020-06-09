using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.DTOs.DTOs;
using SMS.Services.Infrastructure;
using Student = SMS.DATA.Models.Student;
using DTOStudent = SMS.DTOs.DTOs.Student;
using DTOStudentFinanceDetail = SMS.DTOs.DTOs.StudentFinanceDetail;

namespace SMS.Services.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _repository;
        private readonly IPersonService _personService;
        private readonly IStudentFinanceDetailsService _studentFinanceDetailsService;
        private readonly IMapper _mapper;
        public StudentService(IRepository<Student> repository, IPersonService personService, IStudentFinanceDetailsService studentFinanceDetailsService, IMapper mapper)
        {
            _repository = repository;
            _personService = personService;
            _studentFinanceDetailsService = studentFinanceDetailsService;
            _mapper = mapper;
        }
        public StudentsList Get(int pageNumber, int pageSize)
        {
            var students = _repository.Get().Where(st => st.IsDeleted == false).OrderByDescending(st => st.RegistrationNumber).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            var studentCount = _repository.Get().Count(st => st.IsDeleted == false);
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
        public StudentsList Get(Guid classId, Guid schoolId)
        {
            var students = _repository.Get().Where(st => st.IsDeleted == false && st.SchoolId == schoolId && st.ClassId == classId).OrderByDescending(st => st.RegistrationNumber).ToList();
            var studentCount = _repository.Get().Count(st => st.IsDeleted == false);
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

        public void Create(DTOStudent dtoStudent)
        {
            dtoStudent.CreatedDate = DateTime.UtcNow;
            dtoStudent.IsDeleted = false;
            dtoStudent.Id = Guid.NewGuid();
            dtoStudent.PersonId = _personService.Create(dtoStudent.Person);
            HelpingMethodForRelationship(dtoStudent);
            InsertStudentFinanceDetail(dtoStudent);
            _repository.Add(_mapper.Map<DTOStudent, Student>(dtoStudent));
        }
        public void Update(DTOStudent dtoStudent)
        {
            var student = Get(dtoStudent.Id);
            dtoStudent.UpdateDate = DateTime.UtcNow;
            var mergedStudent = _mapper.Map(dtoStudent, student);
            _personService.Update(mergedStudent.Person);
            _repository.Update(_mapper.Map<DTOStudent, Student>(mergedStudent));
        }
        public void Delete(Guid? id, string deletedBy)
        {
            if (id == null)
                return;
            var student = Get(id);
            student.IsDeleted = true;
            student.DeletedBy = deletedBy;
            student.DeletedDate = DateTime.UtcNow;
            _personService.Delete(student.PersonId);
            _repository.Update(_mapper.Map<DTOStudent, Student>(student));
        }
        private void InsertStudentFinanceDetail(DTOStudent dtoStudent)
        {
            var stdFinance = new DTOStudentFinanceDetail
            {
                Id = Guid.NewGuid(),
                StudentId = dtoStudent.Id,
                IsDeleted = false,
                CreatedDate = dtoStudent.CreatedDate,
                CreatedBy = dtoStudent.CreatedBy,
                FinanceTypeId = Guid.Parse("8B50E73B-11BF-44B9-8DA1-EF1602F4479E") // need to replace by dropdown
            };
            _studentFinanceDetailsService.Create(stdFinance);

        }

        private void HelpingMethodForRelationship(DTOStudent dtoStudent)
        {
            dtoStudent.SchoolId = dtoStudent.School.Id;
            dtoStudent.ClassId = dtoStudent.Class.Id;
            dtoStudent.Person = null;
            dtoStudent.Class = null;
            dtoStudent.School = null;
            dtoStudent.Image = null;
        }
    }
}
