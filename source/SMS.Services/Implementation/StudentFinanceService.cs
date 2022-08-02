using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using DBStudentFinances = SMS.DATA.Models.Student_Finances;
using DTOStudentFinances = SMS.DTOs.DTOs.Student_Finances;
using DTOStudentFinanceCustom = SMS.DTOs.DTOs.StudentFinanceInfo;
using DBStudentFinanceCustom = SMS.DATA.Models.NonDbContextModels.StudentFinanceInfo;
namespace SMS.Services.Implementation
{
    public class StudentFinanceService : IStudentFinanceService
    {
        #region Properties
        private readonly IRepository<DBStudentFinances> _repository;
        private readonly IStoredProcCaller _storedProcCaller;
        private readonly IStudentFinanceDetailsService _studentFinanceDetailsService;

        private IMapper _mapper;
        #endregion

        #region Init

        public StudentFinanceService(IRepository<DBStudentFinances> repository, IMapper mapper, IStoredProcCaller storedProcCaller, IStudentFinanceDetailsService studentFinanceDetailsService)
        {
            _repository = repository;
            _mapper = mapper;
            _storedProcCaller = storedProcCaller;
            _studentFinanceDetailsService = studentFinanceDetailsService;
        }

        #endregion

        #region Service Calls

        /// <summary>
        /// Service level call : Creates a single record of a StudentFinances
        /// </summary>
        /// <param name="dtoStudentFinances"></param>
        public void Create(DTOStudentFinanceCustom dtoStudentFinances)
        {
            var newFinance = new DBStudentFinances
            {
                StudentFinanceDetailsId = dtoStudentFinances.StudentFinanceDetailsId,
                FeeSubmitted = dtoStudentFinances.FeeSubmitted,
                FeeMonth = dtoStudentFinances.FeeMonth,
                CreatedDate = DateTime.UtcNow,
                FeeYear = dtoStudentFinances.FeeYear,
                IsDeleted = false,
                CreatedBy = dtoStudentFinances.CreatedBy
            };

            if (newFinance.Id == Guid.Empty)
            {
                newFinance.Id = Guid.NewGuid();
            }

            if (newFinance.FeeSubmitted ?? false)
            {
                _repository.Add(newFinance);
            }

        }

        /// <summary>
        /// Service level call : Delete a single record of a StudentFinances
        /// </summary>
        /// <param name="id"></param>
        public void Delete(Guid? id)
        {
            if (id == null)
                return;
            var StudentFinances = Get(id);
            if (StudentFinances != null)
            {
                StudentFinances.IsDeleted = true;
                StudentFinances.DeletedDate = DateTime.UtcNow;
                _repository.Update(_mapper.Map<DTOStudentFinances, DBStudentFinances>(StudentFinances));
            }

        }

        /// <summary>
        /// Retruns a Single Record of a StudentFinances
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DTOStudentFinances Get(Guid? id)
        {
            if (id == null)
            {
                return null;
            }

            var StudentFinances = _repository.Get().FirstOrDefault(x => x.Id == id && (x.IsDeleted == false || x.IsDeleted == null));
            var StudentFinancesDto = _mapper.Map<DBStudentFinances, DTOStudentFinances>(StudentFinances);

            return StudentFinancesDto;
        }

        public List<DTOStudentFinanceCustom> GetByFilter(Guid? schoolId, Guid? classId, Guid? studentId, string feeMonth)
        {
            var rs = _storedProcCaller.GetStudentFinance(schoolId, classId, studentId, feeMonth);
            return _mapper.Map<List<DBStudentFinanceCustom>, List<DTOStudentFinanceCustom>>(rs);
        }

        public List<DTOStudentFinanceCustom> GetDetailByFilter(Guid? schoolId, Guid? ClassId, int? Regno, string Month, string Year)
        {
            var rs = _storedProcCaller.GetStudentFinanceDetail(schoolId, ClassId, Regno, Month, Year);
            return _mapper.Map<List<DBStudentFinanceCustom>, List<DTOStudentFinanceCustom>>(rs);
        }


        /// <summary>
        /// Service level call : Updates the Single Record of a StudentFinances 
        /// </summary>
        /// <param name="DTOStudentFinances"></param>
        public void Update(DTOStudentFinanceCustom dtoStudentFinances)
        {
            var newFinance = new DBStudentFinances
            {
                StudentFinanceDetailsId = dtoStudentFinances.StudentFinanceDetailsId,
                FeeSubmitted = dtoStudentFinances.FeeSubmitted,
                FeeMonth = dtoStudentFinances.FeeMonth,
                Arears = dtoStudentFinances.Arears,
                CreatedDate = DateTime.UtcNow,
                FeeYear = dtoStudentFinances.FeeYear,
                IsDeleted = false,
                CreatedBy = dtoStudentFinances.CreatedBy
            };

            if (newFinance.Id == Guid.Empty)
            {
                newFinance.Id = Guid.NewGuid();
            }

            if (newFinance.FeeSubmitted ?? false)
            {
                _repository.Add(newFinance);
                var studentFinanceDetails=_studentFinanceDetailsService.Get(dtoStudentFinances.StudentFinanceDetailsId);
                studentFinanceDetails.Arears = dtoStudentFinances.Arears;
                _studentFinanceDetailsService.Update(studentFinanceDetails);
            }
        }

        /// <summary>
        /// Service level call : Return all records of a StudentFinances
        /// </summary>
        /// <returns></returns>
        List<DTOStudentFinances> IStudentFinanceService.GetAll()
        {
            var StudentFinancess = _repository.Get().Where(x => (x.IsDeleted == false || x.IsDeleted == null)).ToList();
            var StudentFinancesList = new List<DTOStudentFinances>();
            foreach (var StudentFinances in StudentFinancess)
            {
                StudentFinancesList.Add(_mapper.Map<DBStudentFinances, DTOStudentFinances>(StudentFinances));
            }
            return StudentFinancesList;
        }



        #endregion
    }
}
