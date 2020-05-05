using System;
using SMS.FACADE.Infrastructure;
using System.Web.Http;
using DTOClass = SMS.DTOs.DTOs.Class;

namespace SMS.API.Controllers
{
    [RoutePrefix("api/v1/Class")]
    public class ClassController : ApiController
    {
        public IClassFacade _classFacade;
        public ClassController(IClassFacade classFacade)
        {
            _classFacade = classFacade;
        }

        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get()
        {
            return Ok(_classFacade.Get());
        }
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get(Guid id)
        {
            return Ok(_classFacade.Get(id));
        }
        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create(DTOClass dtoClass)
        {
            _classFacade.Create(dtoClass);
            return Ok();
        }
        [HttpPut]
        [Route("Update")]
        public IHttpActionResult Update(DTOClass dtoClass)
        {
            _classFacade.Update(dtoClass);
            return Ok();
        }
        [HttpDelete]
        [Route("Delete")]
        public IHttpActionResult Delete(Guid id)
        {
            _classFacade.Delete(id);
            return Ok();
        }
    }
}
