﻿using SMS.Services.Infrastructure;
using System;
using System.Web.Http;
using DTOStudentFinanceDetails = SMS.DTOs.DTOs.StudentFinanceDetail;

namespace SMS.API.Controllers
{
    [RoutePrefix("api/v1/StudentFinanceDetails")]
    public class StudentFinanceDetailsController : ApiController
    {
        #region Props and Init
        public IStudentFinanceDetailsService _studentFinanceDetailsService;

        public StudentFinanceDetailsController(IStudentFinanceDetailsService studentFinanceDetailsService)
        {
            _studentFinanceDetailsService = studentFinanceDetailsService;
        }
        #endregion

        #region API Calls
        [HttpGet]
        [Route("Get/{id}")]
        public IHttpActionResult Get(Guid id)
        {
            if (id == null)
            {
                return BadRequest("No Id Recieved");
            }

            try
            {
                var result = _studentFinanceDetailsService.Get(id);
                return Ok(result);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            try
            {
                var result = _studentFinanceDetailsService.GetAll();
                return Ok(result);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create(DTOStudentFinanceDetails dTOStudentFinanceDetails)
        {
            if (dTOStudentFinanceDetails == null)
            {
                return BadRequest("StudentFinances not Recieved");
            }

            try
            {
                _studentFinanceDetailsService.Create(dTOStudentFinanceDetails);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        public IHttpActionResult Update(DTOStudentFinanceDetails dTOStudentFinanceDetails)
        {
            if (dTOStudentFinanceDetails == null)
            {
                return BadRequest("StudentFinances not Recieved");
            }

            try
            {
                _studentFinanceDetailsService.Update(dTOStudentFinanceDetails);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public IHttpActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return BadRequest("No Id Recieved");
            }

            try
            {
                _studentFinanceDetailsService.Delete(id);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
            return Ok();
        }
        #endregion

        #region RequestAPI Calls
        [HttpGet]
        [Route("RequestGet/{id}")]
        public IHttpActionResult RequestGet(Guid id)
        {
            if (id == null)
            {
                return BadRequest("No Id Recieved");
            }

            try
            {
                var result = _studentFinanceDetailsService.RequestGet(id);
                return Ok(result);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("RequestGetAll")]
        public IHttpActionResult RequestGetAll()
        {
            try
            {
                var result = _studentFinanceDetailsService.RequestGetAll();
                return Ok(result);
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("RequestCreate")]
        public IHttpActionResult RequestCreate(DTOStudentFinanceDetails dTOStudentFinanceDetails)
        {
            if (dTOStudentFinanceDetails == null)
            {
                return BadRequest("StudentFinances not Recieved");
            }

            try
            {
                _studentFinanceDetailsService.RequestCreate(dTOStudentFinanceDetails);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
            return Ok();
        }

        [HttpPut]
        [Route("RequestUpdate")]
        public IHttpActionResult RequestUpdate(DTOStudentFinanceDetails dTOStudentFinanceDetails)
        {
            if (dTOStudentFinanceDetails == null)
            {
                return BadRequest("StudentFinances not Recieved");
            }

            try
            {
                _studentFinanceDetailsService.RequestUpdate(dTOStudentFinanceDetails);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
            return Ok();
        }

        [HttpDelete]
        [Route("RequestDelete")]
        public IHttpActionResult RequestDelete(Guid id)
        {
            if (id == null)
            {
                return BadRequest("No Id Recieved");
            }

            try
            {
                _studentFinanceDetailsService.RequestDelete(id);
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
