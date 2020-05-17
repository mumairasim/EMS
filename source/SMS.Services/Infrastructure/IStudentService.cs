using System;
using SMS.DTOs.DTOs;
using DTOStudent = SMS.DTOs.DTOs.Student;

namespace SMS.Services.Infrastructure
{
    public interface IStudentService
    {
        StudentsList Get(int pageNumber, int pageSize);
        DTOStudent Get(Guid? id);
        void Create(DTOStudent student);
        void Update(DTOStudent dtoStudent);
        void Delete(Guid? id, string DeletedBy);
    }
}
