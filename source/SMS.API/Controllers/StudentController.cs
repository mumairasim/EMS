using System;
using System.IO;
using System.Linq;
using System.Web;
using SMS.FACADE.Infrastructure;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
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
        public IHttpActionResult Get(int pageNumber = 1, int pageSize = 10)
        {
            return Ok(_studentFacade.Get(pageNumber, pageSize));
        }
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get(Guid id)
        {
            return Ok(_studentFacade.Get(id));
        }
        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create()
        {

            var httpRequest = HttpContext.Current.Request;
            var studentDetail = JsonConvert.DeserializeObject<DTOStudent>(httpRequest.Params["studentModel"]);
            studentDetail.CreatedBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            studentDetail.Person.CreatedBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            _studentFacade.Create(studentDetail);
            return Ok();
        }
        [HttpPut]
        [Route("Update")]
        public IHttpActionResult Update()
        {
            var httpRequest = HttpContext.Current.Request;
            var studentDetail = JsonConvert.DeserializeObject<DTOStudent>(httpRequest.Params["studentModel"]);
            studentDetail.UpdateBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            _studentFacade.Update(studentDetail);
            return Ok();
        }
        [HttpDelete]
        [Route("Delete")]
        public IHttpActionResult Delete(Guid id)
        {
            var DeletedBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            _studentFacade.Delete(id, DeletedBy);
            return Ok();
        }
    }
}