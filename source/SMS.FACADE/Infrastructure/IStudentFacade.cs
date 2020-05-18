using System;
using SMS.DTOs.DTOs;
using DTOStudent = SMS.DTOs.DTOs.Student;

namespace SMS.FACADE.Infrastructure
{
    public interface IStudentFacade
    {
        StudentsList Get(int pageNumber, int pageSize);
        DTOStudent Get(Guid id);
        void Create(DTOStudent dtoStudent);
        void Update(DTOStudent dtoStudent);
        void Delete(Guid? id,string DeletedBy);
    }
}
