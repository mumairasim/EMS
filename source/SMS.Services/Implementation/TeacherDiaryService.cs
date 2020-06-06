using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SMS.DATA.Infrastructure;
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
        public List<DTOTeacherDiary> Get()
        {
            var teacherDiaries = _repository.Get().Where(td => td.IsDeleted == false).ToList();
            var teacherDiaryList = new List<DTOTeacherDiary>();
            foreach (var teacherDiary in teacherDiaries)
            {
                teacherDiaryList.Add(_mapper.Map<TeacherDiary, DTOTeacherDiary>(teacherDiary));
            }
            return teacherDiaryList;
        }
        public DTOTeacherDiary Get(Guid? id)
        {
            var teacherDiaryRecord = _repository.Get().FirstOrDefault(td => td.Id == id);
            var teacherDiary = _mapper.Map<TeacherDiary, DTOTeacherDiary>(teacherDiaryRecord);
            return teacherDiary;
        }
        public void Create(DTOTeacherDiary teacherDiary)
        {
            teacherDiary.CreatedDate = DateTime.Now;
            teacherDiary.IsDeleted = false;
            teacherDiary.Id = Guid.NewGuid();
            _repository.Add(_mapper.Map<DTOTeacherDiary, TeacherDiary>(teacherDiary));
        }
        public void Update(DTOTeacherDiary dtoTeacherDiary)
        {
            var teacherDiary = Get(dtoTeacherDiary.Id);
            dtoTeacherDiary.UpdateDate = DateTime.Now;
            var mergedTeacherDiary = _mapper.Map(dtoTeacherDiary, teacherDiary);
            _repository.Update(_mapper.Map<DTOTeacherDiary, TeacherDiary>(mergedTeacherDiary));
        }
        public void Delete(Guid? id)
        {
            if (id == null)
                return;
            var teacherDiary = Get(id);
            teacherDiary.IsDeleted = true;
            teacherDiary.DeletedDate = DateTime.Now;
            _repository.Update(_mapper.Map<DTOTeacherDiary, TeacherDiary>(teacherDiary));
        }
    }
}
