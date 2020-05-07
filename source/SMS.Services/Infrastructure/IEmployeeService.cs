using System;
using System.Collections.Generic;
using DTOEmployee = SMS.DTOs.DTOs.Employee;

namespace SMS.Services.Infrastructure
{

    public interface IEmployeeService 
    {
        List<DTOEmployee> Get();
        DTOEmployee Get(Guid? id);
        void Create(DTOEmployee employee);
        void Update(DTOEmployee dtoEmployee);
        void Delete(Guid? id);
    }
}


