using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.REQUESTDATA.Infrastructure;
using SMS.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using DBFinanceType = SMS.DATA.Models.FinanceType;
using DTOFinanceType = SMS.DTOs.DTOs.FinanceType;
using ReqFinanceType = SMS.REQUESTDATA.RequestModels.FinanceType;
namespace SMS.Services.Implementation
{
    public class FinanceTypeService : IFinanceTypeService
    {
        #region Properties
        private readonly IRepository<DBFinanceType> _repository;
        private readonly IRequestRepository<ReqFinanceType> _requestRepository;
        private IMapper _mapper;
        #endregion

        #region Init

        public FinanceTypeService(IRepository<DBFinanceType> repository, IMapper mapper, IRequestRepository<ReqFinanceType> requestRepository)
        {
            _repository = repository;
            _requestRepository = requestRepository;
            _mapper = mapper;
        }

        #endregion

        #region SMS Section

        /// <summary>
        /// Service level call : Creates a single record of a FinanceType
        /// </summary>
        /// <param name="dTOFinanceType"></param>
        public void Create(DTOFinanceType dTOFinanceType)
        {
            dTOFinanceType.CreatedDate = DateTime.Now;
            dTOFinanceType.IsDeleted = false;

            if (dTOFinanceType.Id == Guid.Empty)
            {
                dTOFinanceType.Id = Guid.NewGuid();
            }

            _repository.Add(_mapper.Map<DTOFinanceType, DBFinanceType>(dTOFinanceType));
        }

        /// <summary>
        /// Service level call : Delete a single record of a FinanceType
        /// </summary>
        /// <param name="id"></param>
        public void Delete(Guid? id, string deletedBy)
        {
            if (id == null)
                return;
            var financeType = Get(id);
            financeType.IsDeleted = true;
            financeType.DeletedBy = deletedBy;
            financeType.DeletedDate = DateTime.Now;
            _repository.Update(_mapper.Map<DTOFinanceType, DBFinanceType>(financeType));
        }

        /// <summary>
        /// Retruns a Single Record of a FinanceType
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DTOFinanceType Get(Guid? id)
        {
            if (id == null)
            {
                return null;
            }

            var financeType = _repository.Get().FirstOrDefault(x => x.Id == id && (x.IsDeleted == false || x.IsDeleted == null));
            var financeTypeDto = _mapper.Map<DBFinanceType, DTOFinanceType>(financeType);

            return financeTypeDto;
        }

        /// <summary>
        ///  Retruns a Single Record of a FinanceType by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DTOFinanceType GetByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }

            var financeType = _repository.Get().FirstOrDefault(x => x.Type == name && (x.IsDeleted == false || x.IsDeleted == null));
            var financeTypeDto = _mapper.Map<DBFinanceType, DTOFinanceType>(financeType);

            return financeTypeDto;
        }

        /// <summary>
        /// Service level call : Updates the Single Record of a FinanceType 
        /// </summary>
        /// <param name="dtoFinanceType"></param>
        public void Update(DTOFinanceType dtoFinanceType)
        {
            var FinanceType = Get(dtoFinanceType.Id);
            if (FinanceType != null)
            {
                dtoFinanceType.UpdateDate = DateTime.Now;
                dtoFinanceType.IsDeleted = false;
                var updated = _mapper.Map(dtoFinanceType, FinanceType);
                var updatedDbRec = _mapper.Map<DTOFinanceType, DBFinanceType>(updated);
                _repository.Update(updatedDbRec);
            }
        }

        /// <summary>
        /// Service level call : Return all records of a FinanceType
        /// </summary>
        /// <returns></returns>
        public List<DTOFinanceType> GetAll(string search = "")
        {
            //var financeTypes = _repository.Get().Where(x => (x.IsDeleted == false || x.IsDeleted == null)).ToList();
            var financeTypes = _repository.Get(search + "IsDeleted=false Or IsDeleted=null").ToList();

            var financeTypeList = new List<DTOFinanceType>();
            foreach (var financeType in financeTypes)
            {
                financeTypeList.Add(_mapper.Map<DBFinanceType, DTOFinanceType>(financeType));
            }
            return financeTypeList;
        }

        #endregion

        #region SMS Request Section

        /// <summary>
        /// Service level call : Creates a single record of a FinanceType
        /// </summary>
        /// <param name="dTOFinanceType"></param>
        public void RequestCreate(DTOFinanceType dTOFinanceType)
        {
            dTOFinanceType.CreatedDate = DateTime.Now;
            dTOFinanceType.IsDeleted = false;
            dTOFinanceType.Id = Guid.NewGuid();

            _requestRepository.Add(_mapper.Map<DTOFinanceType, ReqFinanceType>(dTOFinanceType));
        }

        /// <summary>
        /// Service level call : Delete a single record of a FinanceType
        /// </summary>
        /// <param name="id"></param>
        public void RequestDelete(Guid? id, string deletedBy)
        {
            if (id == null)
                return;
            var financeType = RequestGet(id);
            financeType.IsDeleted = true;
            financeType.DeletedBy = deletedBy;
            financeType.DeletedDate = DateTime.Now;
            _requestRepository.Update(_mapper.Map<DTOFinanceType, ReqFinanceType>(financeType));
        }

        /// <summary>
        /// Retruns a Single Record of a FinanceType
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DTOFinanceType RequestGet(Guid? id)
        {
            if (id == null)
            {
                return null;
            }

            var financeType = _requestRepository.Get().FirstOrDefault(x => x.Id == id && (x.IsDeleted == false || x.IsDeleted == null));
            var financeTypeDto = _mapper.Map<ReqFinanceType, DTOFinanceType>(financeType);

            return financeTypeDto;
        }

        /// <summary>
        ///  Retruns a Single Record of a FinanceType by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DTOFinanceType RequestGetByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }

            var financeType = _requestRepository.Get().FirstOrDefault(x => x.Type == name && (x.IsDeleted == false || x.IsDeleted == null));
            var financeTypeDto = _mapper.Map<ReqFinanceType, DTOFinanceType>(financeType);

            return financeTypeDto;
        }

        /// <summary>
        /// Service level call : Updates the Single Record of a FinanceType 
        /// </summary>
        /// <param name="dtoFinanceType"></param>
        public void RequestUpdate(DTOFinanceType dtoFinanceType)
        {
            var FinanceType = RequestGet(dtoFinanceType.Id);
            if (FinanceType != null)
            {
                dtoFinanceType.UpdateDate = DateTime.Now;
                dtoFinanceType.IsDeleted = false;
                var updated = _mapper.Map(dtoFinanceType, FinanceType);
                var updatedDbRec = _mapper.Map<DTOFinanceType, ReqFinanceType>(updated);
                _requestRepository.Update(updatedDbRec);
            }
        }

        /// <summary>
        /// Service level call : Return all records of a FinanceType
        /// </summary>
        /// <returns></returns>
        public List<DTOFinanceType> RequestGetAll()
        {
            var financeTypes = _requestRepository.Get().Where(x => (x.IsDeleted == false || x.IsDeleted == null)).ToList();
            var financeTypeList = new List<DTOFinanceType>();
            foreach (var financeType in financeTypes)
            {
                financeTypeList.Add(_mapper.Map<ReqFinanceType, DTOFinanceType>(financeType));
            }
            return financeTypeList;
        }

        #endregion
    }
}
