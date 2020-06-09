using System;
using System.Collections.Generic;
using SMS.DTOs.DTOs;
using DTOEmployee = SMS.DTOs.DTOs.Employee;

namespace SMS.Services.Infrastructure
{

    public interface IEmployeeService 
    {
        EmployeesList Get(int pageNumber, int pageSize);  
        DTOEmployee Get(Guid? id);
        List<DTOEmployee> GetDesignationTeacher();
        void Create(DTOEmployee employee);
        void Update(DTOEmployee dtoEmployee);
        void Delete(Guid? id, string DeletedBy);
    }
}


