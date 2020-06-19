using SMS.Services.Infrastructure;
using System;
using System.Web.Http;
using System.Web.Http.Cors;
using DTOSchool = SMS.DTOs.DTOs.School;

namespace SMS.API.Controllers
{
    [RoutePrefix("api/v1/School")]
    [EnableCors("*", "*", "*")]
    public class SchoolController : ApiController
    {
        public ISchoolService _schoolService;
        public SchoolController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        #region SMS Section
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
        #endregion

        #region SMS Request Section
        [HttpGet]
        [Route("RequestGet")]
        public IHttpActionResult RequestGet()
        {
            return Ok(_schoolService.RequestGet());
        }
        [HttpGet]
        [Route("RequestGet")]
        public IHttpActionResult RequestGet(Guid id)
        {
            return Ok(_schoolService.RequestGet(id));
        }
        [HttpPost]
        [Route("RequestCreate")]
        public IHttpActionResult RequestCreate(DTOSchool dtoSchool)
        {
            _schoolService.RequestCreate(dtoSchool);
            return Ok();
        }
        [HttpPut]
        [Route("RequestUpdate")]
        public IHttpActionResult RequestUpdate(DTOSchool dtoSchool)
        {
            _schoolService.RequestUpdate(dtoSchool);
            return Ok();
        }
        [HttpDelete]
        [Route("RequestDelete")]
        public IHttpActionResult RequestDelete(Guid id)
        {
            _schoolService.RequestDelete(id);
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
