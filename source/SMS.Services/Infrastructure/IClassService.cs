using System;
using System.Collections.Generic;
using SMS.DTOs.DTOs;
using DTOClass = SMS.DTOs.DTOs.Class;

namespace SMS.Services.Infrastructure
{
    public interface IClassService
    {
        #region SMS Section
        ClassesList Get(int pageNumber, int pageSize);
        DTOClass Get(Guid? id);
        void Create(DTOClass Class);
        void Update(DTOClass dtoClass);
        #endregion

        #region SMS Request Section
        List<DTOClass> RequestGet();
        DTOClass RequestGet(Guid? id);
        //st<DTOClass> GetBySchool(Guid? schoolId);
        void RequestCreate(DTOClass Class);
        void RequestUpdate(DTOClass dtoClass);
        void RequestDelete(Guid? id);
        #endregion


        void Delete(Guid? id, string DeletedBy);
    }
}
