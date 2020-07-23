using System;
using System.Collections.Generic;
using SMS.DTOs.DTOs;
using SMS.DTOs.ReponseDTOs;
using DTOEmployee = SMS.DTOs.DTOs.Employee;

namespace SMS.Services.Infrastructure
{

    public interface IEmployeeService 
    {
        #region SMS Section
        EmployeesList Get(int pageNumber, int pageSize);
        DTOEmployee Get(Guid? id);
        List<DTOEmployee> GetEmployeeByDesignation();
        EmployeeResponse Create(DTOEmployee employee);
        EmployeeResponse Update(DTOEmployee dtoEmployee);
        void Delete(Guid? id, string DeletedBy);
        #endregion

        #region SMS Request Section
        List<DTOEmployee> RequestGet();
        DTOEmployee RequestGet(Guid? id);
        Guid RequestCreate(DTOEmployee dtoEmployee);
        void RequestUpdate(DTOEmployee dtoEmployee);
        void RequestDelete(Guid? id);
        #endregion

    }

}

