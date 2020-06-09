using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.Services.Infrastructure;
using System;
using System.Collections.Generic;
using DBEmployeeFinanceInfo = SMS.DATA.Models.NonDbContextModels.EmployeeFinanceInfo;
using DTOEmployeeFinanceInfo = SMS.DTOs.DTOs.EmployeeFinanceInfo;

namespace SMS.Services.Implementation
{
    public class EmployeeFinanceService : IEmployeeFinanceService
    {
        #region Properties
        private readonly IStoredProcCaller _storedProcCaller;
        private IMapper _mapper;
        #endregion

        #region Init

        public EmployeeFinanceService(IMapper mapper, IStoredProcCaller storedProcCaller)
        {
            _mapper = mapper;
            _storedProcCaller = storedProcCaller;
        }

        #endregion
        public List<DTOEmployeeFinanceInfo> GetByFilter(Guid? schoolId, Guid? DesignationId, string SalaryMonth)
        {
            var rs = _storedProcCaller.GetEmployeeFinance(schoolId, DesignationId, SalaryMonth);
            return _mapper.Map<List<DBEmployeeFinanceInfo>, List<DTOEmployeeFinanceInfo>>(rs);
        }
    }
}
