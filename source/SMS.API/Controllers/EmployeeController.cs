using System;
using System.IO;
using System.Linq;
using System.Web;
using SMS.FACADE.Infrastructure;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using DTOEmployee = SMS.DTOs.DTOs.Employee;

namespace SMS.API.Controllers
{
    [RoutePrefix("api/v1/Employee")]
    [EnableCors("*", "*", "*")]
    public class EmployeeController : ApiController
    {
        public IEmployeeFacade _employeeFacade;
        public EmployeeController(IEmployeeFacade employeeFacade)
        {
            _employeeFacade = employeeFacade;
        }

        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get(int pageNumber = 1, int pageSize = 10)
        {
            return Ok(_employeeFacade.Get(pageNumber, pageSize));
        }

        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get(Guid id)
        {
            return Ok(_employeeFacade.Get(id));
        }
        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create()
        {

            var httpRequest = HttpContext.Current.Request;
            var employeeDetail = JsonConvert.DeserializeObject<DTOEmployee>(httpRequest.Params["employeeModel"]);
            employeeDetail.CreatedBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            employeeDetail.Person.CreatedBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            _employeeFacade.Create(employeeDetail);
            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        public IHttpActionResult Update()
        {
            var httpRequest = HttpContext.Current.Request;
            var employeeDetail = JsonConvert.DeserializeObject<DTOEmployee>(httpRequest.Params["employeeModel"]);
            employeeDetail.UpdateBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            _employeeFacade.Update(employeeDetail);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public IHttpActionResult Delete(Guid id)
        {
            var DeletedBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            _employeeFacade.Delete(id, DeletedBy);
            return Ok();
        }


    }
}