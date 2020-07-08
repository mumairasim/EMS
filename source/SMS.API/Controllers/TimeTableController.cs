using System;
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

        #region SMS Section

        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get(Guid? schoolId, Guid? classId, int pageNumber = 1, int pageSize = 10)
        {
            return Ok(TimeTableService.Get(schoolId, classId, pageNumber, pageSize));
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

        #endregion

        #region RequestSMS Section

        [HttpGet]
        [Route("RequestGet")]
        public IHttpActionResult RequestGet(Guid? schoolId, Guid? classId, int pageNumber = 1, int pageSize = 10)
        {
            TimeTableService.RequestGet(schoolId, classId, pageNumber, pageSize);
            return Ok();
        }

        [HttpPost]
        [Route("RequestCreate")]
        public IHttpActionResult RequestCreate(DTOTimeTable dtoTimeTable)
        {
           // var httpRequest = HttpContext.Current.Request;
            //dtoTimeTable = JsonConvert.DeserializeObject<DTOTimeTable>(httpRequest.Params["timeTableModel"]);
            //dtoTimeTable.CreatedBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            TimeTableService.RequestCreate(dtoTimeTable);
            return Ok();
        }

        #endregion
    }
}