﻿using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using DBStudentFinanceDetails = SMS.DATA.Models.StudentFinanceDetail;
using DTOStudentFinanceDetails = SMS.DTOs.DTOs.StudentFinanceDetail;

namespace SMS.Services.Implementation
{
    public class StudentFinanceDetailsService : IStudentFinanceDetailsService
    {
        #region Properties
        private readonly IRepository<DBStudentFinanceDetails> _repository;
        private IMapper _mapper;
        #endregion

        #region Init

        public StudentFinanceDetailsService(IRepository<DBStudentFinanceDetails> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        #endregion

        #region Service Calls

        /// <summary>
        /// Service level call : Creates a single record of a StudentFinances
        /// </summary>
        /// <param name="dTOStudentFinanceDetails"></param>
        public void Create(DTOStudentFinanceDetails dTOStudentFinanceDetails)
        {
            dTOStudentFinanceDetails.CreatedDate = DateTime.Now;
            dTOStudentFinanceDetails.IsDeleted = false;
            dTOStudentFinanceDetails.Id = Guid.NewGuid();

            _repository.Add(_mapper.Map<DTOStudentFinanceDetails, DBStudentFinanceDetails>(dTOStudentFinanceDetails));
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
                StudentFinances.DeletedDate = DateTime.Now;
                _repository.Update(_mapper.Map<DTOStudentFinanceDetails, DBStudentFinanceDetails>(StudentFinances));
            }

        }

        /// <summary>
        /// Retruns a Single Record of a StudentFinances
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DTOStudentFinanceDetails Get(Guid? id)
        {
            if (id == null)
            {
                return null;
            }

            var StudentFinances = _repository.Get().FirstOrDefault(x => x.Id == id && (x.IsDeleted == false || x.IsDeleted == null));
            var StudentFinancesDto = _mapper.Map<DBStudentFinanceDetails, DTOStudentFinanceDetails>(StudentFinances);

            return StudentFinancesDto;
        }

        /// <summary>
        /// Service level call : Updates the Single Record of a StudentFinances 
        /// </summary>
        /// <param name="dTOStudentFinanceDetails"></param>
        public void Update(DTOStudentFinanceDetails dTOStudentFinanceDetails)
        {
            var StudentFinances = Get(dTOStudentFinanceDetails.Id);
            if (StudentFinances != null)
            {
                dTOStudentFinanceDetails.UpdateDate = DateTime.Now;
                dTOStudentFinanceDetails.IsDeleted = false;
                var updated = _mapper.Map(dTOStudentFinanceDetails, StudentFinances);

                _repository.Update(_mapper.Map<DTOStudentFinanceDetails, DBStudentFinanceDetails>(updated));
            }
        }

        /// <summary>
        /// Service level call : Return all records of a StudentFinances
        /// </summary>
        /// <returns></returns>
        List<DTOStudentFinanceDetails> IStudentFinanceDetailsService.GetAll()
        {
            var StudentFinancess = _repository.Get().Where(x => (x.IsDeleted == false || x.IsDeleted == null)).ToList();
            var StudentFinancesList = new List<DTOStudentFinanceDetails>();
            foreach (var StudentFinances in StudentFinancess)
            {
                StudentFinancesList.Add(_mapper.Map<DBStudentFinanceDetails, DTOStudentFinanceDetails>(StudentFinances));
            }
            return StudentFinancesList;
        }

        #endregion


    }
}