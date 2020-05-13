using System;
using System.Collections.Generic;
using DTOStudentFinanceDetails = SMS.DTOs.DTOs.StudentFinanceDetail;

namespace SMS.Services.Infrastructure
{
    public interface IStudentFinanceDetailsService
    {
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
    }
}
