using Newtonsoft.Json;
using SMS.DTOs.DTOs;
using SMS.Services.Infrastructure;
using System;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
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

        #region SMS Section
        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult Get(int pageNumber = 1, int pageSize = 10)
        {
            return Ok(EmployeeService.Get(pageNumber, pageSize));
        }
        [HttpGet]
        [Route("Get/{searchString}")]
        public IHttpActionResult Get(string searchString, int pageNumber = 1, int pageSize = 10)
        {
            return Ok(EmployeeService.Get(searchString, pageNumber, pageSize));
        }
        [HttpGet]
        [Route("GetEmpNo")]
        public IHttpActionResult GetEmpNo(int employeeNumber, int pageNumber = 1, int pageSize = 10)
        {
            return Ok(EmployeeService.Get(employeeNumber, pageNumber, pageSize));
        }

        [HttpGet]
        [Route("GetDesignationTeacher")]
        public IHttpActionResult GetDesignationTeacher()
        {
            return Ok(EmployeeService.GetEmployeeByDesignation());
        }

        [HttpGet]
        [Route("Get/{id}")]
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
        #endregion[HttpGet]

        #region SMS Request Section
        [HttpGet]
        [Route("RequestGet")]
        public IHttpActionResult RequestGet()
        {
            return Ok(EmployeeService.RequestGet());
        }
        [HttpGet]
        [Route("RequestGet/{id}")]
        public IHttpActionResult RequestGet(Guid id)
        {
            return Ok(EmployeeService.RequestGet(id));
        }
        [HttpPost]
        [Route("RequestCreate")]
        public IHttpActionResult RequestCreate(DTOEmployee dtoEmployee)
        {

            EmployeeService.RequestCreate(dtoEmployee);
            return Ok();
        }
        [HttpPut]
        [Route("RequestUpdate")]
        public IHttpActionResult RequestUpdate(DTOEmployee dtoEmployee)
        {
            EmployeeService.RequestUpdate(dtoEmployee);
            return Ok();
        }
        [HttpDelete]
        [Route("RequestDelete")]
        public IHttpActionResult RequestDelete(Guid id)
        {
            EmployeeService.RequestDelete(id);
            return Ok();
        }
        #endregion


        #region Request Approver
        [HttpPost]
        [Route("ApproveRequest")]
        public IHttpActionResult ApproveRequest(CommonRequestModel commonRequestModel)
        {

            try
            {
                EmployeeService.ApproveRequest(commonRequestModel);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
            return Ok();
        }
        #endregion


    }
}