using System.Linq;
using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.Services.Infrastructure;
using StudentDiary = SMS.DATA.Models.StudentDiary;
using DTOStudentDiary = SMS.DTOs.DTOs.StudentDiary;
using System;
using System.Collections.Generic;

namespace SMS.Services.Implementation
{
    public class StudentDiaryService : IStudentDiaryService
    {
        private readonly IRepository<StudentDiary> _repository;
        private readonly IMapper _mapper;
        public StudentDiaryService(IRepository<StudentDiary> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public void Create(DTOStudentDiary dtoStudentDiary)
        {
            dtoStudentDiary.CreatedDate = DateTime.UtcNow;
            dtoStudentDiary.IsDeleted = false;
            dtoStudentDiary.Id = Guid.NewGuid();
            dtoStudentDiary.InstructorId = null;
            dtoStudentDiary.School = null;
            _repository.Add(_mapper.Map<DTOStudentDiary, StudentDiary>(dtoStudentDiary));
        }
        public List<DTOStudentDiary> Get()
        {
            var studentDiary = _repository.Get().ToList();
            var StudentDiaryList = new List<DTOStudentDiary>();
            foreach (var studentdiary in studentDiary)
            {
                StudentDiaryList.Add(_mapper.Map<StudentDiary, DTOStudentDiary>(studentdiary));
            }
            return StudentDiaryList;
        }
        public DTOStudentDiary Get(Guid? id)
        {
            if (id == null) return null;
            var StudentDiaryRecord = _repository.Get().FirstOrDefault(sd => sd.Id == id);
            if (StudentDiaryRecord == null) return null;

            return _mapper.Map<StudentDiary, DTOStudentDiary>(StudentDiaryRecord);
        }
        public void Update(DTOStudentDiary dtoStudentDiary)
        {
            var studentDiary = Get(dtoStudentDiary.Id);
            dtoStudentDiary.UpdateDate = DateTime.UtcNow;
            var mergedstudentDiary = _mapper.Map(dtoStudentDiary, studentDiary);
            _repository.Update(_mapper.Map<DTOStudentDiary, StudentDiary>(mergedstudentDiary));
        }
        public void Delete(Guid? id)
        {
            if (id == null)
                return;
            var studentDiary = Get(id);
            studentDiary.IsDeleted = true;
            studentDiary.DeletedDate = DateTime.UtcNow;
            _repository.Update(_mapper.Map<DTOStudentDiary, StudentDiary>(studentDiary));
        }

    }
}
