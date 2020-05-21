using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.DTOs.DTOs;
using SMS.Services.Infrastructure;
using LessonPlan = SMS.DATA.Models.LessonPlan;
using DTOLessonPlan = SMS.DTOs.DTOs.LessonPlan;
namespace SMS.Services.Implementation
{
    
    public class LessonPlanService : ILessonPlanService
    {
        private readonly IRepository<LessonPlan> _repository;
        private readonly IMapper _mapper;
        public LessonPlanService(IRepository<LessonPlan> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public LessonPlansList Get(int pageNumber, int pageSize)
        {
            var lessonPlans = _repository.Get().Where(lp => lp.IsDeleted == false).OrderByDescending(lp => lp.CreatedDate).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            var lessonPlanCount = _repository.Get().Where(st => st.IsDeleted == false).Count();
            var lessonPlanList = new List<DTOLessonPlan>();
            foreach (var lessonPlan in lessonPlans)
            {
                lessonPlanList.Add(_mapper.Map<LessonPlan, DTOLessonPlan>(lessonPlan));
            }
            var lessonPlansList = new LessonPlansList()
            {
                LessonPlans = lessonPlanList,
                LessonPlansCount = lessonPlanCount
            };
            return lessonPlansList;
        }
        public DTOLessonPlan Get(Guid? id)
        {
            if (id == null) return null;
            var lessonplanRecord = _repository.Get().FirstOrDefault(lp=>lp.Id==id && lp.IsDeleted == false);
            var lessonplan= _mapper.Map<LessonPlan, DTOLessonPlan>(lessonplanRecord);
            return lessonplan;
        }
        
        public void Create(DTOLessonPlan lessonPlan)
        {
            lessonPlan.CreatedDate = DateTime.Now;
            lessonPlan.IsDeleted = false;
            lessonPlan.Id = Guid.NewGuid();
            lessonPlan.SchoolId = lessonPlan.School.Id;
            lessonPlan.School = null;
            _repository.Add(_mapper.Map<DTOLessonPlan, LessonPlan>(lessonPlan));
        }

        public void Update(DTOLessonPlan dtoLessonplan)
        {
            var lessonplan = Get(dtoLessonplan.Id);
            dtoLessonplan.UpdateDate = DateTime.Now;
            var mergedLessonPlan = _mapper.Map(dtoLessonplan, lessonplan);
            _repository.Update(_mapper.Map<DTOLessonPlan, LessonPlan>(mergedLessonPlan));
        }

        public void Delete(Guid? id, string DeletedBy)
        {
            if (id == null)
                return;
            var lessonplan= Get(id);
            lessonplan.DeletedBy = DeletedBy;
            lessonplan.IsDeleted = true;
            lessonplan.DeletedDate = DateTime.Now;
            _repository.Update(_mapper.Map<DTOLessonPlan, LessonPlan>(lessonplan));
        }
    }
}
