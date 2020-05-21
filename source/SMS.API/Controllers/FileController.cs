using SMS.Services.Infrastructure;
using System;
using System.IO;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using DTOFile = SMS.DTOs.DTOs.File;


namespace SMS.API.Controllers
{
    [RoutePrefix("api/v1/File")]
    public class FileController : ApiController
    {

        #region Props and Init
        public IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        #endregion

        #region API Calls
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get(Guid id)
        {
            if (id == null)
            {
                return BadRequest("No Id Recieved");
            }

            try
            {
                var result = _fileService.Get(id);
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
                var result = _fileService.GetAll();
                return Ok(result);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("Save")]
        public IHttpActionResult SaveFile()
        {
            string message, fileName, actualFileName, path;
            message = fileName = actualFileName = path = string.Empty;
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files != null)
            {
                var file = httpRequest.Files[0];
                actualFileName = file.FileName;
                fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                int size = file.ContentLength;

                try
                {

                    path = Path.Combine(HostingEnvironment.MapPath("~/UploadedFiles/"));

                    bool exists = Directory.Exists(path);
                    if (!exists)
                        Directory.CreateDirectory(path);

                    path = path + fileName;
                    file.SaveAs(path);
                    DTOFile newFile = new DTOFile
                    {
                        Name = fileName,
                        Path = path,
                        Size = size,
                        IsDeleted = false
                    };

                    _fileService.Create(newFile);


                }
                catch (Exception)
                {

                    throw;
                }
            }
            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        public IHttpActionResult Update(DTOFile file)
        {
            if (file == null)
            {
                return BadRequest("file not Recieved");
            }

            try
            {
                _fileService.Update(file);
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
                _fileService.Delete(id);
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
