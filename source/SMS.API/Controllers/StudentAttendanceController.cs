using System;
using System.Linq;
using System.Web;
using SMS.Services.Infrastructure;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using SMS.Services.Configurations;
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
        #region SMS Section
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
        /// Fetch data on the basis of class and school 
        /// </summary>
        /// <param name="classId"></param>
        /// <param name="schoolId"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Search")]
        public IHttpActionResult Search(Guid? classId, Guid? schoolId, int pageNumber = 1, int pageSize = 10)
        {
            var predicate = PredicateBuilder.True<DATA.Models.StudentAttendance>();
            predicate.And(sa => sa.IsDeleted == false);
            predicate.And(sa => sa.ClassId == classId);
            predicate.And(sa => sa.SchoolId == schoolId);
            return Ok(StudentAttendanceService.Search(predicate, pageNumber, pageSize));
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
        #endregion

        #region RequestSMS Section
        /// <summary>
        /// Fetch all the data
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>

        [HttpGet]
        [Route("RequestGet")]
        public IHttpActionResult RequestGet(int pageNumber = 1, int pageSize = 10)
        {
            return Ok(StudentAttendanceService.RequestGet(pageNumber, pageSize));
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
        [Route("RequestGet")]
        public IHttpActionResult RequestGet(Guid? classId, Guid? schoolId, int pageNumber = 1, int pageSize = 10)
        {
            return Ok(StudentAttendanceService.RequestGet(classId, schoolId, pageNumber, pageSize));
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
        [Route("RequestSearch")]
        public IHttpActionResult RequestSearch(Guid? classId, Guid? schoolId, int pageNumber = 1, int pageSize = 10)
        {
            var predicate = PredicateBuilder.True<DATA.Models.StudentAttendance>();
            predicate.And(sa => sa.IsDeleted == false);
            predicate.And(sa => sa.ClassId == classId);
            predicate.And(sa => sa.SchoolId == schoolId);
            return Ok(StudentAttendanceService.RequestSearch(predicate, pageNumber, pageSize));
        }
        /// <summary>
        /// Fetch by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet]
        [Route("RequestGet")]
        public IHttpActionResult RequestGet(Guid id)
        {
            return Ok(StudentAttendanceService.RequestGet(id));
        }
        [HttpPost]
        [Route("RequestCreate")]
        public IHttpActionResult RequestCreate()
        {
            var httpRequest = HttpContext.Current.Request;
            var studentAttendanceDetail = JsonConvert.DeserializeObject<DTOStudentAttendance>(httpRequest.Params["studentAttendanceModel"]);
            studentAttendanceDetail.CreatedBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            return Ok(StudentAttendanceService.RequestCreate(studentAttendanceDetail));
        }
        [HttpPut]
        [Route("RequestUpdate")]
        public IHttpActionResult RequestUpdate()
        {
            var httpRequest = HttpContext.Current.Request;
            var studentAttendanceDetail = JsonConvert.DeserializeObject<DTOStudentAttendance>(httpRequest.Params["studentAttendanceModel"]);
            studentAttendanceDetail.UpdateBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            StudentAttendanceService.RequestUpdate(studentAttendanceDetail);
            return Ok();
        }
        [HttpDelete]
        [Route("RequestDelete")]
        public IHttpActionResult RequestDelete(Guid id)
        {
            var deletedBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            StudentAttendanceService.RequestDelete(id, deletedBy);
            return Ok();
        }
        #endregion
    }
}
