﻿using System;

using System.Linq;
using System.Web;
using SMS.Services.Infrastructure;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using DTOClass = SMS.DTOs.DTOs.Class;

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
    }
}