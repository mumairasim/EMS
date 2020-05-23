using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Hosting;
using DBFile = SMS.DATA.Models.File;
using DTOFile = SMS.DTOs.DTOs.File;

namespace SMS.Services.Implementation
{
    public class FileService : IFileService
    {
        #region Properties
        private readonly IRepository<DBFile> _repository;
        private IMapper _mapper;
        #endregion

        #region Init

        public FileService(IRepository<DBFile> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        #endregion

        #region Service Calls

        /// <summary>
        /// Service level call : Creates a single record of a File
        /// </summary>
        /// <param name="dToFile"></param>
        public Guid Create(DTOFile dToFile)
        {
            dToFile.CreatedDate = DateTime.Now;
            dToFile.IsDeleted = false;
            dToFile.Id = Guid.NewGuid();
            _repository.Add(_mapper.Map<DTOFile, DBFile>(dToFile));
            return dToFile.Id;
        }
        public Guid? Create(HttpPostedFile file)
        {
            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            int size = file.ContentLength;
            try
            {
                var path = Path.Combine(HostingEnvironment.MapPath(WebConfigurationManager.AppSettings["FileUploadFolder"]));
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
                return Create(newFile);
            }
            catch
            {
                // ignored
                return null;
            }
        }

        /// <summary>
        /// Service level call : Delete a single record of a File
        /// </summary>
        /// <param name="id"></param>
        public void Delete(Guid? id)
        {
            if (id == null)
                return;
            var file = Get(id);
            if (file != null)
            {
                file.IsDeleted = true;
                file.DeletedDate = DateTime.Now;
                _repository.Update(_mapper.Map<DTOFile, DBFile>(file));
            }

        }

        /// <summary>
        /// Retruns a Single Record of a File
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DTOFile Get(Guid? id)
        {
            if (id == null)
            {
                return null;
            }

            var file = _repository.Get().FirstOrDefault(x => x.Id == id && (x.IsDeleted == false || x.IsDeleted == null));
            var fileDto = _mapper.Map<DBFile, DTOFile>(file);
            fileDto.ImageFile = File.ReadAllBytes(fileDto.Path);
            return fileDto;
        }

        /// <summary>
        /// Service level call : Updates the Single Record of a File 
        /// </summary>
        /// <param name="dtoFile"></param>
        private void Update(DTOFile dtoFile)
        {
            dtoFile.UpdateDate = DateTime.Now;
            dtoFile.IsDeleted = false;
            _repository.Update(_mapper.Map<DTOFile, DBFile>(dtoFile));
        }
        public void Update(HttpPostedFile file, Guid fileId)
        {
            try
            {
                var dbFile = Get(fileId);
                File.Delete(dbFile.Path);
                file.SaveAs(dbFile.Path);
                Update(dbFile);
            }
            catch
            {
                // ignored
            }
        }

        /// <summary>
        /// Service level call : Return all records of a File
        /// </summary>
        /// <returns></returns>
        List<DTOFile> IFileService.GetAll()
        {
            var files = _repository.Get().Where(x => (x.IsDeleted == false || x.IsDeleted == null)).ToList();
            var fileList = new List<DTOFile>();
            foreach (var file in files)
            {
                fileList.Add(_mapper.Map<DBFile, DTOFile>(file));
            }
            return fileList;
        }

        #endregion
    }
}
