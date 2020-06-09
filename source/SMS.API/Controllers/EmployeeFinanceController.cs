using SMS.Services.Infrastructure;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SMS.API.Controllers
{
    [RoutePrefix("api/v1/EmployeeFinance")]
    [EnableCors("*", "*", "*")]
    public class EmployeeFinanceController : ApiController
    {
        #region Props and Init
        public IEmployeeFinanceService _empFinanceService;

        public EmployeeFinanceController(IEmployeeFinanceService empFinanceService)
        {
            _empFinanceService = empFinanceService;
        }
        #endregion

        #region APIs
        [HttpGet]
        [Route("GetByFilter/{schoolId}/{SalaryMonth}")]
        public IHttpActionResult GetByFilter(Guid? schoolId = null, Guid? designationId = null, string SalaryMonth = "0")
        {
            if (SalaryMonth == "0")
            {
                SalaryMonth = null;
            }
            try
            {
                var result = _empFinanceService.GetByFilter(schoolId, designationId, SalaryMonth);
                return Ok(result);
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        #endregion
    }
}
