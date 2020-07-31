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
using SMS.REQUESTDATA.Infrastructure;
using RequestStudentFinance = SMS.REQUESTDATA.RequestModels.Student_Finances;
namespace SMS.Services.Implementation
{
    public class StudentFinanceService : IStudentFinanceService
    {
        #region Properties
        private readonly IRepository<DBStudentFinances> _repository;
        private readonly IRequestRepository<RequestStudentFinance> _requestRepository;
        private readonly IStoredProcCaller _storedProcCaller;

        private IMapper _mapper;
        #endregion

        #region Init

        public StudentFinanceService(IRepository<DBStudentFinances> repository, IMapper mapper, IRequestRepository<RequestStudentFinance> requestRepository, IStoredProcCaller storedProcCaller)
        {
            _repository = repository;
            _requestRepository = requestRepository;
            _mapper = mapper;
            _storedProcCaller = storedProcCaller;
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

        public List<DTOStudentFinanceCustom> GetDetailByFilter(Guid? schoolId, Guid? ClassId, Guid? StudentId)
        {
            var rs = _storedProcCaller.GetStudentFinanceDetail(schoolId, ClassId, StudentId);
            return _mapper.Map<List<DBStudentFinanceCustom>, List<DTOStudentFinanceCustom>>(rs);
        }


        /// <summary>
        /// Service level call : Updates the Single Record of a StudentFinances 
        /// </summary>
        /// <param name="DTOStudentFinances"></param>
        public void Update(DTOStudentFinances DTOStudentFinances)
        {
            var StudentFinances = Get(DTOStudentFinances.Id);
            if (StudentFinances != null)
            {
                DTOStudentFinances.UpdateDate = DateTime.UtcNow;
                DTOStudentFinances.IsDeleted = false;
                var updated = _mapper.Map(DTOStudentFinances, StudentFinances);

                _repository.Update(_mapper.Map<DTOStudentFinances, DBStudentFinances>(updated));
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

        #region RequestedService Calls

        /// <summary>
        /// Service level call : Creates a single record of a StudentFinances
        /// </summary>
        /// <param name="DTOStudentFinances"></param>
        public void RequestCreate(DTOStudentFinanceCustom DTOStudentFinances)
        {
            var newFinance = new RequestStudentFinance
            {
                Id = Guid.NewGuid(),
                StudentFinanceDetailsId = DTOStudentFinances.StudentFinanceDetailsId,
                FeeSubmitted = DTOStudentFinances.FeeSubmitted,
                FeeMonth = DTOStudentFinances.FeeMonth,
                CreatedDate = DateTime.UtcNow,
                FeeYear = DTOStudentFinances.FeeYear,
                IsDeleted = false,
                //CreatedBy = Guid.Parse(DTOStudentFinances.CreatedBy)
            };

            if (newFinance.FeeSubmitted ?? false)
            {
                _requestRepository.Add(newFinance);
            }

        }

        /// <summary>
        /// Service level call : Delete a single record of a StudentFinances
        /// </summary>
        /// <param name="id"></param>
        public void RequestDelete(Guid? id)
        {
            if (id == null)
                return;
            var StudentFinances = RequestGet(id);
            if (StudentFinances != null)
            {
                StudentFinances.IsDeleted = true;
                StudentFinances.DeletedDate = DateTime.UtcNow;
                _requestRepository.Update(_mapper.Map<DTOStudentFinances, RequestStudentFinance>(StudentFinances));
            }

        }

        /// <summary>
        /// Retruns a Single Record of a StudentFinances
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DTOStudentFinances RequestGet(Guid? id)
        {
            if (id == null)
            {
                return null;
            }

            var StudentFinances = _requestRepository.Get().FirstOrDefault(x => x.Id == id && (x.IsDeleted == false || x.IsDeleted == null));
            var StudentFinancesDto = _mapper.Map<RequestStudentFinance, DTOStudentFinances>(StudentFinances);

            return StudentFinancesDto;
        }

        public List<DTOStudentFinanceCustom> RequestGetByFilter(Guid? schoolId, Guid? classId, Guid? studentId, string feeMonth)
        {
            var rs = _storedProcCaller.RequestGetStudentFinance(schoolId, classId, studentId, feeMonth);
            return _mapper.Map<List<DBStudentFinanceCustom>, List<DTOStudentFinanceCustom>>(rs);
        }

        public List<DTOStudentFinanceCustom> RequestGetDetailByFilter(Guid? schoolId, Guid? ClassId, Guid? StudentId)
        {
            var rs = _storedProcCaller.RequestGetStudentFinanceDetail(schoolId, ClassId, StudentId);
            return _mapper.Map<List<DBStudentFinanceCustom>, List<DTOStudentFinanceCustom>>(rs);
        }


        /// <summary>
        /// Service level call : Updates the Single Record of a StudentFinances 
        /// </summary>
        /// <param name="DTOStudentFinances"></param>
        public void RequestUpdate(DTOStudentFinances DTOStudentFinances)
        {
            var StudentFinances = RequestGet(DTOStudentFinances.Id);
            if (StudentFinances != null)
            {
                DTOStudentFinances.UpdateDate = DateTime.UtcNow;
                DTOStudentFinances.IsDeleted = false;
                var updated = _mapper.Map(DTOStudentFinances, StudentFinances);

                _requestRepository.Update(_mapper.Map<DTOStudentFinances, RequestStudentFinance>(updated));
            }
        }

        /// <summary>
        /// Service level call : Return all records of a StudentFinances
        /// </summary>
        /// <returns></returns>
        List<DTOStudentFinances> IStudentFinanceService.RequestGetAll()
        {
            var StudentFinancess = _requestRepository.Get().Where(x => (x.IsDeleted == false || x.IsDeleted == null)).ToList();
            var StudentFinancesList = new List<DTOStudentFinances>();
            foreach (var StudentFinances in StudentFinancess)
            {
                StudentFinancesList.Add(_mapper.Map<RequestStudentFinance, DTOStudentFinances>(StudentFinances));
            }
            return StudentFinancesList;
        }



        #endregion
    }
}
