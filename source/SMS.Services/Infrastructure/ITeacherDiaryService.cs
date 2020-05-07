using System;
using System.Collections.Generic;
using DTOTeacherDiary = SMS.DTOs.DTOs.TeacherDiary;

namespace SMS.Services.Infrastructure
{
    public interface ITeacherDiaryService
    {
        List<DTOTeacherDiary> Get();
        DTOTeacherDiary Get(Guid? id);
        void Create(DTOTeacherDiary teacherDiary);
        void Update(DTOTeacherDiary dtoTeacherDiary);
        void Delete(Guid? id);
    }
}