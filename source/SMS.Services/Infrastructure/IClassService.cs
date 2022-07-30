using System;
using System.Collections.Generic;
using SMS.DTOs.DTOs;
using SMS.DTOs.ReponseDTOs;
using DTOClass = SMS.DTOs.DTOs.Class;

namespace SMS.Services.Infrastructure
{
    public interface IClassService
    {
        #region SMS Section
        ClassesList Get(int pageNumber, int pageSize);
        DTOClass Get(Guid? id);
        GenericApiResponse Create(DTOClass Class);
        GenericApiResponse Update(DTOClass dtoClass);
        void Delete(Guid? id, string DeletedBy);
        List<DTOClass> GetBySchool(Guid? schoolId);
        #endregion

    }
}
