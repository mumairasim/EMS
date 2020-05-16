using System;
using System.Collections.Generic;
using DTOStudent = SMS.DTOs.DTOs.Student;

namespace SMS.FACADE.Infrastructure
{
    public interface IStudentFacade
    {
        List<DTOStudent> Get();
        DTOStudent Get(Guid id);
        void Create(DTOStudent dtoStudent);
        void Update(DTOStudent dtoStudent);
        void Delete(Guid? id,string DeletedBy);
    }
}
