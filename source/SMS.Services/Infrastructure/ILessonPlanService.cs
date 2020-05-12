using System;
using System.Collections.Generic;
using DTOLessonPlan = SMS.DTOs.DTOs.LessonPlan;

namespace SMS.Services.Infrastructure
{
    public interface ILessonPlanService
    {
        List<DTOLessonPlan> Get();
        DTOLessonPlan Get(Guid? id);
        void Create(DTOLessonPlan lessonplan);
        void Update(DTOLessonPlan dtolessonplan);
        void Delete(Guid? id);
    }
}
