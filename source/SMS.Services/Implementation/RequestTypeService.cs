using AutoMapper;
using SMS.REQUESTDATA.Infrastructure;
using SMS.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using DBRequestType = SMS.REQUESTDATA.RequestModels.RequestType;
using DTORequestType = SMS.DTOs.DTOs.RequestType;

namespace SMS.Services.Implementation
{
    public class RequestTypeService : IRequestTypeService
    {
        #region Properties
        private readonly IRequestRepository<DBRequestType> _requestRepository;
        private IMapper _mapper;
        #endregion

        #region Init

        public RequestTypeService(IMapper mapper, IRequestRepository<DBRequestType> requestRepository)
        {
            _requestRepository = requestRepository;
            _mapper = mapper;
        }

        #endregion


        #region SMS Request

        /// <summary>
        /// Service level call : Creates a single record of a RequestType of SMS Request
        /// </summary>
        /// <param name="dTORequestType"></param>
        public void RequestCreate(DTORequestType dTORequestType)
        {
            dTORequestType.CreatedDate = DateTime.UtcNow;
            dTORequestType.IsDeleted = false;
            dTORequestType.Id = Guid.NewGuid();

            _requestRepository.Add(_mapper.Map<DTORequestType, DBRequestType>(dTORequestType));
        }

        /// <summary>
        /// Service level call : Delete a single record of a RequestType of SMS Request
        /// </summary>
        /// <param name="id"></param>
        public void RequestDelete(Guid? id)
        {
            if (id == null)
                return;
            var worksheet = RequestGet(id);
            if (worksheet != null)
            {
                worksheet.IsDeleted = true;
                worksheet.DeletedDate = DateTime.UtcNow;
                _requestRepository.Update(_mapper.Map<DTORequestType, DBRequestType>(worksheet));
            }

        }

        /// <summary>
        /// Retruns a Single Record of a RequestType of SMS Request
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DTORequestType RequestGet(Guid? id)
        {
            if (id == null)
            {
                return null;
            }

            var worksheet = _requestRepository.Get().FirstOrDefault(x => x.Id == id && (x.IsDeleted == false || x.IsDeleted == null));
            var worksheetDto = _mapper.Map<DBRequestType, DTORequestType>(worksheet);

            return worksheetDto;
        }

        /// <summary>
        /// Service level call : Updates the Single Record of a RequestType of SMS Request
        /// </summary>
        /// <param name="dtoRequestType"></param>
        public void RequestUpdate(DTORequestType dtoRequestType)
        {
            var worksheet = RequestGet(dtoRequestType.Id);
            if (worksheet != null)
            {
                dtoRequestType.UpdateDate = DateTime.UtcNow;
                dtoRequestType.IsDeleted = false;
                var updated = _mapper.Map(dtoRequestType, worksheet);
                var updatedDbRec = _mapper.Map<DTORequestType, DBRequestType>(updated);
                _requestRepository.Update(updatedDbRec);
            }
        }

        /// <summary>
        /// Service level call : Return all records of a RequestType of SMS Request
        /// </summary>
        /// <returns></returns>
        List<DTORequestType> IRequestTypeService.RequestGetAll()
        {
            var worksheets = _requestRepository.Get().Where(x => (x.IsDeleted == false || x.IsDeleted == null)).ToList();
            var worksheetList = new List<DTORequestType>();
            foreach (var worksheet in worksheets)
            {
                worksheetList.Add(_mapper.Map<DBRequestType, DTORequestType>(worksheet));
            }
            return worksheetList;
        }
        #endregion
    }
}
