using Newtonsoft.Json;
using SMS.DTOs.DTOs;
using SMS.DTOs.ReponseDTOs;
using SMS.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using DTOClass = SMS.DTOs.DTOs.Class;

namespace SMS.API.Controllers
{
    [RoutePrefix("api/v1/Class")]
    [EnableCors("*", "*", "*")]
    public class ClassController : ApiController
    {
        public IClassService _classService;

        public ISchoolService _schoolService;
        public ClassController(IClassService classService, ISchoolService schoolService)
        {
            _classService = classService;
            _schoolService = schoolService;
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
        [Route("Get")]
        public IHttpActionResult Get(string searchString, int pageNumber = 1, int pageSize = 10)
        {
            return Ok(_classService.Get(pageNumber, pageSize, searchString));
        }
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
        [HttpGet]
        [Route("GetBySchool")]
        public IHttpActionResult GetBySchool(Guid schoolId)
        {
            return Ok(_classService.GetBySchool(schoolId));
        }
        [HttpDelete]
        [Route("Delete")]
        public IHttpActionResult Delete(Guid id)
        {
            var DeletedBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            _classService.Delete(id, DeletedBy);
            return Ok();
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("BulkCreate")]
        public IHttpActionResult BulkCreate(List<DATA.Models.Class> classesDetail)
        {
            if (classesDetail == null || classesDetail.Count < 1)
                return Ok(new GenericApiResponse
                {
                    StatusCode = "400",
                    Message = "Invalid Input",
                    Description = "Invalid Parameter"
                });
            if (_schoolService.IsSchoolExist(classesDetail.FirstOrDefault().SchoolId))
                return Ok(_classService.BulkCreate(classesDetail));
            return Ok(new GenericApiResponse
            {
                StatusCode = "400",
                Message = "School Not Found",
                Description = "School Not Found"
            });

        }
        #endregion
    }
}