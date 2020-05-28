using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.DTOs.DTOs;
using SMS.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using StudentDiary = SMS.DATA.Models.StudentDiary;
using DTOStudentDiary = SMS.DTOs.DTOs.StudentDiary;


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
            dtoStudentDiary.CreatedDate = DateTime.Now;
            dtoStudentDiary.IsDeleted = false;
            dtoStudentDiary.Id = Guid.NewGuid();
            HelpingMethodForRelationship(dtoStudentDiary);
            _repository.Add(_mapper.Map<DTOStudentDiary, StudentDiary>(dtoStudentDiary));
        }
        public StudentDiariesList Get(int pageNumber, int pageSize)
        {
            var StudentDiaries = _repository.Get().Where(cl => cl.IsDeleted == false).OrderByDescending(st => st.Id).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            var StudentDiariesCount = _repository.Get().Where(st => st.IsDeleted == false).Count();
            var studentDiaryTempList = new List<DTOStudentDiary>();
            foreach (var studentdiary in StudentDiaries)
            {
                studentDiaryTempList.Add(_mapper.Map<StudentDiary, DTOStudentDiary>(studentdiary));
            }
            var studentDiariesList = new StudentDiariesList()
            {
                StudentDiaries = studentDiaryTempList,
                StudentDiariesCount= StudentDiariesCount
            };
            return studentDiariesList;
        }
        public DTOStudentDiary Get(Guid? id)
        {
            if (id == null) return null;
            var studentDiaryRecord = _repository.Get().FirstOrDefault(cl => cl.Id == id && cl.IsDeleted == false);
            var studentdiary = _mapper.Map < StudentDiary, DTOStudentDiary >(studentDiaryRecord);

            return studentdiary;
        }
        public void Update(DTOStudentDiary dtoStudentDiary)
        {
            var studentDiary = Get(dtoStudentDiary.Id);
            dtoStudentDiary.UpdateDate = DateTime.Now;
            var mergedStudentDiary = _mapper.Map(dtoStudentDiary, studentDiary);
            _repository.Update(_mapper.Map<DTOStudentDiary, StudentDiary>(mergedStudentDiary));
        }
        public void Delete(Guid? id, string DeletedBy)
        {
            if (id == null)
                return;
            var studentDiary = Get(id);
            studentDiary.IsDeleted = true;
            studentDiary.DeletedBy = DeletedBy;
            studentDiary.DeletedDate = DateTime.Now;

            _repository.Update(_mapper.Map<DTOStudentDiary, StudentDiary>(studentDiary));
        }

        private void HelpingMethodForRelationship(DTOStudentDiary dtoStudentDiary)
        {
            dtoStudentDiary.SchoolId = dtoStudentDiary.School.Id;
            dtoStudentDiary.InstructorId = dtoStudentDiary.Employee.Id;
            dtoStudentDiary.School = null;
            dtoStudentDiary.Employee = null;
        }
    }
     

}

