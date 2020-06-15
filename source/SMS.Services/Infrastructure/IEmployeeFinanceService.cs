using System;
using System.Collections.Generic;
using DTOEmployeeFinanceInfo = SMS.DTOs.DTOs.EmployeeFinanceInfo;

namespace SMS.Services.Infrastructure
{
    public interface IEmployeeFinanceService
    {
        /// <summary>
        /// Service level call : Return filtered records of a Employee Finances, pass null to ignore filters
        /// </summary>
        /// <returns></returns>
        List<DTOEmployeeFinanceInfo> GetByFilter(Guid? schoolId, Guid? DesignationId, string SalaryMonth);

        /// <summary>
        /// Service level call : Return filtered records of a Employee Finances, pass null to ignore filters
        /// </summary>
        /// <returns></returns>
        List<DTOEmployeeFinanceInfo> GetDetailByFilter(Guid? schoolId, Guid? DesignationId);

        /// <summary>
        /// Service level call : Creates the monthly record for employee finances
        /// </summary>
        /// <returns></returns>
        void Create(DTOEmployeeFinanceInfo employeeFinanceInfo);
    }
}
