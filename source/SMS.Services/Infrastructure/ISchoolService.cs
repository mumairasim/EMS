using System;
using System.Collections.Generic;
using DTOSchool= SMS.DTOs.DTOs.School;
namespace SMS.Services.Infrastructure
{
    public interface ISchoolService
    {
        List<DTOSchool> Get();
        DTOSchool Get(Guid? id);
        Guid Create(DTOSchool dtoSchool);
        void Update(DTOSchool dtoSchool);
        void Delete(Guid? id);
    }
}
