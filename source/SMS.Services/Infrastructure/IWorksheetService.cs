using System;
using System.Collections.Generic;
using DTOWorksheet = SMS.DTOs.DTOs.Worksheet;
namespace SMS.Services.Infrastructure
{
    public interface IWorksheetService
    {
        /// <summary>
        /// Service level call : Return all records of a Worksheet
        /// </summary>
        /// <returns></returns>
        List<DTOWorksheet> GetAll();

        /// <summary>
        /// Retruns a Single Record of a Worksheet
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DTOWorksheet Get(Guid? id);

        /// <summary>
        /// Service level call : Creates a single record of a Worksheet
        /// </summary>
        /// <param name="dtoWorksheet"></param>
        void Create(DTOWorksheet student);

        /// <summary>
        /// Service level call : Updates the Single Record of a Worksheet 
        /// </summary>
        /// <param name="dtoWorksheet"></param>
        void Update(DTOWorksheet dtoStudent);

        /// <summary>
        /// Service level call : Delete a single record of a Worksheet
        /// </summary>
        /// <param name="id"></param>
        void Delete(Guid? id);
    }
}
