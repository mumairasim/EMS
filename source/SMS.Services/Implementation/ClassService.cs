using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.DTOs.DTOs;
using SMS.DTOs.ReponseDTOs;
using SMS.REQUESTDATA.Infrastructure;
using SMS.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using Class = SMS.DATA.Models.Class;
using DTOClass = SMS.DTOs.DTOs.Class;
using ReqClass = SMS.REQUESTDATA.RequestModels.Class;

namespace SMS.Services.Implementation
{
    public class ClassService : IClassService
    {
        private readonly IRepository<Class> _repository;
        private readonly IRequestRepository<ReqClass> _requestRepository;
        private readonly IRequestTypeService _requestTypeService;
        private readonly IRequestStatusService _requestStatusService;
        private const string error_not_found = "Record not found";
        private const string server_error = "Server error";

        private readonly IMapper _mapper;
        public ClassService(IRepository<Class> repository, IMapper mapper, IRequestRepository<ReqClass> requestRepository, IRequestTypeService requestTypeService, IRequestStatusService requestStatusService)
        {
            _repository = repository;
            _requestRepository = requestRepository;
            _requestTypeService = requestTypeService;
            _requestStatusService = requestStatusService;
            _mapper = mapper;
        }

        #region SMS Section
        public GenericApiResponse Create(DTOClass dtoClass)
        {
            try
            {
                dtoClass.CreatedDate = DateTime.UtcNow;
                dtoClass.IsDeleted = false;
                if (dtoClass.Id == Guid.Empty)
                {
                    dtoClass.Id = Guid.NewGuid();
                }
                HelpingMethodForRelationship(dtoClass);
                _repository.Add(_mapper.Map<DTOClass, Class>(dtoClass));
                return PrepareSuccessResponse("Created", "Instance Created Successfully");

            }
            catch (Exception)
            {
                return PrepareFailureResponse("Error", server_error);
            }

        }
        public ClassesList Get(int pageNumber, int pageSize, string searchString = "")
        {
            var clasess = _repository.Get()
                .Where(cl => string.IsNullOrEmpty(searchString) || cl.School.Name.ToLower().Contains(searchString.ToLower()))
                .Union(_repository.Get().Where(cl => string.IsNullOrEmpty(searchString) || cl.ClassName.ToLower().Contains(searchString.ToLower())))
                .Where(cl => cl.IsDeleted == false).OrderByDescending(st => st.Id).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            var ClassCount = clasess.Count();
            var classTempList = new List<DTOClass>();
            foreach (var Classes in clasess)
            {
                classTempList.Add(_mapper.Map<Class, DTOClass>(Classes));
            }
            var classesList = new ClassesList()
            {
                Classes = classTempList,
                classesCount = ClassCount
            };
            return classesList;
        }
        public DTOClass Get(Guid? id)
        {
            if (id == null) return null;
            var classRecord = _repository.Get().FirstOrDefault(cl => cl.Id == id && cl.IsDeleted == false);
            var classes = _mapper.Map<Class, DTOClass>(classRecord);

            return classes;
        }
        public List<DTOClass> GetBySchool(Guid? schoolId)
        {
            var classes = _repository.Get().Where(cl => cl.SchoolId == schoolId && cl.IsDeleted == false).ToList();
            var classList = new List<DTOClass>();
            foreach (var itemClass in classes)
            {
                classList.Add(_mapper.Map<Class, DTOClass>(itemClass));
            }
            return classList;
        }

        public GenericApiResponse Update(DTOClass dtoClass)
        {
            try
            {
                var Classes = Get(dtoClass.Id);
                if (Classes != null)
                {
                    dtoClass.UpdateDate = DateTime.UtcNow;
                    var mergedClass = _mapper.Map(dtoClass, Classes);
                    _repository.Update(_mapper.Map<DTOClass, Class>(mergedClass));
                    return PrepareSuccessResponse("Updated", "Instance Updated Successfully");
                }
                return PrepareFailureResponse("Error", error_not_found);
            }
            catch (Exception)
            {
                return PrepareFailureResponse("Error", server_error);
            }

        }
        public void Delete(Guid? id, string DeletedBy)
        {
            if (id == null)
                return;
            var classes = Get(id);
            classes.IsDeleted = true;
            classes.DeletedDate = DateTime.UtcNow;
            classes.DeletedBy = DeletedBy;
            _repository.Update(_mapper.Map<DTOClass, Class>(classes));
        }
        #endregion

        #region SMS Request Section

        public List<DTOClass> RequestGet()
        {
            var clasess = _requestRepository.Get().Where(cl => cl.IsDeleted == false).ToList();
            var classList = new List<DTOClass>();
            foreach (var itemClass in clasess)
            {
                classList.Add(_mapper.Map<ReqClass, DTOClass>(itemClass));
            }
            return MapRequestTypeAndStatus(classList).ToList();
        }
        public DTOClass RequestGet(Guid? id)
        {
            var classRecord = _requestRepository.Get().FirstOrDefault(cl => cl.Id == id && cl.IsDeleted == false);
            var classes = _mapper.Map<ReqClass, DTOClass>(classRecord);

            return classes;
        }
        //public List<DTOClass> RequestGetBySchool(Guid? schoolId)
        //{
        //    var classes = _repository.Get().Where(cl => cl.SchoolId == schoolId && cl.IsDeleted == false).ToList();
        //    var classList = new List<DTOClass>();
        //    foreach (var itemClass in classes)
        //    {
        //        classList.Add(_mapper.Map<Class, DTOClass>(itemClass));
        //    }
        //    return classList;
        //}


        public void RequestCreate(DTOClass dtoClass)
        {
            dtoClass.CreatedDate = DateTime.UtcNow;
            dtoClass.IsDeleted = false;
            dtoClass.Id = Guid.NewGuid();
            dtoClass.School = null;
            var dbRec = _mapper.Map<DTOClass, ReqClass>(dtoClass);
            dbRec.RequestTypeId = _requestTypeService.RequestGetByName(dtoClass.RequestTypeString).Id;
            dbRec.RequestStatusId = _requestStatusService.RequestGetByName(dtoClass.RequestStatusString).Id;
            _requestRepository.Add(dbRec);
            // return dtoClass.Id;
        }
        public void RequestUpdate(DTOClass dtoClass)
        {
            var Classes = RequestGet(dtoClass.SchoolId);
            dtoClass.UpdateDate = DateTime.UtcNow;
            var mergedClass = _mapper.Map(dtoClass, Classes);
            _requestRepository.Update(_mapper.Map<DTOClass, ReqClass>(mergedClass));
        }
        public void RequestDelete(Guid? id)
        {
            if (id == null)
                return;
            var classes = RequestGet(id);
            classes.IsDeleted = true;
            classes.DeletedDate = DateTime.UtcNow;
            _requestRepository.Update(_mapper.Map<DTOClass, ReqClass>(classes));
        }
        #endregion

        #region Request Approver
        public GenericApiResponse ApproveRequest(CommonRequestModel dtoCommonRequestModel)
        {
            var dto = RequestGet(dtoCommonRequestModel.Id);
            dto.School = dtoCommonRequestModel.School;
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
                //case "Delete":
                //    status = Delete(dto.Id,"admin");
                //    UpdateRequestStatus(dto, status);
                //    break;
                default:
                    break;
            }

            return status;
        }

        #endregion
        private void HelpingMethodForRelationship(DTOClass dtoClass)
        {
            dtoClass.SchoolId = dtoClass.School.Id;
            dtoClass.School = null;
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

        private IEnumerable<DTOClass> MapRequestTypeAndStatus(IEnumerable<DTOClass> dtoClasses)
        {
            var requestTypes = _requestTypeService.RequestGetAll();
            var requestStatuses = _requestStatusService.RequestGetAll();
            foreach (var dtoClass in dtoClasses)
            {
                dtoClass.RequestTypeString =
                    requestTypes.FirstOrDefault(rt => dtoClass.RequestTypeId != null && rt.Id == dtoClass.RequestTypeId.Value)?.Value;
                dtoClass.RequestStatusString =
                    requestStatuses.FirstOrDefault(rs => dtoClass.RequestStatusId != null && rs.Id == dtoClass.RequestStatusId.Value)?.Type;
            }

            return dtoClasses;
        }

        private void UpdateRequestStatus(DTOClass dto, GenericApiResponse status)
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
    }
}




