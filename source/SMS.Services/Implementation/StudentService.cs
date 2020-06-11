using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.DTOs.DTOs;
using SMS.Services.Infrastructure;
using Student = SMS.DATA.Models.Student;
using DTOStudent = SMS.DTOs.DTOs.Student;
using SMS.DTOs.ReponseDTOs;

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

        public StudentResponse Create(DTOStudent dtoStudent)
        {
            var validationResult = Validation(dtoStudent);
            if(validationResult.IsError)
            {
                return validationResult;
            }
            dtoStudent.CreatedDate = DateTime.UtcNow;
            dtoStudent.IsDeleted = false;
            dtoStudent.Id = Guid.NewGuid();
            dtoStudent.PersonId = _personService.Create(dtoStudent.Person);
            HelpingMethodForRelationship(dtoStudent);
            _repository.Add(_mapper.Map<DTOStudent, Student>(dtoStudent));
            return validationResult;
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

        private void HelpingMethodForRelationship(DTOStudent dtoStudent)
        {
            dtoStudent.SchoolId = dtoStudent.School.Id;
            dtoStudent.ClassId = dtoStudent.Class.Id;
            dtoStudent.Person = null;
            dtoStudent.Class = null;
            dtoStudent.School = null;
            dtoStudent.Image = null;
        }
        private StudentResponse Validation(DTOStudent dtoStudent)
        {
            if (dtoStudent.Person.FirstName == null || dtoStudent.Person.FirstName.Length>100)
            {
                return PrepareFailureResponse(dtoStudent.Id,
                    "InvalidName",
                    "Name may null or exceed than 100 characters"
                    );
            }
            if (dtoStudent.Person.LastName == null || dtoStudent.Person.LastName.Length > 100)
            {
                return PrepareFailureResponse(dtoStudent.Id,
                    "InvalidName",
                    "Name may null or exceed than 100 characters"
                    );
            }
            if (dtoStudent.Person.Phone == null || dtoStudent.Person.Phone.Length > 15)
            {
                return PrepareFailureResponse(dtoStudent.Id,
                    "PhoneLimitError",
                    "Phone cannot exceed from 15 digits"
                    );
            }
            if (dtoStudent.Person.Cnic == null || dtoStudent.Person.Cnic.Length!=13)
            {
                return PrepareFailureResponse(dtoStudent.Id,
                    "CnicLimitError",
                    "Cnic must be of 13 digits"
                    );
            }
            if (dtoStudent.Person.Nationality == null )
            {
                return PrepareFailureResponse(dtoStudent.Id,
                    "InvalidNationality",
                    "Nationality cannot be null"
                    );
            }
            if (dtoStudent.School == null )
            {
                return PrepareFailureResponse(dtoStudent.Id,
                    "InvalidSchool",
                    "School cannot be null"
                    );
            }
            if (dtoStudent.Class == null)
            {
                return PrepareFailureResponse(dtoStudent.Id,
                    "InvalidClass",
                    "Class cannot be null"
                    );
            }
            if (dtoStudent.Person.ParentName == null || dtoStudent.Person.ParentName.Length > 100)
            {
                return PrepareFailureResponse(dtoStudent.Id,
                    "InvalidName",
                    "Name may null or exceed than 100 characters"
                    );
            }
            if (dtoStudent.Person.ParentCnic != null && dtoStudent.Person.ParentCnic.Length != 13)
            {
                return PrepareFailureResponse(dtoStudent.Id,
                    "CnicLimitError",
                    "Cnic must be of 13 digits"
                    );
            }
            if (dtoStudent.Person.ParentRelation == null)
            {
                return PrepareFailureResponse(dtoStudent.Id,
                    "InvalidRelation",
                    "Relation cannot be null"
                    );
            }
            if (dtoStudent.Person.ParentMobile1 == null || dtoStudent.Person.ParentMobile1.Length > 15)
            {
                return PrepareFailureResponse(dtoStudent.Id,
                    "InvalidNumber",
                    "Number cannot be null"
                    );
            }
            if (dtoStudent.Person.ParentEmergencyName == null || dtoStudent.Person.ParentEmergencyName.Length > 100)
            {
                return PrepareFailureResponse(dtoStudent.Id,
                    "InvalidName",
                    "Name may null or exceed than 100 characters"
                    );
            }
            if (dtoStudent.Person.ParentEmergencyRelation == null)
            {
                return PrepareFailureResponse(dtoStudent.Id,
                    "InvalidRelation",
                    "Relation cannot be null"
                    );
            }
            if (dtoStudent.Person.ParentEmergencyMobile == null || dtoStudent.Person.ParentEmergencyMobile.Length > 15)
            {
                return PrepareFailureResponse(dtoStudent.Id,
                    "InvalidNumber",
                    "Number cannot be null"
                    );
            }
            return PrepareSuccessResponse(dtoStudent.Id,
                    "NoError",
                    "No Error Found"
                    );
        }
        private StudentResponse PrepareFailureResponse(Guid id, string errorMessage, string descriptionMessage)
        {
            return new StudentResponse
            {
                Id = id,
                IsError = true,
                StatusCode = "400",
                Message = errorMessage,
                Description = descriptionMessage
            };
        }
        private StudentResponse PrepareSuccessResponse(Guid id, string message, string descriptionMessage)
        {
            return new StudentResponse
            {
                Id = id,
                IsError=false,
                StatusCode = "200",
                Message = message,
                Description = descriptionMessage
            };
        }
    }
}
