using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using DBWorksheet = SMS.DATA.Models.Worksheet;
using DTOWorksheet = SMS.DTOs.DTOs.Worksheet;

namespace SMS.Services.Implementation
{
    public class WorksheetService : IWorksheetService
    {
        #region Properties
        private readonly IRepository<DBWorksheet> _repository;
        private IMapper _mapper;
        #endregion

        #region Init

        public WorksheetService(IRepository<DBWorksheet> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        #endregion

        #region Service Calls

        /// <summary>
        /// Service level call : Creates a single record of a Worksheet
        /// </summary>
        /// <param name="dTOWorksheet"></param>
        public void Create(DTOWorksheet dTOWorksheet)
        {
            dTOWorksheet.CreatedDate = DateTime.Now;
            dTOWorksheet.IsDeleted = false;
            dTOWorksheet.Id = Guid.NewGuid();

            _repository.Add(_mapper.Map<DTOWorksheet, DBWorksheet>(dTOWorksheet));
        }

        /// <summary>
        /// Service level call : Delete a single record of a Worksheet
        /// </summary>
        /// <param name="id"></param>
        public void Delete(Guid? id)
        {
            if (id == null)
                return;
            var worksheet = Get(id);
            if (worksheet != null)
            {
                worksheet.IsDeleted = true;
                worksheet.DeletedDate = DateTime.Now;
                _repository.Update(_mapper.Map<DTOWorksheet, DBWorksheet>(worksheet));
            }

        }

        /// <summary>
        /// Retruns a Single Record of a Worksheet
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DTOWorksheet Get(Guid? id)
        {
            if (id == null)
            {
                return null;
            }

            var worksheet = _repository.Get().FirstOrDefault(x => x.Id == id && (x.IsDeleted == false || x.IsDeleted == null));
            var worksheetDto = _mapper.Map<DBWorksheet, DTOWorksheet>(worksheet);

            return worksheetDto;
        }

        /// <summary>
        /// Service level call : Updates the Single Record of a Worksheet 
        /// </summary>
        /// <param name="dtoWorksheet"></param>
        public void Update(DTOWorksheet dtoWorksheet)
        {
            var worksheet = Get(dtoWorksheet.Id);
            if (worksheet != null)
            {
                dtoWorksheet.UpdateDate = DateTime.Now;
                dtoWorksheet.IsDeleted = false;
                var updated = _mapper.Map(dtoWorksheet, worksheet);

                _repository.Update(_mapper.Map<DTOWorksheet, DBWorksheet>(updated));
            }
        }

        /// <summary>
        /// Service level call : Return all records of a Worksheet
        /// </summary>
        /// <returns></returns>
        List<DTOWorksheet> IWorksheetService.GetAll()
        {
            var worksheets = _repository.Get().Where(x => (x.IsDeleted == false || x.IsDeleted == null)).ToList();
            var worksheetList = new List<DTOWorksheet>();
            foreach (var worksheet in worksheets)
            {
                worksheetList.Add(_mapper.Map<DBWorksheet, DTOWorksheet>(worksheet));
            }
            return worksheetList;
        }

        #endregion
    }
}
