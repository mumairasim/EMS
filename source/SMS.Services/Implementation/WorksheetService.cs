using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.DTOs.ReponseDTOs;
using SMS.REQUESTDATA.Infrastructure;
using SMS.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using SMS.DTOs.DTOs;
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
        private readonly IRequestTypeService _requestTypeService;
        private readonly IRequestStatusService _requestStatusService;
        private const string error_not_found = "Record not found";
        private const string server_error = "Server error";

        private IMapper _mapper;
        #endregion

        #region Init

        public WorksheetService(IRepository<DBWorksheet> repository, IMapper mapper, IRequestRepository<ReqWorksheet> requestRepository, IRequestTypeService requestTypeService, IRequestStatusService requestStatusService)
        {
            _requestTypeService = requestTypeService;
            _requestStatusService = requestStatusService;
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
        public GenericApiResponse Create(DTOWorksheet dTOWorksheet)
        {
            try
            {
                dTOWorksheet.CreatedDate = DateTime.UtcNow;
                dTOWorksheet.IsDeleted = false;

                //below check is to create request type instances with the same Ids in both DBs, 
                //if request is from front end then assign a new Id
                if (dTOWorksheet.Id == null)
                {
                    dTOWorksheet.Id = Guid.NewGuid();
                }

                _repository.Add(_mapper.Map<DTOWorksheet, DBWorksheet>(dTOWorksheet));
                return PrepareSuccessResponse("Created", "Instance Created Successfully");

            }
            catch (Exception)
            {
                return PrepareFailureResponse("Error", server_error);
            }
        }

        /// <summary>
        /// Service level call : Delete a single record of a Worksheet
        /// </summary>
        /// <param name="id"></param>
        public GenericApiResponse Delete(Guid? id)
        {
            try
            {
                if (id == null)
                    return null;
                var worksheet = Get(id);
                if (worksheet != null)
                {
                    worksheet.IsDeleted = true;
                    worksheet.DeletedDate = DateTime.UtcNow;
                    _repository.Update(_mapper.Map<DTOWorksheet, DBWorksheet>(worksheet));
                    return PrepareSuccessResponse("Deleted", "Instance Deleted Successfully");
                }
                return PrepareFailureResponse("Error", error_not_found);
            }
            catch (Exception)
            {
                return PrepareFailureResponse("Error", server_error);
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
        public GenericApiResponse Update(DTOWorksheet dtoWorksheet)
        {
            try
            {
                var worksheet = Get(dtoWorksheet.Id);
                if (worksheet != null)
                {
                    dtoWorksheet.UpdateDate = DateTime.UtcNow;
                    dtoWorksheet.IsDeleted = false;
                    var updated = _mapper.Map(dtoWorksheet, worksheet);
                    var updatedDbRec = _mapper.Map<DTOWorksheet, DBWorksheet>(updated);
                    _repository.Update(updatedDbRec);
                    return PrepareSuccessResponse("Updated", "Instance Updated Successfully");
                }
                return PrepareFailureResponse("Error", error_not_found);
            }
            catch (Exception)
            {
                return PrepareFailureResponse("Error", server_error);
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
            var dbRec = _mapper.Map<DTOWorksheet, ReqWorksheet>(dTOWorksheet);
            dbRec.RequestTypeId = _requestTypeService.RequestGetByName(dTOWorksheet.RequestTypeString).Id;
            dbRec.RequestStatusId = _requestStatusService.RequestGetByName(dTOWorksheet.RequestStatusString).Id;
            _requestRepository.Add(dbRec);
        }

        /// <summary>
        /// Service level call : Delete a single record of a Worksheet of SMS Request
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
            var worksheet = RequestGet(dtoWorksheet.Id);
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
        public List<DTOWorksheet> RequestGetAll()
        {
            var worksheets = _requestRepository.Get().Where(x => (x.IsDeleted == false || x.IsDeleted == null)).ToList();
            var worksheetList = new List<DTOWorksheet>();
            foreach (var worksheet in worksheets)
            {
                worksheetList.Add(_mapper.Map<ReqWorksheet, DTOWorksheet>(worksheet));
            }
            return MapRequestTypeAndStatus(worksheetList).ToList();
        }
        #endregion

        #region Request Approver
        public GenericApiResponse ApproveRequest(CommonRequestModel dtoCommonRequestModel)
        {
            var dto = RequestGet(dtoCommonRequestModel.Id);
            GenericApiResponse status = null;
            switch (dtoCommonRequestModel.RequestTypeString)
            {
                case "Create":
                    status = Create(dto);
                    UpdateRequestStatus(dto, status);
                    break;
                case "Update":
                    status = Update(dto);
                    UpdateRequestStatus(dto, status);
                    break;
                case "Delete":
                    status = Delete(dto.Id);
                    UpdateRequestStatus(dto, status);
                    break;
                default:
                    break;
            }

            return status;
        }

        #endregion

        #region Utils
        private void UpdateRequestStatus(DTOWorksheet dto, GenericApiResponse status)
        {
            if (status.StatusCode == "200")//success
            {
                dto.RequestStatusId = _requestStatusService.RequestGetByName("Approved").Id;
            }
            else
            {
                dto.RequestStatusId = _requestStatusService.RequestGetByName("Error").Id;
            }
            //updating the status of the current request in Request DB
            RequestUpdate(dto);
        }
        private GenericApiResponse PrepareFailureResponse(string errorMessage, string descriptionMessage)
        {
            return new GenericApiResponse
            {
                StatusCode = "400",
                Message = errorMessage,
                Description = descriptionMessage
            };
        }
        private GenericApiResponse PrepareSuccessResponse(string message, string descriptionMessage)
        {
            return new GenericApiResponse
            {
                StatusCode = "200",
                Message = message,
                Description = descriptionMessage
            };
        }

        private IEnumerable<DTOWorksheet> MapRequestTypeAndStatus(IEnumerable<DTOWorksheet> dtoWorksheets)
        {
            var requestTypes = _requestTypeService.RequestGetAll();
            var requestStatuses = _requestStatusService.RequestGetAll();
            foreach (var worksheet in dtoWorksheets)
            {
                worksheet.RequestTypeString =
                    requestTypes.FirstOrDefault(rt => worksheet.RequestTypeId != null && rt.Id == worksheet.RequestTypeId.Value)?.Value;
                worksheet.RequestStatusString =
                    requestStatuses.FirstOrDefault(rs => worksheet.RequestStatusId != null && rs.Id == worksheet.RequestStatusId.Value)?.Type;
            }

            return dtoWorksheets;
        }
        #endregion
    }
}
