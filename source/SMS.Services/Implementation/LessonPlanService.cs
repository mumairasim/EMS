using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.DTOs.DTOs;
using SMS.Services.Infrastructure;
using LessonPlan = SMS.DATA.Models.LessonPlan;
using DTOLessonPlan = SMS.DTOs.DTOs.LessonPlan;
using SMS.DTOs.ReponseDTOs;
using System.Text.RegularExpressions;
using SMS.REQUESTDATA.Infrastructure;
using ReqLessonPlan = SMS.REQUESTDATA.RequestModels.LessonPlan;


namespace SMS.Services.Implementation
{

    public class LessonPlanService : ILessonPlanService
    {
        private readonly IRepository<LessonPlan> _repository;
        private readonly IRequestRepository<ReqLessonPlan> _requestRepository;
        private readonly IRequestTypeService _requestTypeService;
        private readonly IRequestStatusService _requestStatusService;
        private readonly IMapper _mapper;
        public LessonPlanService(IRepository<LessonPlan> repository, IMapper mapper, IRequestRepository<ReqLessonPlan> requestRepository, IRequestTypeService requestTypeService, IRequestStatusService requestStatusService)
        {
            _repository = repository;
            _requestRepository = requestRepository;
            _requestTypeService = requestTypeService;
            _requestStatusService = requestStatusService;
            _mapper = mapper;
        }

        #region SMS Section
        public LessonPlansList Get(int pageNumber, int pageSize)
        {
            var lessonPlans = _repository.Get().Where(lp => lp.IsDeleted == false).OrderByDescending(lp => lp.CreatedDate).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            var lessonPlanCount = _repository.Get().Where(st => st.IsDeleted == false).Count();
            var lessonPlanList = new List<DTOLessonPlan>();
            foreach (var lessonPlan in lessonPlans)
            {
                lessonPlanList.Add(_mapper.Map<LessonPlan, DTOLessonPlan>(lessonPlan));
            }
            var lessonPlansList = new LessonPlansList()
            {
                LessonPlans = lessonPlanList,
                LessonPlansCount = lessonPlanCount
            };
            return lessonPlansList;
        }
        public DTOLessonPlan Get(Guid? id)
        {
            if (id == null) return null;
            var lessonplanRecord = _repository.Get().FirstOrDefault(lp => lp.Id == id && lp.IsDeleted == false);
            var lessonplan = _mapper.Map<LessonPlan, DTOLessonPlan>(lessonplanRecord);
            return lessonplan;
        }
        public LessonPlanResponse Create(DTOLessonPlan dtoLessonplan)
        {
            var validationResult = Validation(dtoLessonplan);
            if (validationResult.IsError)
            {
                return validationResult;
            }
            dtoLessonplan.CreatedDate = DateTime.UtcNow;
            dtoLessonplan.IsDeleted = false;
            if (dtoLessonplan.Id == Guid.Empty)
            {
                dtoLessonplan.Id = Guid.NewGuid();
            }
            dtoLessonplan.SchoolId = dtoLessonplan.School?.Id;
            dtoLessonplan.School = null;
            _repository.Add(_mapper.Map<DTOLessonPlan, LessonPlan>(dtoLessonplan));
            return validationResult;
        }

        public LessonPlanResponse Update(DTOLessonPlan dtoLessonplan)
        {
            var validationResult = Validation(dtoLessonplan);
            if (validationResult.IsError)
            {
                return validationResult;
            }
            var lessonplan = Get(dtoLessonplan.Id);
            dtoLessonplan.UpdateDate = DateTime.UtcNow;
            dtoLessonplan.SchoolId = dtoLessonplan.School.Id;
            dtoLessonplan.School = null;
            var mergedLessonPlan = _mapper.Map(dtoLessonplan, lessonplan);
            _repository.Update(_mapper.Map<DTOLessonPlan, LessonPlan>(mergedLessonPlan));
            return validationResult;
        }

        public void Delete(Guid? id, string deletedBy)
        {
            if (id == null)
                return;
            var lessonplan = Get(id);
            lessonplan.DeletedBy = deletedBy;
            lessonplan.IsDeleted = true;
            lessonplan.DeletedDate = DateTime.UtcNow;
            _repository.Update(_mapper.Map<DTOLessonPlan, LessonPlan>(lessonplan));
        }
        private LessonPlanResponse Validation(DTOLessonPlan dtoLessonplan)
        {
            //var alphaRegex = new Regex("^[a-zA-Z ]+$");
            //var numericRegex = new Regex("^[0-9]*$");
            var alphanumericRegex = new Regex("^[a-zA-Z0-9 ]*$");
            if (dtoLessonplan == null)
            {
                return PrepareFailureResponse(dtoLessonplan.Id,
                    "Invalid",
                    "Object cannot be null"
                    );
            }
            if (string.IsNullOrWhiteSpace(dtoLessonplan.Name) || dtoLessonplan.Name.Length > 100)
            {
                return PrepareFailureResponse(dtoLessonplan.Id,
                    "InvalidName",
                    "Name may null or exceed than 100 characters"
                    );
            }
            if (!alphanumericRegex.IsMatch(dtoLessonplan.Name))
            {
                return PrepareFailureResponse(dtoLessonplan.Id,
                   "InvalidName",
                   "Text Field doesn't contain any numbers"
                   );
            }
            if (string.IsNullOrWhiteSpace(dtoLessonplan.Text))
            {
                return PrepareFailureResponse(dtoLessonplan.Id,
                    "InvalidText",
                    "This field cannot be null"
                    );
            }
            if (!alphanumericRegex.IsMatch(dtoLessonplan.Text))
            {
                return PrepareFailureResponse(dtoLessonplan.Id,
                   "InvalidName",
                   "Text Field doesn't contain any numbers"
                   );
            }
            if (dtoLessonplan.FromDate == null)
            {
                return PrepareFailureResponse(dtoLessonplan.Id,
                    "InvalidField",
                    "This field cannot be null"
                    );
            }
            if (dtoLessonplan.ToDate == null)
            {
                return PrepareFailureResponse(dtoLessonplan.Id,
                    "InvalidField",
                    "This field cannot be null"
                    );
            }
            return PrepareSuccessResponse(dtoLessonplan.Id,
                    "NoError",
                    "No Error Found"
                    );
        }
        private LessonPlanResponse PrepareFailureResponse(Guid id, string errorMessage, string descriptionMessage)
        {
            return new LessonPlanResponse
            {
                Id = id,
                IsError = true,
                StatusCode = "400",
                Message = errorMessage,
                Description = descriptionMessage
            };
        }
        private LessonPlanResponse PrepareSuccessResponse(Guid id, string message, string descriptionMessage)
        {
            return new LessonPlanResponse
            {
                Id = id,
                IsError = false,
                StatusCode = "200",
                Message = message,
                Description = descriptionMessage
            };
        }
        #endregion

        #region SMS Request Section

        public List<DTOLessonPlan> RequestGet()
        {
            var lessonPlans = _requestRepository.Get().Where(lp => lp.IsDeleted == false).ToList();
            var lessonPlanList = new List<DTOLessonPlan>();
            foreach (var lessonPlan in lessonPlans)
            {
                lessonPlanList.Add(_mapper.Map<ReqLessonPlan, DTOLessonPlan>(lessonPlan));
            }
            return MapRequestTypeAndStatus(lessonPlanList).ToList();
        }
        public DTOLessonPlan RequestGet(Guid? id)
        {
            if (id == null) return null;

            var lessonPlanRecord = _requestRepository.Get().FirstOrDefault(lp => lp.Id == id && lp.IsDeleted == false);
            if (lessonPlanRecord == null) return null;

            return _mapper.Map<ReqLessonPlan, DTOLessonPlan>(lessonPlanRecord);
        }
        public Guid RequestCreate(DTOLessonPlan dtoLessonPlan)
        {
            dtoLessonPlan.CreatedDate = DateTime.UtcNow;
            dtoLessonPlan.IsDeleted = false;
            dtoLessonPlan.Id = Guid.NewGuid();
            var dbRec = _mapper.Map<DTOLessonPlan, ReqLessonPlan>(dtoLessonPlan);
            dbRec.RequestTypeId = _requestTypeService.RequestGetByName(dtoLessonPlan.RequestTypeString).Id;
            dbRec.RequestStatusId = _requestStatusService.RequestGetByName(dtoLessonPlan.RequestStatusString).Id;
            _requestRepository.Add(dbRec);
            return dtoLessonPlan.Id;
        }
        public void RequestUpdate(DTOLessonPlan dtoLessonPlan)
        {
            var lessonPlan = RequestGet(dtoLessonPlan.Id);
            dtoLessonPlan.UpdateDate = DateTime.UtcNow;
            var mergedLessonPlan = _mapper.Map(dtoLessonPlan, lessonPlan);
            _requestRepository.Update(_mapper.Map<DTOLessonPlan, ReqLessonPlan>(mergedLessonPlan));
        }
        public void RequestDelete(Guid? id)
        {
            if (id == null)
                return;
            var lessonPlan = RequestGet(id);
            lessonPlan.IsDeleted = true;
            lessonPlan.DeletedDate = DateTime.UtcNow;
            _requestRepository.Update(_mapper.Map<DTOLessonPlan, ReqLessonPlan>(lessonPlan));
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
        private IEnumerable<DTOLessonPlan> MapRequestTypeAndStatus(IEnumerable<DTOLessonPlan> dtoLessonPlans)
        {
            var requestTypes = _requestTypeService.RequestGetAll();
            var requestStatuses = _requestStatusService.RequestGetAll();
            foreach (var dtoLessonPlan in dtoLessonPlans)
            {
                dtoLessonPlan.RequestTypeString =
                    requestTypes.FirstOrDefault(rt => dtoLessonPlan.RequestTypeId != null && rt.Id == dtoLessonPlan.RequestTypeId.Value)?.Value;
                dtoLessonPlan.RequestStatusString =
                    requestStatuses.FirstOrDefault(rs => dtoLessonPlan.RequestStatusId != null && rs.Id == dtoLessonPlan.RequestStatusId.Value)?.Type;
            }

            return dtoLessonPlans;
        }
        private void UpdateRequestStatus(DTOLessonPlan dto, GenericApiResponse status)
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
