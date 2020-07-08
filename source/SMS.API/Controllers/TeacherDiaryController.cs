using System;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using SMS.Services.Infrastructure;
using DTOTeacherDiary = SMS.DTOs.DTOs.TeacherDiary;

namespace SMS.API.Controllers
{
    [RoutePrefix("api/v1/TeacherDiary")]
    [EnableCors("*", "*", "*")]
    public class TeacherDiaryController : ApiController
    {
        public ITeacherDiaryService TeacherDiaryService;
        public TeacherDiaryController(ITeacherDiaryService teacherDiaryService)
        {
            TeacherDiaryService = teacherDiaryService;
        }
        #region SMS Section
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get(int pageNumber = 1, int pageSize = 10)
        {
            return Ok(TeacherDiaryService.Get(pageNumber, pageSize));
        }

        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get(Guid id)
        {
            return Ok(TeacherDiaryService.Get(id));
        }
        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create()
        {

            var httpRequest = HttpContext.Current.Request;
            var teacherDiaryDetail = JsonConvert.DeserializeObject<DTOTeacherDiary>(httpRequest.Params["teacherDiaryModel"]);
            teacherDiaryDetail.CreatedBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            //teacherDiaryDetail.Person.CreatedBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            return Ok(TeacherDiaryService.Create(teacherDiaryDetail));
        }
        [HttpPut]
        [Route("Update")]
        public IHttpActionResult Update()
        {
            var httpRequest = HttpContext.Current.Request;
            var teacherDiaryDetail = JsonConvert.DeserializeObject<DTOTeacherDiary>(httpRequest.Params["teacherDiaryModel"]);
            teacherDiaryDetail.UpdateBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            return Ok(TeacherDiaryService.Update(teacherDiaryDetail));
        }

        [HttpDelete]
        [Route("Delete")]
        public IHttpActionResult Delete(Guid id)
        {
            var deletedBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            TeacherDiaryService.Delete(id, deletedBy);
            return Ok();
        }

        #endregion

        #region RequestSMS Section
        [HttpGet]
        [Route("RequestGet")]
        public IHttpActionResult RequestGet(int pageNumber = 1, int pageSize = 10)
        {
            return Ok(TeacherDiaryService.RequestGet(pageNumber, pageSize));
        }

        [HttpGet]
        [Route("RequestGet")]
        public IHttpActionResult RequestGet(Guid id)
        {
            return Ok(TeacherDiaryService.RequestGet(id));
        }
        [HttpPost]
        [Route("RequestCreate")]
        public IHttpActionResult RequestCreate(DTOTeacherDiary dtoTeacherDiary)
        {

            //var httpRequest = HttpContext.Current.Request;
            //var teacherDiaryDetail = JsonConvert.DeserializeObject<DTOTeacherDiary>(httpRequest.Params["teacherDiaryModel"]);
            //teacherDiaryDetail.CreatedBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            //teacherDiaryDetail.Person.CreatedBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            TeacherDiaryService.RequestCreate(dtoTeacherDiary);
            return Ok();
        }
        [HttpPut]
        [Route("RequestUpdate")]
        public IHttpActionResult RequestUpdate(DTOTeacherDiary dtoTeacherDiary)
        {
            //var httpRequest = HttpContext.Current.Request;
            //var teacherDiaryDetail = JsonConvert.DeserializeObject<DTOTeacherDiary>(httpRequest.Params["teacherDiaryModel"]);
            //teacherDiaryDetail.UpdateBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            return Ok(TeacherDiaryService.RequestUpdate(dtoTeacherDiary));
        }

        [HttpDelete]
        [Route("RequestDelete")]
        public IHttpActionResult RequestDelete(Guid id)
        {
            var deletedBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            TeacherDiaryService.RequestDelete(id, deletedBy);
            return Ok();
        }

        #endregion
    }
}