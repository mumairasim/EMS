using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.Services.Infrastructure;
using System;
using System.Collections.Generic;
using DBEmployeeFinanceInfo = SMS.DATA.Models.NonDbContextModels.EmployeeFinanceInfo;
using DBEmployeeFinance = SMS.DATA.Models.EmployeeFinance;
using DBEmployeeFinanceDetail = SMS.DATA.Models.EmployeeFinanceDetail;
using DTOEmployeeFinanceInfo = SMS.DTOs.DTOs.EmployeeFinanceInfo;
using SMS.DTOs.DTOs;
using System.Linq;

namespace SMS.Services.Implementation
{
    public class EmployeeFinanceService : IEmployeeFinanceService
    {
        #region Properties
        private readonly IStoredProcCaller _storedProcCaller;
        private IMapper _mapper;
        private readonly IRepository<DBEmployeeFinance> _repository;
        private readonly IRepository<DBEmployeeFinanceDetail> _repositoryFinanceDetail;
        #endregion

        #region Init

        public EmployeeFinanceService(IMapper mapper, IStoredProcCaller storedProcCaller, IRepository<DBEmployeeFinance> repository, IRepository<DBEmployeeFinanceDetail> repositoryFinanceDetail)
        {
            _mapper = mapper;
            _storedProcCaller = storedProcCaller;
            _repository = repository;
            _repositoryFinanceDetail = repositoryFinanceDetail;
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

        public EmployeeFinanceDetail GetFinanceDetailByEmployeeId(Guid empId)
        {
            var singleFinanceDetail = _repositoryFinanceDetail.Get().FirstOrDefault(x => x.EmployeeId == empId && (x.IsDeleted == false || x.IsDeleted == null));
            return _mapper.Map<DBEmployeeFinanceDetail, EmployeeFinanceDetail>(singleFinanceDetail);
        }

        public void Create(DTOEmployeeFinanceInfo employeeFinanceInfo)
        {
            var newFinance = new DBEmployeeFinance
            {
                EmployeeFinanceDetailsId = employeeFinanceInfo.EmpFinanceDetailsId,
                SalaryTransfered = employeeFinanceInfo.IsSalaryTransferred,
                SalaryMonth = employeeFinanceInfo.SalaryMonth,
                CreatedDate = DateTime.UtcNow,
                SalaryYear = employeeFinanceInfo.SalaryYear,
                IsDeleted = false,
                CreatedBy = employeeFinanceInfo.CreatedBy
            };

            if (employeeFinanceInfo.Id == Guid.Empty)
            {
                newFinance.Id = Guid.NewGuid();
            }
            if (newFinance.SalaryTransfered ?? false)
            {
                _repository.Add(newFinance);
            }
        }

        public void CreateFinanceDetails(EmployeeFinanceDetail dTOEmployeeFinanceDetail)
        {
            dTOEmployeeFinanceDetail.CreatedDate = DateTime.UtcNow;
            dTOEmployeeFinanceDetail.IsDeleted = false;
            if (dTOEmployeeFinanceDetail.Id == Guid.Empty)
            {
                dTOEmployeeFinanceDetail.Id = Guid.NewGuid();
            }
            _repositoryFinanceDetail.Add(_mapper.Map<EmployeeFinanceDetail, DBEmployeeFinanceDetail>(dTOEmployeeFinanceDetail));
        }

        public void UpdateFinanceDetail(EmployeeFinanceDetail dTOEmployeeFinanceDetail)
        {
            var financeDetails = GetFinanceDetailByEmployeeId(dTOEmployeeFinanceDetail.EmployeeId ?? Guid.Empty);
            if (financeDetails != null)
            {
                financeDetails.UpdateDate = DateTime.UtcNow;
                financeDetails.IsDeleted = false;
                var updated = _mapper.Map(dTOEmployeeFinanceDetail, financeDetails);
                var updatedDbRec = _mapper.Map<EmployeeFinanceDetail, DBEmployeeFinanceDetail>(updated);
                _repositoryFinanceDetail.Update(updatedDbRec);
            }
        }
    }
}
