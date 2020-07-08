using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.REQUESTDATA.Infrastructure;
using SMS.DTOs.DTOs;
using SMS.Services.Infrastructure;
using Student = SMS.DATA.Models.Student;
using DTOStudent = SMS.DTOs.DTOs.Student;
using SMS.DTOs.ReponseDTOs;
using System.Text.RegularExpressions;
using DTOStudentFinanceDetail = SMS.DTOs.DTOs.StudentFinanceDetail;
using RequestStudent = SMS.REQUESTDATA.RequestModels.Student;

namespace SMS.Services.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _repository;
        private readonly IRequestRepository<RequestStudent> _requestRepository;
        private readonly IPersonService _personService;
        private readonly IStudentFinanceDetailsService _studentFinanceDetailsService;
        private readonly IMapper _mapper;
        public StudentService(IRepository<Student> repository, IPersonService personService, IRequestRepository<RequestStudent> requestRepository, IStudentFinanceDetailsService studentFinanceDetailsService, IMapper mapper)
        {
            _repository = repository;
            _requestRepository = requestRepository;
            _personService = personService;
            _studentFinanceDetailsService = studentFinanceDetailsService;
            _mapper = mapper;
        }

        #region SMS Section
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
            InsertStudentFinanceDetail(dtoStudent);
            _repository.Add(_mapper.Map<DTOStudent, Student>(dtoStudent));
            return validationResult;
        }

        public StudentResponse Update(DTOStudent dtoStudent)
        {
            var validationResult = Validation(dtoStudent);
            if (validationResult.IsError)
            {
                return validationResult;
            }
            var student = Get(dtoStudent.Id);
            dtoStudent.UpdateDate = DateTime.UtcNow;
            HelpingMethodForRelationship(dtoStudent);
            var mergedStudent = _mapper.Map(dtoStudent, student);
            _personService.Update(mergedStudent.Person);
            _repository.Update(_mapper.Map<DTOStudent, Student>(mergedStudent));
            return validationResult;
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
        private StudentResponse Validation(DTOStudent dtoStudent)
        {
            var alphaRegex = new Regex("^[a-zA-Z ]+$");
            var numericRegex = new Regex("^[0-9]*$");
            if (string.IsNullOrWhiteSpace(dtoStudent.Person.FirstName) || dtoStudent.Person.FirstName.Length>100)
            {
                return PrepareFailureResponse(dtoStudent.Id,
                    "InvalidName",
                    "Name may null or exceed than 100 characters"
                    );
            }
            if(!alphaRegex.IsMatch(dtoStudent.Person.FirstName))
            {
                return PrepareFailureResponse(dtoStudent.Id,
                   "InvalidName",
                   "Text Field doesn't contain any numbers"
                   );
            }
            if (string.IsNullOrWhiteSpace(dtoStudent.Person.LastName) || dtoStudent.Person.LastName.Length > 100)
            {
                return PrepareFailureResponse(dtoStudent.Id,
                    "InvalidName",
                    "Name may null or exceed than 100 characters"
                    );
            }
            if (!alphaRegex.IsMatch(dtoStudent.Person.LastName))
            {
                return PrepareFailureResponse(dtoStudent.Id,
                   "InvalidName",
                   "Text Field doesn't contain any numbers"
                   );
            }
            if (dtoStudent.Person.Cnic == null || dtoStudent.Person.Cnic.Length!=13)
            {
                return PrepareFailureResponse(dtoStudent.Id,
                    "CnicLimitError",
                    "Cnic must be of 13 digits"
                    );
            }
            if (!numericRegex.IsMatch(dtoStudent.Person.Cnic))
            {
                return PrepareFailureResponse(dtoStudent.Id,
                   "InvalidInput",
                   "This field contains only digits"
                   );
            }
            if (string.IsNullOrWhiteSpace(dtoStudent.Person.Phone) || dtoStudent.Person.Phone.Length > 15)
            {
                return PrepareFailureResponse(dtoStudent.Id,
                    "PhoneLimitError",
                    "Phone cannot exceed from 15 digits"
                    );
            }
            if (!numericRegex.IsMatch(dtoStudent.Person.Phone))
            {
                return PrepareFailureResponse(dtoStudent.Id,
                   "InvalidInput",
                   "This field contains only digits"
                   );
            }
            if (string.IsNullOrWhiteSpace(dtoStudent.Person.Nationality))
            {
                return PrepareFailureResponse(dtoStudent.Id,
                    "InvalidNationality",
                    "Nationality cannot be null"
                    );
            }
            if (!alphaRegex.IsMatch(dtoStudent.Person.Nationality))
            {
                return PrepareFailureResponse(dtoStudent.Id,
                   "InvalidText",
                   "Text Field doesn't contain any numbers"
                   );
            }
            if (!string.IsNullOrWhiteSpace(dtoStudent.Person.Religion) && !alphaRegex.IsMatch(dtoStudent.Person.Religion))
            {
                return PrepareFailureResponse(dtoStudent.Id,
                   "InvalidText",
                   "Text Field doesn't contain any numbers"
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
            if (string.IsNullOrWhiteSpace(dtoStudent.Person.ParentName) || dtoStudent.Person.ParentName.Length > 100)
            {
                return PrepareFailureResponse(dtoStudent.Id,
                    "InvalidName",
                    "Name may null or exceed than 100 characters"
                    );
            }
            if (!alphaRegex.IsMatch(dtoStudent.Person.ParentName))
            {
                return PrepareFailureResponse(dtoStudent.Id,
                   "InvalidName",
                   "Text Field doesn't contain any numbers"
                   );
            }
            if (dtoStudent.Person.ParentCnic != null && dtoStudent.Person.ParentCnic.Length != 13 && !numericRegex.IsMatch(dtoStudent.Person.ParentCnic))
            {
                return PrepareFailureResponse(dtoStudent.Id,
                    "CnicLimitError",
                    "Cnic must be of 13 digits"
                    );
            }
            if (string.IsNullOrWhiteSpace(dtoStudent.Person.ParentRelation))
            {
                return PrepareFailureResponse(dtoStudent.Id,
                    "InvalidRelation",
                    "Relation cannot be null"
                    );
            }
            if (!alphaRegex.IsMatch(dtoStudent.Person.ParentRelation))
            {
                return PrepareFailureResponse(dtoStudent.Id,
                   "InvalidText",
                   "Text Field doesn't contain any numbers"
                   );
            }
            if (!string.IsNullOrWhiteSpace(dtoStudent.Person.ParentOccupation) && dtoStudent.Person.ParentOccupation.Length > 100 && !alphaRegex.IsMatch(dtoStudent.Person.ParentOccupation))
            {
                return PrepareFailureResponse(dtoStudent.Id,
                    "InvalidText",
                    "Text Field doesn't contain any numbers"
                    );
            }
            if (!string.IsNullOrWhiteSpace(dtoStudent.Person.ParentNationality) && !alphaRegex.IsMatch(dtoStudent.Person.ParentNationality))
            {
                return PrepareFailureResponse(dtoStudent.Id,
                    "InvalidText",
                    "Text Field doesn't contain any numbers"
                    );
            }
            if (string.IsNullOrWhiteSpace(dtoStudent.Person.ParentMobile1) || dtoStudent.Person.ParentMobile1.Length > 15)
            {
                return PrepareFailureResponse(dtoStudent.Id,
                    "InvalidNumber",
                    "Number cannot be null"
                    );
            }
            if (!numericRegex.IsMatch(dtoStudent.Person.ParentMobile1))
            {
                return PrepareFailureResponse(dtoStudent.Id,
                   "InvalidInput",
                   "This field contains only digits"
                   );
            }
            if (string.IsNullOrWhiteSpace(dtoStudent.Person.ParentEmergencyName) || dtoStudent.Person.ParentEmergencyName.Length > 100)
            {
                return PrepareFailureResponse(dtoStudent.Id,
                    "InvalidName",
                    "Name may null or exceed than 100 characters"
                    );
            }
            if (!alphaRegex.IsMatch(dtoStudent.Person.ParentEmergencyName))
            {
                return PrepareFailureResponse(dtoStudent.Id,
                   "InvalidName",
                   "Text Field doesn't contain any numbers"
                   );
            }
            if (string.IsNullOrWhiteSpace(dtoStudent.Person.ParentEmergencyRelation))
            {
                return PrepareFailureResponse(dtoStudent.Id,
                    "InvalidRelation",
                    "Relation cannot be null"
                    );
            }
            if (!alphaRegex.IsMatch(dtoStudent.Person.ParentEmergencyRelation))
            {
                return PrepareFailureResponse(dtoStudent.Id,
                   "InvalidText",
                   "Text Field doesn't contain any numbers"
                   );
            }
            if (string.IsNullOrWhiteSpace(dtoStudent.Person.ParentEmergencyMobile) || dtoStudent.Person.ParentEmergencyMobile.Length > 15)
            {
                return PrepareFailureResponse(dtoStudent.Id,
                    "InvalidNumber",
                    "Number cannot be null"
                    );
            }
            if (!numericRegex.IsMatch(dtoStudent.Person.ParentEmergencyMobile))
            {
                return PrepareFailureResponse(dtoStudent.Id,
                   "InvalidInput",
                   "This field contains only digits"
                   );
            }
            return RequestPrepareSuccessResponse(dtoStudent.Id,
                    "NoError",
                    "No Error Found"
                    );
        }
        private StudentResponse RequestPrepareFailureResponse(Guid id, string errorMessage, string descriptionMessage)
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
        private StudentResponse RequestPrepareSuccessResponse(Guid id, string message, string descriptionMessage)
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
        #endregion

        #region RequestSMS Section
        public StudentsList RequestGet(int pageNumber, int pageSize)
        {
            var students = _requestRepository.Get().Where(st => st.IsDeleted == false).OrderByDescending(st => st.RegistrationNumber).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            var studentCount = _requestRepository.Get().Count(st => st.IsDeleted == false);
            var studentTempList = new List<DTOStudent>();
            foreach (var student in students)
            {
                studentTempList.Add(_mapper.Map<RequestStudent, DTOStudent>(student));
            }

            var studentsList = new StudentsList()
            {
                Students = studentTempList,
                StudentsCount = studentCount
            };

            return studentsList;
        }

        public DTOStudent RequestGet(Guid? id)
        {
            if (id == null) return null;
            var studentRecord = _requestRepository.Get().FirstOrDefault(st => st.Id == id && st.IsDeleted == false);
            var student = _mapper.Map<RequestStudent, DTOStudent>(studentRecord);
            return student;
        }
        public StudentsList RequestGet(Guid classId, Guid schoolId)
        {
            var students = _requestRepository.Get().Where(st => st.IsDeleted == false && st.SchoolId == schoolId && st.ClassId == classId).OrderByDescending(st => st.RegistrationNumber).ToList();
            var studentCount = _requestRepository.Get().Count(st => st.IsDeleted == false);
            var studentTempList = new List<DTOStudent>();
            foreach (var student in students)
            {
                studentTempList.Add(_mapper.Map<RequestStudent, DTOStudent>(student));
            }

            var studentsList = new StudentsList()
            {
                Students = studentTempList,
                StudentsCount = studentCount
            };

            return studentsList;
        }

        public  void/*StudentResponse*/ RequestCreate(DTOStudent dtoStudent)
        {
            //var validationResult = RequestValidation(dtoStudent);
            //if (validationResult.IsError)
            //{
            //    return validationResult;
            //}
            dtoStudent.CreatedDate = DateTime.UtcNow;
            dtoStudent.IsDeleted = false;
            dtoStudent.Id = Guid.NewGuid();
            dtoStudent.Person = null;
            dtoStudent.Class = null;
            dtoStudent.School = null;
            //dtoStudent.PersonId = _personService.RequestCreate(dtoStudent.Person);
            //RequestHelpingMethodForRelationship(dtoStudent);
            //RequestInsertStudentFinanceDetail(dtoStudent);
            _requestRepository.Add(_mapper.Map<DTOStudent, RequestStudent>(dtoStudent));
            //return validationResult;
        }

        public StudentResponse RequestUpdate(DTOStudent dtoStudent)
        {
            var validationResult = RequestValidation(dtoStudent);
            if (validationResult.IsError)
            {
                return validationResult;
            }
            var student = RequestGet(dtoStudent.Id);
            dtoStudent.UpdateDate = DateTime.UtcNow;
            RequestHelpingMethodForRelationship(dtoStudent);
            var mergedStudent = _mapper.Map(dtoStudent, student);
            _personService.RequestUpdate(mergedStudent.Person);
            _requestRepository.Update(_mapper.Map<DTOStudent, RequestStudent>(mergedStudent));
            return validationResult;
        }
        public void RequestDelete(Guid? id/*, string deletedBy*/)
        {
            if (id == null)
                return;
            var student = RequestGet(id);
            student.IsDeleted = true;
            //student.DeletedBy = deletedBy;
            student.DeletedDate = DateTime.UtcNow;
            _personService.RequestDelete(student.PersonId);
            _requestRepository.Update(_mapper.Map<DTOStudent, RequestStudent>(student));
        }
        private void RequestInsertStudentFinanceDetail(DTOStudent dtoStudent)
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

        private void RequestHelpingMethodForRelationship(DTOStudent dtoStudent)
        {
            dtoStudent.SchoolId = dtoStudent.School.Id;
            dtoStudent.ClassId = dtoStudent.Class.Id;
            dtoStudent.Person = null;
            dtoStudent.Class = null;
            dtoStudent.School = null;
            dtoStudent.Image = null;
        }
        private StudentResponse RequestValidation(DTOStudent dtoStudent)
        {
            var alphaRegex = new Regex("^[a-zA-Z ]+$");
            var numericRegex = new Regex("^[0-9]*$");
            if (string.IsNullOrWhiteSpace(dtoStudent.Person.FirstName) || dtoStudent.Person.FirstName.Length > 100)
            {
                return PrepareFailureResponse(dtoStudent.Id,
                    "InvalidName",
                    "Name may null or exceed than 100 characters"
                    );
            }
            if (!alphaRegex.IsMatch(dtoStudent.Person.FirstName))
            {
                return PrepareFailureResponse(dtoStudent.Id,
                   "InvalidName",
                   "Text Field doesn't contain any numbers"
                   );
            }
            if (string.IsNullOrWhiteSpace(dtoStudent.Person.LastName) || dtoStudent.Person.LastName.Length > 100)
            {
                return PrepareFailureResponse(dtoStudent.Id,
                    "InvalidName",
                    "Name may null or exceed than 100 characters"
                    );
            }
            if (!alphaRegex.IsMatch(dtoStudent.Person.LastName))
            {
                return PrepareFailureResponse(dtoStudent.Id,
                   "InvalidName",
                   "Text Field doesn't contain any numbers"
                   );
            }
            if (dtoStudent.Person.Cnic == null || dtoStudent.Person.Cnic.Length != 13)
            {
                return PrepareFailureResponse(dtoStudent.Id,
                    "CnicLimitError",
                    "Cnic must be of 13 digits"
                    );
            }
            if (!numericRegex.IsMatch(dtoStudent.Person.Cnic))
            {
                return PrepareFailureResponse(dtoStudent.Id,
                   "InvalidInput",
                   "This field contains only digits"
                   );
            }
            if (string.IsNullOrWhiteSpace(dtoStudent.Person.Phone) || dtoStudent.Person.Phone.Length > 15)
            {
                return PrepareFailureResponse(dtoStudent.Id,
                    "PhoneLimitError",
                    "Phone cannot exceed from 15 digits"
                    );
            }
            if (!numericRegex.IsMatch(dtoStudent.Person.Phone))
            {
                return PrepareFailureResponse(dtoStudent.Id,
                   "InvalidInput",
                   "This field contains only digits"
                   );
            }
            if (string.IsNullOrWhiteSpace(dtoStudent.Person.Nationality))
            {
                return PrepareFailureResponse(dtoStudent.Id,
                    "InvalidNationality",
                    "Nationality cannot be null"
                    );
            }
            if (!alphaRegex.IsMatch(dtoStudent.Person.Nationality))
            {
                return PrepareFailureResponse(dtoStudent.Id,
                   "InvalidText",
                   "Text Field doesn't contain any numbers"
                   );
            }
            if (!string.IsNullOrWhiteSpace(dtoStudent.Person.Religion) && !alphaRegex.IsMatch(dtoStudent.Person.Religion))
            {
                return PrepareFailureResponse(dtoStudent.Id,
                   "InvalidText",
                   "Text Field doesn't contain any numbers"
                   );
            }
            if (dtoStudent.School == null)
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
            if (string.IsNullOrWhiteSpace(dtoStudent.Person.ParentName) || dtoStudent.Person.ParentName.Length > 100)
            {
                return PrepareFailureResponse(dtoStudent.Id,
                    "InvalidName",
                    "Parent Name may null or exceed than 100 characters"
                    );
            }
            if (!alphaRegex.IsMatch(dtoStudent.Person.ParentName))
            {
                return PrepareFailureResponse(dtoStudent.Id,
                   "InvalidName",
                   "Text Field doesn't contain any numbers"
                   );
            }
            if (dtoStudent.Person.ParentCnic != null && dtoStudent.Person.ParentCnic.Length != 13 && !numericRegex.IsMatch(dtoStudent.Person.ParentCnic))
            {
                return PrepareFailureResponse(dtoStudent.Id,
                    "CnicLimitError",
                    "Cnic must be of 13 digits"
                    );
            }
            if (string.IsNullOrWhiteSpace(dtoStudent.Person.ParentRelation))
            {
                return PrepareFailureResponse(dtoStudent.Id,
                    "InvalidRelation",
                    "Relation cannot be null"
                    );
            }
            if (!alphaRegex.IsMatch(dtoStudent.Person.ParentRelation))
            {
                return PrepareFailureResponse(dtoStudent.Id,
                   "InvalidText",
                   "Text Field doesn't contain any numbers"
                   );
            }
            if (!string.IsNullOrWhiteSpace(dtoStudent.Person.ParentOccupation) && dtoStudent.Person.ParentOccupation.Length > 100 && !alphaRegex.IsMatch(dtoStudent.Person.ParentOccupation))
            {
                return PrepareFailureResponse(dtoStudent.Id,
                    "InvalidText",
                    "Text Field doesn't contain any numbers"
                    );
            }
            if (!string.IsNullOrWhiteSpace(dtoStudent.Person.ParentNationality) && !alphaRegex.IsMatch(dtoStudent.Person.ParentNationality))
            {
                return PrepareFailureResponse(dtoStudent.Id,
                    "InvalidText",
                    "Text Field doesn't contain any numbers"
                    );
            }
            if (string.IsNullOrWhiteSpace(dtoStudent.Person.ParentMobile1) || dtoStudent.Person.ParentMobile1.Length > 15)
            {
                return PrepareFailureResponse(dtoStudent.Id,
                    "InvalidNumber",
                    "Number cannot be null"
                    );
            }
            if (!numericRegex.IsMatch(dtoStudent.Person.ParentMobile1))
            {
                return PrepareFailureResponse(dtoStudent.Id,
                   "InvalidInput",
                   "This field contains only digits"
                   );
            }
            if (string.IsNullOrWhiteSpace(dtoStudent.Person.ParentEmergencyName) || dtoStudent.Person.ParentEmergencyName.Length > 100)
            {
                return PrepareFailureResponse(dtoStudent.Id,
                    "InvalidName",
                    "Name may null or exceed than 100 characters"
                    );
            }
            if (!alphaRegex.IsMatch(dtoStudent.Person.ParentEmergencyName))
            {
                return PrepareFailureResponse(dtoStudent.Id,
                   "InvalidName",
                   "Text Field doesn't contain any numbers"
                   );
            }
            if (string.IsNullOrWhiteSpace(dtoStudent.Person.ParentEmergencyRelation))
            {
                return PrepareFailureResponse(dtoStudent.Id,
                    "InvalidRelation",
                    "Relation cannot be null"
                    );
            }
            if (!alphaRegex.IsMatch(dtoStudent.Person.ParentEmergencyRelation))
            {
                return PrepareFailureResponse(dtoStudent.Id,
                   "InvalidText",
                   "Text Field doesn't contain any numbers"
                   );
            }
            if (string.IsNullOrWhiteSpace(dtoStudent.Person.ParentEmergencyMobile) || dtoStudent.Person.ParentEmergencyMobile.Length > 15)
            {
                return PrepareFailureResponse(dtoStudent.Id,
                    "InvalidNumber",
                    "Number cannot be null"
                    );
            }
            if (!numericRegex.IsMatch(dtoStudent.Person.ParentEmergencyMobile))
            {
                return PrepareFailureResponse(dtoStudent.Id,
                   "InvalidInput",
                   "This field contains only digits"
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
                IsError = false,
                StatusCode = "200",
                Message = message,
                Description = descriptionMessage
            };
        }
        #endregion
    }
}
