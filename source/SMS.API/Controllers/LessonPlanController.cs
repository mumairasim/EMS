
using System;
using SMS.Services.Infrastructure;
using System.Web.Http;
using DTOLessonPlan = SMS.DTOs.DTOs.LessonPlan;

namespace SMS.API.Controllers
{
    [RoutePrefix("api/v1/LessonPlan")]
    public class LessonPlanController : ApiController
    {
        public ILessonPlanService _lessonplanService;
        public LessonPlanController(ILessonPlanService lessonplanService)
        {
            _lessonplanService = lessonplanService;
        }

        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get()
        {
            return Ok(_lessonplanService.Get());
        }

        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get(Guid id)
        {
            return Ok(_lessonplanService.Get(id));
        }

        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create(DTOLessonPlan dtoLessonPlan)
        {
            _lessonplanService.Create(dtoLessonPlan);
            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        public IHttpActionResult Update(DTOLessonPlan dtoLessonPlan)
        {
            _lessonplanService.Update(dtoLessonPlan);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public IHttpActionResult Delete(Guid id)
        {
            _lessonplanService.Delete(id);
            return Ok();
        }

    }
}

