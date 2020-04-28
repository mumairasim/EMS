using System;
using Student = SMS.DATA.Models.Student;
using RequestStudent = SMS.REQUESTDATA.RequestModels.Student;
using DTOStudent = SMS.DTOs.DTOs.Student;

namespace SMS.Services.Infrastructure
{
    public interface IStudentService
    {
        string Get();
        DTOStudent GetbyId(Guid id);
    }
}
