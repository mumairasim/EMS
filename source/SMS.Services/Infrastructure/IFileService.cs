using System;
using System.Collections.Generic;
using DTOFile = SMS.DTOs.DTOs.File;

namespace SMS.Services.Infrastructure
{
    public interface IFileService
    {
        /// <summary>
        /// Service level call : Return all records of a File
        /// </summary>
        /// <returns></returns>
        List<DTOFile> GetAll();

        /// <summary>
        /// Retruns a Single Record of a File
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DTOFile Get(Guid? id);

        /// <summary>
        /// Service level call : Creates a single record of a File
        /// </summary>
        /// <param name="dtoFile"></param>
        void Create(DTOFile dTOFile);

        /// <summary>
        /// Service level call : Updates the Single Record of a File 
        /// </summary>
        /// <param name="dtoFile"></param>
        void Update(DTOFile dTOFile);

        /// <summary>
        /// Service level call : Delete a single record of a File
        /// </summary>
        /// <param name="id"></param>
        void Delete(Guid? id);
    }
}
