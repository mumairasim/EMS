using SMS.Services.Infrastructure;
using System;
using System.Web.Http;
using System.Web.Http.Cors;
using DTODesignation = SMS.DTOs.DTOs.Designation;

namespace SMS.API.Controllers
{
    [RoutePrefix("api/v1/Designation")]
    [EnableCors("*", "*", "*")]
    public class DesignationController : ApiController
    {
        public IDesignationService _designationService;
        public DesignationController(IDesignationService designationService)
        {
            _designationService = designationService;
        }

        #region SMS Section
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get()
        {
            return Ok(_designationService.Get());
        }
        [HttpGet]
        [Route("Get/{id}")]
        public IHttpActionResult Get(Guid id)
        {
            return Ok(_designationService.Get(id));
        }
        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create(DTODesignation dtoDesignation)
        {
            _designationService.Create(dtoDesignation);
            return Ok();
        }
        [HttpPut]
        [Route("Update")]
        public IHttpActionResult Update(DTODesignation dtoDesignation)
        {
            _designationService.Update(dtoDesignation);
            return Ok();
        }
        [HttpDelete]
        [Route("Delete")]
        public IHttpActionResult Delete(Guid id)
        {
            _designationService.Delete(id);
            return Ok();
        }
        #endregion

        #region SMS Request Section
        [HttpGet]
        [Route("RequestGet")]
        public IHttpActionResult RequestGet()
        {
            return Ok(_designationService.RequestGet());
        }
        [HttpGet]
        [Route("RequestGet/{id}")]
        public IHttpActionResult RequestGet(Guid id)
        {
            return Ok(_designationService.RequestGet(id));
        }
        [HttpPost]
        [Route("RequestCreate")]
        public IHttpActionResult RequestCreate(DTODesignation dtoDesignation)
        {
            _designationService.RequestCreate(dtoDesignation);
            return Ok();
        }
        [HttpPut]
        [Route("RequestUpdate")]
        public IHttpActionResult RequestUpdate(DTODesignation dtoDesignation)
        {
            _designationService.RequestUpdate(dtoDesignation);
            return Ok();
        }
        [HttpDelete]
        [Route("RequestDelete")]
        public IHttpActionResult RequestDelete(Guid id)
        {
            _designationService.RequestDelete(id);
            return Ok();
        }
        #endregion

        #region Request Approver
        [HttpGet]
        [Route("ApproveRequest")]
        public IHttpActionResult ApproveRequest(Guid id)
        {
            //to be added
            throw new NotImplementedException();
        }
        #endregion
    }
}
