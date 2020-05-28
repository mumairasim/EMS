using System;
using System.Collections.Generic;
using DTOClass = SMS.DTOs.DTOs.Class;

namespace SMS.Services.Infrastructure
{
    public interface IClassService
    {
        List<DTOClass> Get();
        DTOClass Get(Guid? id);
        List<DTOClass> GetBySchool(Guid? schoolId);
        void Create(DTOClass Class);
        void Update(DTOClass dtoClass);
        void Delete(Guid? id);

    }
}
