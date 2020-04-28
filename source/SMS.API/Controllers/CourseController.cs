using SMS.FACADE.Infrastructure;
using System.Web.Http;

namespace SMS.API.Controllers
{
    [RoutePrefix("api/v1/Course")]
    public class CourseController : ApiController
    {
        public ICourseFacade CourseFacade;

        public CourseController(ICourseFacade courseFacade)
        {
            CourseFacade = courseFacade;
        }
        [HttpGet]
        [Route("Get")]

        public IHttpActionResult Get()
        {
            return Ok(CourseFacade.Test());

        }
    }
}


