using System;
using System.Linq;
using SMS.FACADE.Infrastructure;
using System.Web.Http;
using System.Web.Http.Cors;
using DTOStudent = SMS.DTOs.DTOs.Student;

namespace SMS.API.Controllers
{
    [RoutePrefix("api/v1/Student")]
    [EnableCors("*", "*", "*")]
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
            return Ok(_studentFacade.Get());
        }
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get(Guid id)
        {
            return Ok(_studentFacade.Get(id));
        }
        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create(DTOStudent dtoStudent)
        {
            dtoStudent.CreatedBy = Guid.Parse(Request.Headers.GetValues("UserId").FirstOrDefault());
            _studentFacade.Create(dtoStudent);
            return Ok();
        }
        [HttpPut]
        [Route("Update")]
        public IHttpActionResult Update(DTOStudent dtoStudent)
        {
            dtoStudent.UpdateBy = Guid.Parse(Request.Headers.GetValues("UserId").FirstOrDefault());
            _studentFacade.Update(dtoStudent);
            return Ok();
        }
        [HttpDelete]
        [Route("Delete")]
        public IHttpActionResult Delete(Guid id)
        {
            var DeletedBy = Guid.Parse(Request.Headers.GetValues("UserId").FirstOrDefault());
            _studentFacade.Delete(id);
            return Ok();
        }
    }
}