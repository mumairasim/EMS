using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.DTOs.DTOs;
using SMS.Services.Infrastructure;
using Employee = SMS.DATA.Models.Employee;
using DTOEmployee = SMS.DTOs.DTOs.Employee;

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

        public List<DTOEmployee> GetDesignationTeacher()
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



        public void Create(DTOEmployee dtoEmployee)
        {
            dtoEmployee.CreatedDate = DateTime.UtcNow;
            dtoEmployee.IsDeleted = false;
            dtoEmployee.Id = Guid.NewGuid();
            dtoEmployee.PersonId = _personService.Create(dtoEmployee.Person);
            HelpingMethodForRelationship(dtoEmployee);
            //dtoEmployee.DesignationId = dtoEmployee.Designation.Id;
            //dtoEmployee.Person = null;
            //dtoEmployee.Designation = null;
            _repository.Add(_mapper.Map<DTOEmployee, Employee>(dtoEmployee));
        }
        private void HelpingMethodForRelationship(DTOEmployee dtoEmployee)
        {
            dtoEmployee.SchoolId = dtoEmployee.School.Id;
            dtoEmployee.DesignationId = dtoEmployee.Designation.Id;
            dtoEmployee.Person = null;
            dtoEmployee.Designation = null;
            dtoEmployee.School = null;
        }

        public void Update(DTOEmployee dtoEmployee)
        {
            var employee = Get(dtoEmployee.PersonId);
            dtoEmployee.UpdateDate = DateTime.UtcNow;
            var mergedEmployee = _mapper.Map(dtoEmployee, employee);
            _personService.Update(mergedEmployee.Person);
            _repository.Update(_mapper.Map<DTOEmployee, Employee>(mergedEmployee));
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

    }
}
