using System;
using System.Collections.Generic;
using DTOStudentFinances = SMS.DTOs.DTOs.Student_Finances;

namespace SMS.Services.Infrastructure
{
    public interface IStudentFinanceService
    {
        /// <summary>
        /// Service level call : Return all records of a StudentFinances
        /// </summary>
        /// <returns></returns>
        List<DTOStudentFinances> GetAll();

        /// <summary>
        /// Retruns a Single Record of a StudentFinances
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DTOStudentFinances Get(Guid? id);

        /// <summary>
        /// Service level call : Creates a single record of a StudentFinances
        /// </summary>
        /// <param name="dtoStudentFinances"></param>
        void Create(DTOStudentFinances dTOStudentFinances);

        /// <summary>
        /// Service level call : Updates the Single Record of a StudentFinances 
        /// </summary>
        /// <param name="dtoStudentFinances"></param>
        void Update(DTOStudentFinances dTOStudentFinances);

        /// <summary>
        /// Service level call : Delete a single record of a StudentFinances
        /// </summary>
        /// <param name="id"></param>
        void Delete(Guid? id);
    }
}
