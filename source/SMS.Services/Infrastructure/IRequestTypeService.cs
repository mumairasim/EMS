using System;
using System.Collections.Generic;
using DTORequestType = SMS.DTOs.DTOs.RequestType;

namespace SMS.Services.Infrastructure
{
    public interface IRequestTypeService
    {
        #region SMS Request
        /// <summary>
        /// Service level call : Return all records of a RequestType on SMS Request
        /// </summary>
        /// <returns></returns>
        List<DTORequestType> RequestGetAll();

        /// <summary>
        /// Retruns a Single Record of a RequestType on SMS Request
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DTORequestType RequestGet(Guid? id);

        /// <summary>
        /// Service level call : Creates a single record of a RequestType on SMS Request
        /// </summary>
        /// <param name="dtoRequestType"></param>
        void RequestCreate(DTORequestType dTORequestType);

        /// <summary>
        /// Service level call : Updates the Single Record of a RequestType  on SMS Request
        /// </summary>
        /// <param name="dtoRequestType"></param>
        void RequestUpdate(DTORequestType dTORequestType);

        /// <summary>
        /// Service level call : Delete a single record of a RequestType on SMS Request
        /// </summary>
        /// <param name="id"></param>
        void RequestDelete(Guid? id);
        #endregion
    }
}
