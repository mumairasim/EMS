using AutoMapper;
using SMS.REQUESTDATA;
using SMS.REQUESTDATA.Infrastructure;
using SMS.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services.Implementation
{
    public class BaseService<T> : IBaseService<T>
    {
        #region Properties
        protected readonly IRequestRepository<BaseEntity> _requestRepository;
        protected readonly IRequestTypeService _requestTypeService;
        protected readonly IRequestStatusService _requestStatusService;
        protected IMapper _mapper;
        #endregion

        #region Init

        public BaseService(IMapper mapper, IRequestRepository<BaseEntity> requestRepository, IRequestTypeService requestTypeService, IRequestStatusService requestStatusService)
        {
            _requestTypeService = requestTypeService;
            _requestStatusService = requestStatusService;
            _requestRepository = requestRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Service level call : Return all records of a Worksheet of SMS Request
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> RequestGetAll()
        {
            var worksheets = _requestRepository.Get().Where(x => (x.IsDeleted == false || x.IsDeleted == null)).ToList();
            var worksheetList = new List<T>();
            foreach (var worksheet in worksheets)
            {
                worksheetList.Add(_mapper.Map<ReqWorksheet, DTOWorksheet>(worksheet));
            }
            var t = MapRequestTypeAndStatus(worksheetList);
            return t as IEnumerable<T>;
        }
    }
}
