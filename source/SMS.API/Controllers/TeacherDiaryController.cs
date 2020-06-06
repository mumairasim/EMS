using System;
using SMS.Services.Infrastructure;
using System.Web.Http;
using DTOTeacherDiary = SMS.DTOs.DTOs.TeacherDiary;

namespace SMS.API.Controllers
{
    [RoutePrefix("api/v1/TeacherDiary")]

    public class TeacherDiaryController : ApiController
    {
        public ITeacherDiaryService _teacherDiaryService;
        public TeacherDiaryController(ITeacherDiaryService teacherDiaryService)
        {
            _teacherDiaryService = teacherDiaryService;
        }

        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get()
        {
            return Ok(_teacherDiaryService.Get());
        }

        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get(Guid id)
        {
            return Ok(_teacherDiaryService.Get(id));
        }

        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create(DTOTeacherDiary dtoTeacherDiary)
        {
            _teacherDiaryService.Create(dtoTeacherDiary);
            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        public IHttpActionResult Update(DTOTeacherDiary dtoTeacherDiary)
        {
            _teacherDiaryService.Update(dtoTeacherDiary);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public IHttpActionResult Delete(Guid id)
        {
            _teacherDiaryService.Delete(id);
            return Ok();
        }
    }
}