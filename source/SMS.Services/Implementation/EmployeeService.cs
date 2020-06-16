using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.DTOs.DTOs;
using SMS.Services.Infrastructure;
using Employee = SMS.DATA.Models.Employee;
using DTOEmployee = SMS.DTOs.DTOs.Employee;
using SMS.DTOs.ReponseDTOs;
using System.Text.RegularExpressions;

namespace SMS.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _repository;
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;
        public EmployeeService(IRepository<Employee> repository, IPersonService personService, IMapper mapper)
        {
            _repository = repository;
            _personService = personService;
            _mapper = mapper;
        }

        public EmployeesList Get(int pageNumber, int pageSize)
        {
            var employees = _repository.Get().Where(em => em.IsDeleted == false).OrderByDescending(em => em.CreatedDate).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            var employeeCount = _repository.Get().Where(st => st.IsDeleted == false).Count();
            var employeeTempList = new List<DTOEmployee>();
            foreach (var employee in employees)
            {
                employeeTempList.Add(_mapper.Map<Employee, DTOEmployee>(employee));
            }

            var employeesList = new EmployeesList()
            {
                Employees = employeeTempList,
                EmployeesCount = employeeCount
            };
            return employeesList;
        }

        public List<DTOEmployee> GetEmployeeByDesignation()
        {
            var employees = _repository.Get().Where(em => em.IsDeleted == false && em.Designation.Name == "Teacher").ToList();

            var employeeTempList = new List<DTOEmployee>();
            foreach (var employee in employees)
            {
                employeeTempList.Add(_mapper.Map<Employee, DTOEmployee>(employee));
            }
            return employeeTempList;
        }
        public DTOEmployee Get(Guid? id)
        {
            if (id == null) return null;
            var employeeRecord = _repository.Get().FirstOrDefault(em => em.Id == id && em.IsDeleted == false);
            var employee = _mapper.Map<Employee, DTOEmployee>(employeeRecord);
            return employee;
        }
        public EmployeeResponse Create(DTOEmployee dtoEmployee)
        {
            var validationResult = Validation(dtoEmployee);
            if (validationResult.IsError)
            {
                return validationResult;
            }
            dtoEmployee.CreatedDate = DateTime.UtcNow;
            dtoEmployee.IsDeleted = false;
            dtoEmployee.Id = Guid.NewGuid();
            dtoEmployee.PersonId = _personService.Create(dtoEmployee.Person);
            HelpingMethodForRelationship(dtoEmployee);
            _repository.Add(_mapper.Map<DTOEmployee, Employee>(dtoEmployee));
            return validationResult;
        }
        public EmployeeResponse Update(DTOEmployee dtoEmployee)
        {
            var validationResult = Validation(dtoEmployee);
            if (validationResult.IsError)
            {
                return validationResult;
            }
            var employee = Get(dtoEmployee.PersonId);
            dtoEmployee.UpdateDate = DateTime.UtcNow;
            var mergedEmployee = _mapper.Map(dtoEmployee, employee);
            _personService.Update(mergedEmployee.Person);
            _repository.Update(_mapper.Map<DTOEmployee, Employee>(mergedEmployee));
            return validationResult;
        }
        public void Delete(Guid? id, string DeletedBy)
        {
            if (id == null)
                return;
            var employee = Get(id);
            employee.IsDeleted = true;
            employee.DeletedBy = DeletedBy;
            employee.DeletedDate = DateTime.UtcNow;
            _personService.Delete(employee.PersonId);
            _repository.Update(_mapper.Map<DTOEmployee, Employee>(employee));
        }
        private void HelpingMethodForRelationship(DTOEmployee dtoEmployee)
        {
            dtoEmployee.SchoolId = dtoEmployee.School.Id;
            dtoEmployee.DesignationId = dtoEmployee.Designation.Id;
            dtoEmployee.Person = null;
            dtoEmployee.Designation = null;
            dtoEmployee.School = null;
        }
        private EmployeeResponse Validation(DTOEmployee dtoEmployee)
        {
            var alphaRegex = new Regex("^[a-zA-Z ]+$");
            var numericRegex = new Regex("^[0-9]*$");
            if (dtoEmployee.Person.FirstName == null || dtoEmployee.Person.FirstName.Length > 100)
            {
                return PrepareFailureResponse(dtoEmployee.Id,
                    "InvalidName",
                    "Name may null or exceed than 100 characters"
                    );
            }
            if (!alphaRegex.IsMatch(dtoEmployee.Person.FirstName))
            {
                return PrepareFailureResponse(dtoEmployee.Id,
                   "InvalidName",
                   "Text Field doesn't contain any numbers"
                   );
            }
            if (dtoEmployee.Person.LastName == null || dtoEmployee.Person.LastName.Length > 100)
            {
                return PrepareFailureResponse(dtoEmployee.Id,
                    "InvalidName",
                    "Name may null or exceed than 100 characters"
                    );
            }
            if (!alphaRegex.IsMatch(dtoEmployee.Person.LastName))
            {
                return PrepareFailureResponse(dtoEmployee.Id,
                   "InvalidName",
                   "Text Field doesn't contain any numbers"
                   );
            }
            if (dtoEmployee.Person.Cnic == null || dtoEmployee.Person.Cnic.Length != 13)
            {
                return PrepareFailureResponse(dtoEmployee.Id,
                    "CnicLimitError",
                    "Cnic must be of 13 digits"
                    );
            }
            if (!numericRegex.IsMatch(dtoEmployee.Person.Cnic))
            {
                return PrepareFailureResponse(dtoEmployee.Id,
                   "InvalidInput",
                   "This field contains only digits"
                   );
            }
            if (dtoEmployee.Person.Phone == null || dtoEmployee.Person.Phone.Length > 15)
            {
                return PrepareFailureResponse(dtoEmployee.Id,
                    "PhoneLimitError",
                    "Phone cannot exceed from 15 digits"
                    );
            }
            if (!numericRegex.IsMatch(dtoEmployee.Person.Phone))
            {
                return PrepareFailureResponse(dtoEmployee.Id,
                   "InvalidInput",
                   "This field contains only digits"
                   );
            }
            if (dtoEmployee.Person.Nationality == null)
            {
                return PrepareFailureResponse(dtoEmployee.Id,
                    "InvalidNationality",
                    "Nationality cannot be null"
                    );
            }
            if (!alphaRegex.IsMatch(dtoEmployee.Person.Nationality))
            {
                return PrepareFailureResponse(dtoEmployee.Id,
                   "InvalidText",
                   "Text Field doesn't contain any numbers"
                   );
            }
            if (dtoEmployee.Person.Religion != null && !alphaRegex.IsMatch(dtoEmployee.Person.Religion))
            {
                return PrepareFailureResponse(dtoEmployee.Id,
                   "InvalidText",
                   "Text Field doesn't contain any numbers"
                   );
            }
            if (dtoEmployee.School == null)
            {
                return PrepareFailureResponse(dtoEmployee.Id,
                    "InvalidSchool",
                    "School cannot be null"
                    );
            }
            if (dtoEmployee.Designation == null)
            {
                return PrepareFailureResponse(dtoEmployee.Id,
                    "InvalidClass",
                    "Class cannot be null"
                    );
            }
            if (dtoEmployee.Person.ParentName == null || dtoEmployee.Person.ParentName.Length > 100)
            {
                return PrepareFailureResponse(dtoEmployee.Id,
                    "InvalidName",
                    "Name may null or exceed than 100 characters"
                    );
            }
            if (!alphaRegex.IsMatch(dtoEmployee.Person.ParentName))
            {
                return PrepareFailureResponse(dtoEmployee.Id,
                   "InvalidName",
                   "Text Field doesn't contain any numbers"
                   );
            }
            if (dtoEmployee.Person.ParentCnic != null && dtoEmployee.Person.ParentCnic.Length != 13 && !numericRegex.IsMatch(dtoEmployee.Person.ParentCnic))
            {
                return PrepareFailureResponse(dtoEmployee.Id,
                    "CnicLimitError",
                    "Cnic must be of 13 digits"
                    );
            }
            if (dtoEmployee.Person.ParentRelation == null)
            {
                return PrepareFailureResponse(dtoEmployee.Id,
                    "InvalidRelation",
                    "Relation cannot be null"
                    );
            }
            if (!alphaRegex.IsMatch(dtoEmployee.Person.ParentRelation))
            {
                return PrepareFailureResponse(dtoEmployee.Id,
                   "InvalidText",
                   "Text Field doesn't contain any numbers"
                   );
            }
            if (dtoEmployee.Person.ParentOccupation != null && dtoEmployee.Person.ParentOccupation.Length > 100 && !alphaRegex.IsMatch(dtoEmployee.Person.ParentOccupation))
            {
                return PrepareFailureResponse(dtoEmployee.Id,
                    "InvalidText",
                    "Text Field doesn't contain any numbers"
                    );
            }
            if (dtoEmployee.Person.ParentNationality != null && !alphaRegex.IsMatch(dtoEmployee.Person.ParentNationality))
            {
                return PrepareFailureResponse(dtoEmployee.Id,
                    "InvalidText",
                    "Text Field doesn't contain any numbers"
                    );
            }
            if (dtoEmployee.Person.ParentMobile1 == null || dtoEmployee.Person.ParentMobile1.Length > 15)
            {
                return PrepareFailureResponse(dtoEmployee.Id,
                    "InvalidNumber",
                    "Number cannot be null"
                    );
            }
            if (!numericRegex.IsMatch(dtoEmployee.Person.ParentMobile1))
            {
                return PrepareFailureResponse(dtoEmployee.Id,
                   "InvalidInput",
                   "This field contains only digits"
                   );
            }
            if (dtoEmployee.Person.ParentEmergencyName == null || dtoEmployee.Person.ParentEmergencyName.Length > 100)
            {
                return PrepareFailureResponse(dtoEmployee.Id,
                    "InvalidName",
                    "Name may null or exceed than 100 characters"
                    );
            }
            if (!alphaRegex.IsMatch(dtoEmployee.Person.ParentEmergencyName))
            {
                return PrepareFailureResponse(dtoEmployee.Id,
                   "InvalidName",
                   "Text Field doesn't contain any numbers"
                   );
            }
            if (dtoEmployee.Person.ParentEmergencyRelation == null)
            {
                return PrepareFailureResponse(dtoEmployee.Id,
                    "InvalidRelation",
                    "Relation cannot be null"
                    );
            }
            if (!alphaRegex.IsMatch(dtoEmployee.Person.ParentEmergencyRelation))
            {
                return PrepareFailureResponse(dtoEmployee.Id,
                   "InvalidText",
                   "Text Field doesn't contain any numbers"
                   );
            }
            if (dtoEmployee.Person.ParentEmergencyMobile == null || dtoEmployee.Person.ParentEmergencyMobile.Length > 15)
            {
                return PrepareFailureResponse(dtoEmployee.Id,
                    "InvalidNumber",
                    "Number cannot be null"
                    );
            }
            if (!numericRegex.IsMatch(dtoEmployee.Person.ParentEmergencyMobile))
            {
                return PrepareFailureResponse(dtoEmployee.Id,
                   "InvalidInput",
                   "This field contains only digits"
                   );
            }
            return PrepareSuccessResponse(dtoEmployee.Id,
                    "NoError",
                    "No Error Found"
                    );
        }
        private EmployeeResponse PrepareFailureResponse(Guid id, string errorMessage, string descriptionMessage)
        {
            return new EmployeeResponse
            {
                Id = id,
                IsError = true,
                StatusCode = "400",
                Message = errorMessage,
                Description = descriptionMessage
            };
        }
        private EmployeeResponse PrepareSuccessResponse(Guid id, string message, string descriptionMessage)
        {
            return new EmployeeResponse
            {
                Id = id,
                IsError = false,
                StatusCode = "200",
                Message = message,
                Description = descriptionMessage
            };
        }
    }
}
