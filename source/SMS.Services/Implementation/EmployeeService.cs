using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.Services.Infrastructure;
using Employee = SMS.DATA.Models.Employee;
using DTOEmployee = SMS.DTOs.DTOs.Employee;

namespace SMS.Services.Implementation
{
    public class EmployeeService: IEmployeeService
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
        public List<DTOEmployee> Get()
        {
            var employees = _repository.Get().Where(st => st.IsDeleted == false).ToList();
            var employeeList = new List<DTOEmployee>();
            foreach (var employee in employees)
            {
                employeeList.Add(_mapper.Map<Employee, DTOEmployee>(employee));
            }
            return employeeList;
        }
        public DTOEmployee Get(Guid? id)
        {
            var personRecord = _personService.Get(id);
            if (personRecord == null) return null;
            var employeeRecord = _repository.Get().FirstOrDefault(st => st.PersonId == personRecord.Id && st.IsDeleted == false);
            var employee = _mapper.Map<Employee, DTOEmployee>(employeeRecord);
            return employee;
        }

        public void Create(DTOEmployee dtoEmployee)
        {
            dtoEmployee.CreatedDate = DateTime.Now;
            dtoEmployee.IsDeleted = false;
            dtoEmployee.Id = Guid.NewGuid();
            dtoEmployee.PersonId = _personService.Create(dtoEmployee.Person);
            dtoEmployee.Person = null;
            _repository.Add(_mapper.Map<DTOEmployee, Employee>(dtoEmployee));
        }

        public void Update(DTOEmployee dtoEmployee)
        {
            var employee = Get(dtoEmployee.PersonId);
            dtoEmployee.UpdateDate = DateTime.Now;
            var mergedEmployee = _mapper.Map(dtoEmployee, employee);
            _personService.Update(mergedEmployee.Person);
            _repository.Update(_mapper.Map<DTOEmployee, Employee>(mergedEmployee));
        }
        public void Delete(Guid? id)
        {
            if (id == null)
                return;
            var employee = Get(id);
            employee.IsDeleted = true;
            employee.DeletedDate = DateTime.Now;
            _personService.Delete(employee.PersonId);
            _repository.Update(_mapper.Map<DTOEmployee, Employee>(employee));
        }

    }
}
