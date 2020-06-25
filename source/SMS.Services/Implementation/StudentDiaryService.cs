using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.DATA.Models;
using SMS.REQUESTDATA.Infrastructure;
using SMS.Services.Infrastructure;
using StudentDiary = SMS.DATA.Models.StudentDiary;
using DTOStudentDiary = SMS.DTOs.DTOs.StudentDiary;
using RequestStudentDiary = SMS.REQUESTDATA.RequestModels.StudentDiary;

namespace SMS.Services.Implementation
{
    public class StudentDiaryService : IStudentDiaryService
    {
        private readonly IRepository<StudentDiary> _repository;
        private readonly IRequestRepository<RequestStudentDiary> _requestRepository;
        private readonly IMapper _mapper;
        public StudentDiaryService(IRepository<StudentDiary> repository, IRequestRepository<RequestStudentDiary> requestRepository, IMapper mapper)
        {
            _repository = repository;
            _requestRepository = requestRepository;
            _mapper = mapper;
        }
        #region SMS Section
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
        #endregion

        #region RequestSMS Section
        public void RequestCreate(DTOStudentDiary dtoStudentDiary)
        {
            dtoStudentDiary.CreatedDate = DateTime.UtcNow;
            dtoStudentDiary.IsDeleted = false;
            dtoStudentDiary.Id = Guid.NewGuid();
            dtoStudentDiary.InstructorId = null;
            dtoStudentDiary.School = null;
            _requestRepository.Add(_mapper.Map<DTOStudentDiary, RequestStudentDiary>(dtoStudentDiary));
        }
        public List<DTOStudentDiary> RequestGet()
        {
            var studentDiary = _requestRepository.Get().ToList();
            var StudentDiaryList = new List<DTOStudentDiary>();
            foreach (var studentdiary in studentDiary)
            {
                StudentDiaryList.Add(_mapper.Map<RequestStudentDiary, DTOStudentDiary>(studentdiary));
            }
            return StudentDiaryList;
        }
        public DTOStudentDiary RequestGet(Guid? id)
        {
            if (id == null) return null;
            var StudentDiaryRecord = _requestRepository.Get().FirstOrDefault(sd => sd.Id == id);
            if (StudentDiaryRecord == null) return null;

            return _mapper.Map<RequestStudentDiary, DTOStudentDiary>(StudentDiaryRecord);
        }
        public void RequestUpdate(DTOStudentDiary dtoStudentDiary)
        {
            var studentDiary = Get(dtoStudentDiary.Id);
            dtoStudentDiary.UpdateDate = DateTime.UtcNow;
            var mergedstudentDiary = _mapper.Map(dtoStudentDiary, studentDiary);
            _requestRepository.Update(_mapper.Map<DTOStudentDiary, RequestStudentDiary>(mergedstudentDiary));
        }
        public void RequestDelete(Guid? id)
        {
            if (id == null)
                return;
            var studentDiary = Get(id);
            studentDiary.IsDeleted = true;
            studentDiary.DeletedDate = DateTime.UtcNow;
            _requestRepository.Update(_mapper.Map<DTOStudentDiary, RequestStudentDiary>(studentDiary));
        }
        #endregion
    }
}
