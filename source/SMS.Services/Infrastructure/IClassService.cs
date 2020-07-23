using System;
using SMS.DTOs.DTOs;
using DTOClass = SMS.DTOs.DTOs.Class;

namespace SMS.Services.Infrastructure
{
    public interface IClassService
    {
        ClassesList Get(int pageNumber, int pageSize);
        DTOClass Get(Guid? id);
        void Create(DTOClass Class);
        void Update(DTOClass dtoClass);
        void Delete(Guid? id, string DeletedBy);
    }
}
