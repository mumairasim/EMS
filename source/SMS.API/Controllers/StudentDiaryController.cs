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
    }
}
