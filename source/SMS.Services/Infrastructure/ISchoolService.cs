using System;
using SMS.DTOs.DTOs;
using DTOSchool= SMS.DTOs.DTOs.School;
using System.Collections.Generic;
namespace SMS.Services.Infrastructure
{
    public interface ISchoolService
    {
        #region SMS
        SchoolsList Get(int pageNumber, int pageSize);
        DTOSchool Get(Guid? id);
       void Create(DTOSchool dtoSchool);
        void Update(DTOSchool dtoSchool);
        void Delete(Guid? id, string DeletedBy);
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
