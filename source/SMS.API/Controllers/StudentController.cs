using System;
using SMS.FACADE.Infrastructure;
using System.Web.Http;
using DTOStudent = SMS.DTOs.DTOs.Student;

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
            _studentFacade.Create(dtoStudent);
            return Ok();
        }
        [HttpPut]
        [Route("Update")]
        public IHttpActionResult Update(DTOStudent dtoStudent)
        {
            _studentFacade.Update(dtoStudent);
            return Ok();
        }
        [HttpDelete]
        [Route("Delete")]
        public IHttpActionResult Delete(Guid id)
        {
            _studentFacade.Delete(id);
            return Ok();
        }
    }
}