using System;
using System.Linq;
using System.Web;
using SMS.Services.Infrastructure;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using SMS.DTOs.DTOs;
using DTOStudentAttendance = SMS.DTOs.DTOs.StudentAttendance;

namespace SMS.API.Controllers
{
    [RoutePrefix("api/v1/StudentAttendance")]
    [EnableCors("*", "*", "*")]
    public class StudentAttendanceController : ApiController
    {
        public IStudentAttendanceService StudentAttendanceService;
        public StudentAttendanceController(IStudentAttendanceService studentAttendanceService)
        {
            StudentAttendanceService = studentAttendanceService;
        }
        /// <summary>
        /// Fetch all the data
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get(int pageNumber = 1, int pageSize = 10)
        {
            return Ok(StudentAttendanceService.Get(pageNumber, pageSize));
        }
        /// <summary>
        /// Fetch data on the basis of class and school 
        /// </summary>
        /// <param name="classId"></param>
        /// <param name="schoolId"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get(Guid? classId, Guid? schoolId, int pageNumber = 1, int pageSize = 10)
        {
            return Ok(StudentAttendanceService.Get(classId, schoolId, pageNumber, pageSize));
        }
        /// <summary>
        /// Fetch by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get(Guid id)
        {
            return Ok(StudentAttendanceService.Get(id));
        }
        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create()
        {
            var httpRequest = HttpContext.Current.Request;
            var studentAttendanceDetail = JsonConvert.DeserializeObject<DTOStudentAttendance>(httpRequest.Params["studentAttendanceModel"]);
            studentAttendanceDetail.CreatedBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            return Ok(StudentAttendanceService.Create(studentAttendanceDetail));
        }
        [HttpPut]
        [Route("Update")]
        public IHttpActionResult Update()
        {
            var httpRequest = HttpContext.Current.Request;
            var studentAttendanceDetail = JsonConvert.DeserializeObject<DTOStudentAttendance>(httpRequest.Params["studentAttendanceModel"]);
            studentAttendanceDetail.UpdateBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            StudentAttendanceService.Update(studentAttendanceDetail);
            return Ok();
        }
        [HttpDelete]
        [Route("Delete")]
        public IHttpActionResult Delete(Guid id)
        {
            var deletedBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            StudentAttendanceService.Delete(id, deletedBy);
            return Ok();
        }
    }
}
