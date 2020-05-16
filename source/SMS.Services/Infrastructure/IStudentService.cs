using System;
using System.Collections.Generic;
using DTOStudent = SMS.DTOs.DTOs.Student;

namespace SMS.Services.Infrastructure
{
    public interface IStudentService
    {
        List<DTOStudent> Get();
        DTOStudent Get(Guid? id);
        void Create(DTOStudent student);
        void Update(DTOStudent dtoStudent);
        void Delete(Guid? id, string DeletedBy);
    }
}
