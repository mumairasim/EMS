using System;
using System.Collections.Generic;
using SMS.DTOs.DTOs;
using DTOEmployee = SMS.DTOs.DTOs.Employee;
using SMS.FACADE.Infrastructure;
using SMS.Services.Infrastructure;


namespace SMS.FACADE.Implementation
{
   public class EmployeeFacade: IEmployeeFacade
    {
        public IEmployeeService EmployeeService;
        public EmployeeFacade(IEmployeeService employeeService)
        {
            EmployeeService = employeeService;
        }
        public EmployeesList Get(int pageNumber, int pageSize)
        {
            return EmployeeService.Get(pageNumber, pageSize);
        }
        public DTOEmployee Get(Guid id)
        {
            return EmployeeService.Get(id);
        }

        public void Create(DTOEmployee dtoEmployee)
        {
            EmployeeService.Create(dtoEmployee);
        }
        public void Update(DTOEmployee dtoEmployee)
        {
            EmployeeService.Update(dtoEmployee);
        }

        public void Delete(Guid? id, string DeletedBy)
        {
            EmployeeService.Delete(id, DeletedBy);
        }


    }
}
