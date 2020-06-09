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
    }
}
