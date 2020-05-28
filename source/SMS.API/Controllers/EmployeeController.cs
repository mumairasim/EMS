using System;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using SMS.Services.Infrastructure;
using DTOEmployee = SMS.DTOs.DTOs.Employee;

namespace SMS.API.Controllers
{
    [RoutePrefix("api/v1/Employee")]
    [EnableCors("*", "*", "*")]
    public class EmployeeController : ApiController
    {
        public IEmployeeService EmployeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            EmployeeService = employeeService;
        }

        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get(int pageNumber = 1, int pageSize = 10)
        {
            return Ok(EmployeeService.Get(pageNumber, pageSize));
        }

        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get(Guid id)
        {
            return Ok(EmployeeService.Get(id));
        }
        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create()
        {

            var httpRequest = HttpContext.Current.Request;
            var employeeDetail = JsonConvert.DeserializeObject<DTOEmployee>(httpRequest.Params["employeeModel"]);
            employeeDetail.CreatedBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            employeeDetail.Person.CreatedBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            EmployeeService.Create(employeeDetail);
            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        public IHttpActionResult Update()
        {
            var httpRequest = HttpContext.Current.Request;
            var employeeDetail = JsonConvert.DeserializeObject<DTOEmployee>(httpRequest.Params["employeeModel"]);
            employeeDetail.UpdateBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            EmployeeService.Update(employeeDetail);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public IHttpActionResult Delete(Guid id)
        {
            var deletedBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            EmployeeService.Delete(id, deletedBy);
            return Ok();
        }


    }
}