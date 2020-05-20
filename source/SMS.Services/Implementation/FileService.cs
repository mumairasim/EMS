using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
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
        /// <param name="dTOFile"></param>
        public void Create(DTOFile dTOFile)
        {
            dTOFile.CreatedDate = DateTime.Now;
            dTOFile.IsDeleted = false;
            dTOFile.Id = Guid.NewGuid();

            _repository.Add(_mapper.Map<DTOFile, DBFile>(dTOFile));
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

            return fileDto;
        }

        /// <summary>
        /// Service level call : Updates the Single Record of a File 
        /// </summary>
        /// <param name="dtoFile"></param>
        public void Update(DTOFile dtoFile)
        {
            var file = Get(dtoFile.Id);
            if (file != null)
            {
                dtoFile.UpdateDate = DateTime.Now;
                dtoFile.IsDeleted = false;
                var updated = _mapper.Map(dtoFile, file);

                _repository.Update(_mapper.Map<DTOFile, DBFile>(updated));
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
            foreach (var File in files)
            {
                fileList.Add(_mapper.Map<DBFile, DTOFile>(File));
            }
            return fileList;
        }

        #endregion
    }
}
