using System;
using System.Collections.Generic;
using DTOStudentDiary = SMS.DTOs.DTOs.StudentDiary;
namespace SMS.Services.Infrastructure
{
    public interface IStudentDiaryService
    {
        List<DTOStudentDiary> Get();
        DTOStudentDiary Get(Guid? id);
        void Create(DTOStudentDiary StudentDiary );
        void Update(DTOStudentDiary dtoStudentDiary);
        void Delete(Guid? id);
    }
}
