using System;
using System.Web.Http;
using DTOClass = SMS.DTOs.DTOs.Class;
using SMS.Services.Infrastructure;
using System.Web.Http.Cors;

namespace SMS.API.Controllers
{
    [RoutePrefix("api/v1/Class")]
    [EnableCors("*", "*", "*")]
    public class ClassController : ApiController
    {
        public IClassService ClassService;
        public ClassController(IClassService classService)
        {
            ClassService = classService;
        }

        #region SMS Section
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get()
        {
            return Ok(ClassService.Get());
        }
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get(Guid id)
        {
            return Ok(ClassService.Get(id));
        }
        [HttpGet]
        [Route("GetBySchool")]
        public IHttpActionResult GetBySchool(Guid schoolId)
        {
            return Ok(ClassService.GetBySchool(schoolId));
        }
        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create(DTOClass dtoClass)
        {
            ClassService.Create(dtoClass);
            return Ok();
        }
        [HttpPut]
        [Route("Update")]
        public IHttpActionResult Update(DTOClass dtoClass)
        {
            ClassService.Update(dtoClass);
            return Ok();
        }
        [HttpDelete]
        [Route("Delete")]
        public IHttpActionResult Delete(Guid id)
        {
            ClassService.Delete(id);
            return Ok();
        }
        #endregion

        #region SMS Request Section
        [HttpGet]
        [Route("RequestGet")]
        public IHttpActionResult RequestGet()
        {
            return Ok(ClassService.RequestGet());
        }
        [HttpGet]
        [Route("RequestGet")]
        public IHttpActionResult RequestGet(Guid id)
        {
            return Ok(ClassService.RequestGet(id));
        }
        //[HttpGet]
        //[Route("GetBySchool")]
        //public IHttpActionResult GetBySchool(Guid schoolId)
        //{
        //    return Ok(ClassService.GetBySchool(schoolId));
        //}
        [HttpPost]
        [Route("RequestCreate")]
        public IHttpActionResult RequestCreate(DTOClass dtoClass)
        {
            ClassService.RequestCreate(dtoClass);
            return Ok();
        }
        [HttpPut]
        [Route("RequestUpdate")]
        public IHttpActionResult RequestUpdate(DTOClass dtoClass)
        {
            ClassService.RequestUpdate(dtoClass);
            return Ok();
        }
        [HttpDelete]
        [Route("RequestDelete")]
        public IHttpActionResult RequestDelete(Guid id)
        {
            ClassService.RequestDelete(id);
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
