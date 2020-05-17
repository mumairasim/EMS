using System;
using System.Collections.Generic;
using DTOEmployee = SMS.DTOs.DTOs.Employee;

namespace SMS.Services.Infrastructure
{

    public interface IEmployeeService 
    {
        EmployeesList Get(int pageNumber, int pageSize);  
        DTOEmployee Get(Guid? id);
        void Create(DTOEmployee employee);
        void Update(DTOEmployee dtoEmployee);
        void Delete(Guid? id, string DeletedBy);
    }
}


