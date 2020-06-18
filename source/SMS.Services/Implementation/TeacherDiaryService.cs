using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.DTOs.DTOs;
using SMS.Services.Infrastructure;
using TeacherDiary = SMS.DATA.Models.TeacherDiary;
using DTOTeacherDiary = SMS.DTOs.DTOs.TeacherDiary;

namespace SMS.Services.Implementation
{
        public class TeacherDiaryService: ITeacherDiaryService
    {
        private readonly IRepository<TeacherDiary> _repository;
        private readonly IMapper _mapper;
        public TeacherDiaryService(IRepository<TeacherDiary> repository,  IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public TeacherDiariesList Get(int pageNumber, int pageSize)
        {
            var teacherDiaries = _repository.Get().Where(td => td.IsDeleted == false).OrderByDescending(st => st.DairyDate).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList(); ;
            var teacherDiaryCount = _repository.Get().Count(td => td.IsDeleted == false);
            var teacherDiaryTempList = new List<DTOTeacherDiary>();
            foreach (var teacherDiary in teacherDiaries)
            {
                teacherDiaryTempList.Add(_mapper.Map<TeacherDiary, DTOTeacherDiary>(teacherDiary));
            }
            var teacherDiariesList = new TeacherDiariesList()
            {
                TeacherDiaries = teacherDiaryTempList,
                TeacherDiariesCount = teacherDiaryCount
            };
            return teacherDiariesList;
        }
        public DTOTeacherDiary Get(Guid? id)
        {
            if (id == null) return null;
            var teacherDiaryRecord = _repository.Get().FirstOrDefault(td => td.Id == id && td.IsDeleted == false);
            var teacherDiary = _mapper.Map<TeacherDiary, DTOTeacherDiary>(teacherDiaryRecord);
            return teacherDiary;
        }

        public void Create(DTOTeacherDiary dtoteacherDiary)
        {
            dtoteacherDiary.CreatedDate = DateTime.Now;
            dtoteacherDiary.IsDeleted = false;
            dtoteacherDiary.Id = Guid.NewGuid();
            HelpingMethodForRelationship(dtoteacherDiary);
            _repository.Add(_mapper.Map<DTOTeacherDiary, TeacherDiary>(dtoteacherDiary));
        }
        private void HelpingMethodForRelationship(DTOTeacherDiary dtoteacherDiary)
        {
            dtoteacherDiary.SchoolId = dtoteacherDiary.School.Id;
            dtoteacherDiary.School = null;
            dtoteacherDiary.InstructorId = dtoteacherDiary.Employee.Id;
            dtoteacherDiary.Employee = null;
        }

        
        public void Update(DTOTeacherDiary dtoteacherDiary)
        {
            var teacherDiary = Get(dtoteacherDiary.Id);
            dtoteacherDiary.UpdateDate = DateTime.UtcNow;
            HelpingMethodForRelationship(dtoteacherDiary);
            var mergedTeacherDiary = _mapper.Map(dtoteacherDiary, teacherDiary);
            _repository.Update(_mapper.Map<DTOTeacherDiary, TeacherDiary>(mergedTeacherDiary));
        }

        public void Delete(Guid? id, string DeletedBy)
        {
            if (id == null)
                return;
            var teacherDiary = Get(id);
            teacherDiary.IsDeleted = true;
            teacherDiary.DeletedBy = DeletedBy;
            teacherDiary.DeletedDate = DateTime.UtcNow;
            _repository.Update(_mapper.Map<DTOTeacherDiary, TeacherDiary>(teacherDiary));
        }
    }
}
