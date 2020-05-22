using System;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using SMS.Services.Infrastructure;
using DTOStudent = SMS.DTOs.DTOs.Student;

namespace SMS.API.Controllers
{
    [RoutePrefix("api/v1/Student")]
    [EnableCors("*", "*", "*")]
    public class StudentController : ApiController
    {
        public IStudentService StudentService;
        public IFileService FileService;
        public StudentController(IStudentService studentService, IFileService fileService)
        {
            StudentService = studentService;
            FileService = fileService;
        }

        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get(int pageNumber = 1, int pageSize = 10)
        {
            return Ok(StudentService.Get(pageNumber, pageSize));
        }
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get(Guid id)
        {
            return Ok(StudentService.Get(id));
        }
        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create()
        {

            var httpRequest = HttpContext.Current.Request;
            var studentDetail = JsonConvert.DeserializeObject<DTOStudent>(httpRequest.Params["studentModel"]);
            studentDetail.CreatedBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            studentDetail.Person.CreatedBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            if (httpRequest.Files.Count > 0)
            {
                var file = httpRequest.Files[0];
                studentDetail.ImageId = FileService.Create(file);
            }
            StudentService.Create(studentDetail);
            return Ok();
        }
        [HttpPut]
        [Route("Update")]
        public IHttpActionResult Update()
        {
            var httpRequest = HttpContext.Current.Request;
            var studentDetail = JsonConvert.DeserializeObject<DTOStudent>(httpRequest.Params["studentModel"]);
            studentDetail.UpdateBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            studentDetail.Person.UpdateBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            if (httpRequest.Files.Count > 0)
            {
                var file = httpRequest.Files[0];
                FileService.Update(file, studentDetail.Image);
            }
            StudentService.Update(studentDetail);
            return Ok();
        }
        [HttpDelete]
        [Route("Delete")]
        public IHttpActionResult Delete(Guid id)
        {
            var deletedBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            StudentService.Delete(id, deletedBy);
            return Ok();
        }
    }
}