using System;
using SMS.Services.Infrastructure;
using System.Web.Http;
using DTOStudentDiary = SMS.DTOs.DTOs.StudentDiary;


namespace SMS.API.Controllers
{
    [RoutePrefix("api/v1/StudentDiary")]
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
        public IHttpActionResult Get()
        {
            return Ok(_studentDiaryService.Get());
        }
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get(Guid id)
        {
            return Ok(_studentDiaryService.Get(id));
        }
        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create(DTOStudentDiary dtoStudentDiary)
        {
            _studentDiaryService.Create(dtoStudentDiary);
            return Ok();
        }
        [HttpPut]
        [Route("Update")]
        public IHttpActionResult Update(DTOStudentDiary dtoStudentDiary)
        {
            _studentDiaryService.Update(dtoStudentDiary);
            return Ok();
        }
        [HttpDelete]
        [Route("Delete")]
        public IHttpActionResult Delete(Guid id)
        {
            _studentDiaryService.Delete(id);
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
