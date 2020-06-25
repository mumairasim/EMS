using System;
using System.Collections.Generic;
using DTOStudentDiary = SMS.DTOs.DTOs.StudentDiary;
namespace SMS.Services.Infrastructure
{
    public interface IStudentDiaryService
    {
        #region SMS Section
        List<DTOStudentDiary> Get();
        DTOStudentDiary Get(Guid? id);
        void Create(DTOStudentDiary StudentDiary );
        void Update(DTOStudentDiary dtoStudentDiary);
        void Delete(Guid? id);
        #endregion

        #region RequestSMS Section
        List<DTOStudentDiary> RequestGet();
        DTOStudentDiary RequestGet(Guid? id);
        void RequestCreate(DTOStudentDiary StudentDiary);
        void RequestUpdate(DTOStudentDiary dtoStudentDiary);
        void RequestDelete(Guid? id);
        #endregion
    }
}
