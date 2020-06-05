using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using DBStudentFinances = SMS.DATA.Models.Student_Finances;
using DTOStudentFinances = SMS.DTOs.DTOs.Student_Finances;

namespace SMS.Services.Implementation
{
    public class StudentFinanceService : IStudentFinanceService
    {
        #region Properties
        private readonly IRepository<DBStudentFinances> _repository;
        private IMapper _mapper;
        #endregion

        #region Init

        public StudentFinanceService(IRepository<DBStudentFinances> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        #endregion

        #region Service Calls

        /// <summary>
        /// Service level call : Creates a single record of a StudentFinances
        /// </summary>
        /// <param name="DTOStudentFinances"></param>
        public void Create(DTOStudentFinances DTOStudentFinances)
        {
            DTOStudentFinances.CreatedDate = DateTime.UtcNow;
            DTOStudentFinances.IsDeleted = false;
            DTOStudentFinances.Id = Guid.NewGuid();

            _repository.Add(_mapper.Map<DTOStudentFinances, DBStudentFinances>(DTOStudentFinances));
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


    }
}
