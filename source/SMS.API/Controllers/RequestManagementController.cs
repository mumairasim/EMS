using SMS.Services.Infrastructure;
using System;
using System.Web.Http;

namespace SMS.API.Controllers
{
    [RoutePrefix("api/v1/RequestManagement")]
    public class RequestManagementController : ApiController
    {
        #region Props and Init
        public IRequestManagementService RequestManagementService;

        public RequestManagementController(IRequestManagementService requestManagementService)
        {
            RequestManagementService = requestManagementService;
        }
        #endregion

        #region SMS


        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            try
            {
                var result = RequestManagementService.GetAllRequests();
                return Ok(result);
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }
        #endregion
    }
}
