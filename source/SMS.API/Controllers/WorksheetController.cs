using SMS.DTOs.DTOs;
using SMS.Services.Infrastructure;
using System;
using System.Web.Http;

namespace SMS.API.Controllers
{
    [RoutePrefix("api/v1/Worksheet")]
    public class WorksheetController : ApiController
    {
        #region Props and Init
        public IWorksheetService _worksheetService;

        public WorksheetController(IWorksheetService worksheetService)
        {
            _worksheetService = worksheetService;
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
                var result = _worksheetService.Get(id);
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
                var result = _worksheetService.GetAll();
                return Ok(result);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create(Worksheet worksheet)
        {
            if (worksheet == null)
            {
                return BadRequest("worksheet not Recieved");
            }

            try
            {
                _worksheetService.Create(worksheet);
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        public IHttpActionResult Update(Worksheet worksheet)
        {
            if (worksheet == null)
            {
                return BadRequest("worksheet not Recieved");
            }

            try
            {
                _worksheetService.Update(worksheet);
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
                _worksheetService.Delete(id);
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
