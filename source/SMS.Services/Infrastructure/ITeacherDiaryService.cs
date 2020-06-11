using System;
using SMS.DTOs.DTOs;
using DTOTeacherDiary = SMS.DTOs.DTOs.TeacherDiary;

namespace SMS.Services.Infrastructure
{
    public interface ITeacherDiaryService
    {
        TeacherDiariesList Get(int pageNumber,int pageSize);
        DTOTeacherDiary Get(Guid? id);
        void Create(DTOTeacherDiary teacherDiary);
        void Update(DTOTeacherDiary dtoTeacherDiary);
        void Delete(Guid? id, string DeletedBy);
    }
}





