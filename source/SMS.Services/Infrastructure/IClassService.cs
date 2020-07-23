using System;
using System.Collections.Generic;
using DTOClass = SMS.DTOs.DTOs.Class;

namespace SMS.Services.Infrastructure
{
    public interface IClassService
    {
        #region SMS Section
        List<DTOClass> Get();
        DTOClass Get(Guid? id);
        List<DTOClass> GetBySchool(Guid? schoolId);
        void Create(DTOClass Class);
        void Update(DTOClass dtoClass);
        void Delete(Guid? id);
        #endregion

        #region SMS Request Section
        List<DTOClass> RequestGet();
        DTOClass RequestGet(Guid? id);
        //st<DTOClass> GetBySchool(Guid? schoolId);
        void RequestCreate(DTOClass Class);
        void RequestUpdate(DTOClass dtoClass);
        void RequestDelete(Guid? id);
        #endregion


    }
}
