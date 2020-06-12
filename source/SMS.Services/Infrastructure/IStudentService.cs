using System;
using SMS.DTOs.DTOs;
using SMS.DTOs.ReponseDTOs;
using DTOStudent = SMS.DTOs.DTOs.Student;

namespace SMS.Services.Infrastructure
{
    public interface IStudentService
    {
        StudentsList Get(int pageNumber, int pageSize);
        DTOStudent Get(Guid? id);
        StudentsList Get(Guid classId, Guid schoolId);
        StudentResponse Create(DTOStudent student);
        StudentResponse Update(DTOStudent dtoStudent);
        void Delete(Guid? id, string DeletedBy);
    }
}
