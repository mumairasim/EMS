using System;
using DTOStudent = SMS.DTOs.DTOs.Student;

namespace SMS.FACADE.Infrastructure
{
    public interface IStudentFacade
    {
        string Test();
        DTOStudent GetStudentById(Guid id);
    }
}
