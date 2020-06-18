using SMS.DTOs.DTOs;
using SMS.Services.Infrastructure;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SMS.API.Controllers
{
    [RoutePrefix("api/v1/Course")]
    [EnableCors("*", "*", "*")]
    public class CourseController : ApiController
    {
        #region Props and Init
        public ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        #endregion

        #region API Calls
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get(Guid? id)
        {
            if (id == null)
            {
                return BadRequest("No Id Recieved");
            }

            try
            {
                var result = _courseService.Get(id);
                return Ok(result);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            try
            {
                var result = _courseService.GetAll();
                return Ok(result);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
        [HttpGet]
        [Route("GetAllBySchool")]
        public IHttpActionResult GetAllBySchool(Guid? schoolId)
        {
            try
            {
                var result = _courseService.GetAllBySchool(schoolId);
                return Ok(result);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create(Course course)
        {
            if (course == null)
            {
                return BadRequest("Course not Recieved");
            }

            try
            {
                _courseService.Create(course);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        public IHttpActionResult Update(Course course)
        {
            if (course == null)
            {
                return BadRequest("Course not Recieved");
            }

            try
            {
                _courseService.Update(course);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public IHttpActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return BadRequest("No Id Recieved");
            }

            try
            {
                _courseService.Delete(id);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
            return Ok();
        }
        #endregion
    }
}


