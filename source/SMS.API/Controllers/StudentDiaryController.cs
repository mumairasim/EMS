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

        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get(int pageNumber = 1, int pageSize = 10)
        {
            return Ok(_studentDiaryService.Get(pageNumber, pageSize));
        }
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get(Guid id)
        {
            return Ok(_studentDiaryService.Get(id));
        }
        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create()
        {

            var httpRequest = HttpContext.Current.Request;
            var studentDiaryDetail = JsonConvert.DeserializeObject<DTOStudentDiary>(httpRequest.Params["studentDiaryModel"]);
            studentDiaryDetail.CreatedBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            studentDiaryDetail.CreatedBy = Request.Headers.GetValues("UserName").FirstOrDefault();
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
    }
}
