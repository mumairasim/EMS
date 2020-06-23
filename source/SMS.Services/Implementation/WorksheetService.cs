using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.REQUESTDATA.Infrastructure;
using SMS.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using DBWorksheet = SMS.DATA.Models.Worksheet;
using DTOWorksheet = SMS.DTOs.DTOs.Worksheet;
using ReqWorksheet = SMS.REQUESTDATA.RequestModels.Worksheet;

namespace SMS.Services.Implementation
{
    public class WorksheetService : IWorksheetService
    {
        #region Properties
        private readonly IRepository<DBWorksheet> _repository;
        private readonly IRequestRepository<ReqWorksheet> _requestRepository;
        private IMapper _mapper;
        #endregion

        #region Init

        public WorksheetService(IRepository<DBWorksheet> repository, IMapper mapper, IRequestRepository<ReqWorksheet> requestRepository)
        {
            _repository = repository;
            _requestRepository = requestRepository;
            _mapper = mapper;
        }

        #endregion

        #region SMS


        /// <summary>
        /// Service level call : Creates a single record of a Worksheet
        /// </summary>
        /// <param name="dTOWorksheet"></param>
        public void Create(DTOWorksheet dTOWorksheet)
        {
            dTOWorksheet.CreatedDate = DateTime.UtcNow;
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
                worksheet.DeletedDate = DateTime.UtcNow;
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
                dtoWorksheet.UpdateDate = DateTime.UtcNow;
                dtoWorksheet.IsDeleted = false;
                var updated = _mapper.Map(dtoWorksheet, worksheet);
                var updatedDbRec = _mapper.Map<DTOWorksheet, DBWorksheet>(updated);
                _repository.Update(updatedDbRec);
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

        #region SMS Request

        /// <summary>
        /// Service level call : Creates a single record of a Worksheet of SMS Request
        /// </summary>
        /// <param name="dTOWorksheet"></param>
        public void RequestCreate(DTOWorksheet dTOWorksheet)
        {
            dTOWorksheet.CreatedDate = DateTime.UtcNow;
            dTOWorksheet.IsDeleted = false;
            dTOWorksheet.Id = Guid.NewGuid();

            _requestRepository.Add(_mapper.Map<DTOWorksheet, ReqWorksheet>(dTOWorksheet));
        }

        /// <summary>
        /// Service level call : Delete a single record of a Worksheet of SMS Request
        /// </summary>
        /// <param name="id"></param>
        public void RequestDelete(Guid? id)
        {
            if (id == null)
                return;
            var worksheet = Get(id);
            if (worksheet != null)
            {
                worksheet.IsDeleted = true;
                worksheet.DeletedDate = DateTime.UtcNow;
                _requestRepository.Update(_mapper.Map<DTOWorksheet, ReqWorksheet>(worksheet));
            }

        }

        /// <summary>
        /// Retruns a Single Record of a Worksheet of SMS Request
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DTOWorksheet RequestGet(Guid? id)
        {
            if (id == null)
            {
                return null;
            }

            var worksheet = _requestRepository.Get().FirstOrDefault(x => x.Id == id && (x.IsDeleted == false || x.IsDeleted == null));
            var worksheetDto = _mapper.Map<ReqWorksheet, DTOWorksheet>(worksheet);

            return worksheetDto;
        }

        /// <summary>
        /// Service level call : Updates the Single Record of a Worksheet of SMS Request
        /// </summary>
        /// <param name="dtoWorksheet"></param>
        public void RequestUpdate(DTOWorksheet dtoWorksheet)
        {
            var worksheet = Get(dtoWorksheet.Id);
            if (worksheet != null)
            {
                dtoWorksheet.UpdateDate = DateTime.UtcNow;
                dtoWorksheet.IsDeleted = false;
                var updated = _mapper.Map(dtoWorksheet, worksheet);
                var updatedDbRec = _mapper.Map<DTOWorksheet, ReqWorksheet>(updated);
                _requestRepository.Update(updatedDbRec);
            }
        }

        /// <summary>
        /// Service level call : Return all records of a Worksheet of SMS Request
        /// </summary>
        /// <returns></returns>
        List<DTOWorksheet> IWorksheetService.RequestGetAll()
        {
            var worksheets = _requestRepository.Get().Where(x => (x.IsDeleted == false || x.IsDeleted == null)).ToList();
            var worksheetList = new List<DTOWorksheet>();
            foreach (var worksheet in worksheets)
            {
                worksheetList.Add(_mapper.Map<ReqWorksheet, DTOWorksheet>(worksheet));
            }
            return worksheetList;
        }

        #endregion
    }
}
