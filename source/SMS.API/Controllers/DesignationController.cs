using System;
using SMS.Services.Infrastructure;
using System.Web.Http;
using DTODesignation = SMS.DTOs.DTOs.Designation;

namespace SMS.API.Controllers
{
    [RoutePrefix("api/v1/Designation")]
    public class DesignationController : ApiController
    {
        public IDesignationService _designationService;
        public DesignationController(IDesignationService designationService)
        {
            _designationService = designationService;
        }

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
    }
}
