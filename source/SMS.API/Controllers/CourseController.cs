using SMS.FACADE.Infrastructure;
using System.Web.Http;

namespace SMS.API.Controllers
{
    [RoutePrefix("api/v1/Course")]
    public class CourseController : ApiController
    {
        public ICourseFacade _courseFacade;

        public CourseController(ICourseFacade courseFacade)
        {
            _courseFacade = courseFacade;
        }
        [HttpGet]
        [Route("Get")]

        public IHttpActionResult Get()
        {
            return Ok(_courseFacade.Test());

        }
    }
}


