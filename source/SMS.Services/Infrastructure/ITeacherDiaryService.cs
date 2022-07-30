using System;
using SMS.DTOs.DTOs;
using SMS.DTOs.ReponseDTOs;
using DTOTeacherDiary = SMS.DTOs.DTOs.TeacherDiary;

namespace SMS.Services.Infrastructure
{
    public interface ITeacherDiaryService
    {
        #region SMS Section
        TeacherDiariesList Get(int pageNumber,int pageSize);
        DTOTeacherDiary Get(Guid? id);
        TeacherDiaryResponse Create(DTOTeacherDiary teacherDiary);
        TeacherDiaryResponse Update(DTOTeacherDiary dtoTeacherDiary);
        void Delete(Guid? id, string DeletedBy);
        #endregion

    }
}



