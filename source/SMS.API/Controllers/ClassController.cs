using System;

using System.Linq;
using System.Web;
using SMS.Services.Infrastructure;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using DTOClass = SMS.DTOs.DTOs.Class;
using SMS.Services.Infrastructure;
using System.Web.Http.Cors;
using SMS.DTOs.DTOs;

namespace SMS.API.Controllers
{
    [RoutePrefix("api/v1/Class")]
    [EnableCors("*", "*", "*")]
    public class ClassController : ApiController
    {
        public IClassService _classService;
        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        #region SMS Section
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get(int pageNumber = 1, int pageSize = 10)
        {
            return Ok(_classService.Get(pageNumber, pageSize));
        }
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get(Guid id)
        {
            return Ok(_classService.Get(id));
        }
        [HttpGet]
        
        
        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create()
        {

            var httpRequest = HttpContext.Current.Request;
            var classDetail = JsonConvert.DeserializeObject<DTOClass>(httpRequest.Params["classModel"]);
             classDetail.CreatedBy = Request.Headers.GetValues("UserName").FirstOrDefault();
             _classService.Create(classDetail);
            return Ok();
            
    }
        [HttpPut]
        [Route("Update")]
        public IHttpActionResult Update()
        {
            var httpRequest = HttpContext.Current.Request;
            var classDetail = JsonConvert.DeserializeObject<DTOClass>(httpRequest.Params["classModel"]);
            classDetail.UpdateBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            classDetail.SchoolId = classDetail.School.Id;
            _classService.Update(classDetail);
           
            return Ok();
        }
        [HttpDelete]
        [Route("Delete")]
        public IHttpActionResult Delete(Guid id)
        {
            var DeletedBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            _classService.Delete(id, DeletedBy);
            return Ok();
        }
        #endregion

        #region SMS Request Section
        [HttpGet]
        [Route("RequestGet")]
        public IHttpActionResult RequestGet()
        {
            return Ok(_classService.RequestGet());
        }
        [HttpGet]
        [Route("RequestGet")]
        public IHttpActionResult RequestGet(Guid id)
        {
            return Ok(_classService.RequestGet(id));
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
            _classService.RequestCreate(dtoClass);
            return Ok();
        }
        [HttpPut]
        [Route("RequestUpdate")]
        public IHttpActionResult RequestUpdate(DTOClass dtoClass)
        {
            _classService.RequestUpdate(dtoClass);
            return Ok();
        }
        [HttpDelete]
        [Route("RequestDelete")]
        public IHttpActionResult RequestDelete(Guid id)
        {
            _classService.RequestDelete(id);
            return Ok();
        }
        #endregion

        #region Request Approver
        [HttpPost]
        [Route("ApproveRequest")]
        public IHttpActionResult ApproveRequest(CommonRequestModel commonRequestModel)
        {

            try
            {
                _classService.ApproveRequest(commonRequestModel);
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