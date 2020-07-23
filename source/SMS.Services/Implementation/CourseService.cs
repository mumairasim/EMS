using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.REQUESTDATA.Infrastructure;
using SMS.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using Course = SMS.DATA.Models.Course;
using DTOCourse = SMS.DTOs.DTOs.Course;
using ReqCourse = SMS.REQUESTDATA.RequestModels.Course;

namespace SMS.Services.Implementation
{
    public class CourseService : ICourseService
    {
        #region Properties
        private readonly IRepository<Course> _repository;
        private readonly IRequestRepository<ReqCourse> _requestRepository;
        private IMapper _mapper;
        #endregion

        #region Init

        public CourseService(IRepository<Course> repository, IRequestRepository<ReqCourse> requestRepository, IMapper mapper)
        {
            _repository = repository;
            _requestRepository = requestRepository;
            _mapper = mapper;
        }

        #endregion

        #region SMS Section

        /// <summary>
        /// Service level call : Creates a single record of a Course
        /// </summary>
        /// <param name="dtoCourse"></param>
        public void Create(DTOCourse dtoCourse)
        {
            dtoCourse.CreatedDate = DateTime.UtcNow;
            dtoCourse.IsDeleted = false;
            dtoCourse.Id = Guid.NewGuid();
            _repository.Add(_mapper.Map<DTOCourse, Course>(dtoCourse));
        }

        /// <summary>
        /// Service level call : Delete a single record of a Course
        /// </summary>
        /// <param name="id"></param>
        public void Delete(Guid? id)
        {
            if (id == null)
                return;
            var course = Get(id);
            if (course != null)
            {
                course.IsDeleted = true;
                course.DeletedDate = DateTime.UtcNow;

                _repository.Update(_mapper.Map<DTOCourse, Course>(course));
            }
        }

        /// <summary>
        /// Retruns a Single Record of a Course
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DTOCourse Get(Guid? id)
        {
            if (id == null)
            {
                return null;
            }

            var course = _repository.Get().FirstOrDefault(x => x.Id == id && (x.IsDeleted == false || x.IsDeleted == null));
            var courseDto = _mapper.Map<Course, DTOCourse>(course);

            return courseDto;
        }

        /// <summary>
        /// Service level call : Updates the Single Record of a Course 
        /// </summary>
        /// <param name="dtoCourse"></param>
        public void Update(DTOCourse dtoCourse)
        {
            var course = Get(dtoCourse.Id);
            if (course != null)
            {
                dtoCourse.UpdateDate = DateTime.UtcNow;
                var updated = _mapper.Map(dtoCourse, course);
                dtoCourse.IsDeleted = false;

                _repository.Update(_mapper.Map<DTOCourse, Course>(updated));
            }
        }

        /// <summary>
        /// Service level call : Return all records of course
        /// </summary>
        /// <returns></returns>
        List<DTOCourse> ICourseService.GetAll()
        {
            var courses = _repository.Get().Where(x => (x.IsDeleted == false || x.IsDeleted == null)).ToList();
            var courseList = new List<DTOCourse>();
            foreach (var course in courses)
            {
                courseList.Add(_mapper.Map<Course, DTOCourse>(course));
            }
            return courseList;
        }
        public List<DTOCourse> GetAllBySchool(Guid? schoolId)
        {
            var courses = _repository.Get().Where(x => (x.IsDeleted == false || x.IsDeleted == null) && x.SchoolId == schoolId).ToList();
            var courseList = new List<DTOCourse>();
            foreach (var course in courses)
            {
                courseList.Add(_mapper.Map<Course, DTOCourse>(course));
            }
            return courseList;
        }

        #endregion


        #region SMS Request Section
      
        public List<DTOCourse> RequestGet()
        {
            var courses = _requestRepository.Get().Where(x => (x.IsDeleted == false || x.IsDeleted == null)).ToList();
            var courseList = new List<DTOCourse>();
            foreach (var course in courses)
            {
                courseList.Add(_mapper.Map<ReqCourse, DTOCourse>(course));
            }
            return courseList;
        }
        public DTOCourse RequestGet(Guid? id)
        {
            if (id == null)
            {
                return null;
            }

            var course = _requestRepository.Get().FirstOrDefault(x => x.Id == id && (x.IsDeleted == false || x.IsDeleted == null));
            var courseDto = _mapper.Map<ReqCourse, DTOCourse>(course);

            return courseDto;
        }
        public void RequestCreate(DTOCourse dtoCourse)
        {
            dtoCourse.CreatedDate = DateTime.UtcNow;
            dtoCourse.IsDeleted = false;
            dtoCourse.Id = Guid.NewGuid();
            _requestRepository.Add(_mapper.Map<DTOCourse, ReqCourse>(dtoCourse));
        }

        
        public void RequestDelete(Guid? id)
        {
            if (id == null)
                return;
            var course = RequestGet(id);
            if (course != null)
            {
                course.IsDeleted = true;
                course.DeletedDate = DateTime.UtcNow;

                _requestRepository.Update(_mapper.Map<DTOCourse, ReqCourse>(course));
            }
        }


        
        public void RequestUpdate(DTOCourse dtoCourse)
        {
            var course = RequestGet(dtoCourse.Id);
            if (course != null)
            {
                dtoCourse.UpdateDate = DateTime.UtcNow;
                var updated = _mapper.Map(dtoCourse, course);
                dtoCourse.IsDeleted = false;

                _requestRepository.Update(_mapper.Map<DTOCourse, ReqCourse>(updated));
            }
        }

        
        //public List<DTOCourse> GetAllBySchool(Guid? schoolId)
        //{
        //    var courses = _repository.Get().Where(x => (x.IsDeleted == false || x.IsDeleted == null) && x.SchoolId == schoolId).ToList();
        //    var courseList = new List<DTOCourse>();
        //    foreach (var course in courses)
        //    {
        //        courseList.Add(_mapper.Map<DBCourse, DTOCourse>(course));
        //    }
        //    return courseList;
        //}

        #endregion

    }
}