using SMS.DTOs.DTOs;
using SMS.DTOs.ReponseDTOs;
using System;
using System.Collections.Generic;
using DTOWorksheet = SMS.DTOs.DTOs.Worksheet;
namespace SMS.Services.Infrastructure
{
    public interface IWorksheetService
    {
        #region SMS
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
        GenericApiResponse Create(DTOWorksheet dTOWorksheet);

        /// <summary>
        /// Service level call : Updates the Single Record of a Worksheet 
        /// </summary>
        /// <param name="dtoWorksheet"></param>
        GenericApiResponse Update(DTOWorksheet dTOWorksheet);

        /// <summary>
        /// Service level call : Delete a single record of a Worksheet
        /// </summary>
        /// <param name="id"></param>
        GenericApiResponse Delete(Guid? id);
        #endregion

        #region SMS Request
        /// <summary>
        /// Service level call : Return all records of a Worksheet on SMS Request
        /// </summary>
        /// <returns></returns>
        List<DTOWorksheet> RequestGetAll();

        /// <summary>
        /// Retruns a Single Record of a Worksheet on SMS Request
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DTOWorksheet RequestGet(Guid? id);

        /// <summary>
        /// Service level call : Creates a single record of a Worksheet on SMS Request
        /// </summary>
        /// <param name="dtoWorksheet"></param>
        void RequestCreate(DTOWorksheet dTOWorksheet);

        /// <summary>
        /// Service level call : Updates the Single Record of a Worksheet  on SMS Request
        /// </summary>
        /// <param name="dtoWorksheet"></param>
        void RequestUpdate(DTOWorksheet dTOWorksheet);

        /// <summary>
        /// Service level call : Delete a single record of a Worksheet on SMS Request
        /// </summary>
        /// <param name="id"></param>
        void RequestDelete(Guid? id);
        #endregion

        #region Approver

        GenericApiResponse ApproveRequest(CommonRequestModel dtoCommonRequestModel);

        #endregion
    }
}
