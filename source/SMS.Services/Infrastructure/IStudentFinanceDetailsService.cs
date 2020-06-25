using System;
using System.Collections.Generic;
using DTOStudentFinanceDetails = SMS.DTOs.DTOs.StudentFinanceDetail;

namespace SMS.Services.Infrastructure
{
    public interface IStudentFinanceDetailsService
    {
        #region SMS 
        /// <summary>
        /// Service level call : Return all records of a StudentFinanceDetails
        /// </summary>
        /// <returns></returns>
        List<DTOStudentFinanceDetails> GetAll();

        /// <summary>
        /// Retruns a Single Record of a StudentFinanceDetails
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DTOStudentFinanceDetails Get(Guid? id);

        /// <summary>
        /// Service level call : Creates a single record of a StudentFinanceDetails
        /// </summary>
        /// <param name="dtoStudentFinanceDetails"></param>
        void Create(DTOStudentFinanceDetails dTOStudentFinanceDetails);

        /// <summary>
        /// Service level call : Updates the Single Record of a StudentFinanceDetails 
        /// </summary>
        /// <param name="dtoStudentFinanceDetails"></param>
        void Update(DTOStudentFinanceDetails dTOStudentFinanceDetails);

        /// <summary>
        /// Service level call : Delete a single record of a StudentFinanceDetails
        /// </summary>
        /// <param name="id"></param>
        void Delete(Guid? id);
        #endregion

        #region RequestSMS 
        /// <summary>
        /// Service level call : Return all records of a StudentFinanceDetails
        /// </summary>
        /// <returns></returns>
        List<DTOStudentFinanceDetails> RequestGetAll();

        /// <summary>
        /// Retruns a Single Record of a StudentFinanceDetails
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DTOStudentFinanceDetails RequestGet(Guid? id);

        /// <summary>
        /// Service level call : Creates a single record of a StudentFinanceDetails
        /// </summary>
        /// <param name="dtoStudentFinanceDetails"></param>
        void RequestCreate(DTOStudentFinanceDetails dTOStudentFinanceDetails);

        /// <summary>
        /// Service level call : Updates the Single Record of a StudentFinanceDetails 
        /// </summary>
        /// <param name="dtoStudentFinanceDetails"></param>
        void RequestUpdate(DTOStudentFinanceDetails dTOStudentFinanceDetails);

        /// <summary>
        /// Service level call : Delete a single record of a StudentFinanceDetails
        /// </summary>
        /// <param name="id"></param>
        void RequestDelete(Guid? id);
        #endregion
    }

}
