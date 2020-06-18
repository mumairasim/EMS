using System;
using System.Collections.Generic;
using DTOSchool = SMS.DTOs.DTOs.School;
namespace SMS.Services.Infrastructure
{
    public interface ISchoolService
    {
        #region SMS
        List<DTOSchool> Get();
        DTOSchool Get(Guid? id);
        Guid Create(DTOSchool dtoSchool);
        void Update(DTOSchool dtoSchool);
        void Delete(Guid? id);
        #endregion

        #region SMS Request
        List<DTOSchool> RequestGet();
        DTOSchool RequestGet(Guid? id);
        Guid RequestCreate(DTOSchool dtoSchool);
        void RequestUpdate(DTOSchool dtoSchool);
        void RequestDelete(Guid? id);
        #endregion
    }
}
