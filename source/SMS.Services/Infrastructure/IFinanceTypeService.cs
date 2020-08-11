using System;
using System.Collections.Generic;
using DTOFinanceType = SMS.DTOs.DTOs.FinanceType;

namespace SMS.Services.Infrastructure
{
    public interface IFinanceTypeService
    {
        #region SMS Section
        /// <summary>
        /// Service level call : Return all records of a FinanceType
        /// </summary>
        /// <returns></returns>
        List<DTOFinanceType> GetAll(string search = "");

        /// <summary>
        /// Retruns a Single Record of a FinanceType
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DTOFinanceType Get(Guid? id);

        /// <summary>
        /// Retruns a Single Record of a FinanceType by name
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DTOFinanceType GetByName(string name);

        /// <summary>
        /// Service level call : Creates a single record of a FinanceType
        /// </summary>
        /// <param name="dtoFinanceType"></param>
        void Create(DTOFinanceType dTOFinanceType);

        /// <summary>
        /// Service level call : Updates the Single Record of a FinanceType 
        /// </summary>
        /// <param name="dtoFinanceType"></param>
        void Update(DTOFinanceType dTOFinanceType);

        /// <summary>
        /// Service level call : Delete a single record of a FinanceType
        /// </summary>
        /// <param name="id"></param>
        void Delete(Guid? id, string deletedBy);
        #endregion


        #region SMS Request Section
        /// <summary>
        /// Service level call : Return all records of a FinanceType
        /// </summary>
        /// <returns></returns>
        List<DTOFinanceType> RequestGetAll();

        /// <summary>
        /// Retruns a Single Record of a FinanceType
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DTOFinanceType RequestGet(Guid? id);

        /// <summary>
        /// Retruns a Single Record of a FinanceType by name
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DTOFinanceType RequestGetByName(string name);

        /// <summary>
        /// Service level call : Creates a single record of a FinanceType
        /// </summary>
        /// <param name="dtoFinanceType"></param>
        void RequestCreate(DTOFinanceType dTOFinanceType);

        /// <summary>
        /// Service level call : Updates the Single Record of a FinanceType 
        /// </summary>
        /// <param name="dtoFinanceType"></param>
        void RequestUpdate(DTOFinanceType dTOFinanceType);

        /// <summary>
        /// Service level call : Delete a single record of a FinanceType
        /// </summary>
        /// <param name="id"></param>
        void RequestDelete(Guid? id, string deletedBy);
        #endregion



    }
}
