using SMS.DATA.Models.NonDbContextModels;
using System;
using System.Collections.Generic;

namespace SMS.DATA.Infrastructure
{
    public interface IStoredProcCaller
    {
        UserInfo GetUserInfo(string UserName);
        List<StudentFinanceInfo> GetStudentFinance(Guid? schoolId, Guid? ClassId, Guid? StudentId, string FeeMonth);
        List<EmployeeFinanceInfo> GetEmployeeFinance(Guid? schoolId, Guid? DesignationId, string SalaryMonth);
    }
}
