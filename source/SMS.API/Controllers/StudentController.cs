using SMS.FACADE.Infrastructure;
using System.Web.Http;

namespace SMS.API.Controllers
{
    [RoutePrefix("api/v1/Student")]
    public class StudentController : ApiController
    {
        public IStudentFacade _studentFacade;
        public StudentController(IStudentFacade studentFacade)
        {
            _studentFacade = studentFacade;
        }

        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get()
        {
            return Ok(_studentFacade.Test());

        }
    }
}