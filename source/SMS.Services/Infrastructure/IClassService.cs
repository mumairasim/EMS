using SMS.DTOs.DTOs;
using SMS.DTOs.ReponseDTOs;
using System;
using System.Collections.Generic;
using DTOClass = SMS.DTOs.DTOs.Class;

namespace SMS.Services.Infrastructure
{
    public interface IClassService
    {
        #region SMS Section
        DTOClass Get(Guid? id);
        ClassesList Get(int pageNumber, int pageSize, string searchString = "");
        GenericApiResponse Create(DTOClass Class);
        GenericApiResponse Update(DTOClass dtoClass);
        void Delete(Guid? id, string DeletedBy);
        #endregion

        #region SMS Request Section
        List<DTOClass> RequestGet();
        DTOClass RequestGet(Guid? id);
        List<DTOClass> GetBySchool(Guid? schoolId);
        void RequestCreate(DTOClass Class);
        void RequestUpdate(DTOClass dtoClass);
        void RequestDelete(Guid? id);
        #endregion

        #region Approver

        GenericApiResponse ApproveRequest(CommonRequestModel dtoCommonRequestModel);

        #endregion

    }
}
