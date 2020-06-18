using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.Services.Infrastructure;
using System;
using System.Collections.Generic;
using DBEmployeeFinanceInfo = SMS.DATA.Models.NonDbContextModels.EmployeeFinanceInfo;
using DBEmployeeFinance = SMS.DATA.Models.EmployeeFinance;
using DTOEmployeeFinanceInfo = SMS.DTOs.DTOs.EmployeeFinanceInfo;

namespace SMS.Services.Implementation
{
    public class EmployeeFinanceService : IEmployeeFinanceService
    {
        #region Properties
        private readonly IStoredProcCaller _storedProcCaller;
        private IMapper _mapper;
        private readonly IRepository<DBEmployeeFinance> _repository;
        #endregion

        #region Init

        public EmployeeFinanceService(IMapper mapper, IStoredProcCaller storedProcCaller, IRepository<DBEmployeeFinance> repository)
        {
            _mapper = mapper;
            _storedProcCaller = storedProcCaller;
            _repository = repository;
        }

        #endregion
        public List<DTOEmployeeFinanceInfo> GetByFilter(Guid? schoolId, Guid? DesignationId, string SalaryMonth)
        {
            var rs = _storedProcCaller.GetEmployeeFinance(schoolId, DesignationId, SalaryMonth);
            return _mapper.Map<List<DBEmployeeFinanceInfo>, List<DTOEmployeeFinanceInfo>>(rs);
        }

        public List<DTOEmployeeFinanceInfo> GetDetailByFilter(Guid? schoolId, Guid? DesignationId)
        {
            var rs = _storedProcCaller.GetEmployeeFinanceDetail(schoolId, DesignationId);
            return _mapper.Map<List<DBEmployeeFinanceInfo>, List<DTOEmployeeFinanceInfo>>(rs);
        }

        
        public void Create(DTOEmployeeFinanceInfo employeeFinanceInfo)
        {
            var newFinance = new DBEmployeeFinance
            {
                Id = Guid.NewGuid(),
                EmployeeFinanceDetailsId = employeeFinanceInfo.EmpFinanceDetailsId,
                SalaryTransfered = employeeFinanceInfo.IsSalaryTransferred,
                SalaryMonth = employeeFinanceInfo.SalaryMonth,
                CreatedDate = DateTime.UtcNow,
                SalaryYear = employeeFinanceInfo.SalaryYear,
                IsDeleted = false,
                CreatedBy = employeeFinanceInfo.CreatedBy
            };

            if (newFinance.SalaryTransfered ?? false)
            {
                _repository.Add(newFinance);
            }
        }
    }
}
