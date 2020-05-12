using System;
using SMS.Services.Infrastructure;
using System.Web.Http;
using DTOSchool = SMS.DTOs.DTOs.School;

namespace SMS.API.Controllers
{
    [RoutePrefix("api/v1/School")]
    public class SchoolController : ApiController
    {
        public ISchoolService _schoolService;
        public SchoolController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get()
        {
            return Ok(_schoolService.Get());
        }
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get(Guid id)
        {
            return Ok(_schoolService.Get(id));
        }
        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create(DTOSchool dtoSchool)
        {
            _schoolService.Create(dtoSchool);
            return Ok();
        }
        [HttpPut]
        [Route("Update")]
        public IHttpActionResult Update(DTOSchool dtoSchool)
        {
            _schoolService.Update(dtoSchool);
            return Ok();
        }
        [HttpDelete]
        [Route("Delete")]
        public IHttpActionResult Delete(Guid id)
        {
            _schoolService.Delete(id);
            return Ok();
        }
    }
}
