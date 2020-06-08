﻿using System;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using SMS.Services.Infrastructure;
using DTOTeacherDiary = SMS.DTOs.DTOs.TeacherDiary;

namespace SMS.API.Controllers
{
    [RoutePrefix("api/v1/TeacherDiary")]
    [EnableCors("*", "*", "*")]
    public class TeacherDiaryController : ApiController
    {
        public ITeacherDiaryService TeacherDiaryService;
        public TeacherDiaryController(ITeacherDiaryService teacherDiaryService)
        {
            TeacherDiaryService = teacherDiaryService;
        }

        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get(int pageNumber = 1, int pageSize = 10)
        {
            return Ok(TeacherDiaryService.Get(pageNumber, pageSize));
        }

        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get(Guid id)
        {
            return Ok(TeacherDiaryService.Get(id));
        }
        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create()
        {

            var httpRequest = HttpContext.Current.Request;
            var teacherDiaryDetail = JsonConvert.DeserializeObject<DTOTeacherDiary>(httpRequest.Params["teacherDiaryModel"]);
            teacherDiaryDetail.CreatedBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            //teacherDiaryDetail.Person.CreatedBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            TeacherDiaryService.Create(teacherDiaryDetail);
            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        public IHttpActionResult Update()
        {
            var httpRequest = HttpContext.Current.Request;
            var teacherDiaryDetail = JsonConvert.DeserializeObject<DTOTeacherDiary>(httpRequest.Params["teacherDiaryModel"]);
            teacherDiaryDetail.UpdateBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            TeacherDiaryService.Update(teacherDiaryDetail);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public IHttpActionResult Delete(Guid id)
        {
            var deletedBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            TeacherDiaryService.Delete(id, deletedBy);
            return Ok();
        }


    }
}