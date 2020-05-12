using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using DBCourse = SMS.DATA.Models.Course;
using DTOCourse = SMS.DTOs.DTOs.Course;

namespace SMS.Services.Implementation
{
    public class CourseService : ICourseService
    {
        #region Properties
        private readonly IRepository<DBCourse> _repository;
        private IMapper _mapper;
        #endregion

        #region Init

        public CourseService(IRepository<DBCourse> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        #endregion

        #region Service Calls

        /// <summary>
        /// Service level call : Creates a single record of a Course
        /// </summary>
        /// <param name="dtoCourse"></param>
        public void Create(DTOCourse dtoCourse)
        {
            dtoCourse.CreatedDate = DateTime.Now;
            dtoCourse.IsDeleted = false;
            dtoCourse.Id = Guid.NewGuid();
            _repository.Add(_mapper.Map<DTOCourse, DBCourse>(dtoCourse));
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
                course.DeletedDate = DateTime.Now;

                _repository.Update(_mapper.Map<DTOCourse, DBCourse>(course));
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
            var courseDto = _mapper.Map<DBCourse, DTOCourse>(course);

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
                dtoCourse.UpdateDate = DateTime.Now;
                var updated = _mapper.Map(dtoCourse, course);
                dtoCourse.IsDeleted = false;

                _repository.Update(_mapper.Map<DTOCourse, DBCourse>(updated));
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
                courseList.Add(_mapper.Map<DBCourse, DTOCourse>(course));
            }
            return courseList;
        }

        #endregion
    }
}