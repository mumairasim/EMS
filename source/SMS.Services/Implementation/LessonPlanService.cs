using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SMS.DATA.Infrastructure;
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
        public List<DTOLessonPlan> Get()
        {
            var lessonplans = _repository.Get().Where(lp => lp.IsDeleted == false).ToList();
            var lessonplanList = new List<DTOLessonPlan>();
            foreach (var lessonplan in lessonplans)
            {
                lessonplanList.Add(_mapper.Map<LessonPlan, DTOLessonPlan>(lessonplan));
            }
            return lessonplanList;
        }
        public DTOLessonPlan Get(Guid? id)
        {
            var lessonplanRecord = _repository.Get().FirstOrDefault(lp=>lp.Id==id);
            var lessonplan= _mapper.Map<LessonPlan, DTOLessonPlan>(lessonplanRecord);
            return lessonplan;
        }
        public void Create(DTOLessonPlan lessonPlan)
        {
            lessonPlan.CreatedDate = DateTime.Now;
            lessonPlan.IsDeleted = false;
            lessonPlan.Id = Guid.NewGuid();
            _repository.Add(_mapper.Map<DTOLessonPlan, LessonPlan>(lessonPlan));
        }
        public void Update(DTOLessonPlan dtoLessonplan)
        {
            var lessonplan = Get(dtoLessonplan.Id);
            dtoLessonplan.UpdateDate = DateTime.Now;
            var mergedLessonPlan = _mapper.Map(dtoLessonplan, lessonplan);
            _repository.Update(_mapper.Map<DTOLessonPlan, LessonPlan>(mergedLessonPlan));
        }
        public void Delete(Guid? id)
        {
            if (id == null)
                return;
            var lessonplan= Get(id);
            lessonplan.IsDeleted = true;
            lessonplan.DeletedDate = DateTime.Now;
            _repository.Update(_mapper.Map<DTOLessonPlan, LessonPlan>(lessonplan));
        }
    }
}
