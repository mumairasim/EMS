using SMS.Services.Infrastructure;
using System;
using System.Web.Http;
using DTOStudentFinances = SMS.DTOs.DTOs.Student_Finances;

namespace SMS.API.Controllers
{
    [RoutePrefix("api/v1/StudentFinance")]
    public class StudentFinanceController : ApiController
    {
        #region Props and Init
        public IStudentFinanceService _studentFinanceService;

        public StudentFinanceController(IStudentFinanceService studentFinanceService)
        {
            _studentFinanceService = studentFinanceService;
        }
        #endregion

        #region API Calls
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get(Guid id)
        {
            if (id == null)
            {
                return BadRequest("No Id Recieved");
            }

            try
            {
                var result = _studentFinanceService.Get(id);
                return Ok(result);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            try
            {
                var result = _studentFinanceService.GetAll();
                return Ok(result);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create(DTOStudentFinances dTOStudentFinances)
        {
            if (dTOStudentFinances == null)
            {
                return BadRequest("StudentFinances not Recieved");
            }

            try
            {
                _studentFinanceService.Create(dTOStudentFinances);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        public IHttpActionResult Update(DTOStudentFinances dTOStudentFinances)
        {
            if (dTOStudentFinances == null)
            {
                return BadRequest("StudentFinances not Recieved");
            }

            try
            {
                _studentFinanceService.Update(dTOStudentFinances);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public IHttpActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return BadRequest("No Id Recieved");
            }

            try
            {
                _studentFinanceService.Delete(id);
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
