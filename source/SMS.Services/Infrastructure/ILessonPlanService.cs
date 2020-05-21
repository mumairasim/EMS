using System;
using System.Collections.Generic;
using SMS.DTOs.DTOs;
using DTOLessonPlan = SMS.DTOs.DTOs.LessonPlan;

namespace SMS.Services.Infrastructure
{
    public interface ILessonPlanService
    {
        LessonPlansList Get(int pageNumber, int pageSize);
        //List<DTOLessonPlan> Get();
        DTOLessonPlan Get(Guid? id);
        void Create(DTOLessonPlan lessonplan);
        void Update(DTOLessonPlan dtolessonplan);
        void Delete(Guid? id, string DeletedBy);
    }
}


