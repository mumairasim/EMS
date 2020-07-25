using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.DATA.Models;
using SMS.REQUESTDATA.Infrastructure;
using SMS.DTOs.DTOs;
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
            dtoStudentDiary.UpdateDate = DateTime.UtcNow;
            var mergedstudentDiary = _mapper.Map(dtoStudentDiary, studentDiary);
            _repository.Update(_mapper.Map<DTOStudentDiary, StudentDiary>(mergedstudentDiary));
        }
        public void Delete(Guid? id, string DeletedBy)
        {
            if (id == null)
                return;
            var studentDiary = Get(id);
            studentDiary.IsDeleted = true;
            studentDiary.DeletedBy = DeletedBy;

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
            dtoStudentDiary.Employee = null;
            dtoStudentDiary.School = null;
            _requestRepository.Add(_mapper.Map<DTOStudentDiary, RequestStudentDiary>(dtoStudentDiary));
        }
        public List<DTOStudentDiary> RequestGet()
        {
            var studentDiary = _requestRepository.Get().Where(sd => sd.IsDeleted == false).ToList();
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
            var studentDiary = RequestGet(dtoStudentDiary.Id);
            dtoStudentDiary.UpdateDate = DateTime.UtcNow;
            var mergedstudentDiary = _mapper.Map(dtoStudentDiary, studentDiary);
            _requestRepository.Update(_mapper.Map<DTOStudentDiary, RequestStudentDiary>(mergedstudentDiary));
        }
        public void RequestDelete(Guid? id)
        {
            if (id == null)
                return;
            var studentDiary = RequestGet(id);
            studentDiary.IsDeleted = true;
            studentDiary.DeletedDate = DateTime.UtcNow;
            _requestRepository.Update(_mapper.Map<DTOStudentDiary, RequestStudentDiary>(studentDiary));
        }
        #endregion

        #region private
        private void HelpingMethodForRelationship(DTOStudentDiary dtoStudentDiary)
        {
            dtoStudentDiary.InstructorId = dtoStudentDiary.Employee.Id;
            dtoStudentDiary.SchoolId = dtoStudentDiary.School.Id;
            dtoStudentDiary.School = null;
            dtoStudentDiary.Employee = null;
        }
        #endregion
    }
     

}

