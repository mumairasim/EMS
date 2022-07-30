
using Newtonsoft.Json;
using SMS.DTOs.DTOs;
using SMS.Services.Infrastructure;
using System;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using DTOLessonPlan = SMS.DTOs.DTOs.LessonPlan;


namespace SMS.API.Controllers
{
    [RoutePrefix("api/v1/LessonPlan")]
    [EnableCors("*", "*", "*")]
    public class LessonPlanController : ApiController
    {
        public ILessonPlanService _lessonplanService;
        public LessonPlanController(ILessonPlanService lessonplanService)
        {
            _lessonplanService = lessonplanService;
        }

        #region SMS Section
        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult Get(int pageNumber = 1, int pageSize = 10)
        {
            return Ok(_lessonplanService.Get(pageNumber, pageSize));
        }

        [HttpGet]
        [Route("Get/{id}")]
        public IHttpActionResult Get(Guid id)
        {
            return Ok(_lessonplanService.Get(id));
        }

        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create()
        {
            var httpRequest = HttpContext.Current.Request;
            var lessonPlanDetail = JsonConvert.DeserializeObject<DTOLessonPlan>(httpRequest.Params["lessonPlanModel"]);
            lessonPlanDetail.CreatedBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            return Ok(_lessonplanService.Create(lessonPlanDetail));

        }

        [HttpPut]
        [Route("Update")]
        public IHttpActionResult Update()
        {
            var httpRequest = HttpContext.Current.Request;
            var lessonPlanDetail = JsonConvert.DeserializeObject<DTOLessonPlan>(httpRequest.Params["lessonPlanModel"]);
            lessonPlanDetail.UpdateBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            return Ok(_lessonplanService.Update(lessonPlanDetail));
        }

        [HttpDelete]
        [Route("Delete")]
        public IHttpActionResult Delete(Guid id)
        {
            var DeletedBy = Request.Headers.GetValues("UserName").FirstOrDefault();
            _lessonplanService.Delete(id, DeletedBy);
            return Ok();
        }
        #endregion

        #region SMS Request Section
        [HttpGet]
        [Route("RequestGet")]
        public IHttpActionResult RequestGet()
        {
            return Ok(_lessonplanService.RequestGet());
        }
        [HttpGet]
        [Route("RequestGet/{id}")]
        public IHttpActionResult RequestGet(Guid id)
        {
            return Ok(_lessonplanService.RequestGet(id));
        }
        [HttpPost]
        [Route("RequestCreate")]
        public IHttpActionResult RequestCreate(DTOLessonPlan dtoLessonPlan)
        {
            _lessonplanService.RequestCreate(dtoLessonPlan);
            return Ok();
        }
        [HttpPut]
        [Route("RequestUpdate")]
        public IHttpActionResult RequestUpdate(DTOLessonPlan dtoLessonPlan)
        {
            _lessonplanService.RequestUpdate(dtoLessonPlan);
            return Ok();
        }
        [HttpDelete]
        [Route("RequestDelete")]
        public IHttpActionResult RequestDelete(Guid id)
        {
            _lessonplanService.RequestDelete(id);
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
                _lessonplanService.ApproveRequest(commonRequestModel);
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
            return Ok();
        }
        #endregion

    }
}

