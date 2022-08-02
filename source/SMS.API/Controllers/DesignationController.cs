using System;
using SMS.Services.Infrastructure;
using System.Web.Http;
using DTODesignation = SMS.DTOs.DTOs.Designation;
using System.Web.Http.Cors;

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
        [Route("Get")]
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

    }
}
