using System;
using DTOStudentDiary = SMS.DTOs.DTOs.StudentDiary;
using SMS.DTOs.DTOs;

namespace SMS.Services.Infrastructure
{
    public interface IStudentDiaryService
    {
        StudentDiariesList Get(int pageNumber, int pageSize);
        DTOStudentDiary Get(Guid? id);
        void Create(DTOStudentDiary StudentDiary);
        void Update(DTOStudentDiary dtoStudentDiary);
        void Delete(Guid? id, string DeletedBy);
    }
}
