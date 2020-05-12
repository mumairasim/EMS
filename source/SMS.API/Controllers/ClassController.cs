using System;
using SMS.FACADE.Infrastructure;
using System.Web.Http;
using DTOClass = SMS.DTOs.DTOs.Class;
using SMS.Services.Infrastructure;

namespace SMS.API.Controllers
{
    [RoutePrefix("api/v1/Class")]
    public class ClassController : ApiController
    {
        public IClassService _classService;
        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get()
        {
            return Ok(_classService.Get());
        }
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get(Guid id)
        {
            return Ok(_classService.Get(id));
        }
        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create(DTOClass dtoClass)
        {
            _classService.Create(dtoClass);
            return Ok();
        }
        [HttpPut]
        [Route("Update")]
        public IHttpActionResult Update(DTOClass dtoClass)
        {
            _classService.Update(dtoClass);
            return Ok();
        }
        [HttpDelete]
        [Route("Delete")]
        public IHttpActionResult Delete(Guid id)
        {
            _classService.Delete(id);
            return Ok();
        }
    }
}
