﻿using System;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using SMS.Services.Infrastructure;
using DTOTimeTable = SMS.DTOs.DTOs.TimeTable;

namespace SMS.API.Controllers
{
    [RoutePrefix("api/v1/TimeTable")]
    [EnableCors("*", "*", "*")]
    public class TimeTableController : ApiController
    {
        public ITimeTableService TimeTableService;
        public TimeTableController(ITimeTableService timeTableService)
        {
            TimeTableService = timeTableService;
        }


        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create()
        {
            var httpRequest = HttpContext.Current.Request;
            var timeTable = JsonConvert.DeserializeObject<DTOTimeTable>(httpRequest.Params["timeTableModel"]);
            timeTable.CreatedBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            TimeTableService.Create(timeTable);
            return Ok();
        }


    }
}