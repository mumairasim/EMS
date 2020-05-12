using System;
using System.Collections.Generic;
using DTOEmployee = SMS.DTOs.DTOs.Employee;

namespace SMS.FACADE.Infrastructure
{
    public interface IEmployeeFacade
    {
        List<DTOEmployee> Get();
        DTOEmployee Get(Guid id);
        void Create(DTOEmployee dtoEmployee);
        void Update(DTOEmployee dtoEmployee);
        void Delete(Guid? id);
    }
}
