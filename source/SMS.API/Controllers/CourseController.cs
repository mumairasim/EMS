using SMS.FACADE.Infrastructure;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SMS.API.Controllers
{
    [RoutePrefix("api/v1/Course")]
    [EnableCors("*", "*", "*")]
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


