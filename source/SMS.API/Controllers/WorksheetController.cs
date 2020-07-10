using Newtonsoft.Json;
using SMS.DTOs.DTOs;
using SMS.Services.Infrastructure;
using System;
using System.Linq;
using System.Web;
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

        #region SMS

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
        public IHttpActionResult Create()
        {
            var httpRequest = HttpContext.Current.Request;
            var worksheet = JsonConvert.DeserializeObject<Worksheet>(httpRequest.Params["worksheetModel"]);
            worksheet.CreatedBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            worksheet.Employee = null;
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
        public IHttpActionResult Update()
        {
            var httpRequest = HttpContext.Current.Request;
            var worksheet = JsonConvert.DeserializeObject<Worksheet>(httpRequest.Params["worksheetModel"]);
            worksheet.UpdateBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            worksheet.Employee = null;

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

        #region SMS Request
        [HttpGet]
        [Route("RequestGet")]
        public IHttpActionResult RequestGet(Guid id)
        {
            if (id == null)
            {
                return BadRequest("No Id Recieved");
            }

            try
            {
                var result = _worksheetService.RequestGet(id);
                return Ok(result);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("RequestGetAll")]
        public IHttpActionResult RequestGetAll()
        {
            try
            {
                var result = _worksheetService.RequestGetAll();
                return Ok(result);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("RequestCreate")]
        public IHttpActionResult RequestCreate(Worksheet worksheet)
        {
            worksheet.Employee = null;
            try
            {
                _worksheetService.RequestCreate(worksheet);
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
            return Ok();
        }

        [HttpPut]
        [Route("RequestUpdate")]
        public IHttpActionResult RequestUpdate(Worksheet worksheet)
        {
            worksheet.Employee = null;

            try
            {
                _worksheetService.RequestUpdate(worksheet);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
            return Ok();
        }

        [HttpDelete]
        [Route("RequestDelete")]
        public IHttpActionResult RequestDelete(Guid id)
        {
            if (id == null)
            {
                return BadRequest("No Id Recieved");
            }

            try
            {
                _worksheetService.RequestDelete(id);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
            return Ok();
        }
        #endregion

        #region Request Approver
        [HttpPut]
        [Route("ApproveRequest")]
        public IHttpActionResult ApproveRequest(Worksheet worksheet)
        {
            
            try
            {
                _worksheetService.ApproveRequest(worksheet);
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
