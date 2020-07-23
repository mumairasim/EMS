using System;
using System.IO;
using System.Linq;
using System.Web;
using SMS.Services.Infrastructure;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using DTOStudentDiary = SMS.DTOs.DTOs.StudentDiary;


namespace SMS.API.Controllers
{
    [RoutePrefix("api/v1/StudentDiary")]
    [EnableCors("*", "*", "*")]
    public class StudentDiaryController : ApiController
    {
        public IStudentDiaryService _studentDiaryService;
        public StudentDiaryController(IStudentDiaryService studentDiaryService)
        {
            _studentDiaryService = studentDiaryService;
        }
        #region SMS Section
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get(int pageNumber = 1, int pageSize = 10)
        {
            var studentList = _studentDiaryService.Get(pageNumber, pageSize);
            return Ok(studentList);
        }
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get(Guid id)
        {
            var studentGet = _studentDiaryService.Get(id);
            return Ok(studentGet);
        }
        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create()
        {

            var httpRequest = HttpContext.Current.Request;
            var studentDiaryDetail = JsonConvert.DeserializeObject<DTOStudentDiary>(httpRequest.Params["studentDiaryModel"]);
            studentDiaryDetail.CreatedBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            studentDiaryDetail.CreatedBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            studentDiaryDetail.InstructorId = studentDiaryDetail.Employee.Id;
            studentDiaryDetail.SchoolId = studentDiaryDetail.School.Id;
            _studentDiaryService.Create(studentDiaryDetail);
            return Ok();
        }
        [HttpPut]
        [Route("Update")]
        public IHttpActionResult Update()
        {
            var httpRequest = HttpContext.Current.Request;
            var studentDiaryDetail = JsonConvert.DeserializeObject<DTOStudentDiary>(httpRequest.Params["studentDiaryModel"]);
            studentDiaryDetail.UpdateBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            studentDiaryDetail.CreatedBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            studentDiaryDetail.InstructorId = studentDiaryDetail.Employee.Id;
            studentDiaryDetail.SchoolId = studentDiaryDetail.School.Id;
            _studentDiaryService.Update(studentDiaryDetail);
            return Ok();
        }
        [HttpDelete]
        [Route("Delete")]
        public IHttpActionResult Delete(Guid id)
        {
            var DeletedBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            _studentDiaryService.Delete(id, DeletedBy);
            return Ok();
        }
        #endregion

        #region RequestSMS Section
        [HttpGet]
        [Route("RequestGet")]
        public IHttpActionResult RequestGet()
        {
            return Ok(_studentDiaryService.RequestGet());
        }
        [HttpGet]
        [Route("RequestGet")]
        public IHttpActionResult RequestGet(Guid id)
        {
            return Ok(_studentDiaryService.RequestGet(id));
        }
        [HttpPost]
        [Route("RequestCreate")]
        public IHttpActionResult RequestCreate(DTOStudentDiary dtoStudentDiary)
        {
            _studentDiaryService.RequestCreate(dtoStudentDiary);
            return Ok();
        }
        [HttpPut]
        [Route("RequestUpdate")]
        public IHttpActionResult RequestUpdate(DTOStudentDiary dtoStudentDiary)
        {
            _studentDiaryService.RequestUpdate(dtoStudentDiary);
            return Ok();
        }
        [HttpDelete]
        [Route("RequestDelete")]
        public IHttpActionResult RequestDelete(Guid id)
        {
            _studentDiaryService.RequestDelete(id);
            return Ok();
        }
        #endregion
       
    }
}
