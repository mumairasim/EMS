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
            dtoStudentDiary.CreatedDate = DateTime.Now;
            dtoStudentDiary.IsDeleted = false;
            dtoStudentDiary.Id = Guid.NewGuid();
            dtoStudentDiary.InstructorId = null;
            dtoStudentDiary.School = null;
            _repository.Add(_mapper.Map<DTOStudentDiary, StudentDiary>(dtoStudentDiary));
        }
        public List<DTOStudentDiary> Get(int pageNumber, int pageSize)
        {
             var studentDiaries = _repository.Get().Where(cl => cl.IsDeleted == false).OrderByDescending(st => st.Id).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            var StudentDiaryList = new List<DTOStudentDiary>();
            foreach (var Classes in studentDiaries)
            {
                StudentDiaryList.Add(_mapper.Map<StudentDiary, DTOStudentDiary>(Classes));
            }
            return StudentDiaryList;
        }
        public DTOStudentDiary Get(Guid? id)
        {
            if (id == null) return null;
            var studentRecord = _repository.Get().FirstOrDefault(st => st.Id == id && st.IsDeleted == false);
            var student = _mapper.Map<StudentDiary, DTOStudentDiary>(studentRecord);
            return student;
        }
        public void Update(DTOStudentDiary dtoStudentDiary)
        {
            var student = Get(dtoStudentDiary.Id);
            dtoStudentDiary.UpdateDate = DateTime.Now;
            var mergedStudentDiary = _mapper.Map(dtoStudentDiary, student);
           
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
