using System;
using SMS.DTOs.DTOs;
using DTOSchool= SMS.DTOs.DTOs.School;
namespace SMS.Services.Infrastructure
{
    public interface ISchoolService
    {
        SchoolsList Get(int pageNumber, int pageSize);
        DTOSchool Get(Guid? id);
       void Create(DTOSchool dtoSchool);
        void Update(DTOSchool dtoSchool);
        void Delete(Guid? id, string DeletedBy);
    }
}
