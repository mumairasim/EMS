﻿using System;
using DTOStudentDiary = SMS.DTOs.DTOs.StudentDiary;
using SMS.DTOs.DTOs;
using System.Collections.Generic;

namespace SMS.Services.Infrastructure
{
    public interface IStudentDiaryService
    {
        #region SMS Section
        StudentDiariesList Get(int pageNumber, int pageSize);
        DTOStudentDiary Get(Guid? id);
        void Create(DTOStudentDiary StudentDiary);
        void Update(DTOStudentDiary dtoStudentDiary);
        void Delete(Guid? id, string DeletedBy);
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
