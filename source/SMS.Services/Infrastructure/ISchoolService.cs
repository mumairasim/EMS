using System;
using System.Collections.Generic;
using SMS.DTOs.DTOs;
using DTOSchool= SMS.DTOs.DTOs.School;
namespace SMS.Services.Infrastructure
{
    public interface ISchoolService
    {
        List<DTOSchool> Get(int pageNumber, int pageSize);
        DTOSchool Get(Guid? id);
        Guid Create(DTOSchool dtoSchool);
        void Update(DTOSchool dtoSchool);
        void Delete(Guid? id, string DeletedBy);
    }
}
